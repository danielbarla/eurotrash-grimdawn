using Eurotash.GrimDawn.Core.Analysis.Affinities;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Common
{
    public static class AffinityImageCache
    {
        public static Bitmap CreateImage(AffinitySet affinities, Font font)
        {
            var bitmap = new Bitmap(200, 20);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);

                int offset = 2;

                for (int i = 0; i <= 4; i++)
                {
                    AffinityType affinityType = (AffinityType)i;

                    int value = affinities[affinityType];

                    if (value == 0)
                        continue;

                    Image icon = GetIcon(affinityType.ToString());

                    if (icon != null)
                    {
                        graphics.DrawImage(icon, offset, 0, 16f, 16f);

                        offset += 16 + 2;
                    }

                    string text = value.ToString();

                    if (icon == null)
                        text += " " + affinityType.ToString();

                    var size = graphics.MeasureString(text, font);

                    graphics.DrawString(text, font, Brushes.Black, offset, 2);

                    offset += (int)Math.Ceiling(size.Width + 5);
                }
            }
            
            return bitmap;
        }

        private static Image GetIcon(string name)
        {
            switch(name)
            {
                case "Ascendant":
                    return Properties.Resources.Ascendant_Icon;
                case "Chaos":
                    return Properties.Resources.Chaos_Icon;
                case "Eldritch":
                    return Properties.Resources.Eldritch_Icon;
                case "Order":
                    return Properties.Resources.Order_Icon;
                case "Primordial":
                    return Properties.Resources.Primordial_Icon;
                default:
                    return null;
            }
        }
    }
}
