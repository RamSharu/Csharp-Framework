using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Tools;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Data.EHC;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using Defra.UI.Tests.Pages.Exporter.ReviewAndCheck;
using Defra.UI.Tests.Pages.ApplicationComplete;
using Defra.UI.Tests.Pages.Certifier.Applications;
using Defra.UI.Tests.Pages.Exporter.Consignee;
using Defra.UI.Tests.Pages.Exporter.AccompanyingDocs;
using Defra.UI.Tests.Pages.Exporter.Applications;
using Defra.UI.Tests.Pages.Exporter.BorderControl;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using Defra.UI.Tests.Pages.Exporter.Consignor;
using Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo;
using Defra.UI.Tests.Pages.Exporter.CopyApplication;
using Defra.UI.Tests.Pages.Exporter.WhichSectionsToCopy;
using Defra.UI.Tests.Pages.Exporter.DepartureAndArrival;
using Defra.UI.Tests.Pages.Exporter.ExportInfo;
using Defra.UI.Tests.Pages.Exporter.GrossWeight;
using Defra.UI.Tests.Pages.Exporter.ResponsibleForLoad;
using Defra.UI.Tests.Pages.Exporter.PlaceDestination;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using Defra.UI.Tests.Pages.Exporter.MeansOfTransport;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Pages.Exporter.SelectCertifier;
using Defra.UI.Tests.Pages.Exporter.PurposeOfExport;
using Defra.UI.Tests.Pages.Exporter.RegionOfCertification;
using Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin;
using Defra.UI.Tests.Pages.Common.Signin;
using Defra.UI.Tests.Pages.Exporter.ApplicationReference;
using Defra.UI.Tests.Pages.Certifier.CertifyEHC;
using Defra.UI.Tests.Pages.Certifier.CertIdentification;
using Defra.UI.Tests.Pages.Certifier.ICertIdentification;
using Defra.UI.Tests.Pages.Exporter.CommoditySummary;
using Defra.UI.Tests.Pages.SelectExporterOrConsignorActivity;
using Defra.UI.Tests.Pages.FindAnExporterOrConsignor;
using Defra.UI.Tests.Pages.Exporter.CertificateLookupPage;
using Defra.UI.Tests.Pages.Exporter.EhcNewLanding;
using Defra.UI.Tests.Pages.Exporter.StartNewEhc;
using Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant;
using Defra.UI.Tests.Pages.EstablishmentLookupPage;

namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class PageHooks
    {

        private readonly IObjectContainer _objectContainer;

        public PageHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.Pages)]
        public void BeforeScenario()
        {
            BindAllPages();
        }

        private void BindAllPages()
        {
            // Objects
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());

            // Pages 
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<Signin, ISignin>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ExportInfo, IExportInfo>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<Applications, IApplications>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<EhcNewLanding, IEhcNewLanding>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<StartNewEhc, IStartNewEhc>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CertificateLookup, ICertificateLookup>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CopyApplication, ICopyApplication>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<WhichSectionsToCopy, IWhichSectionsToCopy>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<TaskList, ITaskList>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<Commodity, ICommodity>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<IdentificationPage, IIdentificationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<EstablishmentLookupPage, IEstablishmentLookupPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<AccompanyingDocs, IAccompanyingDocs>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GoodsCertifiedAs, IGoodsCertifiedAs>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GrossWeight, IGrossWeight>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ContainerOrSealNo, IContainerOrSealNo>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ConsignorPage, IConsignorPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<FindAnExporterOrConsignor, IFindAnExporterOrConsignor>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SelectExporterOrConsignorActivity, ISelectExporterOrConsignorActivity>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ConsigneePage, IConsigneePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BorderControl, IBorderControl>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<Transport, ITransport>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ResponsibleForLoad, IResponsibleForLoad>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PlaceDestination, IPlaceDestination>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CheckYourAnswers, ICheckYourAnswers>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReviewAndCheck, IReviewAndCheck>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationComplete, IApplicationComplete>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<EHCData, IEHCData>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PlaceOfOrigin, IPlaceOfOrigin>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SelectCertifier, ISelectCertifier>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PurposeOfExport, IPurposeOfExport>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<RegionOfCertification, IRegionOfCertification>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DepartureAndArrival, IDepartureAndArrival>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationReference, IApplicationReference>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CertifierApplications, ICertifierApplications>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ColdStoreAndManufacturingPlantPage, IColdStoreAndManufacturingPlantPage>());            
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CertifierView, ICertifierView>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CertIdentificationPage, ICertIdentificationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CommoditySummary, ICommoditySummary>());
        }

        private TU GetBaseWithContainer<T, TU>() where T : TU =>
         (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}
