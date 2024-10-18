namespace Defra.UI.Tests.Pages.Exporter.CopyApplication
{
    public interface ICopyApplication
    {
        public bool IsCopyApplicationPage { get; }
        public bool IsBackLinkDisplayed { get; }
        public bool IsCopyApplicationHeaderDisplayed { get; }
        public bool IsContinueButtonDisplayed { get; }
        public bool ValidateApplicationDetails();
        public bool ValidateCopyRadioButtons();
        public void ClickCopyRadioOption(string radioOption);
        public void ClickContinueButton();
    }
}
