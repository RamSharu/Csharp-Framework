using BoDi;
using Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class IdentificationSteps
    {
        private readonly IObjectContainer _objectContainer;

        private IIdentificationPage Identification => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        private IColdStoreAndManufacturingPlantPage ColdStoreAndManufacturingPlant => _objectContainer.IsRegistered<IColdStoreAndManufacturingPlantPage>() ? _objectContainer.Resolve<IColdStoreAndManufacturingPlantPage>() : null;

        public IdentificationSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Given(@"I am on the Identification page")]
        public void GivenIAmOnTheIdentificationPage()
        {
            Assert.IsTrue(Identification.IsIdentificationPage, "Identification page is not displayed");
        }

        [When(@"I click on select manufacturing plant link")]
        public void WhenIClickOnSelectManufacturingPlantLink()
        {
            Identification.ClickManufacturingPlantLink();
        }

        [When(@"I am on the Establishment lookup page")]
        public void WhenIAmOnTheEstablishmentLookupPage()
        {
            Assert.IsTrue(ColdStoreAndManufacturingPlant.IsColdStoreAndManufacturingPlantPage, "Establishment look up page to find Manufacturing plant, cold store, slaughterhouse, etc is not displayed");
        }

        [When(@"I search for the operator '([^']*)'")]
        [When(@"I search for an operator '([^']*)' that has multiple of the same activity")]
        public void WhenISearchForAnOperatorThatHasMultipleOfTheSameActivity(string opertaorName)
        {
            ColdStoreAndManufacturingPlant.SearchOperatorByName(opertaorName);
        }

        [Then(@"I can see that multiple activities with similar names are displayed as one in the activities section of searched operator")]
        public void ThenICanSeeThatMultipleActivitiesWithSimilarNamesAreDisplayedAsOneInTheActivitiesSectionOfSearchedOperator()
        {
            string[] operatorActivitiesArr = ColdStoreAndManufacturingPlant.GetActivitiesOfOperator();
            Assert.True(operatorActivitiesArr.Length == operatorActivitiesArr.Distinct().Count(), "Duplicate activity displayed on establishment lookup page");
        }

        [When(@"I select '([^']*)' from the operator search results and click save and continue")]
        public void WhenISelectFromTheOperatorSearchResultsAndClickSaveAndContinue(string operatorName)
        {
            ColdStoreAndManufacturingPlant.SelectOperatorNameRadio(operatorName);
            ColdStoreAndManufacturingPlant.ClickSaveAndContinue();
        }
    }
}
