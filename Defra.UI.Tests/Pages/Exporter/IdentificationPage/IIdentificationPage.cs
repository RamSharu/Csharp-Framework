using Defra.UI.Tests.Data.Identification;

namespace Defra.UI.Tests.Pages.Exporter.IdentificationPage
{
    public interface IIdentificationPage
    {
        public bool IsIdentificationPage { get; }
        public void AddIdentification(int noOfIdetifications, string certificateNum);
        public void AddCommodityData(List<IdentificationData> dataList);
        public void ClickManufacturingPlantLink();
        public void AddDecimalCommodityData(int noOfIdetifications, string certificateNum, string netWeight);
        public void AddCertifierCommodityData(List<IdentificationData> dataList);
        public bool IsSkipCheckboxVisible();
        public bool IsSkipChecked();
        public void SkipAndContinue();
        public void SelectOperatorSearchCountry(string operatorCountry);
        public void AddCommodityDataWithOutSpecificField(int noOfIdentifications, string certificateNum, string fieldAttribute);
    }
}
