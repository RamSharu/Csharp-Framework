using BoDi;
using Defra.UI.Tests.Pages.Exporter.CertificateLookupPage;
using Defra.UI.Tests.Pages.Exporter.StartNewEhc;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class StartNewEhcSteps
    {
        private readonly IObjectContainer _objectContainer;

        public StartNewEhcSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IStartNewEhc StartNewEhc => _objectContainer.IsRegistered<IStartNewEhc>() ? _objectContainer.Resolve<IStartNewEhc>() : null;
        private ICertificateLookup CertificateLookup => _objectContainer.IsRegistered<ICertificateLookup>() ? _objectContainer.Resolve<ICertificateLookup>() : null;

        [Given(@"I am on start new Ehc page to add a new application reference")]
        public void GivenIAmOnStartNewEhcPageToAddANewApplicationReference()
        {
            Assert.IsTrue(StartNewEhc.IsStartNewEhcPage, "Start new ehc page is not displayed");
        }

        [When(@"I add a valid application reference '([^']*)'")]
        public void WhenIAddAValidApplicationReference(string validString)
        {
            StartNewEhc.AddApplicationRef(validString);
        }

        [Then(@"I can see validation message upon entering invalid application reference")]
        public void ThenICanSeeValidationMessageUponEnteringInvalidApplicationReference(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (string value in row.Values)
                {
                    StartNewEhc.AddApplicationRef(value);
                    StartNewEhc.ClickSaveAndContinueButton();
                    Assert.Multiple(() =>
                    {
                        Assert.True(StartNewEhc.GetErrorSummaryTitleText().Contains("There is a problem"), "Error message title text doesn't match with expecetd string");
                        Assert.True(StartNewEhc.GetErrorSummaryBodyText().Contains("must only include letters, numbers, and special characters such as"), "Error message title text doesn't match with expecetd string");
                        Assert.True(StartNewEhc.GetErrorMessageText().Contains("must only include letters, numbers, and special characters such as"), "Error message title text doesn't match with expecetd string");
                    });
                }
            }
        }

        [When(@"I leave the application reference blank and save")]
        [When(@"I click on save and continue button")]
        public void WhenIClickOnSaveAndContinueButton()
        {
            StartNewEhc.ClickSaveAndContinueButton();
        }

        [Then(@"The application reference is successfully saved as I am taken to the certificate look up page")]
        public void ThenTheApplicationReferenceIsSuccessfullySavedAsIAmTakenToTheCertificateLookUpPage()
        {
            Assert.True(CertificateLookup.IsCertificateLookupPage, "Application reference is not saved successfully after entering allowed inputs");
        }

        [Then(@"I can see that error message for blank application reference is displayed")]
        public void ThenICanSeeThatErrorMessageForBlankApplicationReferenceIsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.True(StartNewEhc.GetErrorSummaryTitleText().Contains("There is a problem"), "Error message title text doesn't match with expecetd string");
                Assert.True(StartNewEhc.GetErrorSummaryBodyText().Contains("Enter your application reference"), "Error message title text doesn't match with expecetd string");
                Assert.True(StartNewEhc.GetErrorMessageText().Contains("Enter your application reference"), "Error message title text doesn't match with expecetd string");
            });
        }
    }
}
