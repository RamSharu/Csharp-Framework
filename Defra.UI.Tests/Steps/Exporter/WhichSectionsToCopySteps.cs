using BoDi;
using Defra.UI.Tests.Pages.Exporter.WhichSectionsToCopy;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class WhichSectionsToCopySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWhichSectionsToCopy? WhichSectionsToCopy => _objectContainer.IsRegistered<IWhichSectionsToCopy>() ? _objectContainer.Resolve<IWhichSectionsToCopy>() : null;

        public WhichSectionsToCopySteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I select any one checkbox on the which sections to copy page")]
        public void WhenISelectAnyOneCheckboxOnTheWhichSectionsToCopyPage()
        {
            Assert.IsTrue(WhichSectionsToCopy.IsWhichSectionsToCopyPage, "Which sections do you want to copy page is not displayed");
            WhichSectionsToCopy.ClickSecondCheckbox();
            WhichSectionsToCopy.ClickContinueButton();
        }

    }
}
