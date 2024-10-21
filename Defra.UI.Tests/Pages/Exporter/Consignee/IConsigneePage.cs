namespace Defra.UI.Tests.Pages.Exporter.Consignee
{
    public interface IConsigneePage
    {
        public bool IsConsigneeOrImporterPage { get; }
        public void ClickConsignee(string consigneeName, string consigneeCountry);
        public void AddConsignee(string consigneeName, string consigneeCountry);
        public void ClickRemoveLink();
        public bool VerifyConsigneeStatus();
        public void SelectConsigneeImporter(string consigneeName, string consigneeCountry);
    }
}
