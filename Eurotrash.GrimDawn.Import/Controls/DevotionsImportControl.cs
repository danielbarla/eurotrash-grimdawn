using Eurotash.GrimDawn.Core.Data;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Eurotrash.GrimDawn.Import.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.Import.Controls
{
    public partial class DevotionsImportControl : UserControl
    {
        public DevotionsImportControl()
        {
            InitializeComponent();

            UpdateControls();
        }

        private void UpdateControls()
        {
            bool hasIndexFile = File.Exists("wiki\\constellation.html");
            bool hasDetailsFiles = (Directory.Exists("wiki") && Directory.GetFiles("wiki", "*.html").Length > 1);

            _downloadDetailPagesButton.Enabled = hasIndexFile;
            _parseDetailsButton.Enabled = hasIndexFile && hasDetailsFiles;
            _downloadImagesButton.Enabled = hasIndexFile && hasDetailsFiles;
            _parseIndexButton.Enabled = hasIndexFile;
        }

        private void _downloadIndexButton_Click(object sender, EventArgs e)
        {
            _listBox.Items.Clear();

            if (!Directory.Exists("wiki"))
                Directory.CreateDirectory("wiki");

            string constellationHtml = HttpHelper.GetString("http://grimdawn.wikia.com/wiki/Constellation");
            File.WriteAllText("wiki\\constellation.html", constellationHtml);

            UpdateControls();
        }

        private void _parseIndexButton_Click(object sender, EventArgs e)
        {
            ParseIndex();
        }

        private void ParseIndex(bool download = false, bool overwrite = false, bool parseDetails = false, bool downloadImages = false)
        {
            var constellations = new List<Constellation>();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.Load("wiki\\constellation.html");

            HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var content = bodyNode.Descendants()
                                  .Where(item => item.Name == "div" && item.Id == "mw-content-text").First();

            var headings = content.Descendants()
                                  .Where(item => item.Name == "h2" && item.InnerText != "Contents")
                                  .ToArray();

            foreach (var heading in headings)
            {
                string category = ExtractHeadingText(heading);

                _listBox.Items.Add("");
                _listBox.Items.Add("## " + category);

                var tables = heading.NextSiblings()
                                 .TakeWhile(item => item.Name != "h2")
                                 .Where(item => item.Name == "table")
                                 .ToArray();

                foreach (var table in tables)
                {
                    var h3 = table.PreviousSiblings()
                                  .TakeWhile(item => item.Name != "table" && item.Name != "h2")
                                  .FirstOrDefault(item => item.Name == "h3");

                    string subCategory = (h3 == null) ? null : ExtractHeadingText(h3);

                    if (subCategory != null)
                    {
                        _listBox.Items.Add("");
                        _listBox.Items.Add("### " + subCategory);
                    }

                    var rows = table.Find("tr")
                                    .Skip(1)
                                    .ToArray();

                    foreach (var row in rows)
                    {
                        var td = row.Find("td").First();
                        var link = td.Find("a").First();

                        string text = link.InnerText;
                        string href = link.Attributes["href"].Value;

                        _listBox.Items.Add(String.Format("  - {0}: {1}", text, href));

                        if (download)
                            Download(text, href, overwrite);

                        if (parseDetails)
                        {
                            var constellation = ParseDetails(text, category: subCategory ?? category, downloadImages: downloadImages);
                            constellations.Add(constellation);
                        }
                    }
                }
            }

            if (parseDetails)
            {
                string json = JsonConvert.SerializeObject(constellations, Formatting.Indented);

                File.WriteAllText("constellations.json", json);

                _listBox.Items.Add("");
                _listBox.Items.Add(">> constellations.json created");
            }
        }

        private Constellation ParseDetails(string text, string category = null, bool downloadImages = false)
        {
            string fileName = GetFriendlyName(text);

            string path = Path.Combine("wiki", fileName) + ".html";

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.Load(path);

            var constellation = new Constellation();
            constellation.Name = text;
            constellation.Category = category;

            HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var content = bodyNode.Descendants()
                                  .Where(item => item.Name == "div" && item.Id == "mw-content-text").First();

            var summary = content.Descendants()
                                 .FirstOrDefault(item => item.Name == "table");


            if (downloadImages)
            {
                var tr = summary.Descendants()
                                .Where(item => item.Name == "tr")
                                .Skip(1)
                                .First();

                var img = tr.Descendants().Where(item => item.Name == "img").First();

                var url = img.Attributes["src"].Value;

                var data = HttpHelper.GetByteArray(url);

                File.WriteAllBytes(String.Format("wiki\\{0}.png", text), data);
            }

            var summaryRows = summary.Descendants()
                                     .Where(item => item.Name == "tr")
                                     .Skip(2)
                                     .ToArray();

            PopulateQuote(constellation, summaryRows[0]);
            constellation.Requirements = ParseAffinity(summaryRows[1]).ToArray();
            constellation.CompletionBonuses = ParseAffinity(summaryRows[2]).ToArray();

            var starTable = content.Descendants()
                                   .Where(item => item.Name == "table")
                                   .Skip(1)
                                   .FirstOrDefault();

            constellation.Stars = ParseStars(starTable).ToArray();

            return constellation;
        }

        private IEnumerable<Star> ParseStars(HtmlAgilityPack.HtmlNode table)
        {
            foreach (var row in table.Descendants().Where(item => item.Name == "tr"))
            {
                var star = new Star();

                var cells = row.Descendants().Where(item => item.Name == "td").ToArray();
                
                int index = Convert.ToInt32(HtmlToPlainText(cells[0].InnerText));

                var links = cells[1].Find("a").ToArray();
                var affinityLinks = links.Where(item => item.Descendants().Any(el => el.Name == "img")).ToArray();
                var skillLinks = links.Where(item => !affinityLinks.Contains(item)).ToArray();

                var stats = cells[1].ChildNodes
                                    .Where(item => !affinityLinks.Contains(item))
                                    .Select(item => HtmlToPlainText(item.InnerText).Trim())
                                    .Where(item => !String.IsNullOrWhiteSpace(item))
                                    .Where(item => !IsAffinityText(item))
                                    .ToArray();

                var affinities = affinityLinks.Select(item => ExtractAffinity(item)).ToArray();

                var bonuses = stats.Select(item => new StatisticBonus() { Text = item })
                                   .Union(affinities.Select(item => new StatisticBonus() { AffinityBonuses = new[] { item }, Text = String.Format("{0} {1} affinity", item.Value, item.Name) }))
                                   .ToArray();

                star.Index = index;
                star.StatisticsBonuses = bonuses;
                star.GrantsSkill = (skillLinks.Length > 0);

                yield return star;
            }
        }

        private static bool IsAffinityText(string text)
        {
            int affinityNumber;
            return Int32.TryParse(text, out affinityNumber);
        }

        private static void PopulateQuote(Constellation constellation, HtmlAgilityPack.HtmlNode row)
        {
            string quote = row.Descendants("span")
                              .First()
                              .InnerText;

            constellation.Quote = quote;
        }

        private IEnumerable<Affinity> ParseAffinity(HtmlAgilityPack.HtmlNode row)
        {
            var cell = row.Descendants()
                          .Where(item => item.Name == "td")
                          .Skip(1)
                          .First();

            foreach (var link in cell.Descendants().Where(item => item.Name == "a"))
            {
                yield return ExtractAffinity(link);
            }
        }

        private Affinity ExtractAffinity(HtmlAgilityPack.HtmlNode link)
        {
            string affinityName = link.Attributes["title"].Value.Trim();

            var valueElements = link.NextSiblings()
                                    .TakeWhile(item => item.Name != "a")
                                    .Select(item => item.InnerText)
                                    .ToArray();

            string value = HtmlToPlainText(String.Join(String.Empty, valueElements));

            return new Affinity() { Name = affinityName, Value = Convert.ToInt32(value) };
        }

        private string HtmlToPlainText(string html)
        {
            html = html.Replace("&#160;", String.Empty);
            html = html.Replace("&amp;", "&");

            return html.Trim();
        }

        private void Download(string text, string href, bool overwrite)
        {
            string fileName = GetFriendlyName(text);

            string path = Path.Combine("wiki", fileName) + ".html";

            bool exists = File.Exists(path);

            if (!exists || overwrite)
            {
                if (exists)
                    _listBox.Items.Add("Overwriting: " + path);
                else
                    _listBox.Items.Add("Creating: " + path);

                Application.DoEvents();

                string url = "http://grimdawn.wikia.com" + href;

                string contents = HttpHelper.GetString(url);

                File.WriteAllText(path, contents);

                _listBox.Items.Add("Done.");
                Application.DoEvents();
            }
            else
            {
                _listBox.Items.Add("File already exists, skipping...");
            }
        }

        private string GetFriendlyName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '-');

            return fileName;
        }

        private string ExtractHeadingText(HtmlAgilityPack.HtmlNode heading)
        {
            return heading.FirstChild.InnerText.Trim();
        }

        private void _downloadDetailPagesButton_Click(object sender, EventArgs e)
        {
            _listBox.Items.Clear();

            ParseIndex(download: true);

            UpdateControls();
        }

        private void _parseDetailsButton_Click(object sender, EventArgs e)
        {
            _listBox.Items.Clear();

            ParseIndex(parseDetails: true);
        }

        private void _downloadImagesButton_Click(object sender, EventArgs e)
        {
            _listBox.Items.Clear();

            ParseIndex(parseDetails: true, downloadImages: true);

            _listBox.Items.Add("Images downloaded.");
        }
    }
}
