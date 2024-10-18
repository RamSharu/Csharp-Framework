using BoDi;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant;
using Defra.UI.Tests.Pages.Exporter.CertificateLookupPage;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using Defra.UI.Tests.Pages.Exporter.CommoditySummary;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CommoditySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ICertificateLookup? CertificateLookup => _objectContainer.IsRegistered<ICertificateLookup>() ? _objectContainer.Resolve<ICertificateLookup>() : null;
        private ICommodity? Commodity => _objectContainer.IsRegistered<ICommodity>() ? _objectContainer.Resolve<ICommodity>() : null;
        private ICommoditySummary? CommoditySummary => _objectContainer.IsRegistered<ICommoditySummary>() ? _objectContainer.Resolve<ICommoditySummary>() : null;
        private IIdentificationPage Identification => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        private IIdentificationPage IdentificationPage => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        private IColdStoreAndManufacturingPlantPage ColdStoreAndManufacturingPlant => _objectContainer.IsRegistered<IColdStoreAndManufacturingPlantPage>() ? _objectContainer.Resolve<IColdStoreAndManufacturingPlantPage>() : null;


        //Data
        private IApplicationData? AppData => _objectContainer.IsRegistered<IApplicationData>() ? _objectContainer.Resolve<IApplicationData>() : null;

        public ApplicationResponse ApplicationResponse { get; set; }

        public CommoditySteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        [Given(@"start a new application and click start now")]
        [When(@"start a new application and click start now")]
        [Then(@"start a new application and click start now")]
        public void ThenStartANewApplicationAndClickStartNow()
        {
            Commodity.StartNewApplication();
            Assert.True(true, "Not able to start the application");
        }

        [Given(@"enter a unique application reference '([^']*)' and continue")]
        [When(@"enter a unique application reference '([^']*)' and continue")]
        [Then(@"enter a unique application reference '([^']*)' and continue")]
        public void ThenEnterAUniqueApplicationReferenceAndContinue(string reference)
        {
            Commodity.EnterRefAndcontinue(reference);
            Assert.True(true, "Not able to start the application");
        }

        [Given(@"select certificate for your export '([^']*)' and continue")]
        [When(@"select certificate for your export '([^']*)' and continue")]
        [Then(@"select certificate for your export '([^']*)' and continue")]
        public void ThenSelectCertifierForYourExportAndContinue(string certificate)
        {
            Assert.IsTrue(CertificateLookup.IsCertificateLookupPage, "Certificate look up page is not displayed for selecting an EHC certificate");
            Commodity.EnterSelectCertificateAndContinue(certificate);
            Assert.True(true, "Not able to start the application");
            string applicationId = GetApplicationIdFromURL();

            if (ConfigSetup.BaseConfiguration.TestConfiguration.Environment.Contains("pre"))
            {
                ApplicationResponse = new ApplicationResponse();
                ApplicationResponse.ApplicationId = applicationId;
            }
            else
            {
                ApplicationResponse = AppData.GetApplicationDisplayId(applicationId);
            }

            _scenarioContext.Add("AppDispId", ApplicationResponse);
            Assert.True(true, "Application is not created successfully");
        }

        private string GetApplicationIdFromURL()
        {
            string env = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
            string certificate = "/Export-health-certificate/Summary/";
            string commodity = "/Commodities/Certificates/Add";
            string url = _driver.Url;
            url = url.Replace(env, "");
            url = url.Replace(certificate, "");
            url = url.Replace(commodity, "");

            return url;
        }

        [Given(@"select commodity '([^']*)' and continue")]
        [When(@"select commodity '([^']*)' and continue")]
        [Then(@"select commodity '([^']*)' and continue")]
        public void ThenSelectCommodityAndContinue(string commodityNumber)
        {
            Commodity.EnterSelectCommodityAndContinue(commodityNumber);
            Assert.True(true, "Not able to start the application");
        }

        [Given(@"add commodity '([^']*)' for '([^']*)' data and continue")]
        [When(@"add commodity '([^']*)' for '([^']*)' data and continue")]
        [Then(@"add commodity '([^']*)' for '([^']*)' data and continue")]
        public void ThenAddCommodityForDataAndContinue(string noofidentification, string certificate)
        {
            Identification.AddIdentification(Convert.ToInt32(noofidentification), certificate);
             Assert.True(true, "Not able to start the application");
        }

        [Given(@"select a country")]
        [When(@"select a country")]
        [Then(@"select a country")]
        public void GivenSelectACountry()
        {
            Identification.SelectOperatorSearchCountry("United Kingdom");
        }

        [Given(@"search by approval number ([^']*)'")]
        [When(@"search by approval number '([^']*)'")]
        [Then(@"search by approval number '([^']*)'")]
        public void GivenSearchByApprovalNumber(string approvalNumber)
        {
            if (approvalNumber.Equals("empty"))
            {
                ColdStoreAndManufacturingPlant.ApprovalNumberSearch("");
                Assert.AreEqual(1, ColdStoreAndManufacturingPlant.IsApprovalNumberAlertPresent(), "Approval Number alert is not present");
                Assert.True(ColdStoreAndManufacturingPlant.ApprovalNumberThrowsAlert(), "Approval Number alert text is wrong");
            }

            else
            {
                ColdStoreAndManufacturingPlant.ApprovalNumberSearch(approvalNumber);
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsApprovalNumberAlertPresent(), "Approval Number alert is present");
                Assert.True(ColdStoreAndManufacturingPlant.SearchResultsAreReturned(), "Approval Number Results are not returned");

            }
        }

        [Then(@"approval number alerts are cleared after searching by '([^']*)'")]
        public void ThenApprovalNumberAlertsAreClearedAfterSearchingBy(string searchResult)
        {
            if (searchResult.Equals("empty"))
            {
                ColdStoreAndManufacturingPlant.GoToApprovalNumberSearch();
                Assert.True(ColdStoreAndManufacturingPlant.IsApprovalNumberSearchCleared(), "Approval Number search box has not been cleared");
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsApprovalNumberAlertPresent(), "Approval Number alert has not been cleared");
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsApprovalNumberSearchResultsPresent(), "Search results have not been cleared");
            }

            else
            {
                ColdStoreAndManufacturingPlant.GoToApprovalNumberSearch();
                Assert.True(ColdStoreAndManufacturingPlant.IsApprovalNumberSearchCleared(), "Approval Number search box has not been cleared");
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsApprovalNumberAlertPresent(), "Approval Number alert has not been cleared");
                Assert.AreEqual(1, ColdStoreAndManufacturingPlant.IsApprovalNumberSearchResultsPresent(), "Search results have been cleared");
                Assert.True(ColdStoreAndManufacturingPlant.SearchResultsText(searchResult), "Search Result still contains Approval search");
            }
        }

        [Given(@"search by operator name '([^']*)'")]
        [When(@"search by operator name '([^']*)'")]
        [Then(@"search by operator name '([^']*)'")]
        public void WhenSearchByOperatorName(string operatorName)
        {
            if (operatorName.Equals("empty"))
            {
                ColdStoreAndManufacturingPlant.SearchOperatorByName("");
                Assert.AreEqual(1, ColdStoreAndManufacturingPlant.IsOperatorNameAlertPresent(), "Operator Name alert is not present");
                Assert.True(ColdStoreAndManufacturingPlant.OperatorNameThrowsAlert(), "Operator Name alert text is wrong");
            }

            else
            {
                ColdStoreAndManufacturingPlant.SearchOperatorByName(operatorName);
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsOperatorNameAlertPresent(), "Operator Name alert is present");
                Assert.True(ColdStoreAndManufacturingPlant.SearchResultsAreReturned(), "Operator Name Results are not returned");
            }
        }

        [Then(@"operator name alerts are cleared after searching by '([^']*)'")]
        public void ThenOperatorNameAlertsAreClearedAfterSearchingBy(string searchResult)
        {
            if (searchResult.Equals("empty"))
            {
                ColdStoreAndManufacturingPlant.GoToOperatorNameSearch();
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsOperatorNameAlertPresent(), "Operator Name alert has not been cleared");
                Assert.True(ColdStoreAndManufacturingPlant.IsOperatorNameSearchCleared(), "Operator Name search box has not been cleared");
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsOperatorNameSearchResultsPresent(), "Operator Name search results have not been cleared");
            }

            else
            {
                ColdStoreAndManufacturingPlant.GoToOperatorNameSearch();
                Assert.AreEqual(0, ColdStoreAndManufacturingPlant.IsOperatorNameAlertPresent(), "Operator Name alert has not been cleared");
                Assert.True(ColdStoreAndManufacturingPlant.IsOperatorNameSearchCleared(), "Operator Name search box has not been cleared");
                Assert.AreEqual(1, ColdStoreAndManufacturingPlant.IsOperatorNameSearchResultsPresent(), "Operator Name search results have not been cleared");
                Assert.True(ColdStoreAndManufacturingPlant.SearchResultsText(searchResult), "Search Result still contains Organisation search");
            }

        }

        [Then(@"I click save and continue")]
        public void ThenIClickSaveAndContinue()
        {
            ColdStoreAndManufacturingPlant.ClickSaveAndContinue();
        }

        [Then(@"organisation alert is thrown")]
        public void ThenOrganisationAlertIsThrown()
        {
            Assert.True(ColdStoreAndManufacturingPlant.OrganisationAlertIsThrown(), "Organisation throws alert");
        }

        [Given(@"select a manufacturing plant")]
        [When(@"select a manufacturing plant")]
        [Then(@"select a manufacturing plant")]
        public void GivenSelectAManufacturingPlant()
        {
            IdentificationPage.ClickManufacturingPlantLink();
        }

        [Given(@"I verify that commodity data is added successfully")]
        [Then(@"I verify that commodity data is added successfully")]
        public void GivenIVerifyThatCommodityDataIsAddedSuccessfully()
        {
            Assert.True(Commodity.VerifyCommodity(), "Commodity not added successfullyy");
        }

        [Given(@"verify commodity has been added successfully")]
        [When(@"verify commodity has been added successfully")]
        [Then(@"verify commodity has been added successfully")]
        public void ThenVerifyCommodityHasBeenAddedSuccessfully()
        {
            Assert.True(Commodity.VerifyCommodity(), "Commodity not added");
        }

        [When(@"I click on copy commodity link")]
        public void ThenVerifyCommodityHasBeenAddedSuccessfullyAndCopyRecords()
        {
            Commodity.CopyCommodityRecords();
        }

        [Then(@"I can verify that the commodity has been copied successfully")]
        public void ThenVerifyCommodityRecordsHasCopiedSuccessfully()
        {
            Assert.True(Commodity.VerifyCopyRecords(), "Commodity not copied successfully");
        }

        [When(@"I click on remove commodity link")]
        public void ThenVerifyCommodityHasBeenAddedSuccessfullyAndRemoveRecords()
        {
            Commodity.RemoveCommodityRecords();
        }

        [Then(@"I can verify that the commodity has been removed successfully")]
        public void ThenIVerifyCommodityRecordsHasRemovedSuccessfully()
        {
            Assert.True(Commodity.VerifyRemoveRecords(), "commodity records has not removed successfully");
        }

        [Then(@"change commodity record fields '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenChangeCommodityRecordFields(string productDesc, string packageCount, string netWeight)
        {
            Commodity.ChangeCommodityRecord(productDesc, packageCount, netWeight);
        }

        [Then(@"update '([^']*)' amount and go to check your answers page")]
        public void ThenUpdateAmountAndGoToCheckYourAnswersPage(string netWeight)
        {
            Commodity.UpdateNetWeightAmount(netWeight);
        }

        [Then(@"verify commodity record has been changed successfully")]
        [When(@"verify commodity record has been changed successfully")]
        public void ThenVerifyCommodityRecordHasBeenChangedSuccessfully()
        {
            Assert.True(Commodity.VerifyChangeRecords(), "commodity records has not changed successfully");
        }

        [Then(@"change commodity activity to '([^']*)'")]
        public void ThenChangeCommodityActivityTo(string activityName)
        {
            Commodity.ChangeCommodityActivity(activityName);
        }

        [Then(@"verify commodity activity '([^']*)' has been changed successfully")]
        public void ThenVerifyCommodityActivityHasBeenChangedSuccessfully(string activityName)
        {
            Assert.True(Commodity.VerifyCommodityActivity(activityName), "commodity activity has not changed successfully");
        }

        [Then(@"the value is saved with the decimal points '([^']*)' for '([^']*)' record")]
        public void ThenTheValueIsSavedWithTheDecimalPoints(string netWeight, string record)
        {
            Assert.True(Commodity.VerifyNetWeight(netWeight, record), "Net weight not the same");
        }

        [When(@"copy commodity record fields '([^']*)', '([^']*)' and '([^']*)'")]
        public void WhenCopyCommodityRecordFieldsAnd(string productDesc, string packageCount, string netWeight)
        {
            Commodity.CopyAndUpdateCommodityRecord(productDesc, packageCount, netWeight);
        }

        [Then(@"add commodity '([^']*)' for '([^']*)' data with '([^']*)' and continue")]
        public void ThenAddCommodityForDataWithAndContinue(string noofidentification, string certificate, string netWeight)
        {
            Identification.AddDecimalCommodityData(Convert.ToInt32(noofidentification), certificate, netWeight);
        }

        [Then(@"I am able to amend the net weight of a commodity using a decimal point to '([^']*)'")]
        public void ThenIAmAbleToAmendTheNetWeightOfACommodityUsingADecimalPointTo(string netWeight)
        {
            Commodity.ClickChangeRecords();
            Commodity.UpdateCommodityRecord("Auto Product", "5", netWeight);
        }

        [Then(@"I have left some mandatory fields blank and chosen to skip")]
        public void ThenIHaveLeftSomeMandatoryFieldsBlankAndChosenToSkip()
        {
            Identification.SkipAndContinue();
            Assert.True(CommoditySummary.IsCommoditySummaryPage(), "Not commodity summary page");
        }

        [When(@"add commodity (.*) for '([^']*)' data without'([^']*)' and continue")]
        public void WhenAddCommodityForDataWithoutAndContinue(int noOfIdentifications, string certificate, string specificField)
        {
            Identification.AddCommodityDataWithOutSpecificField(noOfIdentifications, certificate, specificField);
        }

        [Then(@"I verify validation error messages at the top of the Commodity page without '([^']*)'")]
        public void ThenIVerifyValidationErrorMessagesAtTheTopOfTheCommodityPageWithout(string specificField)
        {
            Assert.True(Commodity.VerifyValidationErrorMessagesTopOfPage(specificField), "Expected validation Error messages are not displayed");
        }

        [Then(@"I verify the error message is marked against the '([^']*)'")]
        public void ThenIVerifyTheErrorMessageIsMarkedAgainstThe(string specificField)
        {
            Assert.True(Commodity.VerifyValidationMsgAgainstSpecificField(specificField), "Expected validation Error messages are not displayed");
        }

        [Then(@"Verify Skip validation error message and check box appears saying that I can select skip")]
        public void ThenVerifySkipValidationErrorMessageAndCheckBoxAppearsSayingThatICanSelectSkip()
        {
            Assert.True(Identification.IsSkipCheckboxVisible(), "Skip Check box is not visible");
            Assert.True(Commodity.VerifySkipValidationErrorMsgBottomOfPage(), "Skip error message doesnot appear at bottom of page");
        }

        [Then(@"Verify the skip validation message \(and checkbox\) is removed")]
        public void ThenVerifyTheSkipValidationMessageAndCheckboxIsRemoved()
        {
            Assert.True(!(Identification.IsSkipCheckboxVisible()), " Skip checkbox is not removed, it still visible");
            Assert.True(!Commodity.VerifySkipValidationErrorMsgBottomOfPage(), "Skip error message is not removed at bottom of page, it still appears");
        }

        [Then(@"I verify skip check box ticked in Identification entry page")]
        [Then(@"I can see the skip checkbox is checked")]
        public void ThenICanSeeTheSkipCheckboxIsChecked()
        {
            Assert.True(IdentificationPage.IsSkipChecked(), "Skip checkbox not checked");
        }

        [Then(@"I can see the skip checkbox is unchecked")]
        public void ThenICanSeeTheSkipCheckboxIsUnchecked()
        {
            Assert.False(IdentificationPage.IsSkipChecked(), "Skip checkbox checked");
        }

        [Then(@"I can see that the skip checkbox is still not there")]
        public void ThenICanSeeThatTheSkipCheckboxIsStillNotThere()
        {
            Assert.False(IdentificationPage.IsSkipCheckboxVisible(), "Skip checkbox is visible");
        }
    }
}
