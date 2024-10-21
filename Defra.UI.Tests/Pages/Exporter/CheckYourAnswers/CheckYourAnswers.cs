using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.CheckYourAnswers
{
    public class CheckYourAnswers : ICheckYourAnswers
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public CheckYourAnswers(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private By CheckYourAnsPageHeaderBy => By.CssSelector(".EhcTaskSummaryList .govuk-heading-l");
        private IWebElement BackLink => _driver.WaitForElement(By.CssSelector(".EhcTaskSummaryList .govuk-back-link"));
        private IWebElement CheckAndContinueButton => _driver.WaitForElement(By.XPath("//button[contains(.,'Check and continue')]"));
        private List<IWebElement> RequiredSectionsList => _driver.FindElements(By.CssSelector(".govuk-list .task")).ToList();
        private List<IWebElement> SummaryOfTasksList => _driver.FindElements(By.CssSelector(".govuk-summary-list")).ToList();
        private IWebElement ChangeGrossWeight => _driver.WaitForElement(By.XPath("//*[@id='grossWeight']/div[3]/a"));
        private IWebElement ChangeCommodity => _driver.WaitForElement(By.XPath("//*[@id='manageCommodities']/div[3]/a"));
        private IWebElement ChangeGoodsCertifiedAs => _driver.WaitForElement(By.XPath("//*[@id='goodsCertifiedAs']/div[3]/a"));
        private IWebElement ChangeContainerNoSealNo => _driver.WaitForElement(By.XPath("//*[@id='containerNoSealNo']/div[3]/a"));
        private IWebElement ChangePurposeOfExport => _driver.WaitForElement(By.XPath("//*[@id='purposeOfTheExport']/div[3]/a"));
        private IWebElement ChangeAccompanyingDocs => _driver.WaitForElement(By.XPath("//*[@id='accompanyingDocuments']/div[3]/a"));
        private IWebElement ChangeConsignorOrExporter => _driver.WaitForElement(By.XPath("//*[@id='consignor']/div[3]/a"));
        private IWebElement ChangeConsigneeOrImporter => _driver.WaitForElement(By.XPath("//*[@id='consignee']/div[3]/a"));
        private IWebElement ChangeCertifier => _driver.WaitForElement(By.XPath("//*[@id='certifier']/div[3]/a"));
        private IWebElement ChangeRegionOfCertification => _driver.WaitForElement(By.XPath("//*[@id='regionOfCertification']/div[3]/a"));
        private IWebElement ChangeResponsibleForLoad => _driver.WaitForElement(By.XPath("//*[@id='operator']/div[3]/a"));
        private IWebElement ChangeDepartureAndArrival => _driver.WaitForElement(By.XPath("//*[@id='arrivalAndDeparture']/div[3]/a"));
        private IWebElement ChangeCountryOfOrigin => _driver.WaitForElement(By.XPath("//*[@id='place-of-origin-country']/div[3]/a"));
        private IWebElement ChangePlaceOfLoading => _driver.WaitForElement(By.XPath("//*[@id='place-of-origin-loading']/div[3]/a"));
        private IWebElement ChangePlaceOfDispatch => _driver.WaitForElement(By.XPath("//*[@id='place-of-origin-dispatch']/div[3]/a"));
        private IWebElement ChangeEntryBCP => _driver.WaitForElement(By.XPath("//*[@id='borderControlPost']/div[3]/a"));
        private IWebElement ChangeMeansOfTransport => _driver.WaitForElement(By.XPath("//*[@id='meansOfTransport']/div[3]/a"));
        private IWebElement ChangePlaceOfDestination => _driver.WaitForElement(By.XPath("//*[@id='placeOfDestination']/div[3]/a"));
        private By PlaceOfOriginCountry => By.Id("place-of-origin-country");
        private By PlaceOfOriginRegion => By.Id("place-of-origin-region");
        private By PlaceOfOriginDispatchBy => By.CssSelector("#place-of-origin-dispatch .govuk-summary-list__value div");
        private IWebElement PlaceOfOriginDispatch => _driver.FindElement(PlaceOfOriginDispatchBy);
        private By PlaceOfOriginLoadingBy => By.CssSelector("#place-of-origin-loading .govuk-summary-list__value div");
        private IWebElement PlaceOfOriginLoading => _driver.FindElement(PlaceOfOriginLoadingBy);
        private By SkippedBCPTextStatusBy => By.CssSelector("#skipBcpNotEntered");
        private By NumberOfCommodityRecords => By.XPath("//div[contains(text(),'1 record for 1 commodity')]");
 
        #endregion

        #region Methods

        public bool IsCheckYourAnswersPage
        {
            get => _driver.WaitForElement(CheckYourAnsPageHeaderBy).Text.Contains("Check your answers before submitting");
        }

        public bool ValidateBackLink => BackLink.Displayed;

        public bool CheckIfRequiredFieldsAreDisplayed()
        {
            if (RequiredSectionsList.Count > 0)
                return true;
            else
                throw new Exception("Required list of tasks doesn't exist on check your answers page");
        }

        public bool CheckIfListOfTasksForTheAppIsDisplayed()
        {
            if (SummaryOfTasksList.Count > 0)
                return true;
            else
                throw new Exception("Task list summary doesn't exist on check your answers page");
        }

        public void ClickChangeCommodity() => ChangeCommodity.Click();
        public void ClickChangeGrossWeight() => ChangeGrossWeight.Click();
        public void ClickChangeGoodsCertifiedAs() => ChangeGoodsCertifiedAs.Click();
        public void ClickChangeContainerNoSealNo() => ChangeContainerNoSealNo.Click();
        public void ClickChangePurposeOfExport() => ChangePurposeOfExport.Click();
        public void ClickChangeAccompanyingDocs() => ChangeAccompanyingDocs.Click();
        public void ClickConsignorOrExporter() => ChangeConsignorOrExporter.Click();
        public void ClickConsigneeOrImporter() => ChangeConsigneeOrImporter.Click();
        public void ClickChangeCertifier() => ChangeCertifier.Click();
        public void ClickChangeRegionOfCertification() => ChangeRegionOfCertification.Click();
        public void ClickChangeResponsibleForLoad() => ChangeResponsibleForLoad.Click();
        public void ClickChangeDepartureAndArrival() => ChangeDepartureAndArrival.Click();
        public void ClickChangeCountryOfOrigin() => ChangeCountryOfOrigin.Click();
        public void ClickChangePlaceOfLoading() => ChangePlaceOfLoading.Click();
        public void ClickChangePlaceOfDispatch() => ChangePlaceOfDispatch.Click();
        public void ClickChangeEntryBCP() => ChangeEntryBCP.Click();
        public void ClickChangeMeansOfTransport() => ChangeMeansOfTransport.Click();
        public void ClickChangePlaceOfDestination() => ChangePlaceOfDestination.Click();

        public void ClickCheckAndContinueButton()
        {
            CheckAndContinueButton.Click();
        }
        public string GetPlaceOfDispatch() => PlaceOfOriginDispatch.Text;
        public string GetPlaceOfLoading() => PlaceOfOriginLoading.Text;

        public bool CheckPlaceOfOrigin(string section, string text)
        {
            bool isValid = false;
            bool isColour = true;
            switch (section)
            {
                case "country":
                    isValid = _driver.WaitForElement(PlaceOfOriginCountry).Text.Contains(text);
                    isColour = isColourValid(text);
                    break;
                case "region":
                    isValid = _driver.WaitForElement(PlaceOfOriginRegion).Text.Contains(text);
                    isColour = isColourValid(text);
                    break;
                case "loading":
                    isValid = _driver.WaitForElement(PlaceOfOriginLoadingBy).Text.Contains(text);
                    isColour = isColourValid(text);
                    break;
                case "dispatch":
                    isValid = _driver.WaitForElement(PlaceOfOriginDispatchBy).Text.Contains(text);
                    isColour = isColourValid(text);
                    break;
                default:
                    break;
            }

            return isValid && isColour;
        }

        private bool isColourValid(string text)
        {
            var isColourValid = true;
            if (text == "Not entered")
            {
                var colour = _driver.WaitForElement(PlaceOfOriginCountry).GetCssValue("color");
                if (colour != "rgba(11, 12, 12, 1)") isColourValid = false;
            }
            return isColourValid;
        }

        public bool IsSkippedFeatureShowNotEntry(string NotEntered)
        {
            return _driver.WaitForElement(SkippedBCPTextStatusBy).Text.Contains("Not entered");
        }

        public bool NumberOfCommoditiesRecords()
        {
            return _driver.WaitForElement(NumberOfCommodityRecords).Text.Contains("1 record for 1 commodity");
        }
        #endregion
    }
}
