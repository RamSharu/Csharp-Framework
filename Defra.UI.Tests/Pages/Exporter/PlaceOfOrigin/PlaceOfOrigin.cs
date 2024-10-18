using BoDi;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin
{
    public class PlaceOfOrigin : IPlaceOfOrigin
    {
        private IObjectContainer _objectContainer;

        public PlaceOfOrigin(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By PlaceOfOriginHeaderBy => By.CssSelector(".Origin .govuk-heading-xl");
        private By PlaceOfDispatchHeaderBy => By.CssSelector("#place-of-dispatch .govuk-heading-l");
        private By PlaceOfLoadingHeaderBy => By.CssSelector("#place-of-loading .govuk-heading-l");
        private By PlaceOfDispatchLinkBy => By.CssSelector("section#place-of-dispatch a.govuk-link");
        private By PlaceOfLoadingLinkBy => By.CssSelector("section#place-of-loading a.govuk-link");
        private IWebElement PlaceOfDispatchHeader => _driver.WaitForElement(PlaceOfDispatchHeaderBy);
        private IWebElement PlaceOfOriginLink => _driver.WaitForElement(By.CssSelector("div#place-of-origin dt.govuk-summary-list__key a.govuk-link"));
        private IWebElement CountryOfOrigin => _driver.WaitForElement(By.CssSelector("select#country-of-origin"));
        private IWebElement RegionOfOrigin => _driver.WaitForElement(By.XPath("//input[@id='region-of-origin']"));
        private IWebElement PlaceOfDispatchLink => _driver.WaitForElement(PlaceOfDispatchLinkBy);
        private IWebElement PlaceOfLoadingLink => _driver.WaitForElement(PlaceOfLoadingLinkBy);
        private IWebElement PlaceOfDispatchOperatorName => _driver.FindElement(By.CssSelector("#place-of-dispatch b[data-testid='operatorName']"));
        private IWebElement PlaceOfLoadingOperatorName => _driver.FindElement(By.CssSelector("#place-of-loading b[data-testid='operatorName']"));
        private IWebElement RemovePlaceOfDispatchLink => _driver.FindElement(By.CssSelector("#place-of-dispatch a.govuk-link"));
        private IWebElement RemovePlaceOfLoadingLink => _driver.FindElement(By.CssSelector("#place-of-loading a.govuk-link"));
        private IWebElement Country => _driver.WaitForElement(By.Id("operator-country"));
        private IWebElement OperatorName => _driver.WaitForElement(By.Id("operator-name"));
        private IWebElement OperatorSearch => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//a[contains(.,'Continue')]"));
        private IWebElement PlaceOfOriginStatusText => _driver.WaitForElement(By.XPath("//div[contains(@id,'place-of-origin')]/dd/span/span"));
        private IWebElement OperatorApproval => _driver.WaitForElement(By.XPath("//input[@id='approval-number']"));
        private By SkipCheckboxBy => By.XPath("//div[@id='skip-question-checkbox']");
        private By SkipCheckboxTickedBy => By.CssSelector("input#skip-question.govuk-checkboxes__input");
        private By SkipSection => By.Id("skip");
        private By SkipErrorMessage => By.Id("skipError");
        private By RemovePlaceOfDispatchBy => By.XPath("//section[@id='place-of-dispatch']//a");
        private By RemovePlaceOfLoadingBy => By.XPath("//section[@id='place-of-loading']//a");
        private IWebElement BackLink => _driver.FindElement(By.ClassName("govuk-back-link"));
        private By SpinnerElementBy => By.CssSelector(".fa-spinner");
        private IWebElement PlaceOfDispatchApproverNo => _driver.FindElement(By.CssSelector("#place-of-dispatch [data-testid='ApprovalNumber']"));
        private IWebElement PlaceOfLoadingApproverNo => _driver.FindElement(By.CssSelector("#place-of-loading [data-testid='ApprovalNumber']"));
        #endregion

        #region Methods
        public bool IsPlaceOfOriginPage => _driver.WaitForElement(PlaceOfOriginHeaderBy).Text.Contains("Place of origin");

        public bool IsPlaceOfDispatchDisplayed()
        {
            return PlaceOfDispatchHeader.Text.Contains("Place of dispatch");
        }
        public bool IsPlaceOfLoadingDisplayed()
        {
            return _driver.WaitForElement(PlaceOfLoadingHeaderBy).Text.Contains("Place of loading");
        }

        public bool IsPlaceOfOriginPageDisplayed()
        {
            PlaceOfOriginLink.Click();
            return _driver.PageSource.Contains("Place of origin");
        }

        public bool IsOperatorPageDisplayed(string page)
        {
            _driver.WaitForSpinnerToAppearAndDisappear(SpinnerElementBy);
            return _driver.PageSource.Contains(page);
        }

        public void ClickPlaceOfDispatchLink() => PlaceOfDispatchLink.Click();
        public void ClickPlaceOfLoadingLink() => PlaceOfLoadingLink.Click();



        public void CompletePlaceOfOriginAndContinue(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading)
        {
            CompleteRegionOfOrigin(countryOfOrigin);
            CompletePlaceOfDispatch(placeOfDispatchCountry, placeOfDispatch);
            CompletePlaceOfLoading(placeOfLoadingCountry, placeOfLoading);
            SaveAndContinue.Click();
        }

        public void CompletePlaceOfOrigin(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading)
        {
            CompleteRegionOfOrigin(countryOfOrigin);
            CompletePlaceOfDispatch(placeOfDispatchCountry, placeOfDispatch);
            CompletePlaceOfLoading(placeOfLoadingCountry, placeOfLoading);
        }

        public void CompletePlaceOfOriginByApprovalNumberAndContinue(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch, string placeOfLoadingCountry, string placeOfLoading, string searchByOpearetor="false")
        {
            CompleteRegionOfOrigin(countryOfOrigin);
            CompletePlaceOfDispatch(placeOfDispatchCountry, placeOfDispatch, searchByOpearetor);
            CompletePlaceOfLoading(placeOfLoadingCountry, placeOfLoading, searchByOpearetor);
            SaveAndContinue.Click();
        }

        public void CompletePlaceOfDispatch(string placeOfDispatchCountry, string placeOfDispatch, string SearchByOpearetor)
        {
            PlaceOfDispatchLink.Click();
            IsOperatorPageDisplayed("Place of dispatch");
            _driver.SelectFromDropdown(Country, placeOfDispatchCountry);
            if (SearchByOpearetor.Equals("true"))
            {
                _driver.ClickRadioButton("Search by operator name");
                OperatorName.SendKeys(placeOfDispatch);
            }
            if (SearchByOpearetor.Equals("false"))
            {
                _driver.ClickFristRadioButton("Search by approval number");
                OperatorApproval.SendKeys(placeOfDispatch);
            }
            OperatorSearch.Click();
            _driver.ClickRadioButton("Defra eTrade Exporters LTD");
            SaveAndContinue.Click();
        }

        public void CompletePlaceOfLoading(string placeOfLoadingCountry, string placeOfLoading, string SearchByOpearetor)
        {
            PlaceOfLoadingLink.Click();
            IsOperatorPageDisplayed("Place of loading");
            _driver.SelectFromDropdown(Country, placeOfLoadingCountry);
            if (SearchByOpearetor.Equals("true"))
            {
                _driver.ClickRadioButton("Search by operator name");
                OperatorName.SendKeys(placeOfLoading);
            }
            else if (SearchByOpearetor.Equals("false"))
            {
                _driver.ClickFristRadioButton("Search by approval number");
                OperatorApproval.SendKeys(placeOfLoading);
            }
            OperatorSearch.Click();
            _driver.ClickRadioButton("Defra eTrade Exporters LTD");
            SaveAndContinue.Click();
        }

        public void CompleteRegionOfOrigin(string countryOfOrigin)
        {
                _driver.SelectFromDropdown(CountryOfOrigin, countryOfOrigin);
                RegionOfOrigin.SendKeys("GB-0");
        }

        public void EditRegionOfOrigin(string countryOfOrigin, string regionOfOrigin)
        {
            _driver.SelectFromDropdown(CountryOfOrigin, countryOfOrigin);
            RegionOfOrigin.SendKeys(regionOfOrigin);
            SaveAndContinue.Click();
        }

        public void CompletePlaceOfDispatch(string placeOfDispatchCountry, string placeOfDispatch)
        {
            PlaceOfDispatchLink.Click();
            IsOperatorPageDisplayed("Place of dispatch");
            _driver.SelectFromDropdown(Country, placeOfDispatchCountry);
            _driver.ClickRadioButton("Search by operator name");
            OperatorName.SendKeys(placeOfDispatch);
            OperatorSearch.Click();
            _driver.ClickRadioButton(placeOfDispatch);
            SaveAndContinue.Click();
        }

        public string GetPlaceOfDispatchOperatorName => PlaceOfDispatchOperatorName.Text;

        public string GetPlaceOfLoadingOperatorName => PlaceOfLoadingOperatorName.Text;

        public void CompletePlaceOfLoading(string placeOfLoadingCountry, string placeOfLoading)
        {
            PlaceOfLoadingLink.Click();
            IsOperatorPageDisplayed("Place of loading");
            _driver.SelectFromDropdown(Country, placeOfLoadingCountry);
            _driver.ClickRadioButton("Search by operator name");
            OperatorName.SendKeys(placeOfLoading);
            OperatorSearch.Click();
            _driver.ClickRadioButton(placeOfLoading);
            SaveAndContinue.Click();
        }

        public bool VerifyPlaceOfOriginStatus()
        {
            var placeOfOriginStatus = PlaceOfOriginStatusText.Text;
            return placeOfOriginStatus.Contains("COMPLETE");
        }

        public void SkipAndContinue()
        {
            SkipCheckbox();
            SaveAndContinue.Click();
        }

        public void SkipCheckbox()
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(SkipSection));
            var r = _driver.WaitForElement(SkipCheckboxBy);
            if (!r.Selected)
                r.Click();
        }

        public void SaveContinue()
        {
            SaveAndContinue.Click();
        }

        public void ClickRemoveLink(string placeOfDispatchLoading)
        {
            if (placeOfDispatchLoading.Contains("dispatch"))
            {
                RemovePlaceOfDispatchLink.Click();
                _driver.WaitForElement(PlaceOfDispatchLinkBy, true).Text.Contains("Select");
            }
            else if (placeOfDispatchLoading.Contains("loading"))
            {
                RemovePlaceOfLoadingLink.Click();
                _driver.WaitForElement(PlaceOfLoadingLinkBy, true).Text.Contains("Select");
            }
            else
                throw new Exception("The section is neither place of dispatch nor place of loading");
        }

        public bool IsPlaceOfDispatchBlank()
        {
            return IsSkippedSectionsStillBlank(PlaceOfDispatchLink);
        }

        public bool IsPlaceOfLoadingBlank()
        {
            return IsSkippedSectionsStillBlank(PlaceOfLoadingLink);
        }

        private bool IsSkippedSectionsStillBlank(IWebElement SkippedSectionLink)
        {
            try
            {
                return SkippedSectionLink.Text.Contains("Select");
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public bool IsSkipCheckboxVisible()
        {
            try
            {
                _driver.FindElement(SkipCheckboxBy);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsSkipChecked()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(SkipCheckboxTickedBy).Selected);
            return true;            
        }

        public bool IsSkipError()
        {
            try
            {
                _driver.FindElement(SkipErrorMessage);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void RemovePlaceOfDispatch()
        {
            _driver.WaitForElement(RemovePlaceOfDispatchBy).Click();
        }

        public void RemovePlaceOfLoading()
        {
            _driver.WaitForElement(RemovePlaceOfLoadingBy).Click();
        }

        public void ClickBackLink()
        {
            BackLink.Click();
        }

        public void RemoveRegionOfOrigin()
        {
            while (!RegionOfOrigin.GetAttribute("value").Equals(""))
            {
                RegionOfOrigin.SendKeys(Keys.Backspace);
            }
        }

        public bool VerifyApprovalNoPresentInSearchItemsInsidePlaceOfDespatch(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch)
        {
            var expectedText = "Approval number:";
            var result = SearchAndFindElementTextInPlaceOfDispatch(placeOfDispatchCountry, placeOfDispatch, expectedText);
            return result;
        }

        public bool VerifyApprovalNoPresentInSearchItemsInsidePlaceOfLoading(string countryOfOrigin, string placeOfLoadingCountry, string placeOfLoading)
        {
            var expectedText = "Approval number:";
            var result = SearchAndFindElementTextInPlaceOfLoading(placeOfLoadingCountry, placeOfLoading, expectedText);
            return result;
        }

        public bool VerifyApprovalNoPresentInTwoTypesOfPlaceSections()
        {
            var expectedText = "Approval number:";
            var result = false;
            result = PlaceOfDispatchApproverNo.Text.Contains(expectedText);
            if (result)
            {
                result = PlaceOfLoadingApproverNo.Text.Contains(expectedText);
            }
            return result;
        }
        #endregion

        private bool SearchAndFindElementTextInPlaceOfDispatch(string placeOfDispatchCountry, string placeOfDispatch, string expectedText)
        {
            PlaceOfDispatchLink.Click();
            IsOperatorPageDisplayed("Place of dispatch");
            _driver.SelectFromDropdown(Country, placeOfDispatchCountry);
            _driver.ClickRadioButton("Search by operator name");
            OperatorName.SendKeys(placeOfDispatch);
            OperatorSearch.Click();
            var elements = _driver.GetRadioButtonChildElements(placeOfDispatch);
            return elements.Any(x => x.Text.Contains(expectedText));
        }

        private bool SearchAndFindElementTextInPlaceOfLoading(string placeOfLoadingCountry, string placeOfLoading, string expectedText)
        {
            PlaceOfLoadingLink.Click();
            IsOperatorPageDisplayed("Place of loading");
            _driver.SelectFromDropdown(Country, placeOfLoadingCountry);
            _driver.ClickRadioButton("Search by operator name");
            OperatorName.SendKeys(placeOfLoading);
            OperatorSearch.Click();
            var elements = _driver.GetRadioButtonChildElements(placeOfLoading);
            return elements.Any(x => x.Text.Contains(expectedText));
        }
    }
}
