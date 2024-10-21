using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ContainerOrSealNumberSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public ContainerOrSealNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IContainerOrSealNo? ContainerOrSealNo => _objectContainer.IsRegistered<IContainerOrSealNo>() ? _objectContainer.Resolve<IContainerOrSealNo>() : null;

        [Given(@"complete '([^']*)' and '([^']*)' and continue")]
        [When(@"complete '([^']*)' and '([^']*)' and continue")]
        public void WhenCompleteAndAndContinue(string containerno, string sealno)
        {
            ContainerOrSealNo.CompleteContainerSealNumber(containerno, sealno);
        }

        [Then(@"verify container and seal number has been added successfully")]
        public void ThenVerifyContainerAndSealNumberHasBeenAddedSuccessfully()
        {
            Assert.True(ContainerOrSealNo.ContainerSealNoStatus(), "Container or Seal Number not completed");

        }

        [When(@"I navigate to container seal number page")]
        public void WhenINavigateToContainerSealNumberPage()
        {
            Assert.True(ContainerOrSealNo.IsContainerSealNumberPageDisplayed(), "Container page not displayed");
        }

    }
}
