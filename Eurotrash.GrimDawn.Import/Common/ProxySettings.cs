using System;

namespace Eurotrash.GrimDawn.Import.Common
{
    /// <summary>
    /// Global in-memory storage of proxy settings, used by the HttpHelper class.
    /// </summary>
    internal static class ProxySettings
    {
        public static bool UseProxy { get; set; }

        public static ProxyCredentialsMode CredentialsMode { get; set; }

        public static string ProxyAddress { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }
    }

    internal enum ProxyCredentialsMode { None, Default, Manual }
}
