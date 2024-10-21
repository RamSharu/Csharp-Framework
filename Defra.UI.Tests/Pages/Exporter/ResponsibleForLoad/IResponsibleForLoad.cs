namespace Defra.UI.Tests.Pages.Exporter.ResponsibleForLoad
{
    public interface IResponsibleForLoad
    {
        public bool IsResponsibleForLoadPage { get; }
        public void CompleteResponsibleForLoad(string responsibleforloadcountry, string responsibleforloadoperator);
        public void ClickRemoveLink();
        public bool VerifyResponsibleForLoadStatus();
        public bool IsResponsibleForLoadPageDisplayed();

    }
}
