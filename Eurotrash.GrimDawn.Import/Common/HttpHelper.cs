using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eurotrash.GrimDawn.Import.Common
{
    internal class HttpHelper
    {
        internal static HttpClient CreateHttpClient()
        {
            if (!ProxySettings.UseProxy)
                return new HttpClient();
            
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy(ProxySettings.ProxyAddress, false),
                UseProxy = true
            };

            if (ProxySettings.CredentialsMode == ProxyCredentialsMode.Default)
                handler.Proxy.Credentials = CredentialCache.DefaultCredentials;
            else if (ProxySettings.CredentialsMode == ProxyCredentialsMode.Manual)
                handler.Proxy.Credentials = new NetworkCredential(ProxySettings.Username, ProxySettings.Password);
 
            return new HttpClient(handler);
        }

        internal static string GetString(string url)
        {
            using (var client = CreateHttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }

        internal static async Task<string> GetStringAsync(string url)
        {
            using (var client = CreateHttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        internal static byte[] GetByteArray(string url)
        {
            using (var client = CreateHttpClient())
            {
                return client.GetByteArrayAsync(url).Result;
            }
        }
    }
}
