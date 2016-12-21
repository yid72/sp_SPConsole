using Microsoft.SharePoint.Client;

namespace SPConsole.Utils
{
    internal class Context
    {
        private const string LocalHost = "http://localhost";
        private const string TDSWebServer = "https://";

        public static ClientContext CreateClientContext()
        {
            return new ClientContext(LocalHost);
        }
    }
}