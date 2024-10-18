using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.RegionOfCertification;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class RegionOfCertificationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;


        public RegionOfCertificationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IRegionOfCertification RegionOfCertification => _objectContainer.IsRegistered<IRegionOfCertification>() ? _objectContainer.Resolve<IRegionOfCertification>() : null;

        [Then(@"navigate to region of certification page")]
        public void ThenNavigateToRegionOfCertificationPage()
        {
            Assert.True(RegionOfCertification.IsRegionOfCertificationDisplayed(), "(Region of certification page not displayed");
        }

        [Then(@"select the region of certification '([^']*)' and continue")]
        public void ThenSelectTheRegionOfCertificationAndContinue(string region)
        {
            RegionOfCertification.RegionOfCertificationtButton(region);
        }

        [Then(@"verify region of certification has been completed successfully")]
        public void ThenVerifyRegionOfCertificationHasBeenCompletedSuccessfully()
        {
            Assert.True(RegionOfCertification.RegionOfCertificationStatus(), "Region of certification not completed successfully");
        }
    }
}