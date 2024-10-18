using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant
{
    public class ColdStoreAndManufacturingPlantPage : IColdStoreAndManufacturingPlantPage
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public ColdStoreAndManufacturingPlantPage(ObjectContainer container)
        {
            _objectContainer = container;
            _driver = _objectContainer.Resolve<IWebDriver>();
        }
        public ColdStoreAndManufacturingPlantPage(IWebDriver driver)
        {
            _driver = driver;
            //_objectContainer.Resolve<IWebDriver>(); 
        }

        #region Page Objects
        private IWebElement ApproverElementInput => _driver.WaitForElement(By.CssSelector("div.EstablishmentlookupPage #approval-number"));
        private IWebElement CertifierApproverElementInput => _driver.WaitForElement(By.XPath("//input[@class='govuk-input'][contains(@id,'STORE')]"));
        private IWebElement CertifierOperatorElementInput => _driver.WaitForElement(By.XPath("//input[@id='search-field-MANUFACTURING_PLANT']"));
        private IWebElement ColdStoreOperatorSearch => _driver.WaitForElement(By.Id("search-field-COLD_STORE"));
        private IWebElement OperatorElementInput => _driver.WaitForElement(By.Id("operator-name"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//a[contains(.,'Save and continue')]"));
        private IWebElement SaveAndContinueButtonElement => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement SearchButton => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement SearchButtonColdStore => _driver.WaitForElement(By.XPath("(//*[@id='search-field-COLD_STORE']/ following-sibling::div/button) | (//span[contains(text(),'Search')]/..)"));
        private IWebElement SearchButtonElement => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement SearchButtonManPlant => _driver.WaitForElement(By.XPath("//*[@id='search-field-MANUFACTURING_PLANT']/ following-sibling::div/button"));
        private IWebElement SearchByApprovalColdStore => _driver.WaitForElement(By.XPath("//label[@for='search-by-approval-COLD_STORE']"));
        private IWebElement SearchByOperatorNameColdStore => _driver.WaitForElement(By.XPath("//input[@id='search-field-COLD_STORE']"));
        private IList<IWebElement> SelectColdStorelist => _driver.FindElements(By.XPath("//input[@class='govuk-radios__input']"));
        private IWebElement SelectFirstOperatorActivity => _driver.WaitForElement(By.XPath("(//select[@id='operator-search-filter-category'])[1]"));
        private IWebElement SelectOperatorActivity => _driver.WaitForElement(By.CssSelector("select#operator-search-filter-category"));
        private IWebElement SelectOperatorTopActivity => _driver.WaitForElement(By.CssSelector("select#operator-search-filter-classification"));
        private IWebElement SelectSearchByApprovalNumber => _driver.WaitForElement(SelectSearchByApprovalNumberBy);
        private IWebElement SearchByApprovalNumber => _driver.WaitForElement(SearchByApprovalNumberBy);
        private IWebElement SelectSearchByOperatorName => _driver.WaitForElement(SelectSearchByOperatorNameBy);
        private IWebElement SearchByOperatorName => _driver.WaitForElement(SearchByOperatorNameBy);
        private IWebElement SelectThisActivityButton => _driver.WaitForElement(By.XPath("//button[contains(.,'Select this activity')]"));
        private IWebElement SelectThisActivityFirstButton => _driver.WaitForElement(By.XPath("(//button[contains(.,'Select this activity')])[1]"));
        private IList <IWebElement> ApprovalNumberAlert => _driver.FindElements(By.Id("search-field-approval-number-error"));
        private IWebElement ApprovalNumberAlertMessage => _driver.WaitForElement(ApprovalNumberAlertMessageBy);
        private IList <IWebElement> ApprovalNumberSearchResults => _driver.FindElements(By.Id("select-organisation"));
        private IList <IWebElement> OperatorNameAlert => _driver.FindElements(By.Id("search-field-organisation-name-error"));

        private IWebElement OperatorNameAlertMessage => _driver.WaitForElement(By.Id("search-field-organisation-name-error"));
        private IList <IWebElement> OperatorNameSearchResults => _driver.FindElements(By.Id("select-organisation"));
        private IWebElement OrganisationAlert => _driver.WaitForElement(By.Id("results-error"));
        private IWebElement OperatorActivities => _driver.WaitForElement(By.XPath("//span[@class='govuk-hint']"));
        private IWebElement SearchResults => _driver.WaitForElement(SearchResultsBy);
        private By SearchResultsBy => By.Id("select-organisation");        
        private By ApprovalNumberAlertMessageBy => By.Id("search-field-approval-number-error");

        private By SearchForOperatorLabelBy => By.CssSelector(".EstablishmentlookupPage .govuk-fieldset__heading");
        private By SelectSearchByApprovalNumberBy => By.XPath("//input[@data-aria-controls='search-by-approval-number']");
        private By SearchByApprovalNumberBy => By.Id("approval-number");
        private By SelectSearchByOperatorNameBy => By.Id("operator");
        private By SearchByOperatorNameBy => By.Id("operator-name");
        #endregion

        #region Methods

        public bool IsColdStoreAndManufacturingPlantPage
        {
            get => _driver.WaitForElement(SearchForOperatorLabelBy).Text.Contains("Search for an operator");
        }

        public void FillColdStore()
        {
            ColdStoreOperatorSearch.SendKeys("Karro");
            SearchButtonColdStore.Click();
            _driver.SelectFromDropdown(SelectOperatorTopActivity, "PROCESSING_PLANT");
            _driver.SelectFromDropdown(SelectFirstOperatorActivity, "PROCESSING_PLANT");
            SelectThisActivityFirstButton.Click();
            SaveAndContinueButtonElement.Click();
        }

        public void FillProcessingPlant(bool ApprovalNumber, string ApprovalNumberInput, bool OperatorName, string OperatorNameInput, string ActivityInput)
        {
            if (ApprovalNumber)
            {
                ApproverElementInput.SendKeys(ApprovalNumberInput);
                _driver.ClickRadioButton(ApprovalNumberInput);
                SearchButtonColdStore.Click();
                _driver.SelectFromDropdown(SelectOperatorTopActivity, "Processing Plant");
                _driver.SelectFromDropdown(SelectOperatorActivity, "Processing Plant");
                SelectThisActivityButton.Click();
            }
            else if (OperatorName)
            {
                _driver.ClickRadioButton("Search by organisation name");
                OperatorElementInput.SendKeys(OperatorNameInput);
                SearchButtonElement.Click();
                _driver.ClickRadioButton(OperatorNameInput);
            }
            else
            {
                throw new Exception("Data is not either Operator or Approver ");
            }

            SaveAndContinueButtonElement.Click();
            SelectColdStoreBtn(SelectColdStorelist, ActivityInput);
        }

        private void SelectColdStoreBtn(IList<IWebElement> SelectColdStorelist, string activityInput)
        {
            foreach (IWebElement ele in SelectColdStorelist)
            {
                if (ele.GetAttribute("value").Contains(activityInput))
                {
                    Actions action = new Actions(_driver);
                    action.MoveByOffset(50, 50).Perform();
                    ele.Click();
                    SaveAndContinueButton.Click();
                    break;
                }
            }
        }

        public void ApprovalNumberSearch(string approvalNumber)
        {
            _driver.ClickRadioButtonOption("by approval number");
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SearchByApprovalNumberBy)).SendKeys(approvalNumber);
            SearchButton.Click();         
        }

        public void SearchOperatorByName(string operatorName)
        {
            _driver.ClickRadioButtonOption("by organisation name");
            OperatorElementInput.SendKeys(operatorName);
            SearchButtonElement.Click();
        }

        public void SelectOperatorNameRadio(string operatorNameInput)
        {
            _driver.ClickRadioButton(operatorNameInput);
        }

        public void GoToApprovalNumberSearch()
        {
            _driver.ClickRadioButtonOption("by approval number");
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SearchByApprovalNumberBy));
        }

        public void GoToOperatorNameSearch()
        {
            _driver.ClickRadioButtonOption("by organisation name");
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SearchByOperatorNameBy));
        }

        public int IsApprovalNumberAlertPresent()
        {
            return ApprovalNumberAlert.Count();
        }

        public bool IsApprovalNumberSearchCleared()
        {
            return SearchByApprovalNumber.GetAttribute("value").Equals("");
        }

        public int IsApprovalNumberSearchResultsPresent()
        {
            return ApprovalNumberSearchResults.Count();
        }

        public int IsOperatorNameAlertPresent()
        {
            return OperatorNameAlert.Count();
        }

        public bool IsOperatorNameSearchCleared()
        {
            return SearchByOperatorName.GetAttribute("value").Equals("");
        }

        public int IsOperatorNameSearchResultsPresent()
        {
            return OperatorNameSearchResults.Count();
        }

        public void ClickSaveAndContinue() => SaveAndContinueButtonElement.Click();

        public bool ApprovalNumberThrowsAlert()
        {
            return ApprovalNumberAlertMessage.Text.Contains("Enter the organisation's approval number");
        }

        public bool OperatorNameThrowsAlert()
        {
            return OperatorNameAlertMessage.Text.Contains("Enter the organisation's name");
        }

        public bool OrganisationAlertIsThrown()
        {
            return OrganisationAlert.Text.Contains("Select an organisation");
        }

        public bool SearchResultsAreReturned()
        {
            return _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(SearchResultsBy)).Displayed;            
        }

        public bool SearchResultsText(string searchResult)
        {
            return SearchResults.Text.Contains(searchResult);
        }

        public string[] GetActivitiesOfOperator()
        {
            string[] activitiesText = OperatorActivities.Text.Split(new string[] { "Activities:" }, StringSplitOptions.None);
            string[] splitActivities = activitiesText[1].Split(',');
            return splitActivities;
        }

        //Certifier operator selection methods
        public void FillCertifierColdStore(bool ApprovalNumber, string ApprovalNumberInput, bool OperatorName, string OperatorNameInput, string ActivityInput)
        {
            if (ApprovalNumber)
            {
                CertifierApproverElementInput.SendKeys(ApprovalNumberInput);
                SearchByApprovalColdStore.Click();
                SearchButtonColdStore.Click();
                _driver.SelectFromDropdown(SelectOperatorTopActivity, "PROCESSING_PLANT");
                _driver.SelectFromDropdown(SelectOperatorActivity, "PROCESSING_PLANT");
                SelectThisActivityButton.Click();

            }
            else if (OperatorName)
            {
                SearchByOperatorNameColdStore.SendKeys(OperatorNameInput);
                SearchButtonColdStore.Click();
                _driver.SelectFromDropdown(SelectOperatorActivity, "PROCESSING_PLANT");
                SelectThisActivityButton.Click();
            }
            else
            {
                throw new Exception("Data is not either Operator or Approver ");
            }
        }

        public void FillCertifierManufacturingPlant(bool ApprovalNumber, string ApprovalNumberInput, bool OperatorName, string OperatorNameInput, string ActivityInput)
        {
            if (ApprovalNumber)
            {
                CertifierApproverElementInput.SendKeys(ApprovalNumberInput);
                SearchButtonColdStore.Click();
            }
            else if (OperatorName)
            {
                CertifierOperatorElementInput.SendKeys(OperatorNameInput);
                SearchButtonManPlant.Click();
                _driver.SelectFromDropdown(SelectOperatorActivity, "PROCESSING_PLANT");
                SelectThisActivityButton.Click();
            }
            else
            {
                throw new Exception("Data is not either Operator or Approver ");
            }
        }
        #endregion
    }
}
