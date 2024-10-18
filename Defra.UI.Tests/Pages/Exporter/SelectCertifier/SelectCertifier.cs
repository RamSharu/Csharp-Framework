using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.SelectCertifier
{
    public class SelectCertifier : ISelectCertifier
    {
        private IObjectContainer _objectContainer;

        public SelectCertifier(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private IWebElement SelectCertifierLink => _driver.WaitForElement(By.CssSelector("div[id = 'certifier'] a[class='govuk-link']"));
        private By SelectCertifierPageHeaderBy => By.CssSelector("div.Certifier h1.govuk-heading-xl");
        private IWebElement SelectCertifierPageHeader => _driver.WaitForElement(SelectCertifierPageHeaderBy);
        private By SelectForCertifierBy => By.XPath("//a[normalize-space()='Select a certifier']");
        private IWebElement SelectForCertifier => _driver.WaitForElement(SelectForCertifierBy);
        private IWebElement OperatorSearchBox => _driver.WaitForElement(By.XPath("//input[@id='operator-search']"));
        private IWebElement OperatorSearchButton => _driver.WaitForElement(By.XPath("//button[@class='govuk-button govuk-button--primary']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement ContinueButton => _driver.WaitForElement(By.XPath("//a[normalize-space()='Continue']"));
        private IWebElement CertifierStatusText => _driver.WaitForElement(By.CssSelector("div[id='certifier'] span[class='govuk-tag'] span"));
        private List<IWebElement> RemoveLinkList => _driver.FindElements(By.XPath("//a[contains(text(),'Remove')]")).ToList();

        #endregion

        #region Page Methods

        public bool IsSelectCertifierPage => _driver.WaitForElement(SelectCertifierPageHeaderBy).Text.Contains("Certifier");

        public bool IsSelectCertifierPageDisplayed()
        {
            SelectCertifierLink.Click();
            var pageHeaderText = SelectCertifierPageHeader.Text;
            return pageHeaderText.Contains("Certifier");
        }

        public void ClickRemoveLink()
        {
            if (RemoveLinkList.Count > 0)
                RemoveLinkList.ElementAt(0).Click();
        }

        public void ClickSelectCertifier(string certifierName)
        {
            SelectForCertifier.Click();
            if (!string.IsNullOrEmpty(certifierName))
                OperatorSearchBox.SendKeys(certifierName);

            OperatorSearchButton.Click();
            _driver.ClickRadioButton(certifierName);
            SaveAndContinue.Click();
            ContinueButton.Click();
        }

        public bool VerifyCertifierStatus()
        {
            bool certifierStatus = CertifierStatusText.Text.Contains("COMPLETE");
            return certifierStatus;
        }
        #endregion
    }
}