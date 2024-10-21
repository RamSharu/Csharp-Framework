using BoDi;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.Exporter.DepartureAndArrival

{
    public class DepartureAndArrival : IDepartureAndArrival

    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public DepartureAndArrival(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        #region page objects
        private By DepartureArrivalPageHeaderBy => By.CssSelector(".ArrivalAndDeparture .govuk-heading-xl");
        private IWebElement ArrivalDate => _driver.WaitForElement(By.CssSelector("input[name='arrival']"));
        private IWebElement DepartureAndArrivalDateStatusText => _driver.WaitForElement(By.CssSelector("div#departure-and-arrival.govuk-summary-list__row span.govuk-tag"));
        private IWebElement DepartureAndArrivalLink => _driver.WaitForElement(By.CssSelector("div#departure-and-arrival dt.govuk-summary-list__key a.govuk-link"));
        private IWebElement DepartureDate => _driver.WaitForElement(By.CssSelector("input[name='departure']"));
        private IWebElement SaveAndReturn => _driver.WaitForElement(By.Id("submitButton"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("submitButton"));
        private IWebElement SkipValidationInText => _driver.WaitForElement(By.CssSelector("a[href='#skip-question']"));
        private IWebElement SkipCheckBoxText => _driver.WaitForElement(By.CssSelector("label[for='skip-question']"));
        private By SkipCheckboxTickedBy => By.CssSelector("input#skip-question.govuk-checkboxes__input");
        private IWebElement ValidationError => _driver.WaitForElement(By.Id("error-message"));
        #endregion

        DateTime now = DateTime.Now;
        private string arrivalDate;
        private string departureDate;

        public bool IsDepartureArrivalPage => _driver.WaitForElement(DepartureArrivalPageHeaderBy).Text.Contains("Departure and arrival");

        #region Page Methods
        public void CompleteDepartureAndArrivalDate()
        {
            
            AddDepartureAndArrivalDate();
            SaveAndContinue.Click();
        }

        public bool IsDepartureAndArrivalDatePageDisplayed()
        {
            DepartureAndArrivalLink.Click();
            return _driver.PageSource.Contains("Departure and arrival");
        }

        public bool VerifyDepartureAndArrivalDateStatus()
        {
            var departureArrivalDateStatus = DepartureAndArrivalDateStatusText.Text;
            return departureArrivalDateStatus.Contains("COMPLETE");
        }

        public void AddDepartureAndArrivalDate()
        {
            DateTime now = DateTime.Now;
            string arrivalDate = now.ToString("dd/MM/yyyy HH:mm");
            DateTime futureDate = now.AddDays(2);
            string departureDate = futureDate.ToString("dd/MM/yyyy HH:mm");

            if (!string.IsNullOrEmpty(arrivalDate))
            {
                DepartureDate.Click();
                DepartureDate.SendKeys(arrivalDate);
            }

            if (!string.IsNullOrEmpty(departureDate))
            {
                ArrivalDate.Click();
                ArrivalDate.SendKeys(departureDate);
            }
        }

        public void CompleteSkipDepartureAndArrivalDate(string skipcheckbox)
        {
            if (skipcheckbox.Contains("Yes"))
            {
                TaskList.ClickOnSkipFunction();
                SaveAndContinue.Click();
            }
            if (skipcheckbox.Contains("No"))
            {
                AddDepartureAndArrivalDate();
                SaveAndContinue.Click();
            }
            if (skipcheckbox.Contains("Message information"))
            {
                SaveAndContinue.Click();
            }
        }

        public void ClickSaveAndContinue() => SaveAndContinue.Click();

        public void EditDepartureAndArrivalDates()
        {
            departureDate = now.AddDays(1).ToString("dd/MM/yyyy HH:mm");
            arrivalDate = now.AddDays(3).ToString("dd/MM/yyyy HH:mm");

            EnterDepartureDate(departureDate);
            EnterArrivalDate(arrivalDate);
        }

        public void EnterDepartureDate(string departureDate)
        {
            DepartureDate.Click();
            DepartureDate.SendKeys(departureDate);
        }

        public void EnterArrivalDate(string arrivalDate)
        {
            ArrivalDate.Click();
            ArrivalDate.SendKeys(arrivalDate);
        }

        public bool VerifySkipValidationInformation()
        {
            var SkipValidationStatus = SkipValidationInText.Text;
            return SkipValidationStatus.Contains("Select if you have answered");
        }

        public bool IsSkipChecked()
        {
            DepartureAndArrivalLink.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(SkipCheckboxTickedBy).Selected);
            return true;
        }
                
        public void CompleteDepartureDate()
        {
            AddDepartureDate();
            SaveAndContinue.Click();
        }
        public void CompleteArrivalDate()
        {
            AddArrivalDate();
            SaveAndContinue.Click();
        }

        public void AddDepartureDate()
        {
            DateTime now = DateTime.Now;
            string arrivalDate = now.ToString("dd/MM/yyyy HH:mm");
            DateTime futureDate = now.AddDays(2);
            string departureDate = futureDate.ToString("dd/MM/yyyy HH:mm");

            if (!string.IsNullOrEmpty(departureDate))
            {
                DepartureDate.Click();
                DepartureDate.SendKeys(departureDate);
            }
        }

        public void AddArrivalDate()
        {
            DateTime now = DateTime.Now;
            string arrivalDate = now.ToString("dd/MM/yyyy HH:mm");
            DateTime futureDate = now.AddDays(2);
            string departureDate = futureDate.ToString("dd/MM/yyyy HH:mm");

            if (!string.IsNullOrEmpty(arrivalDate))
            {
                ArrivalDate.Click();
                ArrivalDate.SendKeys(arrivalDate);
            }
        } 

        public bool VerifyValidationError(string validationError)
        {
            return ValidationError.Text.Contains(validationError);
        }

        #endregion
    }
}