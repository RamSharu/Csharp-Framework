using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.CopyApplication
{
    public class CopyApplication : ICopyApplication
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By ContinueButtonBy => By.XPath("//div[@class='CopyApplicationOption']//button[contains(text(),'Continue')]");
        private IWebElement BackLink => _driver.FindElement(By.ClassName("govuk-back-link"));
        private By CopyApplicationHeaderBy => By.CssSelector(".CopyApplicationOption .govuk-heading-xl");
        private IWebElement CopyApplicationHeader => _driver.FindElement(CopyApplicationHeaderBy);
        private List<IWebElement> ApplicationDetailsList => _driver.FindElements(By.ClassName("govuk-summary-list__key")).ToList();
        private List<IWebElement> CopyEverythingRadioGroup => _driver.FindElements(By.ClassName("govuk-radios__input")).ToList();
        private IWebElement ContinueButton => _driver.FindElement(ContinueButtonBy);
        #endregion

        public CopyApplication(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsCopyApplicationPage
        {
            get => _driver.WaitForElement(CopyApplicationHeaderBy).Text.Contains("Copy application");
        }

        public bool IsBackLinkDisplayed => BackLink.Displayed;

        public bool IsCopyApplicationHeaderDisplayed => !string.IsNullOrEmpty(CopyApplicationHeader.Text);

        public bool IsContinueButtonDisplayed => ContinueButton.Displayed;

        public bool ValidateApplicationDetails()
        { 
            foreach(var applicationDetails in ApplicationDetailsList)
            {
                var appDetailsText = applicationDetails.Text.Trim();
                if (string.IsNullOrEmpty(applicationDetails.Text))
                    return false;

                if (appDetailsText.Contains("Serial No") || appDetailsText.Contains("Reference") || appDetailsText.Contains("Certificate") || appDetailsText.Contains("Consignee"))
                    return true;
            }
            return false;
        }

        public bool ValidateCopyRadioButtons()
        {
            foreach(var radioItem in CopyEverythingRadioGroup)
            {
                var radioOption = radioItem.GetAttribute("id");
                if (radioOption.Contains("yes") || radioOption.Contains("no"))
                    return true;
            }
            return false;
        }

        public void ClickCopyRadioOption(string radioOption)
        {
            if (radioOption.Contains("yes"))
                CopyEverythingRadioGroup[0].Click();
            else if (radioOption.Contains("no"))
                CopyEverythingRadioGroup[1].Click();
            else
                throw new Exception("Radio option is neither yes nor no");
        }

        public void ClickContinueButton()
        {
            _driver.WaitForElement(ContinueButtonBy);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(ContinueButton);
            actions.Perform();
            ContinueButton.Click();

            _driver.WaitForElementCondition(ExpectedConditions.InvisibilityOfElementLocated(ContinueButtonBy));
        }
    }
}
