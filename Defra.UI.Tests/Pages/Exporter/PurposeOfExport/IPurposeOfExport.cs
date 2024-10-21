namespace Defra.UI.Tests.Pages.Exporter.PurposeOfExport
{
    public interface IPurposeOfExport
    {
        public bool IsPurposeOfExporterPageDisplayed();
        public void ClickPurposeOfExportButton(string purposetype);
        public int ClickSaveAndContinue(string purposeType);
        public bool PurposeOfExportAlertMessage();
        public bool PurposeOfExportCountryAlertMessage();
        public bool PurposeOfExportStatus();
    }
}