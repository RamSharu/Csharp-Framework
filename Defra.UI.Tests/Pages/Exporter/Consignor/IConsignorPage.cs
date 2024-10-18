namespace Defra.UI.Tests.Pages.Exporter.Consignor
{
    public interface IConsignorPage
    {
        public bool IsConsignorOrExporterPage { get; }
        public string GetConsignorOrExporterPageHeaderText { get; }
        public bool IsBackLinkDisplayed { get; }
        public bool IsContinueButtonDisplayed { get; }
        public string GetExporterConsignorCaption { get; }
        public string GetExporterConsignorDesc { get; }
        public string GetExporterConsignorLinkText { get; }
        public void ClickSelectExporterOrConsignorLink();
        public void ClickChangeActivityLink();
        public void AddConsignor(string consignorName);
        public void AddConsignorData(string consignorName);
        public void FindConsignorData(string consignorName);
        public bool VerifyConsignorStatus();
        public void SelectExporterOrConsignor(string consignorName);
        public void SearchConsignor(string consignorName);
        public bool VerifyConsignorActivity();
        public bool ValidateConsignorAndAddressIfAdded();
        public bool ValidateConsignorActivityIfAdded { get; }
        public string GetConsignorActivity { get; }
    }
}
