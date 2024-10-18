namespace Defra.UI.Tests.Pages.SelectExporterOrConsignorActivity
{
    public interface ISelectExporterOrConsignorActivity
    {
        public bool IsSelectExporterOrConsignorActivityPage { get; }
        public string GetPageName { get; }
        public bool IsBackLinkDisplayed { get; }
        public bool IsHintTextDisplayed { get; }
        public bool ValidateActivityRadios { get; }
        public bool IsSaveAndContinueButtonDisplayed { get; }
        public void ClickHelpAddingActivitiesLink();
        public void ClickSaveAndContinueButton();
        public string GetHelpText();
        public void ClickActivityRadio();
        public void ClickActivityRadio(string activity);
    }
}
