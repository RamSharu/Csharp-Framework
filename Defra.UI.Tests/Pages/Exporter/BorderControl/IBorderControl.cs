namespace Defra.UI.Tests.Pages.Exporter.BorderControl
{
    public interface IBorderControl
    {
        public bool IsBcpPage { get; }
        bool VerifyCompleteBorderControl(string countryId, string borderName);
        bool IsBorderControlDetailsCompleted();
        public bool VerifyCompleteBorderControlCheckBox(string countryId, string borderName, string skipcheckbox);
        public bool VerifySkipValidationInformation();
        public void CompleteBorderControl(string countryId, string borderName);
        public void ClickBcpSkipCheckbox();
        public void ClickSaveAndContinueButton();
        public bool VerifyBorderControlPostNotEnteredOnReviewPage();
    }
}
