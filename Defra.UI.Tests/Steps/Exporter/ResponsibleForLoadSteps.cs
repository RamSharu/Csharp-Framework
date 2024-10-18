using NUnit.Framework;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.GrossWeight;
using Defra.UI.Tests.Pages.Exporter.ResponsibleForLoad;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ResponsibleForLoadSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public ResponsibleForLoadSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IResponsibleForLoad? ResponsibleForLoad => _objectContainer.IsRegistered<IResponsibleForLoad>() ? _objectContainer.Resolve<IResponsibleForLoad>() : null;

        [Then(@"verify responsible for load has been added successfully")]
        public void ThenVerifyResponsibleForLoadHasBeenAddedSuccessfully()
        {
            Assert.True(ResponsibleForLoad.VerifyResponsibleForLoadStatus(), "Responsible load not completed");

        }

        [When(@"I navigate to responsible for load page")]
        public void WhenINavigateToResponsibleForLoadPage()
        {
            Assert.True(ResponsibleForLoad.IsResponsibleForLoadPageDisplayed(), "Responsible for load page not displayed");
        }


        [When(@"complete responsible for load '([^']*)' and '([^']*)' and continue")]
        public void WhenCompleteResponsibleForLoadAndAndContinue(string responsibleforloadcountry, string responsibleforloadoperator)
        {
            ResponsibleForLoad.CompleteResponsibleForLoad(responsibleforloadcountry, responsibleforloadoperator);

        }

    }
}
