
namespace Defra.UI.Tests.Pages.Exporter.StartNewEhc
{
    public interface IStartNewEhc
    {
        public bool IsStartNewEhcPage { get; }
        public void AddApplicationRef(string appRef);
        public void ClickSaveAndContinueButton();
        public string GetErrorSummaryTitleText();
        public string GetErrorSummaryBodyText();
        public string GetErrorMessageText();
    }
}
