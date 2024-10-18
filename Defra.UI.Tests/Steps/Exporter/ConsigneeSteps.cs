using BoDi;
using Defra.UI.Tests.Pages.Exporter.Consignee;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ConsigneeSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public ConsigneeSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IConsigneePage Consignee => _objectContainer.IsRegistered<IConsigneePage>() ? _objectContainer.Resolve<IConsigneePage>() : null;


        [Then(@"add consignee '([^']*)' for '([^']*)' and continue")]
        public void ThenAddConsigneeForAndContinue(string consigneeName, string consigneeCountry)
        {
            Consignee.ClickConsignee(consigneeName, consigneeCountry);
        }

        [Then(@"verify consignee has been added successfully")]
        public void ThenVerifyConsigneeHasBeenAddedSuccessfully()
        {
            Assert.True(Consignee.VerifyConsigneeStatus(), "Consignee not added successfully");
        }
    }
}
