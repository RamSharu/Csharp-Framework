namespace Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant
{
    public interface IColdStoreAndManufacturingPlantPage
    {
        public bool IsColdStoreAndManufacturingPlantPage { get; }
        public void ApprovalNumberSearch(string approvalNumber);
        public void GoToApprovalNumberSearch();
        public void GoToOperatorNameSearch();
        public int IsApprovalNumberAlertPresent();
        public bool IsApprovalNumberSearchCleared();
        public int IsApprovalNumberSearchResultsPresent();
        public int IsOperatorNameAlertPresent();
        public bool IsOperatorNameSearchCleared();
        public int IsOperatorNameSearchResultsPresent();
        public void ClickSaveAndContinue();
        public bool ApprovalNumberThrowsAlert();
        public bool OperatorNameThrowsAlert();
        public bool OrganisationAlertIsThrown();
        public void FillColdStore();
        public bool SearchResultsAreReturned();
        public void SearchOperatorByName(string operatorName);
        public string[] GetActivitiesOfOperator();
        public void SelectOperatorNameRadio(string operatorNameInput);
        public bool SearchResultsText(string searchResult);
    }
}