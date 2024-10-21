namespace Defra.UI.Tests.Pages.Exporter.Applications
{
    public interface IApplications
    {
        public bool IsApplicationsPage { get; }
        public void ClickStartNewApplicationButton();
        public bool IsApplicationsTableDisplayed { get; }
        public bool IsApplicationsTableRowsDisplayed();
        public bool IsCountrylistDisplayed();
        public bool IsDateListDisplayed();
        public bool IsStatusListDisplayed();
        public void ClickCopyApplication();
        public void ClickDeleteApplication();
        public bool VerifyIfApplicationIsDeleted();
        public bool IsCountryFiltered(string filter);
        public bool IsDateFiltered(string filter);
        public bool IsStatusFiltered(string filter);
        public bool VerifyViewApplication();
        public bool VerifyViewApplicationReference();
        public bool SearchApplication(string application);
        public void ClickShowLink();
        public bool VerifyStatus(string status);
        public bool ClickReplacingApplication(string status);
        public bool ClickReplacementApplication();
        public bool ValidateFirstPage { get; }
        public void ClickNextPageLink();
        public void ClickLastPageLink();
        public bool ValidateNumOfApplications();
        public bool ValidateIfNextPageIsDisplayed();
        public bool ValidateIfLastPageIsDisplayed();
        public bool ValidateIfLastPageApplicationsAreDisplayed();
        public bool VerifyCertificateStatus(string referenceName);
        public string GetHomePageHeader();
        public bool IsStartNewAppButtonDisplayed { get; }
        public string GetStartNewAppButtonText();
        public string GetSearchApplicationHeader();
        public string GetSearchHintText();
        public bool IsSearchTextBoxDisplayed { get; }
        public bool IsClearFiltersLinkDisplayed { get; }
        public List<string> GetFiltersTextList();
        public List<string> GetTableHeaderElements();
        public bool ValidateApplicationSerialNum();
        public bool IsCertificateSubTableDisplayed { get; }
        public List<string> GetButtonElements();
        public void ClickViewApplication();
    }
}
