namespace Defra.UI.Tests.Pages.EstablishmentLookupPage
{
    public interface IEstablishmentLookupPage
    {
        public bool IsEstablishmentLookupPage { get; }
        public bool IsEstablishmentLookUpPageHeaderDisplayed { get; }
        public bool IsBackLinkDisplayed { get; }
        public string GetHintText { get; }
        public string GetHelpAddingActivitiesLinkText { get; }
        public void ClickHelpAddingActivitiesLink();
        public string GetHelpAddingActivitiesDetailsText { get; }
        public bool IsSaveAndContinueButtonDisplayed { get; }
        public void ClickSaveAndContinueButton();
        public bool ValidateActivityRadioElements();
        public bool CheckIfActivitiesInAlphabeticalOrder();
        public string GetErrorSummaryHeader { get; }
        public string GetErrorSummaryMessage { get; }
        public string GetActivityErrorMessage { get; }
    }
}
