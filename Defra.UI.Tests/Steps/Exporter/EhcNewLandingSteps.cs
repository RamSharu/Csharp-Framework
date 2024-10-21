using BoDi;
using Defra.UI.Tests.Pages.Exporter.EhcNewLanding;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class EhcNewLandingSteps
    {
        private readonly IObjectContainer _objectContainer;

        public EhcNewLandingSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IEhcNewLanding EhcNewLanding => _objectContainer.IsRegistered<IEhcNewLanding>() ? _objectContainer.Resolve<IEhcNewLanding>() : null;

        [Given(@"I click on start now button from Ehc New Landing page")]
        public void ThenStartANewApplicationAndClickStartNow()
        {
            Assert.True(EhcNewLanding.IsEhcNewLandingPage, "Ehc new landing page is not displayed after we click on start a new application button from home page");
            EhcNewLanding.ClickStartNowButton();
        }
    }
}
