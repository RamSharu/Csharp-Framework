namespace Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs
{
    public interface IGoodsCertifiedAs
    {
        public bool IsGoodsCertifiedPage { get; }
        public void ClickGoodsCertifiedAsValue(string goodsCertifiedAsValue);
        public void SelectGoodsCertifiedAsRadio(string goodsCertifiedAsRadio);
        public bool GoodsCertifiesAsStatus();
    }
}