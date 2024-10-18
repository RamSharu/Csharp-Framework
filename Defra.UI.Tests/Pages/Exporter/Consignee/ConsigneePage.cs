using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Defra.UI.Tests.HelperMethods;

namespace Defra.UI.Tests.Pages.Exporter.Consignee
{
    public class ConsigneePage : IConsigneePage
    {
        private IObjectContainer _objectContainer;

        public ConsigneePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By ConsigneePageHeaderBy => By.CssSelector(".Consignee h1.govuk-heading-xl");
        private IWebElement ConsigneeImporterLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Consignee or Importer')]"));
        private IWebElement SelectConsignee => _driver.WaitForElement(By.XPath("//a[contains(text(),'Select')]"));
        private IWebElement Country => _driver.WaitForElementClickable(By.Id("operator-country"));
        private IWebElement OperatorName => _driver.WaitForElement(By.XPath("//input[@id='operator-search']"));
        private IWebElement OperatorSearch => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//a[contains(.,'Continue')]"));
        IWebElement ConsigneeStatus => _driver.WaitForElement(By.XPath("//a[contains(text(),'Consignee or Importer')]/../following-sibling::dd/span/span"));
        private List<IWebElement> RemoveLinkList => _driver.FindElements(By.XPath("//a[contains(text(),'Remove')]")).ToList();
        
        #endregion

        #region Methods

        public bool IsConsigneeOrImporterPage => _driver.WaitForElement(ConsigneePageHeaderBy).Text.Contains("Consignee or importer");
        
        public void ClickConsignee(string consigneeName, string consigneeCountry)
        {
            ConsigneeImporterLink.Click();
            AddConsignee(consigneeName, consigneeCountry);
        }

        public void ClickRemoveLink()
        {
            if (RemoveLinkList.Count > 0)
                RemoveLinkList.ElementAt(0).Click();
        }

        public void AddConsignee(string consigneeName, string consigneeCountry)
        {
            SelectConsigneeImporter(consigneeName, consigneeCountry);
            Continue.Click();
        }

        public void SelectConsigneeImporter(string consigneeName, string consigneeCountry)
        {
            SelectConsignee.Click();
            _driver.ElementImplicitWait();
            Country.Click();
            _driver.SelectFromDropdown(Country, consigneeCountry);

            if (!string.IsNullOrEmpty(consigneeName))
                OperatorName.SendKeys(consigneeName);

            OperatorSearch.Click();
            _driver.ClickRadioButton(consigneeName);
            SaveAndContinue.Click();
        }

        public bool VerifyConsigneeStatus()
        {
            return ConsigneeStatus.Text.Contains("COMPLETE");
        }
        #endregion
    }
}
