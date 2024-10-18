using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.WhichSectionsToCopy
{
    public class WhichSectionsToCopy : IWhichSectionsToCopy
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public WhichSectionsToCopy(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects
        private By WhichSectionsToCopyPageHeaderBy => By.CssSelector(".CopyApplicationTaskSelection .govuk-heading-xl");
        private IWebElement SelectAllCheckbox => _driver.FindElement(By.Id("select-all"));
        private IWebElement SecondCheckbox => _driver.FindElement(By.XPath("(//div[@class='govuk-checkboxes__item']/input)[2]"));
        private By ContinueButtonBy => By.XPath("//button[contains(text(), 'Continue')]");
        private IWebElement ContinueButton => _driver.FindElement(ContinueButtonBy);
        #endregion

        public bool IsWhichSectionsToCopyPage
        {
            get => _driver.WaitForElement(WhichSectionsToCopyPageHeaderBy).Text.Contains("Which sections do you want to copy?");
        }

        public void ClickSelectAllCheckbox()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(SelectAllCheckbox);
            actions.Perform();
            SelectAllCheckbox.Click();
        }

        public void ClickSecondCheckbox()
        {
            SecondCheckbox.Click();
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
