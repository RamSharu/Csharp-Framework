using BoDi;
using Defra.UI.Tests.Pages.SelectExporterOrConsignorActivity;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class SelectExporterOrConsignorActivitySteps
    {
        private readonly IObjectContainer _objectContainer;

        private ISelectExporterOrConsignorActivity? SelectExporterOrConsignorActivity => _objectContainer.IsRegistered<ISelectExporterOrConsignorActivity>() ? _objectContainer.Resolve<ISelectExporterOrConsignorActivity>() : null;

        public SelectExporterOrConsignorActivitySteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I am on the consignor activity selection page")]
        public void ThenIAmOnTheConsignorActivitySelectionPage()
        {
            Assert.True(SelectExporterOrConsignorActivity.IsSelectExporterOrConsignorActivityPage, "Select an exporter or consignor activity page is not displayed");
        }

        [Then(@"I can validate the fields on consignor activity selection page")]
        public void ThenICanValidateTheFieldsOnConsignorActivitySelectionPage()
        {
            var pageName = SelectExporterOrConsignorActivity.GetPageName;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(SelectExporterOrConsignorActivity.IsBackLinkDisplayed, $"Back link is not displayed on {pageName}");
                Assert.IsTrue(SelectExporterOrConsignorActivity.IsHintTextDisplayed, $"Hint text is not displayed on {pageName}");
                Assert.IsTrue(SelectExporterOrConsignorActivity.ValidateActivityRadios, $"Activities for the selected consignor are not displayed on {pageName}");
                Assert.IsTrue(SelectExporterOrConsignorActivity.GetHelpText().StartsWith("If you cannot"), $"Help with adding activities text is not displayed on {pageName}");
                Assert.IsTrue(SelectExporterOrConsignorActivity.IsSaveAndContinueButtonDisplayed, $"Save and continue button is not displayed on {pageName}");
            });
        }

        [Then(@"I select a consignor activity from the list of activities")]
        public void ThenISelectAConsignorActivityFromTheListOfActivities()
        {
            SelectExporterOrConsignorActivity.ClickActivityRadio();
        }

        [Then(@"I choose the new activity '([^']*)' on the select activity page")]
        public void ThenIChooseTheNewActivityOnTheSelectActivityPage(string newActivity)
        {
            SelectExporterOrConsignorActivity.ClickActivityRadio(newActivity);
        }

        [Then(@"I click on save and continue from select activity page")]
        public void ThenIClickOnSaveAndContinueFromSelectActivityPage()
        {
            Assert.True(SelectExporterOrConsignorActivity.IsSelectExporterOrConsignorActivityPage, "Select an exporter or consignor activity page is not displayed on clicking the change activity link");
            SelectExporterOrConsignorActivity.ClickSaveAndContinueButton();
        }
    }
}
