using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.ReviewAndCheck
{
    public class ReviewAndCheck : IReviewAndCheck
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ReviewAndCheck(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private By ReviewAndCheckPageHeaderBy => By.CssSelector(".CheckAnswers .govuk-heading-xl");
        private IWebElement ConfirmAndSubmitButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Confirm and submit')]"));
        #endregion

        #region Methods

        public bool IsReviewAndCheckPage
        {
            get => _driver.WaitForElement(ReviewAndCheckPageHeaderBy).Text.Contains("Exporter declaration");
        }

        public void ClickConfirmCheckBox() => _driver.ClickRadioButton("I confirm");

        public void ClickConfirmAndSubmitButton() => ConfirmAndSubmitButton.Click();
        #endregion
    }
}
