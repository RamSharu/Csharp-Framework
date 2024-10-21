using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.UI.Tests.Pages.Exporter.CommoditySummary
{
    public class CommoditySummary : ICommoditySummary
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private IWebElement ChangeLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Change') and contains(@class, 'govuk-link--no-visited-state')]"));
        private IWebElement CopyLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Copy') and contains(@class, 'govuk-link--no-visited-state')]"));
        private By PageHeadingBy => By.CssSelector("div.CommoditySummaryPage h1.govuk-heading-xl");
        private IWebElement ShowDetails => _driver.WaitForElement(By.ClassName("govuk-accordion__section-toggle"));
        private By SummaryTextBy => By.XPath("//dl/div[contains(@class, 'govuk-grid-row')]");
        private IReadOnlyCollection<IWebElement> ContinueButton => _driver.WaitForElements(By.TagName("button"));
        private List<IWebElement> RadioButtonGroup => _driver.FindElements(By.ClassName("govuk-radios__input")).ToList();
        IWebElement ExporterContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Continue')]"));
        #endregion

        public CommoditySummary(ObjectContainer container)
        {
            _objectContainer = container;
        }
        #region Methods
        public bool IsCommoditiesSummaryPage => !string.IsNullOrEmpty(_driver.WaitForElement(PageHeadingBy).Text);
        public void ClickChangeLink() => ChangeLink.Click();
        public void ClickCopyLink() => CopyLink.Click();

        public bool IsCommoditySummaryPage()
        {
            return _driver.WaitForElement(PageHeadingBy).Displayed;
        }

        public void ClickShowDetails() => ShowDetails.Click();

        public bool IsLabelTagNotEntered()
        {
            return _driver.WaitForElement(SummaryTextBy).Text.Contains("Not entered");
        }

        public void ClickNoForAddMoreRecords(string No)
        {
            _driver.ClickRadioButton(No);
            var borderElement = ContinueButton.Where(e => e.Text.Contains("Continue")).ToArray()[0];
            borderElement.Click();
        }

        public void ClickRadioOptionForAnotherRecord(string radioOption)
        {
            if (radioOption.Contains("yes"))
                RadioButtonGroup[0].Click();
            else if (radioOption.Contains("no"))
                RadioButtonGroup[1].Click();
            else
                throw new Exception("Radio option is neither yes nor no");

            ExporterContinue.Click();
        }
        #endregion
    }
}
