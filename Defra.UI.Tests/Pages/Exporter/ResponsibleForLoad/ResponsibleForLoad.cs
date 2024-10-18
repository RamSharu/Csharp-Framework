using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.Exporter.ResponsibleForLoad
{
    public class ResponsibleForLoad : IResponsibleForLoad
    {
        private IObjectContainer _objectContainer;

        public ResponsibleForLoad(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By ResponsibleForLoadPageHeaderBy => By.CssSelector(".ResponsibleForLoad .govuk-heading-xl");
        private IWebElement ContinueButton => _driver.WaitForElement(By.CssSelector("a.govuk-button"));
        private IWebElement OperatorSearch => _driver.WaitForElement(By.CssSelector("input#operator-search"));
        private IWebElement ResponsibleForLoadLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Responsible for load (optional)')]"));
        private IWebElement ResponsibleForLoadStatusText => _driver.WaitForElement(By.XPath("//div[contains(@id,'responsible-for-load-(optional)')]/dd/span/span"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//button[contains(text(),' Save and continue ')]"));
        private IWebElement SearchButton => _driver.WaitForElement(By.CssSelector("button.govuk-button.govuk-button--primary"));
        private IWebElement SelectCountry => _driver.WaitForElement(By.Id("operator-country"));
        private IWebElement SelectFirstRadio => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-radios__item')]"));
        private IWebElement SelectResponsibleForLoadLink => _driver.WaitForElement(By.CssSelector("p.govuk-body a.govuk-link"));
        private List<IWebElement> RemoveLinkList => _driver.FindElements(By.XPath("//a[contains(text(),'Remove')]")).ToList();
        private IWebElement RemoveLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Remove')]"));

        #endregion

        #region Methods

        public bool IsResponsibleForLoadPage => _driver.WaitForElement(ResponsibleForLoadPageHeaderBy).Text.Contains("Responsible for load");
       
        public void CompleteResponsibleForLoad(string responsibleForLoadCountry, string responsibleForLoadOperator)
        {
            SelectResponsibleForLoadLink.Click();
            SelectElement dropDown = new SelectElement(SelectCountry);
            dropDown.SelectByValue(responsibleForLoadCountry);
            OperatorSearch.SendKeys(responsibleForLoadOperator);
            SearchButton.Click();
            SelectFirstRadio.Click();
            SaveAndContinueButton.Click();
            ContinueButton.Click();
        }

        public void ClickRemoveLink()
        {
            if (RemoveLinkList.Count > 0)
                RemoveLinkList.ElementAt(0).Click();
        }

        public bool IsResponsibleForLoadPageDisplayed()
        {
            ResponsibleForLoadLink.Click();
            return _driver.PageSource.Contains("Responsible for load");
        }

        public bool VerifyResponsibleForLoadStatus()
        {
            var responsibleForLoadStatus = ResponsibleForLoadStatusText.Text;
            return responsibleForLoadStatus.Contains("COMPLETE");
        }
        #endregion
    }
}
