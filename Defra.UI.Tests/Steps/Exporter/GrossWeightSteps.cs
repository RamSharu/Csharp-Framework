using NUnit.Framework;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.GrossWeight;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class GrossWeightSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public GrossWeightSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IGrossWeight? GrossWeight => _objectContainer.IsRegistered<IGrossWeight>() ? _objectContainer.Resolve<IGrossWeight>() : null;

        [When(@"complete Gross Weight as '([^']*)' and '([^']*)'")]
        public void WhenCompleteGrossWeightAsAnd(string grossweightamount, string grossweightunit)
        {
            GrossWeight.CompleteGrossWeight(grossweightamount, grossweightunit);
        }

        [Then(@"verify Gross Weight has been added successfully")]
        public void ThenVerifyGrossWeightHasBeenAddedSuccessfully()
        {
            Assert.True(GrossWeight.VerifyGrossWeightStatus(), "Gross Weight not completed");
        }

        [Then(@"the value is saved with the decimal points '([^']*)'")]
        public void ThenTheValueIsSavedWithTheDecimalPoints(string grossweightamount)
        {
            Assert.True(GrossWeight.VerifyGrossWeightAmount(grossweightamount), "Gross weight not correct");
        }

        [When(@"add Gross Weight as '([^']*)' and '([^']*)'")]
        public void WhenAddGrossWeightAsAnd(string grossweightamount, string grossweightunit)
        {
            GrossWeight.AddGrossWeightAmount(grossweightamount, grossweightunit);
        }


        [When(@"complete Gross Weight as '([^']*)', '([^']*)' and '([^']*)'")]
        public void WhenCompleteGrossWeightAsAnd(string grossweightamount, string grossweightunit, string skipcheckbox)
        {
            GrossWeight.CompleteGrossWeightWithSkipFun(grossweightamount, grossweightunit, skipcheckbox);
        }

        [Then(@"verify Gross Weight validation message information")]
        public void ThenVerifyGrossWeightValidationMessageInformation()
        {
            Assert.True(GrossWeight.VerifySkipValidationInformation(), "Skip validation information displayed");
        }

        [Then(@"verify Gross Weight validation displayed against Net Weight")]
        public void ThenVerifyGrossWeightValidationDisplayedAgainstNetWeight()
        {
            Assert.True(GrossWeight.VerifyGrossAgainstNetWeightValidationMessage(), "gross weight validation message against net weight displayed");
            Assert.True(GrossWeight.VerifyGrossAgainstNetWeightFieldValidationMessage(), "gross weight validation message against net weight displayed");

        }

        [When(@"I add gross weight unit '([^']*)' leaving gross weight amount blank")]
        public void WhenIAddGrossWeightUnitLeavingGrossWeightAmountBlank(string grossweightunit)
        {
            GrossWeight.GrossWeightUnitAndGrossWeightAmountBlank(grossweightunit);
        }

        [Then(@"verify skip error validation displayed on page ""([^""]*)""")]
        public void ThenVerifySkipErrorValidationDisplayedOnPage(string errorMessage)
        {
            Assert.True(GrossWeight.VerifyskipErrorValidationOnPage(errorMessage));
        }

        [When(@"I fill Gross Weight unit without clicking save and continue button")]
        public void WhenIFillGrossWeightUnitWithoutClickingSaveAndContinueButton()
        {
            GrossWeight.FillGrossWeightUnit();
        }

        [Then(@"verify Gross Weight amount validation displayed on page ""([^""]*)""")]
        public void ThenVerifyGrossWeightAmountValidationDisplayedOnPage(string errorMessage)
        {
            Assert.True(GrossWeight.VerifyGrossWeightAmountErrorValidationOnPage(errorMessage));
        }

        [When(@"I fill Gross Weight amount without clicking save and continue button")]
        public void WhenIFillGrossWeightAmountWithoutClickingSaveAndContinueButton()
        {
            GrossWeight.FillGrossWeightAmount();
        }

        [Then(@"verify Gross Weight unit validation displayed on page ""([^""]*)""")]
        public void ThenVerifyGrossWeightUnitValidationDisplayedOnPage(string errorMessage)
        {
            Assert.True(GrossWeight.VerifyGrossWeightUnitErrorValidationOnPage(errorMessage));
        }

        [Given(@"I press back from check your answers page")]
        [When(@"I press back from check your answers page")]
        [Then(@"I press back from check your answers page")]
        public void WhenIPressBackFromCheckYourAnswersPage()
        {
            GrossWeight.ClickBackLink();
        }

        [When(@"I click save and continue button without adding gross weight amount and units")]
        public void WhenIClickSaveAndContinueButtonWithoutAddingGrossWeightAmountAndUnits()
        {
            Assert.True(GrossWeight.IsGrossWeightPage, "Gross weight page is not displayed");
            GrossWeight.ClickSaveAndContinue();
        }

    }
}
