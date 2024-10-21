using BoDi;
using Defra.UI.Tests.Pages.Exporter.SelectCertifier;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{

    [Binding]
    public class SelectCertifierSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public SelectCertifierSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISelectCertifier SelectCertifier => _objectContainer.IsRegistered<ISelectCertifier>() ? _objectContainer.Resolve<ISelectCertifier>() : null;

        [When(@"navigate to select certifier page")]
        public void WhenNavigateToSelectCertifierPage()
        {
            Assert.True(SelectCertifier.IsSelectCertifierPageDisplayed(), "Certifier page not displayed");
        }

        [When(@"select certifier '([^']*)' and continue")]
        public void WhenSelectCertifierAndContinue(string certifierName)
        {
            SelectCertifier.ClickSelectCertifier(certifierName);
        }

        [Then(@"verify certifier has been added successfully")]
        public void ThenVerifyCertifierHasBeenAddedSuccessfully()
        {
            Assert.True(SelectCertifier.VerifyCertifierStatus(), "Certifier has not been selected");
        }
    }
}