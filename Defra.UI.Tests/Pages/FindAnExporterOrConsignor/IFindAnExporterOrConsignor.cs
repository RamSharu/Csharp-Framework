using Defra.UI.Framework.Driver;

namespace Defra.UI.Tests.Pages.FindAnExporterOrConsignor
{
    public interface IFindAnExporterOrConsignor
    {
        public bool IsFindAnExporterOrConsignorPage { get; }
        public bool IsBackLinkDisplayed { get; }
        public string GetFindExporterConsignorDesc { get; }
        public string GetFindExporterConsignorLabelText { get; }
        public bool IsHintTextDisplayed { get; }
        public bool IsSearchBoxDisplayed { get; }
        public bool IsSearchButtonDisplayed { get; }
        public void SearchConsignor(string consignorName);
        public void ClickSearchButton();
        public void SelectConsignorRadioOption(string consignorName);
        public void ClickSaveAndContinueButton();
    }
}
