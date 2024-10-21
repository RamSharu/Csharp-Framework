using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.SelectExporterOrConsignorActivity
{
    public class SelectExporterOrConsignorActivity : ISelectExporterOrConsignorActivity
    {
        private IObjectContainer _objectContainer;

        public SelectExporterOrConsignorActivity(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page objects
        private By SelectActivityPageHeaderBy => By.CssSelector(".Consignor h1.govuk-heading-xl");
        private IWebElement BackLink => _driver.FindElement(By.CssSelector(".Consignor .govuk-back-link"));
        private IWebElement HintText => _driver.FindElement(By.ClassName("govuk-hint"));
        private List<IWebElement> SelectActivityRadioList => _driver.FindElements(By.XPath("//*[@class='govuk-radios__item']/input")).ToList();
        private IWebElement HelpAddingActivitiesLink => _driver.FindElement(By.ClassName("govuk-details__summary-text"));
        private IWebElement HelpAddingActivitiesText => _driver.WaitForElement(By.ClassName("govuk-details__text"));
        private IWebElement SaveAndContinueButton => _driver.FindElement(By.XPath("//*[@class='govuk-details']/following-sibling::button"));

        #endregion

        #region Methods
        public bool IsSelectExporterOrConsignorActivityPage => _driver.WaitForElement(SelectActivityPageHeaderBy).Text.Contains("Select an exporter or consignor activity");

        public string GetPageName => _driver.FindElement(SelectActivityPageHeaderBy).Text;
        public bool IsBackLinkDisplayed => BackLink.Displayed;
        public bool IsHintTextDisplayed => HintText.Displayed;
        public bool ValidateActivityRadios => SelectActivityRadioList.Count() > 0;
        public bool IsSaveAndContinueButtonDisplayed => SaveAndContinueButton.Displayed;
        public void ClickHelpAddingActivitiesLink() => HelpAddingActivitiesLink.Click();
        
        public void ClickSaveAndContinueButton()
        {
            SaveAndContinueButton.Click();
            _driver.WaitForElementCondition(ExpectedConditions.InvisibilityOfElementWithText(SelectActivityPageHeaderBy, "Select an exporter or consignor activity"));
        }

        public string GetHelpText()
        {
            ClickHelpAddingActivitiesLink();
            return HelpAddingActivitiesText.Text;
        }

        public void ClickActivityRadio()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(SelectActivityRadioList.First());
            action.Perform();
            SelectActivityRadioList.First().Click();
        }

        public void ClickActivityRadio(string activity)
        {
            _driver.ClickRadioButtonOption(activity);
        }
        #endregion
    }
}
