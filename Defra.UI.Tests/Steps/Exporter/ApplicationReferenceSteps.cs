using BoDi;
using Defra.UI.Tests.Pages.Exporter.ApplicationReference;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ApplicationReferenceSteps
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IApplicationReference? ApplicationReference => _objectContainer.IsRegistered<IApplicationReference>() ? _objectContainer.Resolve<IApplicationReference>() : null;
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        public ApplicationReferenceSteps(ScenarioContext context, IObjectContainer container)
        {
            _objectContainer = container;
        }

        [When(@"I enter a new reference on the copy application reference page")]
        public void WhenIEnterANewReferenceOnTheCopyApplicationReferencePage()
        {
            Assert.IsTrue(ApplicationReference.IsCopyApplicationReferencePage, "Copy application create new reference page is not displayed");
            ApplicationReference.CreateNewReferenceOnCopyApp();
        }

        [When(@"I click Create copy button")]
        public void WhenIClickCreateCopyButton()
        {
            ApplicationReference.ClickCreateCopyButton();
        }

        [Then(@"I am directed to input a new reference page whereby I can input and save a new reference")]
        public void ThenIAmDirectedToInputANewReferencePageWherebyICanInputAndSaveANewReference()
        {
            Assert.True(ApplicationReference.IsApplicationReferencePage, "Change application reference page not displayed");
            var newAppRef = ApplicationReference.ChangeApplicationReference();
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            var isRefEqual = newAppRef == TaskList.GetApplicationReference() ? true : false;
            Assert.IsTrue(isRefEqual, "Application reference not updated");
        }

        [When(@"I provide a reference with greater than (.*) characters")]
        public void WhenIProvideAReferenceWithGreaterThanCharacters(int noOfCharacters)
        {
            Assert.True(ApplicationReference.IsApplicationReferencePage, "Change application reference page not displayed");
            ApplicationReference.InvalidApplicationReference(noOfCharacters);
        }

        [Then(@"I am shown validation '([^']*)'")]
        public void ThenIAmShownValidation(string validationError)
        {
            Assert.True(ApplicationReference.ValidationError(validationError), "Error message not displayed");
        }


    }
}