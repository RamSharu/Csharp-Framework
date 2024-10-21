using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Defra.UI.Tests.HelperMethods;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs
{
    public class GoodsCertifiedAs : IGoodsCertifiedAs
    {
        private IObjectContainer _objectContainer;

        public GoodsCertifiedAs(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page objects
        private By GoodsCertifiedAsPageHeaderBy => By.CssSelector(".GoodsCertifiedAs .govuk-heading-xl");
        //private IWebElement ClickFirstSearchResult => _driver.WaitForElement(By.CssSelector("label.govuk-label.govuk-radios__label[for='goods-certified-as-0']"));
        private List<IWebElement> ClickFirstSearchResult => _driver.WaitForElements(By.CssSelector("label.govuk-label.govuk-radios__label")).ToList();
        private IWebElement GoodsCertifiedAsLink => _driver.WaitForElement(By.CssSelector("div#goods-certified-as dt.govuk-summary-list__key a.govuk-link"));
        private IWebElement GoodsCertifiedAsStatusText => _driver.WaitForElement(By.CssSelector("div#goods-certified-as.govuk-summary-list__row span.govuk-tag"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement SaveAndReturn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and return')]"));
        private IWebElement SearchButton => _driver.WaitForElement(By.CssSelector("button.govuk-button.govuk-button--primary"));
        private IWebElement SearchGoodsCertifedAs => _driver.WaitForElement(By.CssSelector("input#search-goods-certified-as.govuk-input"));
        #endregion

        #region Methods
        public bool IsGoodsCertifiedPage => _driver.WaitForElement(GoodsCertifiedAsPageHeaderBy).Text.Contains("What is your consignment certified as?");
        
        public void ClickGoodsCertifiedAsValue(string goodsCertifiedAsValue)
        {
            GoodsCertifiedAsLink.Click();
            SelectGoodsCertifiedAsRadio(goodsCertifiedAsValue);
        }

        public void SelectGoodsCertifiedAsRadio(string goodsCertifiedAsRadioOptionValue)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(ClickFirstSearchResult.First());
            action.Perform();
            _driver.ClickRadioButtonOption(goodsCertifiedAsRadioOptionValue);
            SaveAndContinue.Click();

        }

        public bool GoodsCertifiesAsStatus()
        {
            var goodsCertifiedAsStatus = GoodsCertifiedAsStatusText.Text;
            return goodsCertifiedAsStatus.Contains("COMPLETE");
        }
        #endregion
    }
}