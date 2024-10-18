using BoDi;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.Exporter.GrossWeight
{
    public class GrossWeight : IGrossWeight
    {
        private IObjectContainer _objectContainer;

        public GrossWeight(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region page objects
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private By GrossWeightPageHeaderBy => By.CssSelector(".CertificateWeightPage h1.govuk-heading-xl");
        private IWebElement GrossWeightLink => _driver.WaitForElement(By.CssSelector("div#gross-weight dt.govuk-summary-list__key a.govuk-link"));
        private IWebElement GrossWeightAmount => _driver.WaitForElement(By.Id("gross-weight-amount"));
        private IWebElement GrossWeightUnit => _driver.WaitForElement(By.Id("gross-weight-amount-units"));
        private IWebElement ConfirmAndSend => _driver.WaitForElement(By.Id("submitButton"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("submitButton"));
        private IWebElement GrossWeightStatusText => _driver.WaitForElement(By.CssSelector("div#gross-weight.govuk-summary-list__row span.govuk-tag"));
        private IWebElement SkipValidationInText => _driver.WaitForElement(By.CssSelector("#error-summary-title"));
        private IWebElement GrossWeightNetWeightValidationText => _driver.WaitForElement(By.CssSelector("ul.govuk-error-summary__list li a"));
        private IWebElement GrossWeightNetWeightFieldValidationText => _driver.WaitForElement(By.CssSelector("p#gross-weight-amount-error.govuk-error-message"));
        private IWebElement SkipFunction => _driver.WaitForElement(By.XPath("//input[@id='skip-question']"));
        private IWebElement BackLink => _driver.FindElement(By.ClassName("govuk-back-link"));

        #endregion

        #region Page Methods
        public bool IsGrossWeightPage => _driver.WaitForElement(GrossWeightPageHeaderBy).Text.Contains("total weight");

        public void CompleteGrossWeight(string grossWeightamount, string grossWeightunit)
        {
            AddGrossWeight(grossWeightamount, grossWeightunit);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void AddGrossWeightAmount(string grossWeightamount, string grossWeightunit)
        {
            GrossWeightAmount.Clear();
            GrossWeightAmount.Click();
            GrossWeightAmount.SendKeys(grossWeightamount);
            SelectElement dropDown = new SelectElement(GrossWeightUnit);
            dropDown.SelectByValue(grossWeightunit);
            SaveAndContinue.Click();
        }

        public bool VerifyGrossWeightStatus()
        {
            var grossWeightStatus = GrossWeightStatusText.Text;
            return grossWeightStatus.Contains("COMPLETE");
        }

        public void CompleteGrossWeightWithSkipFun(string grossWeightamount, string grossWeightunit, string skipCheckbox)
        {
            AddGrossWeight(grossWeightamount, grossWeightunit);

            if (skipCheckbox.Contains("Yes"))
            {
                TaskList.ClickOnSkipFunction();
            }
            SaveAndContinue.Click();
        }

        public void AddGrossWeight(string grossWeightamount, string grossWeightunit)
        {
            GrossWeightLink.Click();

            if (!string.IsNullOrEmpty(grossWeightamount))
            {
                GrossWeightAmount.Clear();
                GrossWeightAmount.Click();
                GrossWeightAmount.SendKeys(grossWeightamount);
            }

            if (!string.IsNullOrEmpty(grossWeightunit))
            {
                SelectElement weightUnitDropDown = new SelectElement(GrossWeightUnit);
                weightUnitDropDown.SelectByValue(grossWeightunit);
            }
        }

        public bool VerifySkipValidationInformation()
        {
            var SkipValidationStatus = SkipValidationInText.Text;
            return SkipValidationStatus.Contains("There is a problem");
        }
        public bool VerifyGrossAgainstNetWeightValidationMessage()
        {
            var GrossWeightValidation = GrossWeightNetWeightValidationText.Text;
            return GrossWeightValidation.Contains("The gross weight of the commodities cannot be less than the net weight");
        }

        public bool VerifyGrossAgainstNetWeightFieldValidationMessage()
        {
            var GrossWeightFieldValidation = GrossWeightNetWeightValidationText.Text;
            return GrossWeightFieldValidation.Contains("The gross weight of the commodities cannot be less than the net weight");
        }

        public bool VerifyGrossWeightAmount(string grossWeightamount)
        {
            GrossWeightLink.Click();
            _driver.WaitForElement(GrossWeightPageHeaderBy).Text.Contains("total weight");
            //Thread.Sleep(1000);  
            return GrossWeightAmount.GetAttribute("value").Equals(grossWeightamount);
        }

        public bool VerifyskipErrorValidationOnPage(string errorMessage)
        {
            IWebElement skipError = _driver.FindElement(By.Id("skipError"));
            return skipError.Text.Contains(errorMessage);
        }

        public bool VerifyGrossWeightAmountErrorValidationOnPage(string errorMessage)
        {
            IWebElement skipError = _driver.FindElement(By.Id("gross-weight-amount-error"));
            return skipError.Text.Contains(errorMessage);
        }
        public bool VerifyGrossWeightUnitErrorValidationOnPage(string errorMessage)
        {
            IWebElement skipError = _driver.FindElement(By.Id("gross-weight-amount-units-error"));
            return skipError.Text.Contains(errorMessage);
        }

        public void GrossWeightUnitAndGrossWeightAmountBlank(string grossWeightunit)
        {
            SelectElement grossWeightUnitDropdown = new SelectElement(GrossWeightUnit);
            grossWeightUnitDropdown.SelectByValue(grossWeightunit);
            SaveAndContinue.Click();
        }

        public void ClickBackLink() => BackLink.Click();

        public void ClickSaveAndContinue() => SaveAndContinue.Click();

        public void FillGrossWeight()
        {
            GrossWeightAmount.Clear();
            GrossWeightAmount.Click();
            GrossWeightAmount.SendKeys("1");
            SelectElement dropDown = new SelectElement(GrossWeightUnit);
            dropDown.SelectByValue("KGM");
        }

        public void FillGrossWeightUnit()
        {
            SelectElement dropDown = new SelectElement(GrossWeightUnit);
            dropDown.SelectByValue("KGM");
        }

        public void FillGrossWeightAmount()
        {
            GrossWeightAmount.Clear();
            GrossWeightAmount.Click();
            GrossWeightAmount.SendKeys("1");
        }
        #endregion
    }
        
}