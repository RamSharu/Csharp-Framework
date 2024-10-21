namespace Defra.UI.Tests.Pages.Exporter.TaskList
{
    public interface ITaskList
    {
        public bool IsTaskListPage { get; }
        public void ClickManageCommoditiesLink();
        public void ClickGrossWeightLink();
        public void ClickAccompanyingDocsLink();
        public void ClickDepartureAndArrivalLink();
        public void ClickPlaceOfOriginLink();
        public void ClickMeansOfTransportLink();
        public void ClickPreviewCertificateLink();
        public bool ValidatePreviewSummary { get; }
        public bool ValidateDownloadLink { get; }
        public void ClickDownloadLink();
        public bool ConfirmPreviewCertDownload();
        public void ClickReviewAnswersLink();
        public void ClickChangeApplicationReference();
        public string GetApplicationReference();
        public bool SearchOnPage(string text);
        public string GetApplySectionStatus();
        public void ClickOnSkipFunction();
        public void ClickSkipFunctionCheckBox();
        public void ClickExporterOrConsignorLink();
    }
}
