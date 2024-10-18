using NUnit.Framework;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.DepartureAndArrival;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class DepartureAndArrivalSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        public DepartureAndArrivalSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IDepartureAndArrival? DepartureAndArrival => _objectContainer.IsRegistered<IDepartureAndArrival>() ? _objectContainer.Resolve<IDepartureAndArrival>() : null;
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        [When(@"verify Departure And Arrival section has been added successfully")]
        [Then(@"verify Departure And Arrival section has been added successfully")]
        public void ThenVerifyDepartureAndArrivalSectionHasBeenAddedSuccessfully()
        {
            Assert.True(DepartureAndArrival.VerifyDepartureAndArrivalDateStatus(), "Departure and Arrival not completed");
        }

        [When(@"complete Departure And Arrival dates")]
        public void WhenCompleteDepartureAndArrivalDates()
        {
            DepartureAndArrival.CompleteDepartureAndArrivalDate();
        }

        [When(@"I navigate to departure and arrival page")]
        public void WhenINavigateToDepartureAndArrivalPage()
        {
            TaskList.ClickDepartureAndArrivalLink();
            Assert.True(DepartureAndArrival.IsDepartureArrivalPage, "Departure and arrival page not displayed");
        }

        [When(@"complete Departure And Arrival dates with '([^']*)'")]
        public void WhenCompleteDepartureAndArrivalDatesWith(string skipcheckbox)
        {
            DepartureAndArrival.CompleteSkipDepartureAndArrivalDate(skipcheckbox);
        }

        [Then(@"verify Departure And Arrival validation message information")]
        public void ThenVerifyDepartureAndArrivalValidationMessageInformation()
        {
            Assert.True(DepartureAndArrival.VerifySkipValidationInformation(), "Skip validation information displayed");
        }

        [When(@"I click back Departure and Arrival to verify skip check box still ticked")]
        public void WhenIClickBackDepartureAndArrivalToVerifySkipCheckBoxStillTicked()
        {
            Assert.True(DepartureAndArrival.IsSkipChecked(), "Skip checkbox not checked");
        }

        [When(@"complete with '([^']*)' And '([^']*)'")]
        public void WhenCompleteWithAnd(string departureValue, string arrivalValue)
        {
            if (departureValue.Equals("Empty"))
            {
                DepartureAndArrival.CompleteArrivalDate();
            }

            if (arrivalValue.Equals("Empty"))
            {
                DepartureAndArrival.CompleteDepartureDate();
            }
        }

        [Then(@"verify Departure And Arrival '([^']*)' Information")]
        public void ThenVerifyDepartureAndArrivalInformation(string validationError)
        {
            Assert.True(DepartureAndArrival.VerifyValidationError(validationError), "Validation error not as expected");
        }
    }
}
