using BoDi;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Defra.UI.Tests.Pages.Exporter.PlaceDestination;
using Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class PlaceDestinationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public PlaceDestinationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IPlaceDestination? Place => _objectContainer.IsRegistered<IPlaceDestination>() ? _objectContainer.Resolve<IPlaceDestination>() : null;

        [Then(@"verify place of destination by adding '([^']*)' and '([^']*)'")]
        public void ThenVerifyPlaceOfDestinationByAddingAnd(string placeofDestCountry, string placeofDestination)
        {
            Assert.True(Place.VerifyPlaceDestination(placeofDestCountry, placeofDestination), "PlaceDestination entry not completed");
        }

        [Then(@"place of destination details added successfully")]
        public void ThenPlaceOfDestinationDetailsAddedSuccessfully()
        {
            Assert.True(Place.IsPlaceDestinationDetailsCompleted(), "PlaceDestination details not added successfully");
        }
        
        [Given(@"I navigate to place of destination")]
        [When(@"I navigate to place of destination")]
        [Then(@"I navigate to place of destination")]
        public void WhenINavigateToPlaceOfDestination()
        {
            Assert.True(Place.IsPlaceOfDestinationPageDisplayed(), "Place of destination page not displayed");
        }

        [Given(@"select a place of destination")]
        [When(@"select a place of destination")]
        [Then(@"select a place of destination")]
        public void GivenSelectAPlaceOfDestination()
        {
            Place.ClickToSelectAPlaceOfDestination();
        }

        [Then(@"search by '([^']*)' and '([^']*)'")]
        public void ThenSearchByAnd(string destinationCountry, string destinationName)
        {

            if (destinationName.Equals("empty") && destinationCountry.Equals("empty"))
            {
                Place.ClickSearch();
                Assert.AreEqual(1, Place.IsDestinationCountryAlertPresent(), "Destination Country alert is not present");
                Assert.True(Place.DestinationCountryThrowsAlert(), "Destination Country alert text is wrong");
                Assert.AreEqual(1, Place.IsDestinationNameAlertPresent(), "Destination Name alert text is not displayed");
                Assert.True(Place.DestinationNameThrowsAlert(), "Destination Name alert text is wrong");
            }

            if (!destinationName.Equals("empty") && !destinationCountry.Equals("empty"))
            {
                Place.SelectDestinationSearchCountry(destinationCountry);
                Place.EnterDestinationSearchName(destinationName);
                Place.ClickSearch();
                Assert.AreEqual(0, Place.IsDestinationCountryAlertPresent(), "Destination Country alert is  present");
                Assert.AreEqual(0, Place.IsDestinationNameAlertPresent(), "Destination Name alert is present");
            }

            if (destinationCountry.Equals("empty") && !destinationName.Equals("empty"))
            {
                Place.EnterDestinationSearchName(destinationName);
                Place.ClickSearch();
                Assert.AreEqual(1, Place.IsDestinationCountryAlertPresent(), "Destination Country alert is not present");
                Assert.True(Place.DestinationCountryThrowsAlert(), "Destination Country alert text is wrong");
            }

            if (!destinationCountry.Equals("empty"))
            {
                Place.SelectDestinationSearchCountry(destinationCountry);
                Place.ClickSearch();
                Assert.AreEqual(0, Place.IsDestinationCountryAlertPresent(), "Destination Country alert is  present");
            }

            if (destinationName.Equals("empty") && !destinationCountry.Equals("empty"))
            {
                Place.SelectDestinationSearchCountry(destinationCountry);
                Place.ClickSearch();
                Assert.AreEqual(1, Place.IsDestinationNameAlertPresent(), "Destination Name alert text is not displayed");
                Assert.True(Place.DestinationNameThrowsAlert(), "Destination Name alert text is wrong");
            }

            if (!destinationName.Equals("empty"))
            {
                Place.EnterDestinationSearchName(destinationName);
                Place.ClickSearch();
                Assert.AreEqual(0, Place.IsDestinationNameAlertPresent(), "Destination Name alert is present");
            }
        }




    }
}
