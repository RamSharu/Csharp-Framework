using BoDi;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Data.EHC;
using Defra.UI.Tests.Data.Identification;
using Defra.UI.Tests.Pages.Certifier.Applications;
using Defra.UI.Tests.Pages.Certifier.CertifyEHC;
using Defra.UI.Tests.Pages.Certifier.ICertIdentification;
using Defra.UI.Tests.Pages.Exporter.Applications;
using Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Certifier
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public ApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IApplications? Applications => _objectContainer.IsRegistered<IApplications>() ? _objectContainer.Resolve<IApplications>() : null;

        // Pages
        private ICertifierApplications? CertApplications => _objectContainer.IsRegistered<ICertifierApplications>() ? _objectContainer.Resolve<ICertifierApplications>() : null;
        private ICertifierView? CertifierView => _objectContainer.IsRegistered<ICertifierView>() ? _objectContainer.Resolve<ICertifierView>() : null;
        private ICertIdentificationPage CertIdentification => _objectContainer.IsRegistered<ICertIdentificationPage>() ? _objectContainer.Resolve<ICertIdentificationPage>() : null;
        private IEHCData? EHCdata => _objectContainer.IsRegistered<IEHCData>() ? _objectContainer.Resolve<IEHCData>() : null;
        private IIdentificationPage Identification => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        private IColdStoreAndManufacturingPlantPage ColdStoreAndManufacturingPlantPage => _objectContainer.IsRegistered<IColdStoreAndManufacturingPlantPage>() ? _objectContainer.Resolve<IColdStoreAndManufacturingPlantPage>() : null;


        [Then(@"add new commodity record")]
        public void ThenAddNewCommodityRecord(EHC data)
        {
            List<IdentificationData> IdenList = new List<IdentificationData> { data.Identification };

            //Manage Commodity Task
            Identification.AddCommodityData(IdenList);
        }

        [Given(@"on certifier application page is displayed")]
        [Then(@"on certifier application page is displayed")]
        public void ThenApplicationPageIsDisplayed()
        {
            Assert.True(CertApplications.IsApplicationsPage, "Application Page not displayed");
        }

        [Given(@"I search and click on the certificate to proceed to the certifier view page")]
        public void GivenISearchAndClickOnTheCertificateToProceedToTheCertifierViewPage()
        {
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                Assert.True(Applications.SearchApplication(applicationres.ApplicatioDisplayId.ToString()), $"{applicationres.ApplicatioDisplayId} not able to search on the page");
            }

            Applications.ClickShowLink();
            CertApplications.ClickFirstApplication();
        }

        [Then(@"I verify changed record operator")]
        public void ThenIVerifyChangedRecordOperator()
        {
            Assert.True(CertApplications.VerifyChangedOperator(), "Opereator not matching");
        }

        [Then(@"I verify changed region of certification")]
        public void ThenIVerifyChangedRegionOfCertification()
        {
            Assert.True(CertApplications.VerifyChangedRegionOfCertification(), "Region of Certification not matching");
        }

        [Then(@"I verify new commodity record added successfully")]
        public void ThenIVerifyNewCommodityRecordAddedSuccessfully()
        {
            Assert.True(CertApplications.IsNewCommodityRecordDisplayed, "New Commodity Record not displayed");
        }

        [Then(@"search for a created application '([^']*)'")]
        public void ThenSearchForACreatedApplication(string ApplicationName)
        {
            Assert.True(CertApplications.SearchApplication(ApplicationName), "Application not found");
        }

        [When(@"edit the certifier commodity details")]
        public void WhenEditTheCertifierCommodityDetails()
        {
            CertApplications.ClickToViewCommodityDetails();
        }

        [When(@"I remove first commodity record and keep one record")]
        public void WhenIRemoveFirstCommodityRecordAndKeepOneRecord()
        {
            CertApplications.RemoveExistingRecord();
        }

        [When(@"edit the commodity details")]
        public void WhenEditTheCommodityDetails()
        {
            CertApplications.ClickToViewCommodityDetails();
            CertApplications.AddNewRecord();
        }

        [Given(@"I change commodity record operator")]
        [When(@"I change commodity record operator")]
        [Then(@"I change commodity record operator")]
        public void WhenIChangeCommodityRecordOperator()
        {
            CertApplications.EditExistingRecord();
            CertApplications.ChangeRecordOperator();
            ColdStoreAndManufacturingPlantPage.FillColdStore();
        }

        [When(@"I change region of certification")]
        public void WhenIChangeRegionOfCertification()
        {
            CertApplications.EditRegionOfCertification();
        }

        [Given(@"I click in to the created application")]
        [When(@"I click in to the created application")]
        [Then(@"I click in to the created application")]
        public void WhenIClickInToTheCreatedApplication()
        {
            Applications.ClickShowLink();
            CertApplications.ClickFirstApplication();
        }

        [When(@"click to expand the Commodity Details Panel")]
        public void WhenClickToExpandTheCommodityDetailsPanel()
        {
            CertApplications.ClickToViewCommodityDetails();
        }

        [When(@"click to collapse the Commodity Parent Tab Details Panel")]
        public void WhenClickToCollapseTheCommodityParentTabDetailsPanel()
        {
            CertApplications.ClickToCollapseCommodityParentTabDetails();
        }

        [When(@"click to expand the Container Seal Number")]
        public void WhenClickToExpandTheContainerSealNumber()
        {
            CertApplications.ClickToViewContainerNumberSealNumberTabDetails();
        }


        [When(@"I change responsible for load")]
        public void WhenIChangeResponsibleForLoad()
        {
            CertApplications.EditResponsibleForLoad();
        }

        [Then(@"I verify changed responsible for load")]
        public void ThenIVerifyChangedResponsibleForLoad()
        {
            CertApplications.VerifyResponsibleForLoad();
        }

        [Then(@"I edit and continue responsible for load '([^']*)''([^']*)'")]
        public void ThenIEditAndContinueResponsibleForLoad(string organisationName, string countryName)
        {
            CertApplications.CertifierEditResponsibleForLoad(organisationName, countryName);
        }

        [Then(@"verify responsoible for load '([^']*)'")]
        public void ThenVerifyResponsoibleForLoad(string validationInformation)
        {
            Assert.True(CertApplications.VerifyCertifierRFLValidation(validationInformation), "Responsible for load validation error not as expected");
        }

        [When(@"I change change purpose of export")]
        public void WhenIChangeChangePurposeOfExport()
        {
            CertApplications.EditPurposeOfExport();
        }

        [Then(@"I verify changed change purpose of export")]
        public void ThenIVerifyChangedChangePurposeOfExport()
        {
            Assert.True(CertApplications.VerifyChangedPurposeOfExport(), "Purpose of export not matching");
        }

        [When(@"I change change goods certified as '([^']*)'")]
        public void WhenIChangeChangeGoodsCertifiedAs(string goodscertifiedas)
        {
            CertApplications.EditGoodsCertifiedAs(goodscertifiedas);
        }

        [Then(@"I verify changed goods certified as")]
        public void ThenIVerifyChangedGoodsCertifiedAs()
        {
            Assert.True(CertApplications.VerifyChangedGoodsCertifiedAs(), "Goods certified as not matching");
        }

        [When(@"I change container or seal number as '([^']*)' and '([^']*)'")]
        public void WhenIChangeContainerOrSealNumberAsAnd(string containerNumber, string sealNumber)
        {
            CertApplications.EditContainerOrSealNumber(containerNumber, sealNumber);
        }

        [Then(@"I verify changed container or seal number")]
        public void ThenIVerifyChangedContainerOrSealNumber()
        {
            Assert.True(CertApplications.VerifyChangedContainerOrSealNumber(), "Container and Seal Number not matching");
        }

        [Then(@"I change Depature and Arrival date")]
        public void ThenIChangeDepatureAndArrivalDate()
        {
            CertApplications.EditDepartureAndArrival();
        }

        [When(@"I click edit on application departure and arrival")]
        public void WhenIClickEditOnApplicationDepartureAndArrival()
        {
            CertApplications.ClickOnDepartureAndArrivalLink();
        }

        [When(@"I continue with '([^']*)' and '([^']*)'")]
        public void WhenIContinueWithAnd(string departureDate, string arrivalDate)
        {
            CertApplications.ContinueWithNoDepartureAndArrivalDate(departureDate,arrivalDate);
        }

        [When(@"I verify Departure and Arrival '([^']*)'")]
        public void WhenIVerifyDepartureAndArrival(string validationInformation)
        {
            Assert.True(CertApplications.ValidationMsgDepartureAndArrival(validationInformation), "Departure and Arrival date validation information not as expected");
        }

        [Then(@"I verify changed Depature and Arrival date")]
        public void ThenIVerifyChangedDepatureAndArrivalDate()
        {
            Assert.True(CertApplications.VerifyChangedDepatureAndArrivalDate(), "Departure and Arrival not matching");
        }

        [When(@"I change  means of transport")]
        public void WhenIChangeMeansOfTransport()
        {
            CertApplications.EditMeansofTranport();
        }
        
        [Given(@"I remove place of origin details")]
        [When(@"I remove place of origin details")]
        [Then(@"I remove place of origin details")]

        public void GivenIRemovePlaceOfOriginDetails()
        {
            CertApplications.EditPlaceOfOrigin();
            CertApplications.RemoveExistingRecord(); // remove place of dispatch
            CertApplications.RemoveExistingRecord(); // remove place of loading
        }

        [Given(@"I remove place of loaing details")]
        [When(@"I remove place of loaing details")]
        [Then(@"I remove place of loaing details")]
        public void GivenIRemovePlaceOfLoaingDetails()
        {
            CertApplications.EditPlaceOfOrigin();
            CertApplications.RemoveExistingRecord(); // remove place of dispatch
            CertApplications.RemoveExistingRecord(); // remove place of loading
        }

        [Given(@"I remove place of destination")]
        [When(@"I remove place of destination")]
        [Then(@"I remove place of destination")]

        public void GivenIRemovePlaceOfDestination()
        {
            CertApplications.EditPlaceOfDestination();
            CertApplications.RemoveExistingRecord();
        }


        [When(@"I click edit on application means of transport")]
        public void WhenIClickEditOnApplicationMeansOfTransport()
        {
            CertApplications.ClickOnMeansOfTranportLink();
        }

        [Then(@"I verify changed means of transport")]
        public void ThenIVerifyChangedMeansOfTransport()
        {
            Assert.True(CertApplications.VerifyChangedMeansOfTransport(), "Means of transport not matching");
        }

        [Then(@"I submit Border Control Post without answering bcp value")]
        public void ThenISubmitBorderControlPostWithoutAnsweringBcpValue()
        {
            CertApplications.EditBorderControlPost();
        }

        [Then(@"I verify error message for Border Control Post '([^']*)'")]
        public void ThenIVerifyErrorMessageForBorderControlPost(string bcpErrorMessage)
        {
            StringAssert.Contains(bcpErrorMessage, CertApplications.VerifyChangedBorderControlPost(), "Select a country from the provided list message  is not appearing under the Border Control post section");
        }


        [Then(@"I verify error message '([^']*)'")]
        public void ThenIVerifyErrorMessage(string errorMessage)
        {
            StringAssert.Contains(errorMessage, CertApplications.VerifySkipErrorMessage(), "Expected error message NOT found");
        }

        [Then(@"click on show button")]
        public void ThenClickOnShowButton()
        {
            Applications.ClickShowLink();
        }

        [Then(@"assign another certifier '([^']*)'")]
        public void ThenAssignAnotherCertifier(string certifierName)
        {
            CertApplications.AssignCertifier(certifierName);
        }

        [Then(@"verify assigned certifier '([^']*)'")]
        public void ThenVerifyAssignedCertifier(string certifierName)
        {
            CertApplications.VerifyAssignedCerfier(certifierName);
        }

        [Then(@"click in to the created application link")]
        public void ThenClickInToTheCreatedApplicationLink()
        {
            CertApplications.ClickFirstApplication();
        }

        [Then(@"click on back button")]
        public void ThenClickOnBackButton()
        {
            CertifierView.ClickBackButtonOnApplicationSummary();
        }

        [Then(@"title is displayed")]
        public void ThenTitleIsDisplayed()
        {
            Assert.True(CertApplications.IsTitleDisplayed(), "Certifier Page Title is not displayed");
        }

        [Then(@"search box is displayed")]
        public void ThenSearchBoxIsDisplayed()
        {
            Assert.True(CertApplications.IsSearchBoxDisplayed, "Search Box is not displayed");
        }

        [Then(@"filters are displayed")]
        public void ThenFiltersAreDisplayed()
        {
            Assert.True(CertApplications.IsCountrylistDisplayed(), "Country Filter is not displayed");
            Assert.True(CertApplications.IsDateListDisplayed(), "Date Filter is not displayed");
            Assert.True(CertApplications.IsStatusListDisplayed(), "Status Filter is not displayed");
            Assert.True(CertApplications.IsClearFiltersLinkDisplayed(), "Clear Filter is not displayed");
        }

        [Then(@"application record table is displayed")]
        public void ThenApplicationRecordTableIsDisplayed()
        {
            Assert.True(CertApplications.IsApplicationsTableDisplayed(), "Applications Table is not displayed");
            CertApplications.ClickShowLink();
            Assert.True(CertApplications.IsApplicationLinkDisplayed(), "View Application Link is not displayed");
        }

        [Then(@"page numbers are displayed")]
        public void ThenPageNumbersAreDisplayed()
        {
            Assert.True(CertApplications.IsPageNumberDisplayed(), "Page Numbers are not displayed");
            Assert.True(CertApplications.IsCurrentPageNumberDisplayed(), "Current Page Number is not displayed");
        }

        [Then(@"assign application")]
        public void ThenAssignApplication()
        {
            CertApplications.AssignApplicationToCertifier();
            Assert.True(CertApplications.IsApplicationAssigned(), "Application has not been assigned");
        }

        [Then(@"cancel application")]
        public void ThenCancelApplication()
        {
            CertApplications.CancelApplication();
            Assert.True(CertApplications.IsApplicationCancelled(), "Application has not been cancelled");
        }
           
        [When(@"edit means of transport and not selecting with '([^']*)','([^']*)'")]
        public void WhenEditMeansOfTransportAndNotSelectingWith(string transCondition, string meansOfTrans)
        {
           CertApplications.NotEnteredMeansOfTransport(transCondition, meansOfTrans);      
        }

        [Then(@"verify all validation Information for a means of transport '([^']*)','([^']*)' without its required details '([^']*)'")]
        public void ThenVerifyAllValidationInformationForAMeansOfTransportWithoutItsRequiredDetails(string transCondition, string meansOfTrans, string requiredDetails)
        {
            Assert.True(CertApplications.ValidateErrMsgTransport(transCondition,meansOfTrans, requiredDetails), "validation messages are not as expected");
        }

        [Then(@"verify Validation Information for not selecting Means of transports condition")]
        public void ThenVerifyValidationInformationForNotSelectingMeansOfTransportsCondition()
        {
            Assert.True(CertApplications.VerifyTransConditionValidation(), "Validation information not match as expected");
        }
    
        [When(@"I click on application commodity details")]
        [When(@"I click Add new link in the commodity section to add a new commodity record")]
        public void WhenIClickOnApplicationCommodityDetails()
        {
            CertApplications.ClickOnCommodityDetails();
        }

        [Then(@"verify skip functionality no longer on certifier page")]
        public void ThenVerifySkipFunctionalityNoLongerOnCertifierPage()
        {
            Assert.False(CertApplications.IsSkipFunctionlityExist(), "Skip checkbox is visible");
        }

        [Then(@"I click edit on application place of origin")]
        public void ThenIClickEditOnApplicationPlaceOfOrigin()
        {
            CertApplications.EditPlaceOfOrigin();
        }


        [Then(@"Change place of origin with '([^']*)' and '([^']*)'")]
        public void ThenChangePlaceOfOriginWithAnd(string placeOfDispatch, string placeOfLoading)
        {
            CertApplications.ChangePlaceOfOrigin(placeOfDispatch, placeOfLoading);
        }

        [Then(@"I verify the place of origin changed successfully")]
        public void ThenIVerifyThePlaceOfOriginChangedSuccessfully()
        {
            Assert.True(CertApplications.VerifyChangedPlaceOfDispatch(), "Place of dispatch has not changed as expected");
            Assert.True(CertApplications.VerifyChangedPlaceOfLoading(), "Place of loading has not changed as expected");
        }

        [Then(@"change the broder control post with '([^']*)' and '([^']*)'")]
        public void WhenChangeTheBroderControlPostWithAnd(string countryId, string borderName)
        {
            CertApplications.ChangeBorderControPostl(countryId, borderName);
        }

        [Then(@"verify change has added successfully")]
        public void ThenVerifyChangeHasAddedSuccessfully()
        {
            Assert.True(CertApplications.VerifyChangeOfBorderControPostl(), "Border post control has not made successfully");
        }

        [When(@"I click Save and continue button without adding mandatory fields")]
        public void WhenIClickSaveAndContinueButtonWithoutAddingMandatoryFields()
        {
            CertApplications.ClickSaveAndContinue();
        }

        [Then(@"I can see validation messages displayed for all the mandatory fields in the commodity identification data modal")]
        public void ThenICanSeeValidationMessagesDisplayedForAllTheMandatoryFieldsInTheCommodityIdentificationDataModal()
        {
            Assert.True(CertApplications.ValidateIdenDataModalErrorMessages(), "Validation message not displayed when mandatory fields are not entered on commodity identification data modal");
        }

        [When(@"I click on Transport Tab")]
        public void WhenIClickOnTransportTab()
        {
            CertApplications.ClickOnTransportTab();
        }

        [When(@"I click to collapse the Departuer and arrival Details Panel")]
        public void WhenIClickToCollapseTheDepartuerAndArrivalDetailsPanel()
        {
            CertApplications.ClickToCollapseDepartureAndArrivalPanelDetails();
        }


        [When(@"I click to expand the Means of Transport")]
        public void WhenIClickToExpandTheMeansOfTransport()
        {
            CertApplications.ClickOnMeansOfTranportLink();
        }
    }
}
