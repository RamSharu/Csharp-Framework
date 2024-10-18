using BoDi;
using Defra.UI.Tests.Pages.Exporter.CopyApplication;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CopyApplicationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ICopyApplication? CopyApplication => _objectContainer.IsRegistered<ICopyApplication>() ? _objectContainer.Resolve<ICopyApplication>() : null;

        public CopyApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"the copy application page is displayed")]
        [Then(@"the copy application page is displayed")]
        public void WhenTheCopyApplicationPageIsDisplayed()
        {
            Assert.True(CopyApplication.IsCopyApplicationPage, "Copy Application Page not displayed");
        }

        [When(@"I click on ""([^""]*)"" to copy everything from the application")]
        public void WhenIClickOnRadioOptionToCopyEverythingFromTheApplication(string yesOrNoRadio)
        {
            CopyApplication.ClickCopyRadioOption(yesOrNoRadio);
        }

        [When(@"I click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
            CopyApplication.ClickContinueButton();
        }

        [When(@"I click on Confirm and send button")]
        public void WhenIClickOnConfirmAndSendButton()
        {
            CopyApplication.ClickContinueButton();
        }

        [Then(@"I can validate all the fields on copy application page")]
        public void ThenICanValidateAllTheFieldsOnCopyApplicationPage()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(CopyApplication.IsBackLinkDisplayed, "Back link is not displayed");
                Assert.IsTrue(CopyApplication.IsCopyApplicationHeaderDisplayed, "Copy application page header is not displayed");
                Assert.IsTrue(CopyApplication.ValidateApplicationDetails(), "Key application details are not displayed");
                Assert.IsTrue(CopyApplication.ValidateCopyRadioButtons(), "Radio buttons for copy application are not displayed");
                Assert.IsTrue(CopyApplication.IsContinueButtonDisplayed, "Continue button is not displayed");
            });
        }
    }
}
