using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.Commodity
{
    public class Commodity : ICommodity
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public Commodity(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects
        private By PageHeadingBy => By.CssSelector("div.CommoditySummaryPage h1.govuk-heading-xl");
        private By TaskPageHeadingBy => By.CssSelector("div.EhcTaskList h1.govuk-heading-xl");
        IWebElement PageHeading => _driver.WaitForElement(PageHeadingBy);
        IWebElement StartNewApplicationElement => _driver.WaitForElement(By.CssSelector("button.govuk-button--start"));
        IWebElement EhcNewLandingHeadingElement => _driver.WaitForElement(By.CssSelector("div.EhcNewLanding h1"));
        IWebElement ApplicationHomePageElement => _driver.WaitForElement(By.CssSelector("button.govuk-button--start"));
        IWebElement ApplicationRefrenceElement => _driver.WaitForElement(By.CssSelector("div.StartNewEhc input#user-reference"));
        IWebElement SearchCertifierElement => _driver.WaitForElement(By.CssSelector("div.CertificateLookupPage input#search-term"));
        IWebElement CommoditiesLookupPageInputElement => _driver.WaitForElement(By.CssSelector("div.CommoditiesLookupPage input#search-term"), true);
        By CommoditySearchResultBy => By.CssSelector(".govuk-radios__label .govuk-tag");
        IWebElement SaveAndContinueButtonElement => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        IWebElement CertifierContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Continue')]"));
        //IWebElement AddAnotherComm => _driver.WaitForElement(By.XPath("//input[@id='add-another-commodity-no']"));
        IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//a[contains(.,'Save and continue')]"));
        IWebElement RemoveRecords => _driver.WaitForElement(By.PartialLinkText("Remo"));
        By RemoveRadioButtonBy => By.CssSelector("div.RemoveCommodity #confirm-remove-cn");
        IWebElement CertificatePageHeading => _driver.WaitForElement(By.CssSelector("div.CertificateLookupPage h1.govuk-fieldset__heading"));
        IWebElement CopyRecords => _driver.WaitForElement(By.PartialLinkText("Copy"));
        IWebElement ChangeRecords => _driver.WaitForElement(By.XPath("//section[@id='commodityGroups']//a[contains(text(),'Change')]"));
        IWebElement ChangeRecordsSecond => _driver.WaitForElement(By.XPath("//section[@id='commodityGroups']//dt/strong[contains(text(),'NEW')]/../following-sibling::dd//a[contains(text(),'Change')]"));
        IWebElement ProductDescElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'PRODUCT_DESCRIPTION')]"));
        IWebElement PkgCountElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'PACKAGE_COUNT')]"));
        IWebElement WeightElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'NET_WEIGHT')]"));
        IWebElement VerifyUpdatedRecord => _driver.WaitForElement(By.Id("govuk-notification-banner-title"));
        IWebElement VerifyUpdatedNetWeight => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'NET_WEIGHT')]"));
        IWebElement ChangeActivity => _driver.WaitForElement(By.XPath("//a[contains(text(),'Change activity')]"));
        IWebElement Activity => _driver.WaitForElement(By.XPath("//p[contains(.,'Activity:')]"));
        IWebElement CommodityStatus => _driver.WaitForElement(By.XPath("//a[contains(text(),'Manage commodities')]/../following-sibling::dd/span/span"));
        IWebElement ManageCommodityLink => _driver.WaitForElement(By.XPath("//div[@id='manage-commodities']//a[contains(text(),'Manage commodities')]"));
        private List<IWebElement> ListOfAllActualErrorMessagesOnCommodityPage => _driver.FindElements(By.XPath("//li/a[@class='govuk-link']")).ToList();
        IWebElement ActualErrorMsgAgainstPckgCountField => _driver.WaitForElement(By.XPath("//span[contains(text(),'Enter the number of packages for this commodity')]"));
        IWebElement ActualErrorMsgAgainstPacakageTypeValidationField => _driver.WaitForElement(By.XPath("//span[contains(text(),'Select the type of packaging that the commodity will use')]"));
        IWebElement ActualErrorMsgAgainstWeightUnitValidationField => _driver.WaitForElement(By.XPath("//span[contains(text(),'Select the unit of weight for the commodity')]"));
        IWebElement ActualErrorMsgAgainstNetWeightValidationField => _driver.WaitForElement(By.XPath("//span[contains(text(),'Enter the net weight of the commodity')]"));
        IWebElement SkipErrorMsgBottomPage => _driver.WaitForElement(By.Id("skip-error"));
        private By SkipCheckboxBy => By.XPath("//input[@id='skip-functionality']");
        IWebElement ClickContinueButton => _driver.WaitForElement(By.XPath("//button[contains(.,'Continue')]"));
        IWebElement ReviewAndSubmitLink => _driver.WaitForElement(By.CssSelector("div#review-and-submit-application a.govuk-link"));
        IWebElement CheckAndContinueLink => _driver.WaitForElement(By.XPath("//button[contains(.,'Check and continue')]"));

        private By SkipSection => By.Id("skip-functionality");
        private By AddAnotherComm => By.XPath("//input[@id='add-another-commodity-no']");


        #endregion

        private int numRecordsBeforeCopy;
        private int numRecordsAfterCopy;

        public bool IsCommoditiesPage => !string.IsNullOrEmpty(_driver.WaitForElement(PageHeadingBy).Text);

        public void StartNewApplication()
        {
            StartNewApplicationElement.Click();
            var ehcNewLandingtxt = EhcNewLandingHeadingElement.Text;
            if (ehcNewLandingtxt.Contains("health certificate"))
                ApplicationHomePageElement.Click();
        }
        private object _lock = new object();
        private TimeSpan timeout;

        public void EnterRefAndcontinue(string reference)
        {
            lock (_lock)
            {
                Random rnd = new Random();
                int randomNum = rnd.Next(200, 999);
                ApplicationRefrenceElement.SendKeys(reference + randomNum);
                SaveAndContinueButtonElement.Click();
            }
        }
        public void EnterSelectCertificateAndContinue(string commodity)
        {
            SearchCertifierElement.SendKeys(commodity);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _driver.ClickRadioButton(commodity);
            CertifierContinue.Click();
        }

        public void EnterSelectCommodityAndContinue(string commodityCode)
        {
            CommoditiesLookupPageInputElement.SendKeys(commodityCode);
            _driver.WaitForElement(CommoditySearchResultBy).Text.Contains(commodityCode);
            _driver.ClickRadioButton(commodityCode);
            SaveAndContinueButtonElement.Click();
        }

        public bool VerifyCommodity()
        {
            return CommodityStatus.Text.Contains("ADDED");
        }

        public void ClickNoRadioForAddMoreCommodity()
        {
            _driver.ClickRadioButton("No");
            CertifierContinue.Click();
        }

        public void CopyCommodityRecords()
        {
            _driver.WaitForElement(TaskPageHeadingBy);
            ManageCommodityLink.Click();
            _driver.WaitForElement(PageHeadingBy);
            numRecordsBeforeCopy = int.Parse(PageHeading.Text.Split()[1]);
            CopyRecords.Click();
            SaveAndContinueButtonElement.Click();
        }

        public bool VerifyCopyRecords()
        {
            _driver.WaitForElement(PageHeadingBy);
            numRecordsAfterCopy = int.Parse(PageHeading.Text.Split()[1]);
            return numRecordsAfterCopy > numRecordsBeforeCopy;
        }

        public void RemoveCommodityRecords()
        {
            _driver.WaitForElement(TaskPageHeadingBy);
            ManageCommodityLink.Click();
            _driver.WaitForElement(PageHeadingBy); RemoveRecords.Click();
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(RemoveRadioButtonBy)).Click();
            CertifierContinue.Click();
        }

        public bool VerifyRemoveRecords()
        {
            bool certificatePageStatus = CertificatePageHeading.Text.Contains("Select a certificate for your export");
            return certificatePageStatus;
        }

        public void ChangeCommodityRecord(string productDesc, string packageCount, string netWeight)
        {
            _driver.WaitForElement(TaskPageHeadingBy);
            ManageCommodityLink.Click();
            _driver.WaitForElement(PageHeadingBy);
            ChangeRecords.Click();
            UpdateCommodityRecord(productDesc, packageCount, netWeight);
        }

        public void UpdateNetWeightAmount(string netWeight)
        {
            ClickChangeRecords();
            if (!string.IsNullOrEmpty(netWeight))
            {
                WeightElement.Clear();
                WeightElement.SendKeys(netWeight);
            }
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(SkipSection));
            var r = _driver.FindElement(SkipCheckboxBy);
            if (!r.Selected)
                r.Click();
            SaveAndContinueButtonElement.Click();
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(AddAnotherComm));
            _driver.ClickRadioButton("No");
            ClickContinueButton.Click();
            CheckAndContinueLink.Click();
        }

        public void CopyAndUpdateCommodityRecord(string productDesc, string packageCount, string netWeight)
        {
            _driver.WaitForElement(TaskPageHeadingBy);
            ManageCommodityLink.Click();
            _driver.WaitForElement(PageHeadingBy);
            CopyRecords.Click();
            UpdateCommodityRecord(productDesc, packageCount, netWeight);
        }

        public void UpdateCommodityRecord(string productDesc, string packageCount, string netWeight)
        {
            if (!string.IsNullOrEmpty(productDesc))
                ProductDescElement.Clear();
            ProductDescElement.SendKeys(productDesc);

            if (!string.IsNullOrEmpty(packageCount))
            {
                PkgCountElement.Clear();
                PkgCountElement.SendKeys(packageCount);
            }

            if (!string.IsNullOrEmpty(netWeight))
            {
                WeightElement.Clear();
                WeightElement.SendKeys(netWeight);
            }
            SaveAndContinueButtonElement.Click();
        }

        public bool VerifyChangeRecords()
        {
            bool updateStatus = VerifyUpdatedRecord.Text.Contains("Success");
            return updateStatus;
        }

        public void ChangeCommodityActivity(string activityName)
        {
            _driver.WaitForElement(TaskPageHeadingBy);
            ManageCommodityLink.Click();
            _driver.WaitForElement(PageHeadingBy);
            ChangeRecords.Click();
            ChangeActivity.Click();
            _driver.ClickRadioButtonOption(activityName);
            SaveAndContinueButton.Click();
        }

        public bool VerifyCommodityActivity(string activityName)
        {
            bool changeActivityStatus = Activity.Text.Contains(activityName);
            SaveAndContinueButtonElement.Click();
            return changeActivityStatus;
        }

        public bool VerifyNetWeight(string netWeight, string record)
        {
            _driver.WaitForElement(PageHeadingBy);
            if (record == "Copy")
                ChangeRecordsSecond.Click();
            else
                ChangeRecords.Click();

            bool updatedNetWeight = VerifyUpdatedNetWeight.GetAttribute("value").Contains(netWeight);
            return updatedNetWeight;
        }

        public void ClickChangeRecords()
        {
            ChangeRecords.Click();
        }

        public bool VerifyValidationErrorMessagesTopOfPage(string specificField)
        {
            return VerifyCommodityErrorMessage("Select if you have answered as many questions as you can") && VerifyCommodityErrorMessage(ExceptedValidationMsgAgainstSpecificField(specificField));
        }

        public bool VerifySkipValidationErrorMsgBottomOfPage()
        {
            bool result = false;
            try
            {
                if (SkipErrorMsgBottomPage.Text.Contains("Select if you have answered as many questions as you can"))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }   

        public bool VerifyValidationMsgAgainstSpecificField(string specificField)
        {
            bool result = false;
            switch (specificField)
            {
                case "PkgCount":
                    result = ActualErrorMsgAgainstPckgCountField.Text.Contains(ExceptedValidationMsgAgainstSpecificField(specificField));
                    break;
                case "PkgUnit":
                    result = ActualErrorMsgAgainstPacakageTypeValidationField.Text.Contains(ExceptedValidationMsgAgainstSpecificField(specificField));
                    break;
                case "Weight":
                    result = ActualErrorMsgAgainstNetWeightValidationField.Text.Contains(ExceptedValidationMsgAgainstSpecificField(specificField));
                    break;
                case "WeightUnit":
                    result = ActualErrorMsgAgainstWeightUnitValidationField.Text.Contains(ExceptedValidationMsgAgainstSpecificField(specificField));
                    break;

            }
            return result;
        }

        public string ExceptedValidationMsgAgainstSpecificField(string specificField)
        {
            string expectedCommodityPageErrorMsg = string.Empty;
            switch (specificField)
            {
                case "PkgCount":
                    expectedCommodityPageErrorMsg = "Enter the number of packages for this commodity";
                    break;
                case "PkgUnit":
                    expectedCommodityPageErrorMsg = "Select the type of packaging that the commodity will use";
                    break;
                case "Weight":
                    expectedCommodityPageErrorMsg = "Enter the net weight of the commodity";
                    break;
                case "WeightUnit":
                    expectedCommodityPageErrorMsg = "Select the unit of weight for the commodity";
                    break;
            }
            return expectedCommodityPageErrorMsg;
        }

        public bool VerifyCommodityErrorMessage(string expectedErrorMessage)
        {
            bool flag = false;
            foreach (IWebElement errorMsgs in ListOfAllActualErrorMessagesOnCommodityPage)
            {
                if (errorMsgs.Text.Contains(expectedErrorMessage))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
