namespace Defra.UI.Tests.Pages.Exporter.MeansOfTransport
{
    public interface ITransport
    { 
        public bool IsMeansOfTransportPage { get; }
        public bool VerifyTransport();
        public void EditTransportCondition();
        public bool IsTransportDetailsCompleted();
        public void SelectTransport(string TransportCondition, string meansOfTransport);
        public bool CompleteMeansOfTransport(string transCondition, string meansOfTrans, string skipCheckbox);
        public bool VerifyTransportValidationMessage();
        public bool IsMeansOfTransportSkipCheckboxVisible();
    }
}
