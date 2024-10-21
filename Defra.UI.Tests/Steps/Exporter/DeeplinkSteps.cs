using BoDi;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Pages.Exporter.Applications;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{

    [Binding]
    public class DeeplinkSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private readonly object _lock = new object();
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        public DeeplinkSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }
 
        [Given(@"I deeplink to the commodity selection page with certificate '([^']*)'")]
        [When(@"I deeplink to the commodity selection page with certificate '([^']*)'")]
        [Then(@"I deeplink to the commodity selection page with certificate '([^']*)'")]
        public void ThenIDeeplinkToTheCommoditySelectionPageWithCertificate(string certificate)
        {
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                string url = UrlBuilder.Default().Add("Export-health-certificate")
                    .Add("Commodity")
                    .Add("Add")
                    .Add(applicationres.ApplicationId)
                    .Add(certificate).Build();

                _driver.Navigate().GoToUrl(url);
            }
        }

        [Then(@"I deeplink to the EHC summary page")]
        [When(@"I deeplink to the EHC summary page")]
        public void ThenIDeeplinkToTheEHCSummaryPage()
        {
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                string url = UrlBuilder.Default().Add("Export-health-certificate")
                    .Add("Summary")
                    .Add(applicationres.ApplicationId)
                    .Build();

                _driver.Navigate().GoToUrl(url);
            }

        }

    }
}
