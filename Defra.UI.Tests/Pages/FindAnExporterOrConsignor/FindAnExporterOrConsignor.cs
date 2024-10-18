using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.FindAnExporterOrConsignor
{
    public class FindAnExporterOrConsignor : IFindAnExporterOrConsignor
    {
        private IObjectContainer _objectContainer;
        
        public FindAnExporterOrConsignor(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page objects

        private By FindAnExporterOrConsignorPageHeaderBy => By.CssSelector(".Consignor h1.govuk-heading-xl");
        private IWebElement BackLink => _driver.FindElement(By.CssSelector(".Consignor .govuk-back-link"));
        private IWebElement DescriptionText => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']/following-sibling::p"));
        private IWebElement LabelText => _driver.WaitForElement(By.ClassName("govuk-label"));
        private IWebElement HintText => _driver.WaitForElement(By.ClassName("govuk-hint"));
        private IWebElement Searchbox => _driver.WaitForElement(By.CssSelector("input#operator-search"));
        private IWebElement SearchButton => _driver.WaitForElement(By.CssSelector(".Consignor .govuk-form-group .govuk-button"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//*[@id='cannotFindDetails']/following-sibling::button"));

        #endregion

        #region Methods

        public bool IsFindAnExporterOrConsignorPage => _driver.WaitForElement(FindAnExporterOrConsignorPageHeaderBy).Text.Contains("Find an exporter or consignor");

        public bool IsBackLinkDisplayed => BackLink.Displayed;
        public string GetFindExporterConsignorDesc => DescriptionText.Text.Trim();
        public string GetFindExporterConsignorLabelText => LabelText.Text.Trim();
        public bool IsHintTextDisplayed => string.IsNullOrEmpty(HintText.Text.Trim());
        public bool IsSearchBoxDisplayed => Searchbox.Displayed;
        public bool IsSearchButtonDisplayed => SearchButton.Displayed;
        public void SearchConsignor(string consignorName) => Searchbox.SendKeys(consignorName);
        public void ClickSearchButton() => SearchButton.Click();
        public void SelectConsignorRadioOption(string consignorName) => _driver.ClickRadioButton(consignorName);
        public void ClickSaveAndContinueButton() => SaveAndContinueButton.Click();
        #endregion
    }
}
