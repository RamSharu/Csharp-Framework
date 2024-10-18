using BoDi;
using Defra.UI.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.UI.Tests.Tools;
using Defra.UI.Tests.Pages.Exporter.TaskList;

namespace Defra.UI.Tests.Pages.Exporter.BorderControl
{
    public class BorderControl : IBorderControl
    {
        private IObjectContainer _objectContainer;

        public BorderControl(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        #region to Page objects
        private By BcpPaheHeaderBy => By.CssSelector(".BorderControlPost .govuk-heading-xl");
        private IWebElement BorderControlElement =>
            _driver.WaitForElement(
                By.CssSelector("div#entry-border-control-post dt.govuk-summary-list__key a.govuk-link"));

        private IWebElement CountryElement => _driver.WaitForElement(By.CssSelector("div.BorderControlPost #country"));
        private IWebElement SearchInputAvlOptions => _driver.WaitForElement(By.Id("search-border-post-name"));
        private IReadOnlyCollection<IWebElement> tableElements => _driver.WaitForElements(By.CssSelector("div.border-inspection-post"));
        private IWebElement SaveAndReturn =>   _driver.WaitForElement(By.XPath("//button[contains(text(), 'Save and continue')]"));
        private IWebElement BorderControlStatus => _driver.WaitForElement(By.CssSelector("div#entry-border-control-post.govuk-summary-list__row span.govuk-tag span"));
        private IWebElement SkipValidationInText => _driver.WaitForElement(By.CssSelector("#error-summary-title"));
        private IWebElement ChangeBCP => _driver.WaitForElement(By.XPath("//div[contains(text(),'Entry border control post')]/..//a"));
        private IWebElement BCPValue => _driver.WaitForElement(By.XPath("//div[contains(text(), 'Entry border control post')]/..//span"));
        private IWebElement BcpSkipCheckbox => _driver.WaitForElementExists(By.CssSelector("#skip-question"));
        #endregion

        #region Page Methods

        public bool IsBcpPage
        {
            get => _driver.WaitForElement(BcpPaheHeaderBy).Text.Contains("Entry border control post");
        }
            
        public bool VerifyCompleteBorderControl(string countryId, string borderName)
        {
            CompleteBorderControl(countryId, borderName);
            SaveAndReturn.Click();
            return true;
        }

        public bool IsBorderControlDetailsCompleted()
        {
            var borderControlStatus = BorderControlStatus.Text;
            return borderControlStatus.Contains("COMPLETE");
        }

        public bool VerifyCompleteBorderControlCheckBox(string countryId, string borderName,string skipcheckbox)
        {
            CompleteBorderControl(countryId, borderName);
            
            if (skipcheckbox.Contains("Yes"))
            {
                TaskList.ClickOnSkipFunction();
            }
            
            SaveAndReturn.Click();
            return true;
        }

        public void CompleteBorderControl(string countryId, string borderName)
        {
            BorderControlElement.Click();
            if (!string.IsNullOrEmpty(countryId))
            {
                _driver.SelectFromDropdown(CountryElement, countryId);
            }

            if (!string.IsNullOrEmpty(borderName))
            {
                SearchInputAvlOptions.SendKeys(borderName);
                var borderElement = tableElements.Where(e => e.Text.Contains(borderName)).ToArray()[0];
                borderElement.FindElement(By.TagName("button")).Click();
            }
        }

        public bool VerifySkipValidationInformation()
        {
            var SkipValidationStatus = SkipValidationInText.Text;
            return SkipValidationStatus.Contains("There is a problem");
        }

        public void ClickBcpSkipCheckbox()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", BcpSkipCheckbox);
        }

        public void ClickSaveAndContinueButton() => SaveAndReturn.Click();

        public bool VerifyBorderControlPostNotEnteredOnReviewPage()
        {
            var BCPReviewValue = BCPValue.Text;
            return BCPReviewValue.Contains("Not entered");
        }
        #endregion
    }
}
