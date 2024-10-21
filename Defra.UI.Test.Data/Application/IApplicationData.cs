using RestSharp;

namespace Defra.UI.Test.Data.Application;

public interface IApplicationData
{
    public Task<RestResponse> CreateApplication(bool iscertifier = false);
    public void CreateApplicationWithAllTasks(bool iscertifier = false);
    public Task<RestResponse> DeleteApplication(string appId);
    public string ApplicationId { get; set; }
    public ApplicationResponse GetApplicationDisplayId(string appId);
    public Task<RestResponse> SubmitApplication(string applicationId);
    public void CertifierSubmitApplication(string ApplicationId);
    public void UpdateCertificationRegion(string ApplicationId);
    public void CreateApplicationWithAllTasksSkipFunction();
    public void CreateApplicationWithAllTasksWithDiseaseClearance();
    public Task<RestResponse> SubmitSkipApplication(string applicationId);
}