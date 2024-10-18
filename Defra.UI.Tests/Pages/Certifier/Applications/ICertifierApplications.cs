using Defra.UI.Framework.Driver;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Certifier.Applications
{
    public interface ICertifierApplications
    {
        public bool IsApplicationsPage { get; }

        public void AddNewRecord();

        public void ChangeRecordOperator();

        public void ClickFirstApplication();

        public void ClickToViewCommodityDetails();

        public void ClickToCollapseCommodityParentTabDetails();

        public void ClickToViewContainerNumberSealNumberTabDetails();

        public void EditExistingRecord();

        public void RemoveExistingRecord();

        public void EditRegionOfCertification();

        public bool IsNewCommodityRecordDisplayed { get; }

        public bool SearchApplication(string ApplicationName);

        public bool VerifyChangedOperator();
        public bool VerifyChangedRegionOfCertification();

        public void EditResponsibleForLoad();
        public void CertifierEditResponsibleForLoad(string operatorName, string countryName);
        public bool VerifyCertifierRFLValidation(string validationInformation);

        public bool VerifyResponsibleForLoad();

        public bool ViewApplication(string ApplicationName);
        public void EditPurposeOfExport();
        public bool VerifyChangedPurposeOfExport();
        public void EditGoodsCertifiedAs(string goodscertifiedas);
        public bool VerifyChangedGoodsCertifiedAs();
        public void EditContainerOrSealNumber(string containerNo, string sealNo);
        public bool VerifyChangedContainerOrSealNumber();
        public void EditDepartureAndArrival();
        public bool VerifyChangedDepatureAndArrivalDate();
        public void EditMeansofTranport();
        public bool VerifyChangedMeansOfTransport();
        public void EditBorderControlPost();
        public string VerifyChangedBorderControlPost();
        public string VerifySkipErrorMessage();
        public void AssignCertifier(string certifierName);
        public bool VerifyAssignedCerfier(string certifierName);
        public bool IsTitleDisplayed();
        public bool IsSearchBoxDisplayed { get; }
        public void ClickClearFiltersButton();
        public bool IsClearFiltersLinkDisplayed();
        public bool IsCountrylistDisplayed();
        public bool IsDateListDisplayed();
        public bool IsStatusListDisplayed();
        public bool IsApplicationsTableDisplayed();
        public void ClickShowLink();
        public bool IsApplicationLinkDisplayed();
        public bool IsPageNumberDisplayed();
        public bool IsCurrentPageNumberDisplayed();
        public void AssignApplicationToCertifier();
        public bool IsApplicationAssigned();
        public void CancelApplication();
        public bool IsApplicationCancelled();
        public void NotEnteredMeansOfTransport(string transCondition, string meansOfTrans);
        public string ExceptedErrMsgTransportSection(string transCondition,string meansOfTransport, string requiredDetails);
        public bool ValidateErrMsgTransport(string transCondition,string meansOfTransport, string requiredDetails);
        public IWebElement locatorMeansOfTrans(int value);
        public bool VerifyTransConditionValidation();
        public void ClickOnCommodityDetails();
        public bool IsSkipFunctionlityExist();
        public void ClickOnDepartureAndArrivalLink();
        public void ContinueWithNoDepartureAndArrivalDate(string depatureValidation, string arrivalValidation);
        public bool ValidationMsgDepartureAndArrival(string validationInformation);
        public void ClickOnMeansOfTranportLink();
        public void ChangePlaceOfOrigin(string placeOfDispatch, string placeOfLoading);
        public bool VerifyChangedPlaceOfDispatch();
        public bool VerifyChangedPlaceOfLoading();
        public void ChangeBorderControPostl(string countryId, string borderName);
        public bool VerifyChangeOfBorderControPostl();
        public void EditPlaceOfOrigin();
        public void EditPlaceOfDestination();
        public void ClickSaveAndContinue();
        public bool ValidateIdenDataModalErrorMessages();
        public void ClickOnTransportTab();

        public void ClickToCollapseDepartureAndArrivalPanelDetails();
    }
}