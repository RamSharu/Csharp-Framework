using BoDi;
using Defra.UI.Test.Data.Configuration;
using RestSharp;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Defra.UI.Test.Data
{
    public class BaseClient
    {
        private RestClient client;
        private RestRequest request;
        private X509Certificate2 certificate;
        private IObjectContainer _objectContainer;

        protected string RequestFolder { get; set; }

        private string ApiEndpoint { get; set; }

        public BaseClient()
        {
            string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            RequestFolder = Path.Combine(jsonPath, "RequestJson");
        }

        public void AddCertificate(string certPath, string certFileName)
        {
            var certFile = Path.Combine(certPath, certFileName);
            certificate = new X509Certificate2(certFile);
        }

        public RestClient SetUrl(string endpoint)
        {
            ApiEndpoint = DataSetupConfig.Configuration.ApiEndPoint;
            var url = Path.Combine(ApiEndpoint, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-version", "1");

            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-api-version", "1");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePutRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-version", "1");

            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreateDeleteRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-api-version", "1");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }
}