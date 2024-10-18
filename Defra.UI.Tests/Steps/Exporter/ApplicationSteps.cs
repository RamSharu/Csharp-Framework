using BoDi;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Pages.Exporter.Applications;
using Defra.UI.Tests.Pages.Exporter.CopyApplication;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        public ApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        public ApplicationResponse ApplicationResponse { get; set; }
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        //Data
        private IApplicationData? AppData => _objectContainer.IsRegistered<IApplicationData>() ? _objectContainer.Resolve<IApplicationData>() : null;

        // Pages
        private IApplications? Applications => _objectContainer.IsRegistered<IApplications>() ? _objectContainer.Resolve<IApplications>() : null;
        private ICopyApplication? CopyApplication => _objectContainer.IsRegistered<ICopyApplication>() ? _objectContainer.Resolve<ICopyApplication>() : null;
       
        [Given(@"application page is displayed")]
        [When(@"application page is displayed")]
        [Then(@"application page is displayed")]
        [Then(@"application home page is displayed")]
        public void ThenApplicationPageIsDisplayed()
        {
            Assert.True(Applications.IsApplicationsPage, "Application Page not displayed");
        }

        [Given(@"I start a new application from applications home page")]
        public void GivenIClickOnStartANewApplicationButton()
        {
            Applications.ClickStartNewApplicationButton();
        }

        [Then(@"application submitted date is not overwritten")]
        public void ThenApplicationSubmittedDateIsNotOverwritten()
        {
            lock (_lock)
            {
                var submissionResponse = _scenarioContext.Get<ApplicationResponse>($"SubmittedResponse_{_scenarioContext.ScenarioInfo.Title}");
                var resubmissionResponse = _scenarioContext.Get<ApplicationResponse>($"ResubmittedResponse_{_scenarioContext.ScenarioInfo.Title}");
                var expected = submissionResponse.Submitted == resubmissionResponse.Submitted;

                Assert.True(expected, $"{submissionResponse.ApplicatioDisplayId} submitted date is overwritten (Expected: {submissionResponse.Submitted.GetValueOrDefault():dd/MM/yyyy hh:mm:ss.fff tt}, Found: {resubmissionResponse.Submitted.GetValueOrDefault():dd/MM/yyyy hh:mm:ss.fff tt}");
            }
        }

        [Then(@"check the below table with '([^']*)' works correctly '([^']*)'")]
        public void ThenCheckTheBelowTableWithWorksCorrectly(string filter, string filterValue)
        {
            if (filter.Equals("country"))
            {
                Assert.True(Applications.IsCountryFiltered(filterValue), "Selected country not been filtered");

            }
            else if (filter.Equals("date"))
            {
                Assert.True(Applications.IsDateFiltered(filterValue), "Selected date not been filtered");
            }
            else if (filter.Equals("status"))
            {
                Assert.True(Applications.IsStatusFiltered(filterValue), "Selected status not been filtered");
            }
            Thread.Sleep(2000); // TODO: replaced with a better way to wait for the table to reload
        }

        [Then(@"I can see that the last page is displayed")]
        public void ThenICanSeeThatTheLastPageIsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Applications.ValidateIfLastPageIsDisplayed(), "Last page is not displayed");
                Assert.True(Applications.IsApplicationsTableDisplayed, "Applications table in last page is not loaded");
            });
        }

        [Then(@"I can see that the next page is displayed")]
        public void ThenICanSeeThatTheNextPageIsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.True(Applications.ValidateIfNextPageIsDisplayed(), "Second page is not displayed after clicking the Next page link");
                Assert.True(Applications.IsApplicationsTableDisplayed, "Applications table in second page is not loaded");
            });
        }

        [Then(@"I can see the number of applications")]
        public void ThenICanSeeTheNumberOfApplications()
        {
            Assert.IsTrue(Applications.ValidateNumOfApplications(), "Number of applications is not displayed correctly");
        }

        [Given(@"I can validate that first page is displayed by default")]
        [Then(@"I can validate that first page is displayed by default")]
        public void ThenICanValidateThatFirstPageIsDisplayedByDefault()
        {
            Assert.IsTrue(Applications.ValidateFirstPage, "First page is not displayed by default");
        }

        [When(@"resubmit an application via backend")]
        public void ThenResubmitApplicationViaBackend()
        {
            lock (_lock)
            {
                var applicationResponse = _scenarioContext.Get<ApplicationResponse>($"AppDispId_{_scenarioContext.ScenarioInfo.Title}");

                var response = AppData.SubmitApplication(applicationResponse.ApplicationId);
                ApplicationResponse = AppData.GetApplicationDisplayId(applicationResponse.ApplicationId);

                _scenarioContext.Add($"ResubmittedResponse_{_scenarioContext.ScenarioInfo.Title}", ApplicationResponse);
            }
        }

        [Given(@"search for a created application")]
        [When(@"search for a created application")]
        [Then(@"search for a created application")]
        public void ThenSearchForACreatedApplication()
        {
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                Assert.True(Applications.SearchApplication(applicationres.ApplicatioDisplayId.ToString()), $"{applicationres.ApplicatioDisplayId} not able to search on the page");
            }
        }

        [Then(@"The submitted application is displayed on the application page")]
        public void ThenTheSubmittedApplicationIsDisplayedOnTheApplicationPage()
        {
            Assert.True(Applications.IsApplicationsPage, "Application Page not displayed");
            lock (_lock)
            {
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                var applicationres = (ApplicationResponse)_scenarioContext[appDisIdForScenario];
                Assert.True(Applications.SearchApplication(applicationres.ApplicatioDisplayId.ToString()), $"{applicationres.ApplicatioDisplayId} not able to search on the page");
            }
        }

        [Given(@"select '([^']*)' filter from applications page")]
        [Then(@"select '([^']*)' filter from applications page")]
        public void ThenSelectFilterFromApplicationsPage(string filter)
        {
            if (filter.Equals("country"))
            {
                Assert.True(Applications.IsCountrylistDisplayed(), "Country list Not displayed");

            }
            else if (filter.Equals("date"))
            {
                Assert.True(Applications.IsDateListDisplayed(), "Date list Not displayed");
            }
            else if (filter.Equals("status"))
            {
                Assert.True(Applications.IsStatusListDisplayed(), "Status list Not displayed");
            }
        }

        [Given(@"set status value as '([^']*)'")]
        [Then(@"set status value as '([^']*)'")]
        public void ThenSetStatusValueAs(string status)
        {
            if (status.Equals("draft"))
            {
                Assert.True(Applications.IsStatusFiltered(status), "Status draft not displayed");
            }
        }

        [Given(@"setup an application via backend")]
        [When(@"setup an application via backend")]
        [Then(@"setup an application via backend")]
        public void ThenSetupAnApplicationViaBackend()
        {
            lock (_lock)
             {
                AppData.CreateApplication();
                ApplicationResponse = AppData.GetApplicationDisplayId(AppData.ApplicationId);
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
                _scenarioContext.Add("AppDispId", ApplicationResponse);
            }
        }
        [Given(@"setup an application with all tasks via backend '([^']*)'")]
        [When(@"setup an application with all tasks via backend '([^']*)'")]
        [Then(@"setup an application with all tasks via backend '([^']*)'")]
        public void WhenSetupAnApplicationWithAllTasksViaBackend(string certifier)
        {
            lock (_lock)
            {
                if (certifier.Equals("exporter"))
                {
                    AppData.CreateApplicationWithAllTasks();
                }
                else
                {
                    AppData.CreateApplicationWithAllTasks(true);
                }
                ApplicationResponse = AppData.GetApplicationDisplayId(AppData.ApplicationId);
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
                _scenarioContext.Add("AppDispId", ApplicationResponse);
            }
        }

        [Given(@"setup an application with all tasks with skip funtion via backend")]
        [When(@"setup an application with all tasks with skip funtion via backend")]
        [Then(@"setup an application with all tasks with skip funtion via backend")]
        public void ThenSetupAnApplicationWithAllTasksSkipFunViaBackend()
        {
            lock (_lock)
            {
                AppData.CreateApplicationWithAllTasksSkipFunction();
                ApplicationResponse = AppData.GetApplicationDisplayId(AppData.ApplicationId);
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
                _scenarioContext.Add("AppDispId", ApplicationResponse);
            }
        }


        [Given(@"setup an application with all tasks via backend")]
        [When(@"setup an application with all tasks via backend")]
        [Then(@"setup an application with all tasks via backend")]
        public void ThenSetupAnApplicationWithAllTasksViaBackend()
        {
            lock (_lock)
            {
                AppData.CreateApplicationWithAllTasks();
                ApplicationResponse = AppData.GetApplicationDisplayId(AppData.ApplicationId);
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
                _scenarioContext.Add("AppDispId", ApplicationResponse);
            }
        }

        [When(@"submit an application with skip funtion via backend")]
        public void WhenSubmitAnApplicationWithSkipFuntionViaBackend()
        {
            lock (_lock)
            {
                var applicationResponse = _scenarioContext.Get<ApplicationResponse>($"AppDispId_{_scenarioContext.ScenarioInfo.Title}");

                var response = AppData.SubmitSkipApplication(applicationResponse.ApplicationId);
                ApplicationResponse = AppData.GetApplicationDisplayId(applicationResponse.ApplicationId);

                _scenarioContext.Add($"SubmittedResponse_{_scenarioContext.ScenarioInfo.Title}", ApplicationResponse);
            }
        }


        [Given(@"submit an application via backend")]
        [When(@"submit an application via backend")]
        [Then(@"submit an application via backend")]
        public void ThenSubmitAnApplicationViaBackend()
        {
            lock (_lock)
            {
                var applicationResponse = _scenarioContext.Get<ApplicationResponse>($"AppDispId_{_scenarioContext.ScenarioInfo.Title}");

                var response = AppData.SubmitApplication(applicationResponse.ApplicationId);
                ApplicationResponse = AppData.GetApplicationDisplayId(applicationResponse.ApplicationId);

                _scenarioContext.Add($"SubmittedResponse_{_scenarioContext.ScenarioInfo.Title}", ApplicationResponse);
            }
        }

        [Given(@"create a certificate via backend")]
        [When(@"create a certificate via backend")]
        [Then(@"create a certificate via backend")]
        public void WhenCreateACertificateViaBackend()
        {
            lock (_lock)
            {
                var applicationResponse = _scenarioContext.Get<ApplicationResponse>($"AppDispId_{_scenarioContext.ScenarioInfo.Title}");

                AppData.CertifierSubmitApplication(applicationResponse.ApplicationId);
                ApplicationResponse = AppData.GetApplicationDisplayId(applicationResponse.ApplicationId);
            }
        }


        [Then(@"The application is deleted successfully")]
        public void ThenTheApplicationIsDeletedSuccessfully()
        {
            Assert.True(Applications.VerifyIfApplicationIsDeleted(), "Application not deleted");
        }

        [Then(@"the applications in last page are displayed")]
        public void ThenTheApplicationsInLastPageAreDisplayed()
        {
            Assert.IsTrue(Applications.ValidateIfLastPageApplicationsAreDisplayed(), "Applications in last page are not displayed");
        }

        [When(@"I click on the delete application")]
        public void ThenUserClicksTheDeleteApplicationAndVerify()
        {
            Applications.ClickDeleteApplication();
        }

        [Given(@"user clicks the view application and verify")]
        [When(@"user clicks the view application and verify")]
        [Then(@"user clicks the view application and verify")]
        public void ThenUserClicksTheViewApplicationAndVerify()
        {
            Assert.True(Applications.VerifyViewApplication(), "Application view not successful");
        }

        [Given(@"user clicks the view application and verify application reference")]
        [When(@"user clicks the view application and verify application reference")]
        [Then(@"user clicks the view application and verify application reference")]

        public void ThenUserClicksTheViewApplicationAndVerifyApplicationReference()
        {
            Assert.True(Applications.VerifyViewApplicationReference(), "Application view not successful");
        }


        [When(@"I click on the copy application")]
        public void WhenIClickOnTheCopyApplication()
        {
            Applications.ClickCopyApplication();
            Assert.True(CopyApplication.IsCopyApplicationPage, "Copy Application Page not displayed");
        }
        [When(@"I click on the last page link")]
        public void WhenIClickOnTheLastPageLink()
        {
            Applications.ClickLastPageLink();
        }

        [When(@"I click the Next link on pagination")]
        public void WhenIClickTheNextLinkOnPagination()
        {
            Applications.ClickNextPageLink();
        }

        [Given(@"I set up an application with all tasks via backend for EHCs having disease clearance")]
        public void GivenISetUpAnApplicationWithAllTasksViaBackendForEHCsHavingDiseaseClearance()
        {
            lock (_lock)
            {
                AppData.CreateApplicationWithAllTasksWithDiseaseClearance();
                
                ApplicationResponse = AppData.GetApplicationDisplayId(AppData.ApplicationId);
                string appDisIdForScenario = $"AppDispId_{_scenarioContext.ScenarioInfo.Title}";
                _scenarioContext.Add(appDisIdForScenario, ApplicationResponse);
                _scenarioContext.Add("AppDispId", ApplicationResponse);
            }
        }

        [Then(@"I can validate mandatory fields on the home page for '([^']*)'")]
        public void ThenICanValidateMandatoryFieldsOnTheHomePageFor(string userType)
        {
            Assert.Multiple(() =>
            {
                Assert.True(Applications.GetSearchApplicationHeader().Contains("Search for an application"), "Search application header is not displayed on Home page");
                Assert.True(Applications.GetSearchHintText().StartsWith("Search by Certificate Name"), "Search application hint text is not displayed on Home page");
                Assert.True(Applications.IsSearchTextBoxDisplayed, "Search textbox is not displayed on home page");
                Assert.True(Applications.IsClearFiltersLinkDisplayed, "Clear filters link is not displayed on Home page");

                if (userType.Equals("exporter"))
                {
                    Assert.True(Applications.GetHomePageHeader().Contains("Your Applications"), "Exporter home page doesn't display the correct header");
                    Assert.True(Applications.IsStartNewAppButtonDisplayed, "Exporter home page does not display start new application button");
                    Assert.True(Applications.GetStartNewAppButtonText().Contains("Start a new application"), "Start new application button does not have expected string");
                }
                else if (userType.Equals("certifier"))
                {
                    Assert.True(Applications.GetHomePageHeader().Contains("Certify an export health certificate"), "Certifier home page doesn't display the correct header");
                }
            });
        }

        [Then(@"I can validate the filters and texts on the filters '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenICanValidateTheFiltersAndTextsOnTheFilters(string countryFilterText, string dateFilterText, string statusFilterText)
        {
            List<string> filtersExpectedTextList = new List<string>()
            { 
                countryFilterText, dateFilterText, statusFilterText 
            };

            List<string> filtersActualTextList = Applications.GetFiltersTextList();
            Assert.True(filtersExpectedTextList.SequenceEqual(filtersActualTextList), "Text on the filter buttons doesn't match with expected texts");
        }

        [Then(@"I can see that applications table is displayed")]
        public void ThenICanSeeThatApplicationsTableIsDisplayed()
        {
            Assert.True(Applications.IsApplicationsTableDisplayed, "Applications table is not displayed on home page");
        }

        [Then(@"the table headers display correct texts")]
        public void ThenTheTableHeadersDisplayCorrectTexts()
        {
            Applications.GetTableHeaderElements();
        }

        [Then(@"the table headers display correct texts for '([^']*)' as in '([^']*)'")]
        public void ThenTheTableHeadersDisplayCorrectTextsForAsIn(string userType, string headerTexts)
        {
            List<string> headerTextsExpectedList = new List<string>(headerTexts.Split(','));
            List<string> headerTextsActualList = Applications.GetTableHeaderElements();
            Assert.True(headerTextsExpectedList.SequenceEqual(headerTextsActualList), $"The header texts doesn't display the expected text for '{userType}");
        }

        [Then(@"the applications are displayed in table rows")]
        public void ThenTheApplicationsAreDisplayedInTableRows()
        {
            Assert.True(Applications.IsApplicationsTableRowsDisplayed(), "Applications are not displayed in the home page");
            Assert.True(Applications.ValidateApplicationSerialNum());
        }

        [Then(@"the show link on click displays certificate data and '([^']*)' related to the application for '([^']*)'")]
        public void ThenTheShowLinkOnClickDisplaysCertificateDataAndRelatedToTheApplicationFor(string buttonTexts, string userType)
        {
            List<string> buttonTextsExpectedList = new List<string>(buttonTexts.Split(','));

            Applications.ClickShowLink();
            Assert.True(Applications.IsCertificateSubTableDisplayed, "Certificate details in table format is not displayed after show link is clicked");
            List<string> buttonTextsActualList = Applications.GetButtonElements();
            Assert.True(buttonTextsExpectedList.SequenceEqual(buttonTextsActualList), $"Button names doesn't display the expected text for '{userType}");
        }

        [Given(@"I view application")]
        [When(@"I view application")]
        [Then(@"I view application")]
        public void GivenIViewApplication()
        {
            Applications.ClickViewApplication();
        }
    }
}
