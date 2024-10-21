using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using System.Text.RegularExpressions;

namespace Defra.UI.Tests.Pages.Exporter.Applications
{
    public class Applications : IApplications
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public int GlobalWeight => ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;

        #region Page Objects
        private string CountryFilterRows = "IE";
        private string DateFilterRows = "dateFilter-last14";
        private string StatusFilterRows = "status-3";
        private string StatusFilterDraft = "status-14";
        private string StatusFilterPendingReplacement = "status-19";
        private string StatusFilterReplacement = "status-21";
        private string StatusFilterReplaced = "status-20";
        private string StatusFilterSubmitted = "status-23";

        private By ApplicationPageHeaderBy => By.XPath("//div[@class='govuk-form-group']//span[contains(@class,'govuk-label')]");
        private By ApplicationsTableBy => By.CssSelector(".govuk-table.loaded");
        private IWebElement ApplicationsTable => _driver.WaitForElement(ApplicationsTableBy);
        private List<IWebElement> ApplicationTableRows => _driver.WaitForElements(By.XPath("//table[contains(@class,'govuk-table')]/tbody/tr")).ToList();
        private By CountryListCheckBoxesBy => By.CssSelector("#countryFilter fieldset .govuk-checkboxes .govuk-checkboxes__item");
        private By DateFilterRadioButtonBy => By.CssSelector("#dateFilter fieldset .govuk-radios .govuk-radios__item");
        private By StatusFilterButtonBy => By.CssSelector("#statusFilter fieldset .govuk-checkboxes .govuk-checkboxes__item");
        private By CountryFilterTableListBy => By.CssSelector("table.govuk-table tbody span.f-ie");
        private By DatesFilterTableListBy => By.CssSelector("table.govuk-table tbody");
        private By StatusFilterTableListBy => By.CssSelector("table.govuk-table.loaded tbody tr.govuk-table__row");
        private By GetFirstApplicationSerialBy => By.XPath("(//span[@class='small-text'])[1]");
        private By CopyApplicationButtonBy => By.PartialLinkText("Copy application");
        private By DeleteApplicationButtonBy => By.XPath("//a[contains(.,'Delete application')]");
        private By ShowLinkBy => By.XPath("(//span[contains(@class,'show')])[2]");
        private By ClickYesBy => By.XPath("//button[contains(.,'Yes')]");
        private By SearchBy => By.CssSelector("#app main div#main-content input#search");
        private By SearchResultsCountBy => By.CssSelector("p.moj-pagination__results");
        private By ViewApplicationButtonBy => By.XPath("//a[contains(.,'View application')]");
        private By GetFirstApplicationReferenceBy => By.XPath("(//span[@class='small-text'])[2]");
        private By ApplicationReferenceBy => By.XPath("//div[text() = ' Application Reference ']/following-sibling :: div");
        private By ApplPageHeaderBy => By.CssSelector("h1.govuk-heading-xl");
        private By CheckYourAnswersPageHeaderBy => By.ClassName("govuk-heading-l");
        private By ApplicationStatusBy => By.XPath("(//span[contains(@class, 'govuk-tag')])[2]");
        private By ClickReplacingApplicationBy => By.XPath("//div[contains(@class,'certficate-subtable govuk-inset-text')]//a");
        private IWebElement StartNewApplicationButton => _driver.FindElement(By.CssSelector(".Home .govuk-button--start"));
        private List<IWebElement> FilterButtonList => _driver.FindElements(By.CssSelector(".govuk-button--secondary")).ToList();
        private IWebElement SerialNumberTexts => _driver.FindElement(By.CssSelector("table.govuk-table tbody tr td.d-md-table-cell a .small-text"));
        private By CurrentPageBy => By.CssSelector(".moj-pagination__item--active");
        private IWebElement CurrentPage => _driver.WaitForElement(CurrentPageBy);
        private IWebElement NextPageLink => _driver.WaitForElement(By.CssSelector(".moj-pagination__item--next a"));
        private IWebElement LastPageLink => _driver.WaitForElement(By.XPath("//li[contains(@class,'pagination__item--next')]/preceding-sibling::li[1]/a"));
        private List<IWebElement> PaginationResultsList => _driver.FindElements(By.CssSelector(".moj-pagination__results b")).ToList();
        private IWebElement Search => _driver.WaitForElement(By.Id("search"));
        private IWebElement AppStatusCount => _driver.WaitForElement(By.XPath("//p[@class='moj-pagination__results pull-right']/b[3]"));
        private IWebElement HomePageHeader => _driver.WaitForElement(By.CssSelector(".Home .govuk-heading-xl"));
        private IWebElement SearchApplicationHeader => _driver.WaitForElement(ApplicationPageHeaderBy);
        private IWebElement SearchHint => _driver.WaitForElement(By.Id("search-hint"));
        private IWebElement ClearFiltersLink => _driver.WaitForElement(By.Id("search-hint"));
        private IWebElement TableHeaderElement => _driver.WaitForElement(By.CssSelector(".govuk-table.loaded thead"));
        private List<IWebElement> ApplicationSerialNumList => _driver.WaitForElements(By.XPath("//table[contains(@class,'loaded')]//tbody/tr/td[1]")).ToList();
        private IWebElement CertificateSubTable => _driver.WaitForElement(By.CssSelector(".certficate-subtable"));
        private List<IWebElement> ButtonGroupList => _driver.WaitForElements(By.XPath("//div[contains(@class,'certficate-subtable')]/following-sibling::div[contains(@class, 'govuk-button-group')]/a")).ToList();

        #endregion

        private string beforeDeleteAppRef;
        private string searchResultCountText;
        private string lastPageNum => LastPageLink.Text;

        public Applications(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsApplicationsPage
        {
            get => _driver.WaitForElement(ApplicationPageHeaderBy).Text.Contains("Search for an application");
        }

        #region Private Methods

        private void ClickFliterCountryButton()
        {
            FilterButtonList.SingleOrDefault(d => d.Text.Contains("Filter by Country")).Click();
        }
        private void ClickFliterDateButton()
        {
            FilterButtonList.SingleOrDefault(d => d.Text.Contains("Filter by Date")).Click();
        }
        private void ClickFliterStatusButton()
        {
            FilterButtonList.SingleOrDefault(d => d.Text.Contains("Filter by Status")).Click();
        }
        private bool IsCountriesDisplayed()
        {
            var countryList = _driver.WaitForElements(CountryListCheckBoxesBy).Count;
            return countryList > 0;
        }
        private bool IsDatesDisplayed()
        {
            var countryList = _driver.WaitForElements(DateFilterRadioButtonBy).Count;
            return countryList > 0;
        }
        private bool IsStatusDisplayed()
        {
            var countryList = _driver.WaitForElements(StatusFilterButtonBy, true).Count;
            return countryList > 0;
        }

        #endregion

        public void ClickStartNewApplicationButton() => StartNewApplicationButton.Click();

        public bool IsApplicationsTableDisplayed => ApplicationsTable.Displayed;

        public bool IsApplicationsTableRowsDisplayed()
        {
            return ApplicationTableRows.Count > 0;
        }

        public bool IsCountrylistDisplayed()
        {
            ClickFliterCountryButton();
            return IsCountriesDisplayed();
        }

        public bool IsDateListDisplayed()
        {
            ClickFliterDateButton();
            return IsDatesDisplayed();
        }

        public void ClickShowLink()
        {
            if (_driver.WaitForElement(ApplicationPageHeaderBy).Text.Contains("Search for an application"))
            {
                _driver.WaitForElement(ShowLinkBy, true).Click();
            }
        }

        public void ClickFirstApplicationLink()
        {
            _driver.WaitForElement(GetFirstApplicationReferenceBy, true).Click();
        }

        public void ClickViewApplication()
        {
            _driver.WaitForElement(ViewApplicationButtonBy, true).Click();
        }

        public void ClickCopyApplication()
        {
            ClickShowLink();
            _driver.WaitForElement(CopyApplicationButtonBy, true).Click();
        }

        public void ClickDeleteApplication()
        {
            ClickShowLink();
            beforeDeleteAppRef = _driver.WaitForElement(GetFirstApplicationSerialBy).Text;
            _driver.WaitForElement(DeleteApplicationButtonBy).Click();
            _driver.WaitForElement(ClickYesBy).Click();
        }

        public bool VerifyIfApplicationIsDeleted()
        {
            _driver.WaitForElement(SearchBy).Clear();
            _driver.WaitForElement(SearchBy).SendKeys(beforeDeleteAppRef);
            searchResultCountText = _driver.WaitForElement(SearchResultsCountBy, true).Text;
            return searchResultCountText.Contains("0 to 0 of 0");
        }

        public bool IsStatusListDisplayed()
        {
            ClickFliterStatusButton();
            return IsStatusDisplayed();
        }

        public bool IsCountryFiltered(string filter)
        {
            if (filter.Contains("ie"))
            {
                filter = CountryFilterRows;
            }
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id(filter))).Click();
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(CountryFilterTableListBy));
            var filterList = _driver.WaitForElements(CountryFilterTableListBy);
            return filterList.Select(d => d.GetAttribute("class").Contains(filter)).ToList().Count > 0;
        }

        public bool IsDateFiltered(string filter)
        {
            if (filter.Contains("last14"))
            {
                filter = DateFilterRows;
            }
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id(filter))).Click();
            var filterList = _driver.WaitForElements(DatesFilterTableListBy);
            return filterList.Count > 0;
        }

        public bool IsStatusFiltered(string filter)
        {
            if (filter.Contains("cancelled"))
            {
                filter = StatusFilterRows;
            }
            else if (filter.Contains("draft"))
            {
                filter = StatusFilterDraft;
            }
            else if (filter.Contains("pending replacement"))
            {
                filter = StatusFilterPendingReplacement;
            }
            else if (filter.Contains("replacement"))
            {
                filter = StatusFilterReplacement;
            }
            else if (filter.Contains("replaced"))
            {
                filter = StatusFilterReplaced;
            }
            else if (filter.Contains("submitted"))
            {
                filter = StatusFilterSubmitted;
            }
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.Id(filter))).Click();
            var filterList = _driver.WaitForElements(StatusFilterTableListBy);
            return filterList.Count > 0;
        }

        public bool VerifyViewApplication()
        {
            ClickShowLink();
            string beforeViewApplication = _driver.WaitForElement(GetFirstApplicationReferenceBy).Text;
            ClickViewApplication();
            _driver.WaitForElement(CheckYourAnswersPageHeaderBy, true).Text.Contains("Check your answers after submitting");
            string afterViewApplication = GetApplicationRefValue();
            return afterViewApplication.Contains(beforeViewApplication);
        }

        public bool VerifyViewApplicationReference()
        {
            ClickShowLink();
            string beforeViewApplication = _driver.WaitForElement(GetFirstApplicationReferenceBy).Text;
            ClickViewApplication();
            _driver.WaitForElement(ApplPageHeaderBy, true).Text.Contains("Apply for an export health certificate");
            string afterViewApplication = GetApplicationRefValue();
            return afterViewApplication.Contains(beforeViewApplication);
        }

        public string GetApplicationRefValue()
        {
            _driver.WaitForElement(ApplicationReferenceBy);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            //string refVal = (string)jsExecutor.ExecuteScript("return document.getElementById('appReference').value");
            string refVal = _driver.WaitForElement(ApplicationReferenceBy).Text;
            return refVal;
        }

        public bool SearchApplication(string application)
        {
            _driver.WaitForElement(SearchBy).SendKeys(application);
            searchResultCountText = _driver.WaitForElement(SearchResultsCountBy, true).Text;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(GlobalWeight));
            wait.Until(d => d.FindElement(SearchResultsCountBy).Text.Contains("1 to 1 of 1"));
            return true;
        }

        public bool VerifyStatus(string status)
        {
            return _driver.WaitForElementCondition(ExpectedConditions.ElementExists(ApplicationStatusBy)).Text.Contains(status);
        }

        public bool ClickReplacingApplication(string status)
        {
            var element = _driver.WaitForElementCondition(ExpectedConditions.ElementExists(ClickReplacingApplicationBy));
            bool isLinked = false;
            if (status == "replacement")
            {
                isLinked = element.FindElement(By.XPath("span")).Text.Contains("Replacing");
            }
            else if (status == "replaced")
            {
                isLinked = element.FindElement(By.XPath("span")).Text.Contains("Replaced by ");
            }

            element.Click();
            return isLinked;
        }

        public bool ClickReplacementApplication()
        {
            var element = _driver.WaitForElement(ClickReplacingApplicationBy, true);
            bool isLinked = element.FindElement(By.XPath("span")).Text.Contains("Awaiting replacement by ");
            element.Click();
            return isLinked;
        }

        public bool ValidateFirstPage => CurrentPage.Text.Contains("1");

        public void ClickNextPageLink() => NextPageLink.Click();

        public void ClickLastPageLink() => LastPageLink.Click();

        public bool ValidateIfNextPageIsDisplayed()
        {
            return _driver.WaitForElementCondition(ExpectedConditions.TextToBePresentInElementLocated(CurrentPageBy, "2"));
        }

        public bool ValidateIfLastPageIsDisplayed()
        {
            return _driver.WaitForElementCondition(ExpectedConditions.TextToBePresentInElementLocated(CurrentPageBy, lastPageNum));
        }

        public bool ValidateNumOfApplications()
        {
            foreach (var applicationNum in PaginationResultsList)
            {
                if (string.IsNullOrEmpty(applicationNum.Text))
                    return false;
            }
            return true;
        }

        public bool ValidateIfLastPageApplicationsAreDisplayed()
        {
            return PaginationResultsList.ElementAt(1).Text.Contains(PaginationResultsList.ElementAt(2).Text);
        }

        public bool VerifyCertificateStatus(string AppReferenceName)
        {
            bool CertStatus = false;
            string CertStatusPath = "//span[contains(text(),'" + AppReferenceName + "')]/../../following-sibling::td[6]/span/span";
            Search.Clear();
            Search.SendKeys(AppReferenceName);
            Search.Click();
            if (Convert.ToInt32(AppStatusCount.Text) > 0)
            {
                List<IWebElement> statusEle = _driver.WaitForElements(By.XPath(CertStatusPath)).ToList();

                foreach (IWebElement Ele in statusEle)
                {
                    CertStatus = Ele.Text.Contains("SUBMITTED TO CERTIFIER");
                    break;
                }
            }
            return CertStatus;
        }

        //Page validation methods
        public string GetHomePageHeader() => HomePageHeader.Text;
        public string GetSearchApplicationHeader() => SearchApplicationHeader.Text;
        public string GetSearchHintText() => SearchHint.Text.Trim();
        public bool IsStartNewAppButtonDisplayed => StartNewApplicationButton.Displayed;
        public string GetStartNewAppButtonText() => StartNewApplicationButton.Text.Trim();
        public bool IsSearchTextBoxDisplayed => Search.Displayed;
        public bool IsClearFiltersLinkDisplayed => ClearFiltersLink.Displayed;

        public List<string> GetFiltersTextList()
        {
            List<string> filtersActualTextList = new List<string>();
            foreach (var textElement in FilterButtonList)
            {
                filtersActualTextList.Add(textElement.Text.ToString());
            }
            return filtersActualTextList;
        }

        public List<string> GetTableHeaderElements()
        {
            List<string> tableHeaderListActual = new List<string>();
            var columnHeader = TableHeaderElement.FindElements(By.TagName("th"));
            foreach (var element in columnHeader)
            {
                tableHeaderListActual.Add(element.Text.ToString());
            }
            return tableHeaderListActual;
        }

        public bool ValidateApplicationSerialNum()
        {
            var applicationNumPattern = "^[a-zA-Z0-9]{15}$";
            Regex regToMatch = new Regex(applicationNumPattern);

            foreach (var appNum in ApplicationSerialNumList)
            {
                if (!regToMatch.IsMatch(appNum.Text))
                    return false;
            }
            return true;
        }

        public bool IsCertificateSubTableDisplayed => CertificateSubTable.Displayed;

        public List<string> GetButtonElements()
        {
            List<string> buttonTextsListActual = new List<string>();
            foreach (var element in ButtonGroupList)
            {
                buttonTextsListActual.Add(element.Text.ToString().Trim());
            }
            return buttonTextsListActual;
        }
    }
}
