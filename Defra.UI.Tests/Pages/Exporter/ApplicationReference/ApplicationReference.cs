using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.ApplicationReference
{
    public class ApplicationReference : IApplicationReference
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By CopyApplicationReferenceHeaderBy => By.CssSelector(".CopyApplicationReference .govuk-heading-xl");
        private By ApplicationReferenceHeaderBy => By.CssSelector(".EhcReference .govuk-heading-xl");
        private By ApplicationReferenceBy => By.Id("ref");
        private By ClickSaveAndContinueBy => By.Id("save-button");
        private By CreateCopyButtonBy => By.XPath("//button[contains(text(),'Create copy')]");
        private IWebElement SaveAndContinue => _driver.FindElement(ClickSaveAndContinueBy);
        private IWebElement CreateCopyButton => _driver.FindElement(CreateCopyButtonBy);
        private By ValidationErrorBy => By.ClassName("govuk-error-message");

        #endregion

        public ApplicationReference(ObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Methods

        public bool IsApplicationReferencePage
        {
            get => _driver.WaitForElement(ApplicationReferenceHeaderBy, true).Text.Contains("Your reference for this application");
        }

        public bool IsCopyApplicationReferencePage
        {
            get => _driver.WaitForElement(CopyApplicationReferenceHeaderBy, true).Text.Contains("Create a new reference");
        }

        public void ClickSaveAndContinue()
        {
            ClickButton(ClickSaveAndContinueBy, SaveAndContinue);
        }

        public void ClickCreateCopyButton()
        {
            ClickButton(CreateCopyButtonBy, CreateCopyButton);
        }

        public void ClickButton(By ButtonBy, IWebElement ButtonElement)
        {
            _driver.WaitForElement(ButtonBy);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(ButtonElement);
            actions.Perform();
            ButtonElement.Click();

            _driver.WaitForElementCondition(ExpectedConditions.InvisibilityOfElementLocated(ButtonBy));
        }

        public void CreateNewReferenceOnCopyApp()
        {
            _driver.WaitForElement(ApplicationReferenceBy).SendKeys("AddNewRef");
        }

        public string ChangeApplicationReference()
        {
            var applicationRef = "Edit_App_Ref";
            _driver.WaitForElement(ApplicationReferenceBy).SendKeys(applicationRef);
            ClickSaveAndContinue();
            return applicationRef;
        }

        public void InvalidApplicationReference(int noOfCharacters)
        {
            var applicationRef = string.Concat(Enumerable.Repeat("a", noOfCharacters + 1));
            _driver.WaitForElement(ApplicationReferenceBy).SendKeys(applicationRef);
        }

        public bool ValidationError(string error)
        {
            return _driver.WaitForElement(ValidationErrorBy).Text.Contains(error);
        }

        #endregion
    }
}
