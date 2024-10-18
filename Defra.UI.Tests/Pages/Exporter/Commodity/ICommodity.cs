

using System.Transactions;

namespace Defra.UI.Tests.Pages.Exporter.Commodity
{
    public interface ICommodity
    {
        public bool IsCommoditiesPage { get; }
        public void StartNewApplication();
        public void EnterRefAndcontinue(string refrence);
        public void EnterSelectCertificateAndContinue(string certifierCode);
        public void EnterSelectCommodityAndContinue(string commodityCode);
        public bool VerifyCommodity();
        public void ClickNoRadioForAddMoreCommodity();
        public void CopyCommodityRecords();
        public bool VerifyCopyRecords();
        public void RemoveCommodityRecords();
        public bool VerifyRemoveRecords();
        public void ChangeCommodityRecord(string productDesc, string packageCount, string netWeight);
        public void CopyAndUpdateCommodityRecord(string productDesc, string packageCount, string netWeight);
        public bool VerifyChangeRecords();
        public void ChangeCommodityActivity(string activityName);
        public bool VerifyCommodityActivity(string activityName);
        public bool VerifyNetWeight(string netWeight, string record);
        public void UpdateCommodityRecord(string productDesc, string packageCount, string netWeight);
        public void ClickChangeRecords();
        public bool VerifyValidationErrorMessagesTopOfPage(string specificFields);
        public bool VerifyCommodityErrorMessage(string expectedErrorMessage);
        public string ExceptedValidationMsgAgainstSpecificField(string specificField);
        public bool VerifyValidationMsgAgainstSpecificField(string specificField);
        public bool VerifySkipValidationErrorMsgBottomOfPage();
        public void UpdateNetWeightAmount(string netWeight);
    }
}

