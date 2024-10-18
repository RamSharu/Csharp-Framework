using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow.Tracing;

namespace Defra.UI.Test.Data.Application
{
    public class ApplicationData : BaseClient, IApplicationData
    {
        private readonly object _lock = new object();
        public string ApplicationId { get; set; }

        public Task<RestResponse> CreateApplication(bool iscertifier = false)
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var client = SetUrl("EhcApplication");
                string file = "";
                if (iscertifier)
                {
                    file = Path.Combine(RequestFolder, "CertifierApplicationTaskRequest.json");
                }
                else
                {
                    file = Path.Combine(RequestFolder, "ApplicationTaskRequest.json");
                }
                var requestJson = File.ReadAllText(file);
                var request = CreatePostRequest(requestJson);
                response = GetResponseAsync(client, request);
                ApplicationId = response.Result.Content.Replace("\"", "");
            }
            return response;
        }

        public void CreateApplicationWithAllTasksSkipFunction()
        {
            lock (_lock)
            {
                var client = SetUrl("EhcApplication/all");
                var file = Path.Combine(RequestFolder, "ApplicationSkipTaskRequest.json");
                var requestJson = File.ReadAllText(file);
                var request = CreatePostRequest(requestJson);
                var response = GetResponseAsync(client, request).Result.Content.ToString();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(response.ToString())!;
                ApplicationId = dynamicObject.applicationId;
            }
            UpdateCertificationRegion(ApplicationId);
        }

        public Task<RestResponse> SubmitSkipApplication(string applicationId)
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var client = SetUrl("certificates/create");
                var file = Path.Combine(RequestFolder, "ApplicationSubmitRequest.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.applicationId = ApplicationId;
                var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
                response = GetResponseAsync(client, request);
            }
            return response;
        }

        public void CreateApplicationWithAllTasks(bool iscertifier = false)
        {
            lock (_lock)
            {
                var client = SetUrl("EhcApplication/all");
                string file = "";
                if (iscertifier)
                {
                    file = Path.Combine(RequestFolder, "CertifierApplicationRequest.json");
                }
                else
                {
                    file = Path.Combine(RequestFolder, "ApplicationRequest.json");
                }
                var requestJson = File.ReadAllText(file);
                var requestObject = JsonConvert.DeserializeObject<dynamic>(requestJson);
                requestObject.submitted = DateTime.UtcNow;
                var request = CreatePostRequest(requestJson);
                var response = GetResponseAsync(client, request).Result.Content.ToString();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(response.ToString())!;
                ApplicationId = dynamicObject.applicationId;
            }
            UpdateCertificationRegion(ApplicationId);
        }

        public void CreateApplicationWithAllTasksWithDiseaseClearance()
        {
            lock (_lock)
            {
                var client = SetUrl("EhcApplication/all");
                string file = "";
                file = Path.Combine(RequestFolder, "CertifierApplicationRequest_EHC8370.json");

                var requestJson = File.ReadAllText(file);
                var requestObject = JsonConvert.DeserializeObject<dynamic>(requestJson);
                requestObject.submitted = DateTime.UtcNow;
                var request = CreatePostRequest(requestJson);
                var response = GetResponseAsync(client, request).Result.Content.ToString();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(response.ToString())!;
                ApplicationId = dynamicObject.applicationId;
            }
            UpdateCertificationRegion(ApplicationId);
        }

        public void UpdateCertificationRegion(string ApplicationId)
        {
            lock (_lock)
            {
                var client = SetUrl("ehcs/certification-region");
                var file = Path.Combine(RequestFolder, "CertificationRegionRequest.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.applicationId = ApplicationId;
                var request = CreatePutRequest(JsonConvert.SerializeObject(dynamicObject));
                var response = GetResponseAsync(client, request);
            }
        }

        public ApplicationResponse GetApplicationDisplayId(string appId)
        {
            string appdisId = null;
            DateTime? submitted = null;
            lock (_lock)
            {
                string str = $"EhcApplication/{appId}/all";
                var client = SetUrl(str);
                var getRequest = CreateGetRequest();
                var resJson = GetResponseAsync(client, getRequest).Result.Content.ToString();
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(resJson.ToString())!;
                appdisId = dynamicObject.displayApplicationId;
                appId = dynamicObject.applicationId;
                submitted = dynamicObject.submitted;
            }

            var applicationResponse = new ApplicationResponse();
            applicationResponse.ApplicationId = appId;
            applicationResponse.ApplicatioDisplayId= appdisId;
            applicationResponse.Submitted = submitted;

            return applicationResponse;
        }

        public Task<RestResponse> DeleteApplication(string appId)
        {
            if (string.IsNullOrEmpty(ApplicationId))
            {
                ApplicationId = appId;
            }
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var client = SetUrl($"EhcApplication");
                var body = $"[{ApplicationId}]";
                var request = CreateDeleteRequest(body);
                response = GetResponseAsync(client, request);
            }
            return response;
        }

        public Task<RestResponse> SubmitApplication(string applicationId)
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var cancelReplace = false;
                var confirmedBy = Guid.Empty; 
                var submitUrl = $"Certificates/{applicationId}/{applicationId}/{cancelReplace}/create";

                var client = SetUrl(submitUrl);
                var file = Path.Combine(RequestFolder, "CertifierApplicationRequest.json");
                var requestJson = File.ReadAllText(file);
                var request = CreatePostRequest(requestJson);
                response = GetResponseAsync(client, request);
                ApplicationId = response.Result.Content.Replace("\"", "");
            }
            return response;
        }

        public void CertifierSubmitApplication(string ApplicationId)
        {
            lock (_lock)
            {
                var client = SetUrl("certificates/create");
                var file = Path.Combine(RequestFolder, "CertifierCreateCertificate.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.applicationId = ApplicationId;
                dynamicObject.submittedBy = ApplicationId;
                var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
                var response = GetResponseAsync(client, request);

            }
        }

    }
}
