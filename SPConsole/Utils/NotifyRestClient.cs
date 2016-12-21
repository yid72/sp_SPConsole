using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SPConsole.Utils
{
    class NotifyRestClient
    {
        private const string AAD_Thumbprint = "5dd61e7eb570921f036458e69909d2359be61845";
        private const string SSL_Thumbprint = "c30d44704924e9639d66870277ab5a21f99d6432";

        private static string[] Thumbprints = { AAD_Thumbprint, SSL_Thumbprint};

        private const string RDServerBaseUrl = "https://yidong-notifytest.cloudapp.net";
        private const string LocalServerBaseUrl = "https://localhost";

        private const string PathUnsuscribe = "/api/Test/method/GetUnsubscribeUrl";
        private const string WebLayoutUrl = "https://microsoft-my.sharepoint.com/personal/yid_microsoft_com/_layouts/15";
        private const string UserEmail = "yid@microsoft.com";

        private HttpClient httpClient;

        public NotifyRestClient()
        {
            // Proceed for an invalid cerficate
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            WebRequestHandler handler = new WebRequestHandler();

            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            foreach (string thumbprint in Thumbprints)
            {
                X509Certificate2Collection certCollection = store.Certificates.Find(
                    X509FindType.FindByThumbprint,
                    AAD_Thumbprint,
                    false);

                if (certCollection.Count > 0)
                {
                    handler.ClientCertificates.Add(certCollection[0]);
                }
            }

            store.Close();

            httpClient = new HttpClient(handler);
        }

        public async Task<string> GenerateUnsubscribeUrl()
        {
            string path = RDServerBaseUrl + PathUnsuscribe +
                "?layoutUrl=" + Uri.EscapeUriString(WebLayoutUrl) +
                "&email=" + Uri.EscapeUriString(UserEmail);

            HttpResponseMessage response = await this.httpClient.GetAsync(path);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
