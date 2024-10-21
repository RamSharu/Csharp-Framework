using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Defra.UI.Tests.HelperMethods;

namespace Defra.UI.Tests.Pages.Exporter.Consignor
{
    public class ConsignorPage : IConsignorPage
    {
        private IObjectContainer _objectContainer;

        public ConsignorPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        private readonly object _lock = new object();

        #region Page Objects
        private By ConsignorPageHeaderBy => By.CssSelector(".Consignor h1.govuk-heading-xl");
        private List<IWebElement> RemoveLinkList => _driver.WaitForElements(By.XPath("//a[contains(text(),'Remove')]")).ToList();
        private IWebElement SelectExporterOrConsignorLink => _driver.WaitForElement(By.CssSelector(".find-establishment-link a"));
        private IWebElement BackLink => _driver.WaitForElement(By.CssSelector(".Consignor .govuk-back-link"));
        private IWebElement ExporterOrConsignorCaption => _driver.WaitForElement(By.CssSelector(".Consignor .govuk-caption-xl"));
        private IWebElement ExporterOrConsignorDesc => _driver.WaitForElement(By.XPath("//div[@class='operator-search']/preceding-sibling::p"));
        private IWebElement Country => _driver.WaitForElement(By.Id("operator-country"));
        private IWebElement OperatorName => _driver.WaitForElement(By.XPath("//input[@id='operator-search']"));
        private IWebElement OperatorSearch => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//a[contains(.,'Continue')]"));
        private IWebElement ConsignorActivity=> _driver.WaitForElement(By.CssSelector(".govuk-radios__item .govuk-hint"));
        private IWebElement ConsignorStatus => _driver.WaitForElement(By.XPath("//a[contains(text(),'Exporter or Consignor')]/../following-sibling::dd/span/span"));

        //Elements after Consignor and Activity are added
        private List<IWebElement> ConsignorNameAndAddressAdded => _driver.WaitForElements(By.XPath("//div[contains(@class,'operator-search')]//p[@class='govuk-body'][1]//*[@data-testid]")).ToList();
        private IWebElement ConsignorActivityAdded => _driver.WaitForElement(By.XPath("//div[contains(@class,'operator-search')]//p[@class='govuk-body'][2]"));
        private IWebElement ChangeActivityLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Change activity')]"));

        #endregion

        #region Page Methods

        public bool IsConsignorOrExporterPage => _driver.WaitForElement(ConsignorPageHeaderBy).Text.Contains("Exporter or consignor");

        public string GetConsignorOrExporterPageHeaderText => _driver.WaitForElement(ConsignorPageHeaderBy).Text.Trim();
        public bool IsBackLinkDisplayed => BackLink.Displayed;
        public bool IsContinueButtonDisplayed => Continue.Displayed;
        public string GetExporterConsignorCaption => ExporterOrConsignorCaption.Text.Trim();
        public string GetExporterConsignorDesc => ExporterOrConsignorDesc.Text.Trim();
        public string GetExporterConsignorLinkText => SelectExporterOrConsignorLink.Text.Trim();

        public void ClickSelectExporterOrConsignorLink() => SelectExporterOrConsignorLink.Click();
        public void ClickChangeActivityLink() => ChangeActivityLink.Click();

        public void AddConsignor(string consignorName)
        {
            AddConsignorData(consignorName);
        }

        public void SearchConsignor(string consignorName)
        {
            SelectExporterOrConsignorLink.Click();
            if (!string.IsNullOrEmpty(consignorName))
                OperatorName.SendKeys(consignorName);
            OperatorSearch.Click();
        }

        public void AddConsignorData(string consignorName)
        {
            //if (RemoveLinkList.Count > 0)
                //RemoveLinkList.ElementAt(0).Click();
            SelectExporterOrConsignor(consignorName);
            SelectConsignorActivity();
            SaveAndContinue.Click();
            Continue.Click();
        }

        public void FindConsignorData(string consignorName)
        {
            if (RemoveLinkList.Count > 0)
                RemoveLinkList.ElementAt(0).Click();
            SelectExporterOrConsignor(consignorName);
            Continue.Click();
        }

        public void SelectConsignorActivity()
        {
            _driver.ClickRadioButton("Exporter");
        }

        public void SelectExporterOrConsignor(string consignorName)
        {
            SelectExporterOrConsignorLink.Click();
            _driver.ElementImplicitWait();
            if (!string.IsNullOrEmpty(consignorName))
                OperatorName.SendKeys(consignorName);

            OperatorSearch.Click();
            _driver.ClickRadioButton(consignorName);
            SaveAndContinue.Click();
        }

        public bool VerifyConsignorStatus()
        {
            return ConsignorStatus.Text.Contains("COMPLETE");
        }

        public bool VerifyConsignorActivity()
        {
            return ConsignorActivity.Displayed;
        }

        public bool ValidateConsignorAndAddressIfAdded()
        {
            foreach(var consNameAddress in ConsignorNameAndAddressAdded)
            {
                if (string.IsNullOrEmpty(consNameAddress.Text))
                    return false;
            }
            return true;
        }

        public bool ValidateConsignorActivityIfAdded => !string.IsNullOrEmpty(ConsignorActivityAdded.Text);

        public string GetConsignorActivity => ConsignorActivityAdded.Text;
        #endregion
    }
}
