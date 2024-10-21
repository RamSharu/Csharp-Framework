using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.ApplicationComplete
{
    public class ApplicationComplete : IApplicationComplete
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ApplicationComplete(ObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private By ApplicationStatus => By.XPath("//h1[@class='govuk-panel__title']");
        private IWebElement FinishButton => _driver.WaitForElement(By.XPath("//a[contains(text(),'Finish')]"));
        private IWebElement SerialRefElement => _driver.WaitForElement(By.Id("application-serial-reference"));
        #endregion

        #region Methods
        public bool IsApplicationCompletePage
        {
            get => _driver.WaitForElement(ApplicationStatus).Text.Contains("Application complete");
        }

        public void ClickFinishButton() => FinishButton.Click();

        public string GetApplicationSerialReference()
        {
            return SerialRefElement.Text;
        }

        #endregion
    }
}
