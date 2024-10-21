namespace Defra.UI.Tests.Pages.Exporter.SelectCertifier
{
    public interface ISelectCertifier
    {
        public bool IsSelectCertifierPage { get; }
        public bool IsSelectCertifierPageDisplayed();
        public void ClickRemoveLink();
        public void ClickSelectCertifier(string certifierName);
        public bool VerifyCertifierStatus();
    }
}
