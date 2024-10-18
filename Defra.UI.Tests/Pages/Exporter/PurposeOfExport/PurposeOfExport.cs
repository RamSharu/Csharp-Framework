using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.PurposeOfExport
{
    public class PurposeOfExport : IPurposeOfExport
    {
        private IObjectContainer _objectContainer;

        public PurposeOfExport(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private IWebElement PurposeOfExporterLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Type of consignment']"));
        private IWebElement PurposeOfExportPageHeader => _driver.WaitForElement(By.CssSelector("h1.govuk-fieldset__heading"));
        private IList<IWebElement> PurposeOfExportValidationAlert => _driver.FindElements(PurposeOfExportValidationAlertBy);
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private IWebElement PurposeOfExportStatusText => _driver.WaitForElement(By.XPath("//div[@id='type-of-consignment']//span[contains(text(),'COMPLETE')]"));
        private IWebElement PurposeOfExportValidationMessage => _driver.WaitForElement(PurposeOfExportValidationMessageBy);
        private IWebElement PurposeOfExportCountryValidationMessage => _driver.WaitForElement(PurposeOfExportCountryValidationMessageBy);
        private By PurposeOfExportValidationAlertBy => By.Id("validation-error-summary");
        private By PurposeOfExportValidationMessageBy => By.Id("consignment-type-error");
        private By PurposeOfExportCountryValidationMessageBy => By.Id("final-destination-error");
        #endregion

        #region Page Methods
        public bool IsPurposeOfExporterPageDisplayed()
        {
            PurposeOfExporterLink.Click();
            var pageHeaderText = PurposeOfExportPageHeader.Text;
            return pageHeaderText.Contains("What type of consignment are you sending?");
        }

        public void ClickPurposeOfExportButton(string purposetype)
        {

            _driver.ClickRadioButton(purposetype);
            SaveAndContinueButton.Click();
        }

        public int ClickSaveAndContinue(string purposeType)
        {
            if (!string.IsNullOrEmpty(purposeType))
            {
                _driver.ClickRadioButtonOption(purposeType);
            }
            SaveAndContinueButton.Click();
            return PurposeOfExportValidationAlert.Count();
        }

        public bool PurposeOfExportAlertMessage()
        {
            return PurposeOfExportValidationMessage.Text.Contains("Select the type of consignment you are sending");
        }

        public bool PurposeOfExportCountryAlertMessage()
        {
            return PurposeOfExportCountryValidationMessage.Text.Contains("Enter the destination country for the consignment");
        }
        public bool PurposeOfExportStatus()
        {
            var purposeOfExportStatus = PurposeOfExportStatusText.Text;
            return purposeOfExportStatus.Contains("COMPLETE");
        }
        #endregion
    }
}