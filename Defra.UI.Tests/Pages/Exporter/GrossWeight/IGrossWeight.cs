namespace Defra.UI.Tests.Pages.Exporter.GrossWeight
{
    public interface IGrossWeight
    {
        public bool IsGrossWeightPage { get; }
        public void CompleteGrossWeight(string grossweightamount, string grossweightunit);
        public bool VerifyGrossWeightStatus();
        public bool VerifyGrossWeightAmount(string grossweightamount);
        public void AddGrossWeightAmount(string grossweightamount, string grossweightunit);
        public void CompleteGrossWeightWithSkipFun(string grossweightamount, string grossweightunit, string skipcheckbox);
        public bool VerifySkipValidationInformation();
        public bool VerifyGrossAgainstNetWeightValidationMessage();
        public bool VerifyGrossAgainstNetWeightFieldValidationMessage();
        public void AddGrossWeight(string grossweightamount, string grossweightunit);
        public void GrossWeightUnitAndGrossWeightAmountBlank(string grossWeightunit);
        public void ClickBackLink();
        public bool VerifyskipErrorValidationOnPage(string errorMessage);
        public void FillGrossWeight();
        public void FillGrossWeightUnit();
        public bool VerifyGrossWeightAmountErrorValidationOnPage(string errorMessage);
        public void FillGrossWeightAmount();
        public bool VerifyGrossWeightUnitErrorValidationOnPage(string errorMessage);
        public void ClickSaveAndContinue();
    }
}
