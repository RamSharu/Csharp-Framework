using BoDi;
using Defra.UI.Tests.Pages.EstablishmentLookupPage;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class EstablishmentlookupPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IEstablishmentLookupPage EstablishmentLookupPage => _objectContainer.IsRegistered<IEstablishmentLookupPage>() ? _objectContainer.Resolve<IEstablishmentLookupPage>() : null;

        public EstablishmentlookupPageSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [When(@"I am on the establishment lookup page where list of operator activities are displayed")]
        public void WhenIAmOnTheEstablishmentLookupPageWhereListOfActivitiesRelatedToTheOperatorAreDisplayed()
        {
            Assert.True(EstablishmentLookupPage.IsEstablishmentLookupPage, "Establishment look up page is not displayed for operator activity selection");
        }

        [Then(@"I can validate all the mandatory fields on establishment lookup page")]
        public void ThenICanValidateAllTheMandatoryFieldsOnEstablishmentLookupPage()
        {
            EstablishmentLookupPage.ClickHelpAddingActivitiesLink();
            Assert.Multiple(() =>
            {
                Assert.True(EstablishmentLookupPage.IsEstablishmentLookUpPageHeaderDisplayed, "Establishment look up page header does not display correct text");
                Assert.True(EstablishmentLookupPage.IsBackLinkDisplayed, "Back link is not displayed");
                Assert.True(EstablishmentLookupPage.GetHintText.Contains("Select the activity"), "Hint text does not match the expected string");
                Assert.True(EstablishmentLookupPage.GetHelpAddingActivitiesLinkText.Contains("Help with adding activities"), "Help link does not have expected string");
                Assert.True(EstablishmentLookupPage.GetHelpAddingActivitiesDetailsText.StartsWith("If you're unsure which activity to select"), "Help text does not match the expected string");
                Assert.True(EstablishmentLookupPage.IsSaveAndContinueButtonDisplayed, "Save and continue button not displayed");
            });
        }

        [Then(@"I can see all the activities for all the classification groups and classifications displayed")]
        public void ThenICanSeeAllTheActivitiesForAllTheClassificationGroupsAndClassificationsDisplayed()
        {
            Assert.True(EstablishmentLookupPage.ValidateActivityRadioElements(), "Activities doesn't display classifications or classification groups");
        }

        [Then(@"the activities are displayed in alphabetical order by activity and then classification")]
        public void ThenTheActivitiesAreDisplayedInAlphabeticalOrderByActivityAndThenClassification()
        {
            Assert.True(EstablishmentLookupPage.CheckIfActivitiesInAlphabeticalOrder(), "Operator activities are not arranged in alphabetical order");
        }

        [When(@"I click on Save and continue button without selecting operator activity")]
        public void WhenIClickOnSaveAndContinueButtonWithoutSelectingOperatorActivity()
        {
            EstablishmentLookupPage.ClickSaveAndContinueButton();
        }

        [Then(@"I can see that validation messages are displayed as operator activity is not selected")]
        public void ThenICanSeeThatValidationMessagesAreDisplayedAsOperatorActivityIsNotSelected()
        {
            Assert.Multiple(() =>
            {
                Assert.True(EstablishmentLookupPage.GetErrorSummaryHeader.Contains("There is a problem"), "Error summary header is not displayed");
                StringAssert.StartsWith("Select", EstablishmentLookupPage.GetErrorSummaryMessage, "Error summary message is not displayed");
                Assert.True(EstablishmentLookupPage.GetActivityErrorMessage.Contains("Select"), "Activity selection error message is not displayed");
            });
        }
    }
}