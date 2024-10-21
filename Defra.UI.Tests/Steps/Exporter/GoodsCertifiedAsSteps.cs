using BoDi;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class GoodsCertifiedAsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public GoodsCertifiedAsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IGoodsCertifiedAs? GoodsCertifiedAs => _objectContainer.IsRegistered<IGoodsCertifiedAs>() ? _objectContainer.Resolve<IGoodsCertifiedAs>() : null;

        [Then(@"verify goods certified has been added successfully")]
        public void ThenVerifyGoodsCertifiedHasBeenAddedSuccessfully()
        {
            Assert.True(GoodsCertifiedAs.GoodsCertifiesAsStatus(), "Good certified as not completed");
        }

        [When(@"select goods certified as '([^']*)' and continue")]
        public void WhenSelectGoodsCertifiedAs(string goodsCertifiedasValue)
        {
            GoodsCertifiedAs.ClickGoodsCertifiedAsValue(goodsCertifiedasValue);
        }
    }
}