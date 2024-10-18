using BoDi;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class TaskListSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;
        private ICheckYourAnswers CheckYourAnswers => _objectContainer.IsRegistered<ICheckYourAnswers>() ? _objectContainer.Resolve<ICheckYourAnswers>() : null;

        public TaskListSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click on the accompanying documents link from task list page")]
        public void WhenIClickOnTheTaskLinkFromTaskListPage()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickAccompanyingDocsLink();
        }

        [When(@"I click on the manage commodities link from task list page")]
        public void WhenIClickOnTheManageCommoditiesLinkFromTaskListPage()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickManageCommoditiesLink();
        }

        [When(@"I click on gross weight link from task list page")]
        public void ThenIClickOnGrossWeightLinkFromTaskListPage()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickGrossWeightLink();
        }

        [When(@"I click on the preview certificate link")]
        public void WhenIClickOnThePreviewCertificateLink()
        {
            TaskList.ClickPreviewCertificateLink();
        }

        [Then(@"I can see the certificate details and a link to download the certificate")]
        public void ThenICanSeeTheCertificateDetailsAndALinkToDownloadTheCertificate()
        {
            Assert.Multiple(() =>
            {
                Assert.True(TaskList.ValidatePreviewSummary, "Preview summary is not displayed");
                Assert.True(TaskList.ValidateDownloadLink, "Download link is not displayed");
            });
        }

        [When(@"I click change by application reference")]
        public void WhenIClickChangeByApplicationReference()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickChangeApplicationReference();
        }

        [Then(@"I can see '([^']*)'")]
        public void ThenICanSee(string section)
        {
            Assert.True(TaskList.SearchOnPage(section), $"{section} not found");
        }

        [Then(@"the status of the section shows '([^']*)'")]
        public void ThenTheStatusOfTheSectionShows(string status)
        {
            var isCorrectStatus = TaskList.GetApplySectionStatus() == status ? true : false;
            Assert.True(isCorrectStatus, "Status incorrect");
        }

        [Given(@"I click on the review and submit application hyperlink")]
        [When(@"I click on the review and submit application hyperlink")]
        [Then(@"I click on the review and submit application hyperlink")]
        public void WhenIClickOnTheReviewAndSubmitApplicationHyperlink()
        {
            Assert.True(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickReviewAnswersLink();
        }

        [Then(@"I can see the apply section whereby the review and submit application hyperlink is clickable and this directs me to the check your answers page")]
        public void ThenICanSeeTheApplySectionWherebyTheReviewAndSubmitApplicationHyperlinkIsClickableAndThisDirectsMeToTheCheckYourAnswersPage()
        {
            TaskList.ClickReviewAnswersLink();
            Assert.True(CheckYourAnswers.IsCheckYourAnswersPage, "Check your answers page is not displayed");
        }

        [When(@"I click on the exporter or consignor link from task list page")]
        public void WhenIClickOnTheConsignorOrExporterLinkFromTaskListPage()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickExporterOrConsignorLink();
        }

    }
}
