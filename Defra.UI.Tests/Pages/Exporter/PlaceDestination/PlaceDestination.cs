using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.Exporter.MeansOfTransport;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.PlaceDestination
{
    public class PlaceDestination : IPlaceDestination
    {
        private IObjectContainer _objectContainer;

        public PlaceDestination(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page objects
        private By PlaceOfDestinationPageHeaderBy => By.CssSelector("div.PlaceOfDestination h1.govuk-heading-xl");
        private By SelectCountryBy => By.Id("operator-country");
        private IWebElement PlaceOfDestinationPageHeader => _driver.WaitForElement(PlaceOfDestinationPageHeaderBy);
        private IWebElement PlaceOfDestinationLink => _driver.WaitForElement(By.CssSelector("div#place-of-destination dt.govuk-summary-list__key a.govuk-link"));
        private IWebElement SelectPlaceOfDest => _driver.WaitForElement(By.XPath("//a[contains(.,'Select a place of destination')]"));
        private IWebElement SelectCountry => _driver.WaitForElement(SelectCountryBy);
        private IWebElement PlaceOfDestName => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.XPath("//input[@id='operator-search']")));
        private IWebElement Search => _driver.WaitForElement(By.XPath("//span[contains(text(),'Search')]/.."));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//a[contains(text(),'Continue')]"));
        private IWebElement PlaceOfDestStatus => _driver.WaitForElement(By.CssSelector("div#place-of-destination.govuk-summary-list__row span.govuk-tag span"));
        private IList <IWebElement> DestinationCountryAlert => _driver.FindElements(DestinationCountryAlertMessageBy);
        private IWebElement DestinationCountryAlertMessage => _driver.WaitForElement(DestinationCountryAlertMessageBy);
        private IList <IWebElement> DestinationNameAlert => _driver.FindElements(DestinationNameAlertMessageBy);
        private IWebElement DestinationNameAlertMessage => _driver.WaitForElement(DestinationNameAlertMessageBy);
        private IList<IWebElement> SearchResults => _driver.FindElements(SearchResultsBy);
        private List<IWebElement> RemoveLinkList => _driver.FindElements(By.XPath("//a[contains(text(),'Remove')]")).ToList();
        private By DestinationCountryAlertMessageBy => By.Id("operator-search-country-error");
        private By DestinationNameAlertMessageBy => By.Id("operator-search-organisation-name-error");
        private By SearchResultsBy => By.Id("select-organisation");




        #endregion

        #region Methods

        public bool IsPlaceOfDestinationPage => _driver.WaitForElement(PlaceOfDestinationPageHeaderBy).Text.Contains("Place of destination");

        public void ClickRemoveLink()
        {
            if (RemoveLinkList.Count > 0)
                RemoveLinkList.ElementAt(0).Click();
        }

        public bool VerifyPlaceDestination(string placeOfDestCountry, string placeOfDestination)
        {
            PlaceOfDestinationLink.Click();
            AddPlaceOfDestination(placeOfDestCountry, placeOfDestination);
            return true;
        }

        public void AddPlaceOfDestination(string placeOfDestCountry, string placeOfDestination)
        {
            if (PlaceOfDestinationPageHeader.Text.Contains("Place of destination"))
            {
                SelectPlaceOfDest.Click();
                _driver.SelectFromDropdown(SelectCountry, placeOfDestCountry);
                PlaceOfDestName.Click();
                PlaceOfDestName.SendKeys(placeOfDestination);
                Search.Click();
                _driver.ClickRadioButton(placeOfDestination);
                SaveAndContinue.Click();
                Continue.Click();
            }
        }

        public bool IsPlaceDestinationDetailsCompleted()
        {
            return PlaceOfDestStatus.Text.Contains("COMPLETE"); ;
        }

        public bool IsPlaceOfDestinationPageDisplayed()
        {
            PlaceOfDestinationLink.Click();
            return _driver.PageSource.Contains("Place of destination");
        }

        public void ClickToSelectAPlaceOfDestination() => SelectPlaceOfDest.Click();

        public void SelectDestinationSearchCountry(string destinationCountry)
        {
            _driver.WaitForElementCondition(ExpectedConditions.TextToBePresentInElement(SelectCountry, "United Kingdom - Northern Ireland"));
            _driver.SelectFromDropdown(SelectCountry, destinationCountry);
        }

        public void EnterDestinationSearchName(string destinationName)
        {
            PlaceOfDestName.Click();
            PlaceOfDestName.SendKeys(destinationName);
        }

        public void ClickSearch()
        {
            Search.Click();
        }

        public int IsDestinationCountryAlertPresent()
        {
            return DestinationCountryAlert.Count();
        }

        public int IsDestinationNameAlertPresent()
        {
            return DestinationNameAlert.Count();
        }

        public int IsSearchResultsPresent()
        {
            return SearchResults.Count();
        }

        public bool SearchResultsAreReturned()
        {
            return _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SearchResultsBy)).Displayed;
        }

        public bool DestinationCountryThrowsAlert()
        {
            return DestinationCountryAlertMessage.Text.Contains("Select a country");
        }

        public bool DestinationNameThrowsAlert()
        {
            return DestinationNameAlertMessage.Text.Contains("Enter a place of destination name");
        }

        #endregion
    }
}
