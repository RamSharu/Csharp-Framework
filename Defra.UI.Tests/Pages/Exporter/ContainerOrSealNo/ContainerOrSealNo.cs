using BoDi;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo
{
    public class ContainerOrSealNo : IContainerOrSealNo
    {
        private IObjectContainer _objectContainer;

        public ContainerOrSealNo(IObjectContainer container)
        {
            _objectContainer = container;
        }


        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement ContainerOrSealNoLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Container number/seal number (optional)')]"));
        private IWebElement AddNewRow => _driver.WaitForElement(AddNewRowBy);
        private IWebElement ContainerNo => _driver.WaitForElement(ContainerNoBy);
        private IWebElement SealNo => _driver.WaitForElement(SealNoBy);
        private IWebElement SaveAndReturn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and return to task list')]"));
        private IWebElement ContainerSealStatusText => _driver.WaitForElement(By.XPath("//*[@id='container-number/seal-number-(optional)']/dd/span/span"));
        private IWebElement ApplicationHeader => _driver.WaitForElement(By.CssSelector("div.ContainerSealNumber h1.govuk-heading-xl"));
        private IList <IWebElement> ContainerNoList => _driver.FindElements(ContainerNoBy);
        private IList<IWebElement> SealNoList => _driver.FindElements(SealNoBy);
        private By ContainerNoBy => By.XPath("//input[@name='containerNumber']");

        private By SealNoBy => By.XPath("//input[@name='sealNumber']");
        private By AddNewRowBy => By.XPath("//a[@id='add-a-new-table-row']");



        public void CompleteContainerSealNumber(string containerNo, string sealNo)
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(AddNewRowBy));
            AddNewRow.Click();
            AddContainerSealNumber(containerNo, sealNo);
        }

        public void ContainerAndSealNumberIsRemoved()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(ContainerNoBy));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(SealNoBy));
        }

        public void ClearContainerSealNumber()
        {
            ContainerNo.Clear();
            SealNo.Clear();
        }

        public void AddContainerSealNumber(string containerNo, string sealNo)
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(ContainerNoBy));
            ContainerNo.SendKeys(containerNo);
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SealNoBy));
            SealNo.SendKeys(sealNo);
            SaveAndReturn.Click();
        }

        public bool ContainerSealNoStatus()
        {//EhcTaskList
            var containerSealNoStatus = ContainerSealStatusText.Text;
            return containerSealNoStatus.Contains("COMPLETE");
        }

        public bool IsContainerSealNumberPageDisplayed()
        {
            ContainerOrSealNoLink.Click();
            var pageHeaderText = ApplicationHeader.Text;
            return pageHeaderText.Contains("Container and seal numbers");
        }
    }
}
