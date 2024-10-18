using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Defra.UI.Tests.Pages.Exporter.BorderControl;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class BorderControlSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public BorderControlSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IBorderControl? BorderControl => _objectContainer.IsRegistered<IBorderControl>() ? _objectContainer.Resolve<IBorderControl>() : null;
        private ICheckYourAnswers CheckYourAnswers => _objectContainer.IsRegistered<ICheckYourAnswers>() ? _objectContainer.Resolve<ICheckYourAnswers>() : null;

        [Then(@"verify border control page by adding valid details '([^']*)' with '([^']*)'")]
        public void ThenVerifyBorderControlPageByAddingValidDetailsAnd(string xI, string p1)
        {
            Assert.True(BorderControl.VerifyCompleteBorderControl(xI, p1), "Border Control entry not completed");
        }

        [Then(@"border control details added successfully")]
        public void ThenBorderControlDetailsAddedSuccessfully()
        {
            Assert.True(BorderControl.IsBorderControlDetailsCompleted(), "Border Control details are not completed successfully");
        }

        [Then(@"verify border control page by adding valid details '([^']*)' with '([^']*)' and '([^']*)'")]
        public void ThenVerifyBorderControlPageByAddingValidDetailsAndCheckBox(string xI, string p1,string skipcheckbox)
        {
            Assert.True(BorderControl.VerifyCompleteBorderControlCheckBox(xI, p1, skipcheckbox), "Border Control entry not completed");
        }

        [Then(@"verify Border Control Post validation message information")]
        public void ThenVerifyBorderControlPostValidationMessageInformation()
        {
            Assert.True(BorderControl.VerifySkipValidationInformation(), "No validation message for Border Control post");
        }

        [Then(@"change Border Control Post with skip flag")]
        public void ThenChangeBorderControlPostWithSkipFlag()
        {
            Assert.True(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed after BCP section is skipped and completed");
            CheckYourAnswers.ClickChangeEntryBCP();
            Assert.True(BorderControl.IsBcpPage, "BCP page not displayed after change link from check your answers page is clicked");
            BorderControl.ClickBcpSkipCheckbox();
            BorderControl.ClickSaveAndContinueButton();
        }

        [Then(@"verify Border Control Post not entered on review page")]
        public void ThenVerifyBorderControlPostOnReviewPage()
        {
            Assert.True(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed after BCP section is skipped and completed");
            Assert.True(BorderControl.VerifyBorderControlPostNotEnteredOnReviewPage(), "Review page doesn't have 'Not entered' status when BCP section is skipped");
        }

    }
}
