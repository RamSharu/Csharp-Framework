using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.MeansOfTransport
{
    public class Transport : ITransport
    {
        private IObjectContainer _objectContainer;

        public Transport(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects

        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;
        private By MeansOfTransportPageHeaderBy => By.CssSelector(".MeansOfTransport .govuk-heading-xl");
        private IWebElement TransportElement =>
            _driver.WaitForElement(
                By.CssSelector("div#means-of-transport dt.govuk-summary-list__key a.govuk-link"));

        private IWebElement Condition => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.CssSelector("div.MeansOfTransport #tcondition")));
        private IWebElement AmbientCondition => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.XPath("//input[@value='Ambient']")));
        private IWebElement MeansOfTransport => _driver.WaitForElement(By.CssSelector("div.MeansOfTransport #meansOfTransportSelection"));
        private IWebElement AddMeansOfTransport => _driver.WaitForElement(By.XPath("//button[contains(.,'Add means of transport')]"));
        private IWebElement Identifier => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("identifier-0")));
        private IWebElement SaveAndReturn => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement VehicleReg => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("vehicle-registration-1")));
        private IWebElement VehicleTrailer => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("vehicle-trailer-number-1")));
        private IWebElement Country => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("country-1")));
        private IWebElement FlightNumber => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("flight-number-2")));
        private IWebElement ShipName => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("ship-name-3")));
        private IWebElement FlagState => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("flag-state-3")));
        private IWebElement ImoNumber => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id("imo-number-3")));
        private IWebElement TransportStatus => _driver.WaitForElement(TransportStatusBy);
        private By TransportStatusBy => By.CssSelector("div#means-of-transport.govuk-summary-list__row span.govuk-tag span");
        private IWebElement SkipValidationInText => _driver.WaitForElement(By.Id("skipError"));
        private By SkipCheckboxBy => By.XPath("//input[@id='skip-question']");
        #endregion

        #region Methods

        public bool IsMeansOfTransportPage => _driver.WaitForElement(MeansOfTransportPageHeaderBy).Text.Contains("Means of transport");
        
        public bool VerifyTransport()
        {
            TransportElement.Click();
            Condition.Click();
            _driver.SelectFromDropdown(MeansOfTransport, "Railway");
            AddMeansOfTransport.Click();

            Identifier.Click();
            Identifier.SendKeys("123");

            _driver.SelectFromDropdown(MeansOfTransport, "Road");
            AddMeansOfTransport.Click();
            VehicleReg.SendKeys("AX54KJU");
            VehicleTrailer.SendKeys("1234");
            _driver.SelectFromDropdown(Country, "XI");

            _driver.SelectFromDropdown(MeansOfTransport, "Airplane");
            AddMeansOfTransport.Click();
            FlightNumber.SendKeys("AX123");

            _driver.SelectFromDropdown(MeansOfTransport, "Vessel");
            AddMeansOfTransport.Click();
            ShipName.SendKeys("ShipName");
            _driver.SelectFromDropdown(FlagState, "CO");
            ImoNumber.SendKeys("321");

            SaveAndReturn.Click();
            return true;
        }

        public void EditTransportCondition()
        {
            AmbientCondition.Click();
            SaveAndReturn.Click();
        }

        public bool IsTransportDetailsCompleted()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(TransportStatusBy).Text.Contains("COMPLETE"));
            return true;
        }

        public void SelectTransport(string transportCondition, string meansOfTransport)
        {
            TransportElement.Click();
            ClickTransportConditionRadio(transportCondition);
            _driver.SelectFromDropdown(MeansOfTransport, meansOfTransport);
            AddMeansOfTransport.Click();
            Identifier.Click();
            Identifier.SendKeys("123");
            SaveAndReturn.Click();
        }

        private void ClickTransportConditionRadio(string transportCondition)
        {
            IWebElement transportCondLabel = _driver.WaitForElement(By.XPath($"//label[contains(.,'{transportCondition}')]"));
            transportCondLabel.Click();
        }

        public bool CompleteMeansOfTransport(string transCondition, string meansOfTrans, string skipCheckbox)
        {
            TransportElement.Click();

            if (!string.IsNullOrEmpty(transCondition))
            {
                Condition.Click();
            }

            if (meansOfTrans.Contains("Railway"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Railway");
                AddMeansOfTransport.Click();
                Identifier.Click();
                Identifier.SendKeys("123");
            }

            if (meansOfTrans.Contains("Road"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Road");
                AddMeansOfTransport.Click();
                VehicleReg.SendKeys("AX54KJU");
                VehicleTrailer.SendKeys("1234");
                _driver.SelectFromDropdown(Country, "XI");
            }

            if (meansOfTrans.Contains("Airplane"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Airplane");
                AddMeansOfTransport.Click();
                FlightNumber.SendKeys("AX123");
            }

            if (meansOfTrans.Contains("Vessel"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Vessel");
                AddMeansOfTransport.Click();
                ShipName.SendKeys("ShipName");
                _driver.SelectFromDropdown(FlagState, "CO");
            }

            if (meansOfTrans.Contains("Multiple"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Road");
                AddMeansOfTransport.Click();
                _driver.SelectFromDropdown(MeansOfTransport, "Vessel");
                AddMeansOfTransport.Click();
            }

            if (meansOfTrans.Contains("OneIncomplete"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Railway");
                AddMeansOfTransport.Click();
                Identifier.Click();
                Identifier.SendKeys("123");
                _driver.SelectFromDropdown(MeansOfTransport, "Vessel");
                AddMeansOfTransport.Click();
            }

            if (skipCheckbox.Contains("Yes"))
            {
                TaskList.ClickOnSkipFunction();
            }

            SaveAndReturn.Click();
            return true;
        }

        public bool VerifyTransportValidationMessage()
        {
            var SkipValidationStatus = SkipValidationInText.Text;
            return SkipValidationStatus.Contains("if you have answered as many questions");
        }

        public bool IsMeansOfTransportSkipCheckboxVisible()
        {
            try
            {
                _driver.FindElement(SkipCheckboxBy);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion
    }
}
