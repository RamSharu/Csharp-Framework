using Defra.UI.Framework.Driver;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.PlaceDestination
{
    public interface IPlaceDestination
    {
        public bool IsPlaceOfDestinationPage { get; }
        public void ClickRemoveLink();
        public bool VerifyPlaceDestination(string placeOfDestCountry, string placeOfDestination);
        public void AddPlaceOfDestination(string placeOfDestCountry, string placeOfDestination);
        public bool IsPlaceDestinationDetailsCompleted();
        public bool IsPlaceOfDestinationPageDisplayed();
        public void ClickToSelectAPlaceOfDestination();
        public void SelectDestinationSearchCountry(string destinationCountry);
        public void EnterDestinationSearchName(string destinationName);
        public void ClickSearch();
        public int IsDestinationCountryAlertPresent();
        public int IsDestinationNameAlertPresent();
        public int IsSearchResultsPresent();
        public bool SearchResultsAreReturned();
        public bool DestinationCountryThrowsAlert();
        public bool DestinationNameThrowsAlert();

    }
}
