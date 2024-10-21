using BoDi;
using Defra.UI.Tests.Pages.Exporter.Consignor;
using Defra.UI.Tests.Pages.FindAnExporterOrConsignor;
using Defra.UI.Tests.Pages.SelectExporterOrConsignorActivity;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ConsignorSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IConsignorPage? Consignor => _objectContainer.IsRegistered<IConsignorPage>() ? _objectContainer.Resolve<IConsignorPage>() : null;
        private IFindAnExporterOrConsignor? FindAnExporterOrConsignor => _objectContainer.IsRegistered<IFindAnExporterOrConsignor>() ? _objectContainer.Resolve<IFindAnExporterOrConsignor>() : null;
        private ISelectExporterOrConsignorActivity? SelectExporterOrConsignorActivity => _objectContainer.IsRegistered<ISelectExporterOrConsignorActivity>() ? _objectContainer.Resolve<ISelectExporterOrConsignorActivity>() : null;

        public ConsignorSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"add consignor '([^']*)' and continue")]
        [When(@"add consignor '([^']*)' and continue")]
        public void ThenAddConsignorAndContinue(string consignorName)
        {
            Consignor.AddConsignor(consignorName);   
        }

        [Then(@"I click on select exporter or consignor link to reach the Find an exporter or consignor page")]
        public void ThenIClickOnSelectExporterOrConsignorLinkToReachTheFindAnExporterOrConsignorPage()
        {
            Consignor.ClickSelectExporterOrConsignorLink();
        }

        [Then(@"verify consignor has been added successfully")]
        public void ThenVerifyConsignorHasBeenAddedSuccessfully()
        {
            Assert.True(Consignor.VerifyConsignorStatus(), "Consignor not added successfully");
        }

        [Then(@"search for consignor '([^']*)'")]
        [When(@"search for consignor '([^']*)'")]

        public void ThenSearchForConsignor(string consignorName)
        {
            Consignor.SearchConsignor(consignorName);
        }

        [Then(@"verify consignor activity is displayed on consignor page")]
        public void ThenVerifyConsignorActivityIsDisplayedOnConsignorPage()
        {
            Assert.True(Consignor.VerifyConsignorActivity(), "Consignor activity not displayed");
        }

        [When(@"I navigate to consignor page")]
        [When(@"I am taken to the consignor page")]
        public void WhenINavigateToConsignorPage()
        {
            Assert.True(Consignor.IsConsignorOrExporterPage, "Exporter or Consignor page not displayed");
        }

        [Then(@"I can validate the fields '([^']*)' '([^']*)' '([^']*)' on Exporter or Consignor page")]
        public void ThenICanValidateTheFieldsOnExporterOrConsignorPage(string captionText, string descriptionText, string linkText)
        {
            var pageName = Consignor.GetConsignorOrExporterPageHeaderText;
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Consignor.IsBackLinkDisplayed, $"Back link is not displayed on {pageName}");
                Assert.That(Consignor.GetExporterConsignorCaption.Contains(captionText), $"The caption text doesn't have the expected text on {pageName}");
                Assert.IsTrue(Consignor.GetExporterConsignorDesc.Contains(descriptionText), $"Description doesn't have the expected text on {pageName}");
                Assert.IsTrue(Consignor.GetExporterConsignorLinkText.Contains(linkText), $"Select exporter or consignor link doesn't have the expected text on {pageName}");
                Assert.IsTrue(Consignor.IsContinueButtonDisplayed, $"Continue button is not displayed on {pageName}");
            });
        }

        [When(@"I add the consignor '([^']*)' and consignor activity '([^']*)' to complete the consignor section")]
        public void WhenIAddTheConsignorAndConsignorActivityToCompleteTheConsignorSection(string consignorName, string consignorActivity)
        {
            Consignor.ClickSelectExporterOrConsignorLink();

            Assert.True(FindAnExporterOrConsignor.IsFindAnExporterOrConsignorPage, "Find an exporter or consignor page is not displayed");
            FindAnExporterOrConsignor.SearchConsignor(consignorName);
            FindAnExporterOrConsignor.ClickSearchButton();
            FindAnExporterOrConsignor.SelectConsignorRadioOption(consignorName);
            FindAnExporterOrConsignor.ClickSaveAndContinueButton();

            Assert.True(SelectExporterOrConsignorActivity.IsSelectExporterOrConsignorActivityPage, "Select an exporter or consignor activity page is not displayed");
            SelectExporterOrConsignorActivity.ClickActivityRadio(consignorActivity);
            SelectExporterOrConsignorActivity.ClickSaveAndContinueButton();
        }

        [Then(@"I can see that the consignor and selected activity are displayed on the consignor page")]
        public void ThenICanSeeThatTheConsignorAndSelectedActivityAreDisplayedOnTheConsignorPage()
        {
            Assert.True(Consignor.IsConsignorOrExporterPage, "Exporter or Consignor page is not displayed after adding consignor and activity");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Consignor.ValidateConsignorAndAddressIfAdded(), "Consignor name and address are not added successfully");
                Assert.That(Consignor.ValidateConsignorActivityIfAdded, "Selected consignor activity is not added successfully");
            });
        }

        [Then(@"I can click on change activity link on the consignor page")]
        public void ThenICanClickOnChangeActivityLinkOnTheConsignorPage()
        {
            Consignor.ClickChangeActivityLink();
        }

        [Then(@"I can see that the '([^']*)' is displayed on the consignor page")]
        public void ThenICanSeeThatTheIsDisplayedOnTheConsignorPage(string newActivity)
        {
            Assert.True(Consignor.IsConsignorOrExporterPage, "Exporter or Consignor page not displayed after performing change activity");
            Assert.True(Consignor.GetConsignorActivity.Contains(newActivity), "The changed activity is not displayed");
        }
    }
}
