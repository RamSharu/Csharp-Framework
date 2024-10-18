using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Network;

namespace Defra.UI.Tests.Pages.Exporter.StartNewEhc
{
    public class StartNewEhc : IStartNewEhc
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By StartNewEhcPageHeaderBy => By.CssSelector(".StartNewEhc .govuk-label--xl");
        private IWebElement AddApplicationRefTextbox => _driver.WaitForElement(By.Id("user-reference"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.CssSelector(".StartNewEhc #actions .govuk-button"));

        private IWebElement ErrorSummaryTitleText => _driver.WaitForElement(By.Id("error-summary-title"));
        private IWebElement ErrorSummaryBodyText => _driver.WaitForElement(By.CssSelector("#validation-error-summary .govuk-error-summary__body a"));
        private IWebElement ErrorMessageText => _driver.WaitForElement(By.Id("user-reference-error"));

        #endregion

        #region Methods

        public StartNewEhc(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsStartNewEhcPage
        {
            get => _driver.WaitForElement(StartNewEhcPageHeaderBy).Text.Contains("Your reference for this application");
        }

        public void AddApplicationRef(string appRef)
        {
            AddApplicationRefTextbox.Clear();
            AddApplicationRefTextbox.SendKeys(appRef);
        }

        public void ClickSaveAndContinueButton() => SaveAndContinueButton.Click();

        public string GetErrorSummaryTitleText() => ErrorSummaryTitleText.Text;
        public string GetErrorSummaryBodyText() => ErrorSummaryBodyText.Text;
        public string GetErrorMessageText() => ErrorMessageText.Text;

        #endregion
    }
}
