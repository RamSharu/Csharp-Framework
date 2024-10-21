namespace Defra.UI.Tests.Pages.Exporter.CheckYourAnswers
{
    public interface ICheckYourAnswers
    {
        public bool IsCheckYourAnswersPage { get; }
        public bool ValidateBackLink { get; }
        public bool CheckIfRequiredFieldsAreDisplayed();
        public bool CheckIfListOfTasksForTheAppIsDisplayed();
        public void ClickCheckAndContinueButton();
        public void ClickChangeGrossWeight();
        public void ClickChangeCommodity();
        public void ClickChangeGoodsCertifiedAs();
        public void ClickChangeContainerNoSealNo();
        public void ClickChangePurposeOfExport();
        public void ClickChangeAccompanyingDocs();
        public void ClickConsignorOrExporter();
        public void ClickConsigneeOrImporter();
        public void ClickChangeCertifier();
        public void ClickChangeRegionOfCertification();
        public void ClickChangeResponsibleForLoad();
        public void ClickChangeDepartureAndArrival();
        public void ClickChangeCountryOfOrigin();
        public void ClickChangePlaceOfLoading();
        public void ClickChangePlaceOfDispatch();
        public void ClickChangeEntryBCP();
        public void ClickChangeMeansOfTransport();
        public void ClickChangePlaceOfDestination();
        public bool CheckPlaceOfOrigin(string section, string origin);
        public string GetPlaceOfDispatch();
        public string GetPlaceOfLoading();
        public bool IsSkippedFeatureShowNotEntry(string NotEntered);
        public bool NumberOfCommoditiesRecords();
    }
}
