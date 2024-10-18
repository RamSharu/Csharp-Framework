using BoDi;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin;
using Defra.UI.Tests.Pages.Exporter.TaskList;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static System.Collections.Specialized.BitVector32;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class PlaceOfOriginSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public PlaceOfOriginSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IPlaceOfOrigin? PlaceOfOrigin => _objectContainer.IsRegistered<IPlaceOfOrigin>() ? _objectContainer.Resolve<IPlaceOfOrigin>() : null;
        private ITaskList? TaskList => _objectContainer.IsRegistered<ITaskList>() ? _objectContainer.Resolve<ITaskList>() : null;

        [When(@"complete place of origin with '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)' and continue")]
        public void WhenCompletePlaceOfOriginWithAndContinue(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading)
        {
            PlaceOfOrigin.CompletePlaceOfOriginAndContinue(CountryOfOrigin, PlaceOfDispatchCountry, PlaceOfDispatch, PlaceOfLoadingCountry, PlaceOfLoading);
        }

        [When(@"complete place of origin with '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenCompletePlaceOfOriginWith(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading)
        {
            PlaceOfOrigin.CompletePlaceOfOrigin(CountryOfOrigin, PlaceOfDispatchCountry, PlaceOfDispatch, PlaceOfLoadingCountry, PlaceOfLoading);
        }

        [When(@"complete place of origin with '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' and continue")]
        public void WhenCompletePlaceOfOriginWithAndContinue(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading, string SearchByOpearetor)
        {
            PlaceOfOrigin.CompletePlaceOfOriginByApprovalNumberAndContinue(CountryOfOrigin, PlaceOfDispatchCountry, PlaceOfDispatch, PlaceOfLoadingCountry, PlaceOfLoading, SearchByOpearetor);
        }

        [When(@"I complete place of dispatch with '([^']*)' '([^']*)' skipping the place of loading")]
        public void WhenICompletePlaceOfDispatchWithSkippingThePlaceOfLoading(string countryOfDispatch, string placeOfDispatch)
        {
            PlaceOfOrigin.CompletePlaceOfDispatch(countryOfDispatch, placeOfDispatch);
            Assert.IsTrue(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page is not displayed after completing place of dispatch section");
        }

        [When(@"I complete place of loading with '([^']*)' '([^']*)' skipping the place of dispatch")]
        public void WhenICompletePlaceOfLoadingWithSkippingThePlaceOfDispatch(string countryOfLoading, string placeOfLoading)
        {
            PlaceOfOrigin.CompletePlaceOfLoading(countryOfLoading, placeOfLoading);
            Assert.IsTrue(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page is not displayed after completing place of loading section");
        }

        [Given(@"I navigate to place of origin page from Task list page")]
        [When(@"I navigate to place of origin page from Task list page")]
        [Then(@"I navigate to place of origin page from Task list page")]
        public void WhenINavigateToPlaceOfOriginPageFromTaskListPage()
        {
            Assert.IsTrue(TaskList.IsTaskListPage, "Task list page is not displayed");
            TaskList.ClickPlaceOfOriginLink();
            Assert.IsTrue(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page is not displayed on clicking the place of origin link from task list page");
        }

        [Given(@"I navigate to place of origin page")]
        [When(@"I navigate to place of origin page")]
        [Then(@"I navigate to place of origin page")]
        public void WhenINavigateToPlaceOfOriginPage()
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfOriginPageDisplayed(), "Place of origin page not displayed");
        }

        [When(@"verify place of origin has been added successfully")]
        public void WhenVerifyPlaceOfOriginHasBeenAddedSuccessfully()
        {
            Assert.True(PlaceOfOrigin.VerifyPlaceOfOriginStatus(), "Place of origin not completed");
        }

        [When(@"I can see that the skip checkbox is no longer there")]
        [Then(@"I can see that the skip checkbox is no longer there")]
        public void ThenICanSeeThatTheSkipCheckboxIsNoLongerThere()
        {
            Assert.False(PlaceOfOrigin.IsSkipCheckboxVisible(), "Skip checkbox is visible");
        }

        [When(@"I have ticked the skip checkbox for place of origin and continue")]
        public void WhenIHaveTickedTheSkipCheckboxForPlaceOfOriginAndContinue()
        {
            PlaceOfOrigin.SkipAndContinue();
        }

        [When(@"I remove the section '([^']*)'")]
        public void WhenIRemoveTheSection(string placeOfDispatchLoading)
        {
            PlaceOfOrigin.ClickRemoveLink(placeOfDispatchLoading);
        }

        [Then(@"I can still see the blank fields that I skipped with the skip tickbox still checked")]
        public void ThenICanStillSeeTheBlankFieldsThatISkippedWithTheSkipTickboxStillChecked()
        {
            Assert.True(PlaceOfOrigin.IsSkipChecked(), "Skip checkbox not checked");
        }

        [Then(@"I can still see Place of loading is blank with the skip tickbox still checked")]
        public void ThenICanStillSeePlaceOfLoadingIsBlankWithTheSkipTickboxStillChecked()
        {
            Assert.Multiple(() =>
            {
                Assert.True(PlaceOfOrigin.IsPlaceOfLoadingBlank(), "Place of loading section is not blank");
                Assert.True(PlaceOfOrigin.IsSkipChecked(), "Skip checkbox not checked");
            });
        }

        [Then(@"I can still see Place of dispatch is blank with the skip tickbox still checked")]
        public void ThenICanStillSeePlaceOfDispatchIsBlankWithTheSkipTickboxStillChecked()
        {
            Assert.Multiple(() =>
            {
                Assert.True(PlaceOfOrigin.IsPlaceOfDispatchBlank(), "Place of dispatch section is not blank");
                Assert.True(PlaceOfOrigin.IsSkipChecked(), "Skip checkbox not checked");
            });
        }

        [When(@"I press save and continue")]
        public void WhenIPressSaveAndContinue()
        {
            PlaceOfOrigin.SaveContinue();
        }

        [Then(@"I can see the validation informing me to select the skip checkbox validation")]
        public void ThenICanSeeTheValidationInformingMeToSelectTheSkipCheckboxValidation()
        {
            Assert.True(PlaceOfOrigin.IsSkipError(), "Validation message not visible");
        }

        [Then(@"The skip checkbox is displayed")]
        public void ThenTheSkipCheckboxIsDisplayed()
        {
            Assert.True(PlaceOfOrigin.IsSkipCheckboxVisible(), "Checkbox is not displayed when mandatory section is removed");
        }

        [Then(@"the skip validation message and checkbox is removed")]
        public void ThenTheSkipValidationMessageAndCheckboxIsRemoved()
        {
            Assert.False(PlaceOfOrigin.IsSkipError(), "Validation message is still visible");
            Assert.False(PlaceOfOrigin.IsSkipCheckboxVisible(), "Checkbox is still visible");
        }

        [When(@"complete place of origin with '([^']*)' and region")]
        public void WhenCompletePlaceOfOriginWithAndRegion(string country)
        {
            PlaceOfOrigin.CompleteRegionOfOrigin(country);
        }

        [Then(@"I have unticked skip on the main page of place of origin")]
        public void ThenIHaveUntickedSkipOnTheMainPageOfPlaceOfOrigin()
        {
            PlaceOfOrigin.SkipCheckbox();
        }

        [Then(@"I remove the place of origin data and skip")]
        public void ThenIRemoveThePlaceOfOriginDataAndSkip()
        {            
            PlaceOfOrigin.RemovePlaceOfLoading();            
            PlaceOfOrigin.RemovePlaceOfDispatch();
            PlaceOfOrigin.RemoveRegionOfOrigin();
            PlaceOfOrigin.SkipAndContinue();            
        }

        [Then(@"I am on '([^']*)' page from place of origin")]
        public void ThenIAmOnPageFromPlaceOfOrigin(string page)
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfDispatchDisplayed(), page + " not displayed");
        }

        [Then(@"I am on place of dispatch page from place of origin")]
        public void ThenIAmOnPlaceOfDispatchPageFromPlaceOfOrigin()
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfDispatchDisplayed(), "Place of dispatch not displayed");
        }

        [Then(@"I am on place of loading page from place of origin")]
        public void ThenIAmOnPlaceOfLoadingPageFromPlaceOfOrigin()
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfLoadingDisplayed(), "Place of loading not displayed");
        }


        [When(@"I press back from place of origin page")]
        public void WhenIPressBackFromPlaceOfOriginPage()
        {
            PlaceOfOrigin.ClickBackLink();
        }

        [Then(@"I get place of origin data from place of origin page")]
        public void ThenIGetPlaceOfOriginDataFromPlaceOfOriginPage()
        {
            Assert.True(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page not displayed");
            _scenarioContext.Add("dispatchOperatorName", PlaceOfOrigin.GetPlaceOfDispatchOperatorName);
            _scenarioContext.Add("loadingOperatorName", PlaceOfOrigin.GetPlaceOfLoadingOperatorName);
        }

        [Then(@"I am taken to place of origin main page")]
        public void ThenIAmTakenToPlaceOfOriginMainPage()
        {
            Assert.IsTrue(PlaceOfOrigin.IsPlaceOfOriginPage, "Place of origin page is not displayed on clicking change link next to Country of origin/Region of origin");
            PlaceOfOrigin.ClickBackLink();
        }

        [Given(@"select a place of dispatch")]
        [When(@"select a place of dispatch")]
        [Then(@"select a place of dispatch")]
        public void GivenSelectAPlaceOfDispatch()
        {
            PlaceOfOrigin.ClickPlaceOfDispatchLink();
        }

        [Given(@"select a place of loading")]
        [When(@"select a place of loading")]
        [Then(@"select a place of loading")]
        public void GivenSelectAPlaceOfLoading()
        {
            PlaceOfOrigin.ClickPlaceOfLoadingLink();
        }

        
        [Then(@"Check Operator Approval no present in the operator search in Place of Despatch with '([^']*)','([^']*)', '([^']*)'")]
        public void ThenCheckOperatorApprovalNoPresentInTheOperatorSearchInPlaceOfDespatchWith(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch)
        {
            Assert.True(PlaceOfOrigin?.VerifyApprovalNoPresentInSearchItemsInsidePlaceOfDespatch(countryOfOrigin, placeOfDispatchCountry, placeOfDispatch), "Approval number not present in the search result");
        }

        [Then(@"Check Operator Approval no present in the operator search in Place of Loading with '([^']*)','([^']*)', '([^']*)'")]
        public void ThenCheckOperatorApprovalNoPresentInTheOperatorSearchInPlaceOfLoadingWith(string countryOfOrigin, string placeOfLoadingCountry, string placeOfLoading)
        {
            Assert.True(PlaceOfOrigin?.VerifyApprovalNoPresentInSearchItemsInsidePlaceOfLoading(countryOfOrigin, placeOfLoadingCountry, placeOfLoading), "Approval number not present in the search result");
        }

        [Then(@"verify approval no present in the place of dispatch and place of loading selections")]
        public void ThenVerifyApprovalNoPresentInThePlaceOfDispatchAndPlaceOfLoadingSelections()
        {
            Assert.True(PlaceOfOrigin?.VerifyApprovalNoPresentInTwoTypesOfPlaceSections(), "Approval number not present in the selection of place of dispatch or place of loading");
        }
    }
}
