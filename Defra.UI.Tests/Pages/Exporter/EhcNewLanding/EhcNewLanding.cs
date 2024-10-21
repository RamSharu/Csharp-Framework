using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.EhcNewLanding
{
    public class EhcNewLanding : IEhcNewLanding
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By EhcNewLandingPageHeaderBy => By.CssSelector(".EhcNewLanding .govuk-heading-xl");
        private IWebElement StartNowButton => _driver.WaitForElement(By.ClassName("govuk-button--start"));
        #endregion

        #region Methods

        public EhcNewLanding(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsEhcNewLandingPage
        {
            get => _driver.WaitForElement(EhcNewLandingPageHeaderBy).Text.Contains("Apply for an export health certificate");
        } 

        public void ClickStartNowButton() => StartNowButton.Click();
        #endregion
    }
}
