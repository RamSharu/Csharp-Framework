using BoDi;
using Defra.UI.Tests.Pages.ApplicationComplete;
using Defra.UI.Tests.Pages.Exporter.AccompanyingDocs;
using Defra.UI.Tests.Pages.Exporter.BorderControl;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using Defra.UI.Tests.Pages.Exporter.Consignee;
using Defra.UI.Tests.Pages.Exporter.Consignor;
using Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo;
using Defra.UI.Tests.Pages.Exporter.DepartureAndArrival;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using Defra.UI.Tests.Pages.Exporter.GrossWeight;
using Defra.UI.Tests.Pages.Exporter.MeansOfTransport;
using Defra.UI.Tests.Pages.Exporter.PlaceDestination;
using Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin;
using Defra.UI.Tests.Pages.Exporter.PurposeOfExport;
using Defra.UI.Tests.Pages.Exporter.RegionOfCertification;
using Defra.UI.Tests.Pages.Exporter.ResponsibleForLoad;
using Defra.UI.Tests.Pages.Exporter.ReviewAndCheck;
using Defra.UI.Tests.Pages.Exporter.SelectCertifier;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CheckYourAnswersSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public CheckYourAnswersSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private ICommodity Commodity => _objectContainer.IsRegistered<ICommodity>() ? _objectContainer.Resolve<ICommodity>() : null;
        private IGrossWeight GrossWeight => _objectContainer.IsRegistered<IGrossWeight>() ? _objectContainer.Resolve<IGrossWeight>() : null;
        private IGoodsCertifiedAs GoodsCertifiedAs => _objectContainer.IsRegistered<IGoodsCertifiedAs>() ? _objectContainer.Resolve<IGoodsCertifiedAs>() : null;
        private IContainerOrSealNo ContainerOrSealNo => _objectContainer.IsRegistered<IContainerOrSealNo>() ? _objectContainer.Resolve<IContainerOrSealNo>() : null;
        private IPurposeOfExport PurposeOfExport => _objectContainer.IsRegistered<IPurposeOfExport>() ? _objectContainer.Resolve<IPurposeOfExport>() : null;
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;
        private IAccompanyingDocs AccompanyingDocs => _objectContainer.IsRegistered<IAccompanyingDocs>() ? _objectContainer.Resolve<IAccompanyingDocs>() : null;
        private IConsignorPage Consignor => _objectContainer.IsRegistered<IConsignorPage>() ? _objectContainer.Resolve<IConsignorPage>() : null;
        private IConsigneePage Consignee => _objectContainer.IsRegistered<IConsigneePage>() ? _objectContainer.Resolve<IConsigneePage>() : null;
        private ISelectCertifier Certifier => _objectContainer.IsRegistered<ISelectCertifier>() ? _objectContainer.Resolve<ISelectCertifier>() : null;
        private IRegionOfCertification RegionOfCertification => _objectContainer.IsRegistered<IRegionOfCertification>() ? _objectContainer.Resolve<IRegionOfCertification>() : null;
        private IResponsibleForLoad ResponsibleForLoad => _objectContainer.IsRegistered<IResponsibleForLoad>() ? _objectContainer.Resolve<IResponsibleForLoad>() : null;
        private IDepartureAndArrival DepartureArrival => _objectContainer.IsRegistered<IDepartureAndArrival>() ? _objectContainer.Resolve<IDepartureAndArrival>() : null;
        private IPlaceOfOrigin PlaceOfOrigin => _objectContainer.IsRegistered<IPlaceOfOrigin>() ? _objectContainer.Resolve<IPlaceOfOrigin>() : null;
        private IBorderControl BorderControl => _objectContainer.IsRegistered<IBorderControl>() ? _objectContainer.Resolve<IBorderControl>() : null;
        private ITransport Transport => _objectContainer.IsRegistered<ITransport>() ? _objectContainer.Resolve<ITransport>() : null;
        private IPlaceDestination PlaceDestination => _objectContainer.IsRegistered<IPlaceDestination>() ? _objectContainer.Resolve<IPlaceDestination>() : null;
        private ICheckYourAnswers CheckYourAnswers => _objectContainer.IsRegistered<ICheckYourAnswers>() ? _objectContainer.Resolve<ICheckYourAnswers>() : null;
        private IReviewAndCheck ReviewAndCheck => _objectContainer.IsRegistered<IReviewAndCheck>() ? _objectContainer.Resolve<IReviewAndCheck>() : null;
        private IApplicationComplete ApplicationComplete => _objectContainer.IsRegistered<IApplicationComplete>() ? _objectContainer.Resolve<IApplicationComplete>() : null;

        [Given(@"I am taken to Check your answers page")]
        [When(@"I am taken to Check your answers page")]
        [Then(@"I am taken to Check your answers page")]
        public void ThenIAmTakenToCheckYourAnswersPage()
        {
            Assert.IsTrue(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed");
        }

        [Then(@"I can see the list of tasks that need to be completed followed by the full list of tasks for the application")]
        public void ThenICanSeeTheListOfTasksThatNeedToBeCompletedFollowedByTheFullListOfTasksForTheApplication()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(CheckYourAnswers.CheckIfRequiredFieldsAreDisplayed(), "List of required fields should be displayed at the top of check your answers page");
                Assert.IsTrue(CheckYourAnswers.CheckIfListOfTasksForTheAppIsDisplayed(), "Summary of all the tasks should be displayed on check your answers page");
            });
        }

        [Then(@"I review the commodities section by clicking on the change commodities link")]
        public void ThenIReviewTheCommoditiesSectionByClickingOnTheChangeCommoditiesLink()
        {
            CheckYourAnswers.ClickChangeCommodity();
            Assert.IsTrue(Commodity.IsCommoditiesPage, "Commodities page is not displayed for editing");
            Commodity.ClickNoRadioForAddMoreCommodity();
        }

        [Then(@"I update the gross weight section with gross weight amount '([^']*)' and gross weight unit '([^']*)'")]
        public void ThenICanUpdateTheGrossWeightSectionWithGrossWeightAmountAndGrossWeightUnit(string grossWeight, string grossWeightUnit)
        {
            GrossWeight.AddGrossWeightAmount(grossWeight, grossWeightUnit);
        }

        [Then(@"I update the goods certified as section by selecting '([^']*)' radio option")]
        public void ThenIUpdateTheGoodsCertifiedAsSectionBySelectingRadioOption(string radioOptionName)
        {
            Assert.IsTrue(GoodsCertifiedAs.IsGoodsCertifiedPage, "Goods certified as page is not displayed for editing");
            GoodsCertifiedAs.SelectGoodsCertifiedAsRadio(radioOptionName);
        }

        [Then(@"I update the purpose of export section by selecting '([^']*)' radio option")]
        public void ThenIUpdateThePurposeOfExportSectionBySelectingRadioOption(string purposeOfExport)
        {
            PurposeOfExport.ClickPurposeOfExportButton(purposeOfExport);
        }

        [Then(@"I update the Container number/seal number section with container number '([^']*)' and seal number '([^']*)'")]
        public void ThenIUpdateTheContainerNumberSealNumberSectionWithContainerNumberAndSealNumber(string containerNum, string sealNum)
        {
            ContainerOrSealNo.ClearContainerSealNumber();
            ContainerOrSealNo.AddContainerSealNumber(containerNum, sealNum);
        }

        [Then(@"I can update document type '([^']*)' reference '([^']*)' and attach documents in the documents section")]
        public void ThenICanUpdateDocumentTypeReferenceAndAttachDocumentsInTheDocumentsSection(string docType, string docRef)
        {
            Assert.IsTrue(AccompanyingDocs.IsAccompanyingDocsPage(), "Accompanying documents page is not displayed for editing");
            AccompanyingDocs.CheckIfDocAlreadyAdded();
            Assert.IsTrue(AccompanyingDocs.AddDocument(docType, docRef), "Accompanying document details are not updated successfully");
        }

        [Then(@"I update the consignor or exporter section with the consignor '([^']*)' and country '([^']*)'")]
        public void ThenIUpdateTheConsignorOrExporterSectionWithTheConsignorAndCountry(string consignorName)
        {
            Assert.IsTrue(Consignor.IsConsignorOrExporterPage, "Consignor page is not displayed for editing");
            Consignor.AddConsignorData(consignorName);
        }

        [Then(@"I update the consignor or exporter section with the consignor '([^']*)'")]
        public void ThenIUpdateTheConsignorOrExporterSectionWithTheConsignor(string consignorName)
        {
            Assert.IsTrue(Consignor.IsConsignorOrExporterPage, "Consignor page is not displayed for editing");
            Consignor.FindConsignorData(consignorName);
        }


        [Then(@"I update the consignee or importer section with the consignee '([^']*)' and country '([^']*)'")]
        public void ThenIUpdateTheConsigneeOrImporterSectionWithTheConsigneeAndCountry(string consigneeName, string country)
        {
            Assert.IsTrue(Consignee.IsConsigneeOrImporterPage, "Consignee page is not displayed for editing");
            Consignee.ClickRemoveLink();
            Consignee.AddConsignee(consigneeName, country);
        }

        [Then(@"I update the certifier section with the certifier '([^']*)'")]
        public void ThenIUpdateTheCertifierSectionWithTheCertifier(string certifierName)
        {
            Assert.IsTrue(Certifier.IsSelectCertifierPage, "Certifier page is not displayed for editing");
            Certifier.ClickRemoveLink();
            Certifier.ClickSelectCertifier(certifierName);
        }

        [Then(@"I update the region of certification section by selecting '([^']*)'")]
        public void ThenIUpdateTheRegionOfCertificationSectionBySelecting(string region)
        {
            RegionOfCertification.RegionOfCertificationtButton(region);
        }

        [Then(@"I update the responsible for load section with the inputs '([^']*)' and country '([^']*)'")]
        public void ThenIUpdateTheResponsibleForLoadSectionWithTheInputsAndCountry(string responsibleForLoadCountry, string responsibleForLoadOperator)
        {
            Assert.True(ResponsibleForLoad.IsResponsibleForLoadPage, "Responsible for load page is not displayed for editing");
            ResponsibleForLoad.ClickRemoveLink();
            ResponsibleForLoad.CompleteResponsibleForLoad(responsibleForLoadCountry, responsibleForLoadOperator);
        }

        [Then(@"I update the departure and arrival section")]
        public void ThenIUpdateTheDepartureAndArrivalSection()
        {
            Assert.True(DepartureArrival.IsDepartureArrivalPage, "Departure and arrival page is not displayed for editing");
            DepartureArrival.EditDepartureAndArrivalDates();
            DepartureArrival.ClickSaveAndContinue();
        }

        [Then(@"I update the place of origin section with country of origin '([^']*)' region of origin '([^']*)'")]
        public void ThenIUpdateThePlaceOfOriginSectionWithCountryOfOriginRegionOfOrigin(string countryOfOrigin, string regionOfOrigin)
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page is not displayed for editing");
            PlaceOfOrigin.EditRegionOfOrigin(countryOfOrigin, regionOfOrigin);
        }

        [Then(@"I update the transport conditon")]
        public void ThenIUpdateTheTransportConditon()
        {
            Assert.True(Transport.IsMeansOfTransportPage, "Place of origin page is not displayed for editing");
            Transport.EditTransportCondition();
        }

        [Then(@"I remove and add place of destination with country '([^']*)' and place '([^']*)'")]
        public void ThenIRemoveAndAddPlaceOfDestinationWithCountryAndPlace(string placeOfDestCountry, string placeOfDestination)
        {
            Assert.True(PlaceDestination.IsPlaceOfDestinationPage, "Place of destination page is not displayed for editing");
            PlaceDestination.ClickRemoveLink();
            PlaceDestination.AddPlaceOfDestination(placeOfDestCountry, placeOfDestination);
        }

        [Then(@"I proceed to submit the updated application")]
        public void ThenIProceedToSubmitTheUpdatedApplication()
        {
            CheckYourAnswers.ClickCheckAndContinueButton();

            Assert.IsTrue(ReviewAndCheck.IsReviewAndCheckPage, "Exporter declaration page is not displayed");
            ReviewAndCheck.ClickConfirmCheckBox();
            ReviewAndCheck.ClickConfirmAndSubmitButton();

            Assert.IsTrue(ApplicationComplete.IsApplicationCompletePage, "Application complete page is not displayed");
            ApplicationComplete.ClickFinishButton();
        }

        [When(@"I click on change link next to '([^']*)' on Check your answers page")]
        [Then(@"I am on check your answers page to update '([^']*)' section")]
        public void ThenIClickOnTheReviewAndSubmitApplicationHyperlinkToUpdateSection(string section)
        {
            Assert.IsTrue(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed");

            switch (section)
            {
                case "Commodities":
                    CheckYourAnswers.ClickChangeCommodity();
                    break;
                case "Gross weight":
                    CheckYourAnswers.ClickChangeGrossWeight();
                    break;
                case "Goods certified as":
                    CheckYourAnswers.ClickChangeGoodsCertifiedAs();
                    break;
                case "Container number/seal number":
                    CheckYourAnswers.ClickChangeContainerNoSealNo();
                    break;
                case "Purpose of export":
                    CheckYourAnswers.ClickChangePurposeOfExport();
                    break;
                case "Accompanying documents":
                    CheckYourAnswers.ClickChangeAccompanyingDocs();
                    break;
                case "Consignor or Exporter":
                    CheckYourAnswers.ClickConsignorOrExporter();
                    break;
                case "Consignee or Importer":
                    CheckYourAnswers.ClickConsigneeOrImporter();
                    break;
                case "Certifier":
                    CheckYourAnswers.ClickChangeCertifier();
                    break;
                case "Region of certification":
                    CheckYourAnswers.ClickChangeRegionOfCertification();
                    break;
                case "Responsible for load":
                    CheckYourAnswers.ClickChangeResponsibleForLoad();
                    break;
                case "Departure and arrival":
                    CheckYourAnswers.ClickChangeDepartureAndArrival();
                    break;
                case "Place of origin":
                case "Country of origin":
                case "Region of origin":
                    CheckYourAnswers.ClickChangeCountryOfOrigin();
                    break;
                case "Place of dispatch":
                    CheckYourAnswers.ClickChangePlaceOfDispatch();
                    break;
                case "Place of loading":
                    CheckYourAnswers.ClickChangePlaceOfLoading();
                    break;
                case "EntryBCP":
                    CheckYourAnswers.ClickChangeEntryBCP();
                    break;
                case "Means of transport":
                    CheckYourAnswers.ClickChangeMeansOfTransport();
                    break;
                case "Place of destination":
                    CheckYourAnswers.ClickChangePlaceOfDestination();
                    break;
                default:
                    break;
            }
        }

        [Then(@"I am able to review '([^']*)'")]
        public void ThenIAmAbleToReview(string section)
        {
            switch (section)
            {
                case "Gross weight":
                    CheckYourAnswers.ClickChangeGrossWeight();
                    break;
                case "Commodities":
                    CheckYourAnswers.ClickChangeCommodity();
                    break;
                default:
                    break;
            }
        }

        [Then(@"I can see the answers I provided for place of origin '([^']*)', place of dispatch '([^']*)' and place of loading '([^']*)' \(and optional region if provided\) '([^']*)'")]
        public void ThenICanSeeTheAnswersIProvidedForPlaceOfOriginPlaceOfDispatchAndPlaceOfLoadingAndOptionalRegionIfProvided(string country, string dispatch, string loading, string region)
        {
            Assert.True(CheckYourAnswers.CheckPlaceOfOrigin("country", country), "Country of origin country is incorrect");
            Assert.True(CheckYourAnswers.CheckPlaceOfOrigin("region", region), "Region of origin incorrect"); // TODO: add back in once skip checkbox problem resolved
            Assert.True(CheckYourAnswers.CheckPlaceOfOrigin("loading", loading), "Place of loading is incorrect");
            Assert.True(CheckYourAnswers.CheckPlaceOfOrigin("dispatch", dispatch), "Place of dispatch is incorrect");
        }

        [Then(@"Place of origin details are same on check your answers page and place of origin page")]
        public void ThenPlaceOfOriginDetailsAreSameOnCheckYourAnswersPageAndPlaceOfOriginPage()
        {
            PlaceOfOrigin.SaveContinue();
            Assert.IsTrue(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed after getting the data from Place of origin page");
            Assert.That(CheckYourAnswers.GetPlaceOfDispatch().Contains(_scenarioContext.Get<string>("dispatchOperatorName")), "Place of dispatch is not same on place of origin and check your answers page");
            Assert.That(CheckYourAnswers.GetPlaceOfLoading().Contains(_scenarioContext.Get<string>("loadingOperatorName")), "Place of loading is not same on place of origin and check your answers page");
        }

        [Then(@"I can see the features that skipped labelled as '([^']*)'")]
        public void ThenICanSeeTheFeaturesThatSkippedLabelledAs(string notEntered)
        {
            Assert.True(CheckYourAnswers.IsSkippedFeatureShowNotEntry(notEntered), "Skipped feature shows label as not entered");
        }

        [Then(@"I can see the number of records in commodities section")]
        public void ThenICanSeeTheNumberOfRecordsInCommoditiesSection()
        {
            Assert.True(CheckYourAnswers.NumberOfCommoditiesRecords(), "The number of records in commodities section");
        }
    }
}
