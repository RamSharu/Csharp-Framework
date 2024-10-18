using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Common.Signin
{
    public class Signin : ISignin
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        #region Page Objects
        private By UserIdBy => By.Id("user_id");
        private By ContinueSelectorBy => By.Id("continue");
        private By SignInConfirmBy => By.CssSelector("ul.navbar-nav a.nav-link");
        private By SignOutConfirmMessageBy => By.CssSelector("h1.govuk-heading-xl");
        private By MenuButtonBy => By.CssSelector("button.govuk-header__menu-button");
        private IWebElement UserId => _driver.FindElement(UserIdBy);
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public Signin(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return _driver.WaitForElement(UserIdBy).Displayed;
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(ContinueSelectorBy)).Click();

            if (!Platform.Equals("Desktop"))
                _driver.WaitForElement(MenuButtonBy).Click();

            int count = _driver.WaitForElements(SignInConfirmBy).Count(d => d.Text.Trim().Equals("Sign out"));

            return count > 0;
        }

        public void ClickSignedOut()
        {
            _driver.WaitForElements(SignInConfirmBy).SingleOrDefault(d => d.Text.Trim().Equals("Sign out")).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return _driver.WaitForElement(SignOutConfirmMessageBy).Displayed;
        }
    }
}
