using BoDi;
using Defra.UI.Tests.Pages.Exporter.PurposeOfExport;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class PurposeOfExportSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public PurposeOfExportSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IPurposeOfExport PurposeOfExport => _objectContainer.IsRegistered<IPurposeOfExport>() ? _objectContainer.Resolve<IPurposeOfExport>() : null;

        [Then(@"navigate to purpose of export page")]
        public void ThenNavigateToPurposeOfExportPage()
        {
            Assert.True(PurposeOfExport.IsPurposeOfExporterPageDisplayed(), "(Purpose of export page not displayed");
        }

        [Then(@"click on save and continue without selecting any option")]
        public void ThenClickOnSaveAndContinueWithoutSelectingAnyOption()
        {
            PurposeOfExport.ClickSaveAndContinue("");
        }

        [Then(@"validation message is displayed")]
        public void ThenValidationMessageIsDisplayed()
        {
            Assert.True(PurposeOfExport.PurposeOfExportAlertMessage(), "Purpose of export validation message displayed");
        }

        [Then(@"select the type of consignment '([^']*)' and continue")]
        public void ThenSelectTheTypeOfConsignmentAndContinue(string purposetype)
        {
            PurposeOfExport.ClickSaveAndContinue(purposetype);
        }

        [Then(@"country validation message is displayed")]
        public void ThenCountryValidationMessageIsDisplayed()
        {
            Assert.True(PurposeOfExport.PurposeOfExportCountryAlertMessage(), "Purpose of export country validation message displayed");
        }

        [Then(@"select the purpose of export '([^']*)' and continue")]
        public void ThenSelectThePurposeOfExportAndContinue(string purposetype)
        {
            PurposeOfExport.ClickPurposeOfExportButton(purposetype);
        }

        [Then(@"verify purpose of export has been completed successfully")]
        public void ThenVerifyPurposeOfExportHasBeenCompletedSuccessfully()
        {
            Assert.True(PurposeOfExport.PurposeOfExportStatus(), "Purpose of export not completed successfully");
        }
    }
}