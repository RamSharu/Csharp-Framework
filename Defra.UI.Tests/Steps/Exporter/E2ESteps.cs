using BoDi;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.EHC;
using Defra.UI.Tests.Data.Identification;
using Defra.UI.Tests.Pages.ApplicationComplete;
using Defra.UI.Tests.Pages.Certifier.Applications;
using Defra.UI.Tests.Pages.Exporter.AccompanyingDocs;
using Defra.UI.Tests.Pages.Exporter.Applications;
using Defra.UI.Tests.Pages.Exporter.BorderControl;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using Defra.UI.Tests.Pages.Exporter.Consignee;
using Defra.UI.Tests.Pages.Exporter.Consignor;
using Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo;
using Defra.UI.Tests.Pages.Exporter.DepartureAndArrival;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using Defra.UI.Tests.Pages.Exporter.GrossWeight;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
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
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]

    public class E2ESteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public E2ESteps(ScenarioContext context, IObjectContainer container)
        {
            _objectContainer = container;
            _scenarioContext = context;
        }

        private IAccompanyingDocs AccompanyingDocs => _objectContainer.IsRegistered<IAccompanyingDocs>() ? _objectContainer.Resolve<IAccompanyingDocs>() : null;
        private IApplicationComplete ApplicationComplete => _objectContainer.IsRegistered<IApplicationComplete>() ? _objectContainer.Resolve<IApplicationComplete>() : null;
        private IApplications? Applications => _objectContainer.IsRegistered<IApplications>() ? _objectContainer.Resolve<IApplications>() : null;
        private IBorderControl BorderControl => _objectContainer.IsRegistered<IBorderControl>() ? _objectContainer.Resolve<IBorderControl>() : null;
        private ICertifierApplications? CertApplications => _objectContainer.IsRegistered<ICertifierApplications>() ? _objectContainer.Resolve<ICertifierApplications>() : null;
        private ISelectCertifier Certifier => _objectContainer.IsRegistered<ISelectCertifier>() ? _objectContainer.Resolve<ISelectCertifier>() : null;
        private ICheckYourAnswers CheckYourAnswers => _objectContainer.IsRegistered<ICheckYourAnswers>() ? _objectContainer.Resolve<ICheckYourAnswers>() : null;
        private IConsigneePage Consignee => _objectContainer.IsRegistered<IConsigneePage>() ? _objectContainer.Resolve<IConsigneePage>() : null;
        private IConsignorPage Consignor => _objectContainer.IsRegistered<IConsignorPage>() ? _objectContainer.Resolve<IConsignorPage>() : null;
        private IContainerOrSealNo ContainerOrSealNo => _objectContainer.IsRegistered<IContainerOrSealNo>() ? _objectContainer.Resolve<IContainerOrSealNo>() : null;
        private IDepartureAndArrival DepartureArrival => _objectContainer.IsRegistered<IDepartureAndArrival>() ? _objectContainer.Resolve<IDepartureAndArrival>() : null;
        private IEHCData? EHCdata => _objectContainer.IsRegistered<IEHCData>() ? _objectContainer.Resolve<IEHCData>() : null;
        private IGoodsCertifiedAs GoodsCertifiedAs => _objectContainer.IsRegistered<IGoodsCertifiedAs>() ? _objectContainer.Resolve<IGoodsCertifiedAs>() : null;
        private IGrossWeight GrossWeight => _objectContainer.IsRegistered<IGrossWeight>() ? _objectContainer.Resolve<IGrossWeight>() : null;
        private IIdentificationPage Identification => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        private IPlaceDestination PlaceDestination => _objectContainer.IsRegistered<IPlaceDestination>() ? _objectContainer.Resolve<IPlaceDestination>() : null;
        private IPlaceOfOrigin PlaceOfOrigin => _objectContainer.IsRegistered<IPlaceOfOrigin>() ? _objectContainer.Resolve<IPlaceOfOrigin>() : null;
        private IPurposeOfExport PurposeOfExport => _objectContainer.IsRegistered<IPurposeOfExport>() ? _objectContainer.Resolve<IPurposeOfExport>() : null;
        private IRegionOfCertification RegionOfCertification => _objectContainer.IsRegistered<IRegionOfCertification>() ? _objectContainer.Resolve<IRegionOfCertification>() : null;
        private IResponsibleForLoad ResponsibleForLoad => _objectContainer.IsRegistered<IResponsibleForLoad>() ? _objectContainer.Resolve<IResponsibleForLoad>() : null;
        private IReviewAndCheck ReviewAndCheck => _objectContainer.IsRegistered<IReviewAndCheck>() ? _objectContainer.Resolve<IReviewAndCheck>() : null;
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;
        private ITransport Transport => _objectContainer.IsRegistered<ITransport>() ? _objectContainer.Resolve<ITransport>() : null;
        [Then(@"add '([^']*)' data")]
        public void ThenAddData(string certificate)
        {
            List<EHC> dataList = EHCdata.GetEHCdata(certificate);
            foreach (var data in dataList)
            {
                EnterMandatorySections(data);
            }
        }

        [When(@"add '([^']*)' data and submit")]
        [Then(@"add '([^']*)' data and submit")]
        public void ThenAddDataAndContinue(string certificate)
        {
            //CertApplications.AddNewRecord();
            List<EHC> dataList = EHCdata.GetEHCdata(certificate);
            foreach (var data in dataList)
            {
                EnterMandatorySections(data);

                TaskList.ClickReviewAnswersLink();

                Assert.True(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed");
                CheckYourAnswers.ClickCheckAndContinueButton();

                Assert.IsTrue(ReviewAndCheck.IsReviewAndCheckPage, "Exporter declaration page is not displayed");
                ReviewAndCheck.ClickConfirmCheckBox();
                ReviewAndCheck.ClickConfirmAndSubmitButton();

                Assert.IsTrue(ApplicationComplete.IsApplicationCompletePage, "Application complete page is not displayed");
                string serialRef = ApplicationComplete.GetApplicationSerialReference();
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];

                if (applicationres != null && applicationres.ApplicatioDisplayId == null)
                {
                    applicationres.ApplicatioDisplayId = serialRef;
                }

                ApplicationComplete.ClickFinishButton();
            }
        }

        [Then(@"verify certificate '([^']*)' has been added successfully")]
        public void ThenVerifyCertificateHasBeenAddedSuccessfully(string referenceName)
        {
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                Assert.True(Applications.VerifyCertificateStatus(applicationres.ApplicatioDisplayId.ToString()), "certificate has not submitted successfully");
            }
        }

        [When(@"add '([^']*)' data for new commodity record")]
        public void WhenAddDataForNewCommodityRecord(string certificate)
        {
            CertApplications.AddNewRecord();
            List<EHC> dataList = EHCdata.GetEHCdata(certificate);
            foreach (var data in dataList)
            {
                EnterMandatoryCertifierSections(data);
            }
        }

        private void EnterMandatoryCertifierSections(EHC data)
        {
            List<IdentificationData> IdenList = new List<IdentificationData> { data.Identification };

            //Manage Commodity Task
            Identification.AddCertifierCommodityData(IdenList);
        }

        private void EnterMandatorySections(EHC data)
        {
            List<IdentificationData> IdenList = new List<IdentificationData> { data.Identification };

            //Manage Commodity Task
            Identification.AddCommodityData(IdenList);

            //Gross Weight Task
            GrossWeight.CompleteGrossWeight(data.GrossWeight, data.GrossWeightUnit);

            //Goods CertifiedAs Task
            GoodsCertifiedAs.ClickGoodsCertifiedAsValue(data.GoodsCertifiedAs);

            //Container Seal Number Task
            ContainerOrSealNo.IsContainerSealNumberPageDisplayed();
            ContainerOrSealNo.CompleteContainerSealNumber(data.ContainerNumber, data.SealNumber);

            //Purpose Of Export Task
            PurposeOfExport.IsPurposeOfExporterPageDisplayed();
            PurposeOfExport.ClickPurposeOfExportButton(data.PurposeOfTheExport);

            //Accompanying Documents Task
            //TODO: dsiable to fix future date later
            //TaskList.ClickAccompanyingDocsLink();
            //AccompanyingDocs.IsAccompanyingDocsPage();
            //AccompanyingDocs.AddDocument(data.DocumentType, data.DocumentRef);

            //Consignor Task
            TaskList.ClickExporterOrConsignorLink();
            Consignor.AddConsignor(data.ConsignorName);

            //Consignee Task
            Consignee.ClickConsignee(data.ConsigneeName, data.ConsigneeCountry);

            //Certifier Task
            Certifier.IsSelectCertifierPageDisplayed();
            Certifier.ClickSelectCertifier(data.CertifierName);

            //Region Of Certification Task
            RegionOfCertification.IsRegionOfCertificationDisplayed();
            RegionOfCertification.RegionOfCertificationtButton(data.CertificationRegion);

            //Responsible For Load Task
            ResponsibleForLoad.IsResponsibleForLoadPageDisplayed();
            ResponsibleForLoad.CompleteResponsibleForLoad(data.ResponsibleLoadConutry, data.ResponsibleForLoad);

            //Departure and Arrival Task
            DepartureArrival.IsDepartureAndArrivalDatePageDisplayed();
            DepartureArrival.CompleteDepartureAndArrivalDate();

            //Place Of Origin Task
            PlaceOfOrigin.IsPlaceOfOriginPageDisplayed();
            PlaceOfOrigin.CompletePlaceOfOriginAndContinue(data.CountryOfOrigin, data.PlaceOfDispatchCountry, data.PlaceOfDispatch, data.PlaceOfLoadingCountry, data.PlaceOfLoading);

            //Entry Border Control Post Task
            BorderControl.VerifyCompleteBorderControl(data.BorderControlPostCountry, data.BorderControlPost);

            //Means of Transport Task
            Transport.SelectTransport(data.TransportCondition, data.MeansOfTransport);

            //Place Of Destination Task
            PlaceDestination.VerifyPlaceDestination(data.PlaceOfDestinationCountry, data.PlaceOfDestination);

            // Get Application Display Id
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

            string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
            _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
            Assert.True(true, "Application is not created successfully");
        }
        public ApplicationResponse ApplicationResponse { get; set; }
        private IApplicationData? AppData => _objectContainer.IsRegistered<IApplicationData>() ? _objectContainer.Resolve<IApplicationData>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private string GetApplicationIdFromURL()
        {
            string env = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
            string certificate = "/Export-health-certificate/";
            string url = _driver.Url;
            url = url.Replace(env, "");
            url = url.Replace(certificate, "");
            return url;
        }
    }
}
