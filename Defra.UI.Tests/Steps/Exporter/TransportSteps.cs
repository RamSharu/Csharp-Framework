using BoDi;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Defra.UI.Tests.Pages.Exporter.MeansOfTransport;
using Defra.UI.Tests.Pages.Exporter.TaskList;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class TransportSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public TransportSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        private ITransport? Transport => _objectContainer.IsRegistered<ITransport>() ? _objectContainer.Resolve<ITransport>() : null;

        [Then(@"verify means of transport page by adding valid details")]
        public void ThenVerifyMeansOfTransportPageByAddingValidDetails()
        {
            Assert.True(Transport.VerifyTransport(), "Transport entry not completed");
        }

        [Then(@"transport details added successfully")]
        public void ThenTransportDetailsAddedSuccessfully()
        {
            Assert.True(Transport.IsTransportDetailsCompleted(), "Transport details not added successfully");
        }

        [Then(@"complete means of transport with '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenCompleteMeansOfTransportWithAnd(string transCondition, string meansOfTrans, string skipCheckbox)
        {
            Assert.True(Transport.CompleteMeansOfTransport(transCondition, meansOfTrans, skipCheckbox), "Transport entry not completed with skip");
        }

        [Then(@"verify means of transport validation message information")]
        public void ThenVerifyMeansOfTransportValidationMessageInformation()
        {
            Assert.True(Transport.VerifyTransportValidationMessage(), "No Means of transport validation message");
        }

        [Then(@"I can see means of transport skip checkbox has ticked and visible")]
        public void ThenICanSeeMeansOfTransportSkipCheckboxHasTickedAndVisible()
        {
            Assert.True(TaskList.IsTaskListPage, "Task list page not displayed after means of transport is skipped and completed");
            TaskList.ClickMeansOfTransportLink();
            Assert.True(Transport.IsMeansOfTransportPage, "Means of transport page not displayed");
            Assert.True(Transport.IsMeansOfTransportSkipCheckboxVisible(), "Skip checkbox is not visible");
        }
    }
}
