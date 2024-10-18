using BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo;
using Defra.UI.Tests.Pages.Exporter.GoodsCertifiedAs;
using Defra.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Certifier.Applications
{
    public class CertifierApplications : ICertifierApplications
    {
        private IObjectContainer _objectContainer;

        public CertifierApplications(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IGoodsCertifiedAs? GoodsCertifiedAs => _objectContainer.IsRegistered<IGoodsCertifiedAs>() ? _objectContainer.Resolve<IGoodsCertifiedAs>() : null;
        private IContainerOrSealNo? ContainerOrSealNo => _objectContainer.IsRegistered<IContainerOrSealNo>() ? _objectContainer.Resolve<IContainerOrSealNo>() : null;

        #region Page Objects
        private IWebElement CountryFilterBy => _driver.WaitForElement(By.XPath("//*[@data-target='#countryFilter']"));
        private IWebElement DateFilterBy => _driver.WaitForElement(By.XPath("//*[@data-target='#dateFilter']"));
        private IWebElement StatusFilterBy => _driver.WaitForElement(By.XPath("//*[@data-target='#statusFilter']"));
        private By HideFilterBy => By.LinkText("Hide filter");
        private By ClearFilterBy => By.XPath("//a[contains(.,'Clear all filters')]");
        private IWebElement ClearFilterLink => _driver.WaitForElement(ClearFilterBy);
        private By CountryListCheckBoxesBy => By.CssSelector("#countryFilter fieldset .govuk-checkboxes .govuk-checkboxes__item");
        private By DateFilterRadioButtonBy => By.CssSelector("#dateFilter fieldset .govuk-radios .govuk-radios__item");
        private By StatusFilterButtonBy => By.CssSelector("#statusFilter fieldset .govuk-checkboxes .govuk-checkboxes__item");
        private By ApplicationsTableBy => By.CssSelector(".govuk-table.loaded");
        private IWebElement ShowLink => _driver.WaitForElement(By.CssSelector("span.pi.pi-chevron-circle-down"));
        private IWebElement HideLinkBy => _driver.FindElement(By.CssSelector("span.pi.pi-chevron-circle-up"));
        private By ViewApplicationLinkBy => By.CssSelector("a.govuk-link.small-text");
        private By PageNumbersBy => By.CssSelector(".moj-pagination__list");
        private By CurrentPageBy => By.CssSelector(".moj-pagination__item--active");
        private IWebElement CurrentPage => _driver.WaitForElement(CurrentPageBy);
        private IWebElement AssignApplicationBy => _driver.WaitForElement(By.XPath("//button[normalize-space() = 'Assign']"));
        private By SelectCertifierBy => By.Id("certifier-allocation");
        private SelectElement SelectCertifier => new SelectElement(_driver.FindElement(SelectCertifierBy));
        private SelectElement SelectCertifierNew => new SelectElement(_driver.FindElement(SelectCertifierBy));
        private IWebElement AssignToCertifierBy => _driver.WaitForElement(By.XPath("//button[normalize-space() = 'Assign to certifier']"));
        private IWebElement CancelApplicationBy => _driver.WaitForElement(By.XPath("//a[normalize-space() = 'Cancel application']"));
        private IWebElement YesCancelApplicationBy => _driver.WaitForElement(By.XPath("//button[normalize-space() = 'Yes']"));
        private IWebElement NoCancelApplicationBy => _driver.WaitForElement(By.XPath("//button[normalize-space() = 'No']"));
        private By ApplicationStatusBy => By.CssSelector("span.govuk-tag.CertifierCancelled");
        private IWebElement ApplicationStatus => _driver.WaitForElement(ApplicationStatusBy);
        private IWebElement AddNewLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Add new')]"));
        private IWebElement AppStatusCount => _driver.WaitForElement(By.XPath("//p[@class='moj-pagination__results pull-right']/b[3]"));
        private IWebElement ChangeFirstRecordOperator => _driver.WaitForElement(By.XPath("(//button[contains(.,'Change selection')])[1]"));
        private IWebElement ClickCommodityParentTabDetails => _driver.WaitForElement(By.XPath("//span[contains(.,'Commodity')]"));
        private IWebElement ClickCommodityDetails => _driver.WaitForElement(By.XPath("//h2[contains(.,'Commodity')]/following-sibling::div/div/div/div/a/span/following-sibling::span"));
        private IWebElement ClickContainerNumberSealNumberDetails => _driver.WaitForElement(By.XPath("//span[contains(.,'Container Number/Seal Number')]"));
        private IWebElement ClickFirstApplicationLink => _driver.WaitForElement(By.CssSelector("td.govuk-table__cell a.govuk-link.small-text"));
        private IWebElement EditExistingRecordLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Edit')]"));
        private IWebElement EditLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement EditCommodityLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[1]"));
        private IWebElement EditGoodsCertifiedAsLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement EditContainerNumberOrSealNumberLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[3]"));
        private IWebElement EditTypeOfConsignmentLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[4]"));
        private IWebElement EditExporterOrConsignorLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[1]"));
        private IWebElement EditImporterOrConsigneeLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement EditResponsibleForLoadLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[3]"));
        private IWebElement EditRegionOfCertificationLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[4]"));
        private IWebElement EditDepartureAndArrivalLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[1]"));
        private IWebElement EditPlaceOfOriginLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement EditPlaceOfDestinationLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[3]"));
        private IWebElement EditBorderControlPostLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[4]"));
        private IWebElement EditMeansOfTransportLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[5]"));  
        private IWebElement Edit => _driver.WaitForElement(By.XPath("//button[contains(.,'Edit')]"));
        private IWebElement NewCommodityText => _driver.WaitForElement(By.XPath("//li[contains(.,'Identification - Product 1')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.CssSelector("div.Home h1.govuk-heading-xl"));
        private IWebElement PageTitle => _driver.WaitForElement(By.CssSelector("div.Home span.govuk-label"));
        private IWebElement PersonsInvolved => _driver.WaitForElement(By.XPath("//span[contains(.,'Persons Involved')]"));
        private IWebElement SaveAndReturn => _driver.FindElement(By.XPath("//button[contains(.,'Save and return')]"));
        private IWebElement SaveAndReturnButton => _driver.FindElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement SearchAppl => _driver.WaitForElement(By.XPath("//input[contains(@id,'search')]"));
        private IWebElement RegionOfOriginScotland => _driver.WaitForElement(By.XPath("//label[contains(.,'Scotland')]"));
        private IWebElement ResponsibleForLoad => _driver.WaitForElement(By.XPath("//span[contains(.,'Responsible for Load')]"));
        private IWebElement ResponsibleForLoadCountry => _driver.WaitForElement(By.XPath("//select[@id='operator-country']"));
        private IWebElement OperatorSearch => _driver.WaitForElement(By.XPath("//input[@name='operator-search']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));
        private IWebElement SearchButton => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement DescriptionOfGoods => _driver.WaitForElement(By.XPath("//span[contains(.,'Description of the Goods')]"));
        private IWebElement PurposeOfExport => _driver.FindElement(By.XPath("//span[contains(.,'Purpose of the export')]"));
        private IWebElement PurposeOfExportReEntry => _driver.WaitForElement(By.XPath("//label[contains(.,'Re-entry')]"));
        private IWebElement CommodityLink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Commodity']"));
        private IWebElement GoodsCertifiedAsLink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Goods Certified As']"));
        private IWebElement ContainerNumberOrSealNumber => _driver.WaitForElement(By.XPath("//a[contains(.,'Container Number/Seal Number')]"));
        private IWebElement TypeOfConsignmentLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Type of consignment')]"));
        private IWebElement ExporterOrConsignorLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Exporter or Consignor')]"));
        private IWebElement ImporterOrConsigneeLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Importer or Consignee')]"));
        private IWebElement ResponsibleForLoadLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Select a responsible for load')]"));
        private IWebElement RegionOfCertification => _driver.FindElement(By.XPath("//span[contains(.,'Region of certification')]"));
        private IWebElement DepartureAndArrivallink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Departure and Arrival']"));
        private IWebElement PlaceOfOriginlink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Place of Origin']"));
        private IWebElement PlaceOfDestinationlink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Place of Destination']"));
        private IWebElement BorderControlPostLink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Border Control Post']"));
        private IWebElement MeansOfTransportlink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Means of Transport']"));
        private IWebElement GoodsCertifiedAsSerchBox => _driver.WaitForElement(By.XPath("//input[@id='search-goods-certified-as']"));
        private IWebElement RemoveExistingRecordLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Remove')]"));
        private IWebElement RemoveContainerAndsealnum => _driver.WaitForElement(By.XPath("//tbody/tr[2]/td[3]/button[1]"));
        private IWebElement TransportLink => _driver.WaitForElement(By.XPath("//span[normalize-space()='Transport']"));
        private IWebElement Departure => _driver.WaitForElement(By.XPath("//input[@name='departure']"));
        private IWebElement EstimatedArrival => _driver.WaitForElement(By.XPath("//input[@name='arrival']"));
        private IWebElement VehicleBox => _driver.WaitForElement(By.Id("vehicle-trailer-number-0"));
        private IWebElement TransportTab => _driver.WaitForElement(By.XPath("//span[normalize-space()='Transport']"));
        private IWebElement ChangeLink => _driver.WaitForElement(By.Id("change-selection"));
        private IWebElement SkipError => _driver.WaitForElement(By.XPath("//p[@id='skip-error' and not(self::span)]"));
        private IWebElement BcpError => _driver.WaitForElement(By.CssSelector("#validation-errors .govuk-error-summary a"));
        private IWebElement AssignCert => _driver.WaitForElement(By.XPath("//button[normalize-space() ='Assign']"));
        private IWebElement CertifierAllocation => _driver.WaitForElement(By.Id("certifier-allocation"));
        private IWebElement AssignToCertifier => _driver.WaitForElement(By.XPath("//button[normalize-space() ='Assign to certifier']"));
        private IWebElement GetCertifierName => _driver.WaitForElement(By.XPath("//div[contains(@class ,'certficate-subtable')]//tbody//td[3]"));
        private IWebElement AddMeansOfTransport => _driver.WaitForElement(By.XPath("//button[contains(.,'Add means of transport')]"));
        private IWebElement MeansOfTransport => _driver.WaitForElement(By.CssSelector("#meansOfTransportSelection"));
        private IWebElement TransConditionValidationText => _driver.WaitForElement(By.CssSelector("a[href='#tcondition']"));
        private By SkipCheckboxBy => By.XPath("//input[@id='skip-question']");
        private By PlaceOfDispatchLinkBy => By.CssSelector("section#place-of-dispatch a.govuk-link");
        private By PlaceOfLoadingLinkBy => By.CssSelector("section#place-of-loading a.govuk-link");
        private IWebElement PlaceOfDispatchLink => _driver.WaitForElement(PlaceOfDispatchLinkBy);
        private IWebElement PlaceOfLoadingLink => _driver.WaitForElement(PlaceOfLoadingLinkBy);
        private IWebElement PlaceOfDispatchRemoveLink => _driver.WaitForElement(PlaceOfDispatchLinkBy);
        private IWebElement PlaceOfLoadingRemoveLink => _driver.WaitForElement(PlaceOfLoadingLinkBy);
        private IWebElement PlaceOfOriginOperatorName => _driver.WaitForElement(By.Id("operator-name"));
        private IWebElement PlaceOfOrigiOperatorSearch => _driver.WaitForElement(By.XPath("//button[contains(.,'Search')]"));
        private IWebElement ChangeBCPText => _driver.WaitForElementExists(By.CssSelector("h3[class='govuk-heading-s']"));
        private IWebElement CountryElement => _driver.WaitForElement(By.XPath("//select[@id='country']"));
        private IWebElement SearchInputAvlOptions => _driver.WaitForElement(By.XPath("//input[@id='search-border-post-name']"));
        private IReadOnlyCollection<IWebElement> tableElements => _driver.WaitForElements(By.CssSelector("div.border-inspection-post"));
        private List<IWebElement> IdentificationDataModalLabelList => _driver.WaitForElements(By.XPath("//section[@id='questions']/div[contains(@class,'govuk-form-group')]/label[contains(@class,'govuk-label') and not (contains(@class,'govuk-visually-hidden'))]|//div[@class='govuk-form-group']//h1[@class='govuk-fieldset__heading']")).ToList();
        private IWebElement RFLValidationInformation => _driver.WaitForElement(By.XPath("//ul[@class='govuk-list govuk-error-summary__list']"));
        private IWebElement DepartureAndArrivalPanelLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Departure and Arrival')]"));
        private IWebElement ValidationlocatorDepartureArrival => _driver.WaitForElement(By.XPath("//section[@id='validation-errors']//ul[@class='govuk-list govuk-error-summary__list']"));

        #endregion Page Objects

        #region Methods

        public bool IsApplicationsPage
        {
            get => PageHeading.Text.Contains("export health certificate");
        }

        #region Private Methods

        private void ClickFilterCountryButton() => CountryFilterBy.Click();

        private void ClickFilterDateButton() => DateFilterBy.Click();

        private void ClickFilterStatusButton() => StatusFilterBy.Click();

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

        private bool IsCountriesDisplayed()
        {
            var countryList = _driver.WaitForElements(CountryListCheckBoxesBy).Count;
            return countryList > 0;
        }

        private void ClickAssignApplication() => AssignApplicationBy.Click();

        private void SelectCertifierFromDropdown()
        {
            _driver.WaitForElement(SelectCertifierBy, true);
            SelectCertifier.SelectByText("Declan Certifier");
        }

        private void ClickAssignToCertifier() => AssignToCertifierBy.Click();

        private void ClickCancelApplication() => CancelApplicationBy.Click();

        private void ClickYesForCancelApplication() => YesCancelApplicationBy.Click();

        private void ClickNoForCancelApplication() => NoCancelApplicationBy.Click();

        private void SelectFromDropdown(IWebElement pkgUnitElement, string pkgUnit)
        {
            string script = $"const element = arguments[0]; element.value = '" + pkgUnit + "'; element.dispatchEvent(new Event('change')); element.dispatchEvent(new Event('blur'));";
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", pkgUnitElement);
        }

        #endregion
        public bool IsTitleDisplayed()
        {
            return PageTitle.Text.Contains("Search for an application");
        }

        public bool IsSearchBoxDisplayed => SearchAppl.Displayed;

        public void ClickClearFiltersButton() => ClearFilterLink.Click();

        public bool IsClearFiltersLinkDisplayed()
        {
            var clearFilterList = _driver.WaitForElements(ClearFilterBy);
            return clearFilterList.Count > 0;
        }

        public bool IsCountrylistDisplayed()
        {
            ClickFilterCountryButton();
            return IsCountriesDisplayed();
        }

        public bool IsDateListDisplayed()
        {
            ClickFilterDateButton();
            return IsDatesDisplayed();
        }
        public bool IsStatusListDisplayed()
        {
            ClickFilterStatusButton();
            return IsStatusDisplayed();
        }
        public bool IsApplicationsTableDisplayed()
        {
            var ApplicationsTableRowList = _driver.WaitForElements(ApplicationsTableBy);
            return ApplicationsTableRowList.Count > 0;
        }
        public void ClickShowLink() => ShowLink.Click();

        public bool IsApplicationLinkDisplayed()
        {
            var ViewApplicationList = _driver.WaitForElements(ViewApplicationLinkBy);
            return ViewApplicationList.Count > 0;
        }

        public bool IsPageNumberDisplayed()
        {
            var PageNumberList = _driver.WaitForElements(PageNumbersBy);
            return PageNumberList.Count == 1;
        }

        public bool IsCurrentPageNumberDisplayed()
        {
            return CurrentPage.Text.Contains("1");
        }

        public void AssignApplicationToCertifier()
        {
            ClickShowLink();
            ClickAssignApplication();
            SelectCertifierFromDropdown();
            ClickAssignToCertifier();
        }

        public bool IsApplicationAssigned()
        {
            ClickShowLink();
            return GetCertifierName.Text.Contains("Declan Certifier");
        }

        public void CancelApplication()
        {
            ClickShowLink();
            ClickCancelApplication();
            ClickYesForCancelApplication();
        }

        public bool IsApplicationCancelled()
        {
            return _driver.WaitForElement(ApplicationStatusBy).Text.Contains("CERTIFIER CANCELLED");
        }

        public void AddNewRecord() => AddNewLink.Click();

        public void ChangeRecordOperator() => ChangeFirstRecordOperator.Click();

        public void ClickFirstApplication() => ClickFirstApplicationLink.Click();

        public void ClickToViewCommodityDetails() => ClickCommodityDetails.Click();

        public void ClickToCollapseCommodityParentTabDetails() => ClickCommodityParentTabDetails.Click();

        public void ClickToViewContainerNumberSealNumberTabDetails() => ClickContainerNumberSealNumberDetails.Click();

        public void ClickToHideCommodityTabDetails() => ClickCommodityDetails.Click();

        public void EditExistingRecord() => EditExistingRecordLink.Click();

        public void RemoveExistingRecord() => RemoveExistingRecordLink.Click();

        public void EditRegionOfCertification()
        {
            PersonsInvolved.Click();
            EditRegionOfCertificationLink.Click();
            RegionOfOriginScotland.Click();
            SaveAndContinue.Click();
        }

        public void EditResponsibleForLoad()
        {
            PersonsInvolved.Click();
            EditResponsibleForLoadLink.Click();
            ResponsibleForLoadLink.Click();
            _driver.ElementImplicitWait();
            _driver.SelectFromDropdown(ResponsibleForLoadCountry, "XI");
            OperatorSearch.SendKeys("Defra");
            SearchButton.Click();
            _driver.ClickRadioButton("Defra eTrade Consignees LTD");
            SaveAndContinue.Click();
        }

        public void CertifierEditResponsibleForLoad(string organisationName, string countryName)
        {
            EditResponsibleForLoadLink.Click();
            ResponsibleForLoadLink.Click();
            _driver.ElementImplicitWait();
            _driver.SelectFromDropdown(ResponsibleForLoadCountry, countryName);
            OperatorSearch.SendKeys(organisationName);
            SearchButton.Click();
        }

        public bool VerifyCertifierRFLValidation(string validationInformation)
        {
            return RFLValidationInformation.Text.Contains(validationInformation);
        }

        public void EditGoodsCertifiedAs(string goodscertifiedas)
        {
            DescriptionOfGoods.Click();
            EditGoodsCertifiedAsLink.Click();
            GoodsCertifiedAs.SelectGoodsCertifiedAsRadio(goodscertifiedas);
        }

        public bool VerifyChangedGoodsCertifiedAs()
        {
            return _driver.PageSource.Contains("Human consumption");
        }

        public bool IsNewCommodityRecordDisplayed => NewCommodityText.Displayed;

        public bool SearchApplication(string ApplicationName)
        {
            bool CertStatus = false;
            string CertStatusPath = "//span[contains(text(),'" + ApplicationName + "')]/../following-sibling::td[6]";

            SearchAppl.SendKeys(ApplicationName);
            SearchAppl.Click();
            if (Convert.ToInt32(AppStatusCount.Text) > 0)
            {
                List<IWebElement> statusEle = _driver.FindElements(By.XPath(CertStatusPath)).ToList();

                foreach (IWebElement Ele in statusEle)
                {
                    CertStatus = Ele.Text.Contains("SUBMITTED TO CERTIFIER");
                    break;
                }
            }
            return CertStatus;
        }

        public bool VerifyChangedOperator()
        {
            return _driver.PageSource.Contains("Karro Food Ltd T/A Malton Bacon Factory");
        }

        public bool VerifyResponsibleForLoad()
        {
            return _driver.PageSource.Contains("Defra eTrade Consignees LTD");
        }

        public bool VerifyChangedRegionOfCertification()
        {
            return _driver.PageSource.Contains("Scotland");
        }

        public bool ViewApplication(string ApplicationName)
        {
            return true;
        }

        public void EditPurposeOfExport()
        {
            DescriptionOfGoods.Click();
            EditTypeOfConsignmentLink.Click();
            PurposeOfExportReEntry.Click();
            SaveAndContinue.Click();
        }

        public bool VerifyChangedPurposeOfExport()
        {
            return _driver.PageSource.Contains("Re-entry consignment");
        }

        public void EditContainerOrSealNumber(string containerNumber, string sealNumber)
        {
            DescriptionOfGoods.Click();
            EditContainerNumberOrSealNumberLink.Click();
            RemoveContainerAndsealnum.Click();
            ContainerOrSealNo.ContainerAndSealNumberIsRemoved();
            ContainerOrSealNo.CompleteContainerSealNumber(containerNumber, sealNumber);
        }


        public bool VerifyChangedContainerOrSealNumber()
        {
            return _driver.PageSource.Contains("Container and seal numbers");
        }

        public void EditDepartureAndArrival()
        {
            DateTime now = DateTime.Now;
            string departureDate = now.ToString("dd/MM/yyyy HH:mm");
            DateTime futureDate = now.AddDays(2);
            string estimatedArrivalDate = futureDate.ToString("dd/MM/yyyy HH:mm");
            EditDepartureAndArrivalLink.Click();
            Departure.Clear();
            Departure.SendKeys(departureDate);
            EstimatedArrival.Clear();
            EstimatedArrival.SendKeys(estimatedArrivalDate);
            SaveAndContinue.Click();
        }

        public void ClickOnDepartureAndArrivalLink() => EditDepartureAndArrivalLink.Click();

        public void ContinueWithNoDepartureAndArrivalDate(string depatureValidation, string arrivalValidation)
        {
            DateTime now = DateTime.Now;
            string departureDate = now.ToString("dd/MM/yyyy HH:mm");
            DateTime futureDate = now.AddDays(2);
            string estimatedArrivalDate = futureDate.ToString("dd/MM/yyyy HH:mm");

            Edit.Click();

            if (depatureValidation.Equals("True"))
            {
                Departure.Clear();
                Departure.SendKeys(departureDate);
            }

            if (arrivalValidation.Equals("True"))
            {
                EstimatedArrival.Clear();
                EstimatedArrival.SendKeys(estimatedArrivalDate);
            }

            SaveAndContinue.Click();
        }

        public bool ValidationMsgDepartureAndArrival(string validationInformation)
        {

            return ValidationlocatorDepartureArrival.Text.Contains(validationInformation);
        }

        public bool VerifyChangedDepatureAndArrivalDate()
        {
            return _driver.PageSource.Contains("Departure and Arrival");
        }

        public void EditMeansofTranport()
        {
            TransportTab.Click();
            EditMeansOfTransportLink.Click();
            VehicleBox.Click();
            VehicleBox.Clear();
            VehicleBox.SendKeys("12345");
            SaveAndContinue.Click();
        }

        public void EditPlaceOfOrigin()
        {
            TransportTab.Click();
            EditPlaceOfOriginLink.Click();
        }

        public void EditPlaceOfDestination()
        {
            TransportTab.Click();
            EditPlaceOfDestinationLink.Click();
        }

        public void EditBorderControlPost()
        {
            EditBorderControlPostLink.Click();
            SaveAndContinue.Click();
        }

        public void ClickOnTransportTab()
        {
            TransportTab.Click();
        }

        public void ClickOnMeansOfTranportLink() => MeansOfTransportlink.Click();

        public void ClickToCollapseDepartureAndArrivalPanelDetails()
        {
            DepartureAndArrivalPanelLink.Click();
        }

        public bool VerifyChangedMeansOfTransport()
        {
            return _driver.PageSource.Contains("Means of Transport");
        }

        public string VerifyChangedBorderControlPost()
        {
            return BcpError.Text;
        }

        public string VerifySkipErrorMessage()
        {
            return SkipError.Text;
        }

        public void AssignCertifier(string certifierName)
        {
            AssignCert.Click();
            _driver.WaitForElement(SelectCertifierBy);
            //Thread.Sleep(500);            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(SelectCertifierBy, certifierName));
            SelectCertifierNew.SelectByText(certifierName);
            AssignToCertifier.Click();
        }

        public bool VerifyAssignedCerfier(string certifierName)
        {
            return GetCertifierName.Text.Contains("certifierName");
        }

        public void NotEnteredMeansOfTransport(string transCondition, string meansOfTrans)
        {
            TransportTab.Click();
            EditMeansOfTransportLink.Click();

            if (!string.IsNullOrEmpty(transCondition))
            {
                _driver.ClickRadioButtonOption(transCondition);
            }

            if (meansOfTrans.Contains("Railway"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Railway");
                AddMeansOfTransport.Click();
            }

            if (meansOfTrans.Contains("Road"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Road");
                AddMeansOfTransport.Click();
            }

            if (meansOfTrans.Contains("Airplane"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Airplane");
                AddMeansOfTransport.Click();
            }

            if (meansOfTrans.Contains("Vessel"))
            {
                _driver.SelectFromDropdown(MeansOfTransport, "Vessel");
                AddMeansOfTransport.Click();
            }

            SaveAndContinue.Click();
        }

        public bool VerifyTransConditionValidation()
        {
            var transConditionStatus = TransConditionValidationText.Text;
            return transConditionStatus.Contains("Select the conditions that the consignment will be stored in during transport");
        }

        public string ExceptedErrMsgTransportSection(string transCondition, string meansOfTransport, string requiredDetails)
        {
            string result = string.Empty;
            switch (meansOfTransport)
            {
                case "":
                    if (requiredDetails.Contains(""))
                    {
                        result = "Enter the means of transport";
                    }
                    return result;
                case "Railway":
                    if (requiredDetails.Contains("Identifier"))
                    {
                        result = "Enter the train reporting number and carriage number";
                    }
                    return result;
                case "Road":
                    if (requiredDetails.Contains("Vehicle registration"))
                    {
                        result = "Enter the registration number for the transport vehicle";
                    }
                    else if (requiredDetails.Contains("Trailer number"))
                    {
                        result = "Enter the trailer number for the transport vehicle";
                    }
                    else if (requiredDetails.Contains("Country"))
                    {
                        result = "Select the country that the transport vehicle is registered in";
                    }
                    return result;
                case "Airplane":
                    if (requiredDetails.Contains("Flight number"))
                    {
                        result = "Enter the flight number for the plane that will transport the consignment";
                    }
                    return result;
                case "Vessel":
                    if (requiredDetails.Contains("Ship name"))
                    {
                        result = "Enter the name of the ship that will transport the consignment";
                    }
                    else if (requiredDetails.Contains("Flag state"))
                    {
                        result = "Select the country that the ship is registered in";
                    }
                    else if (requiredDetails.Contains("IMO Number"))
                    {
                        result = "Enter the IMO number for the ship that will transport the consignment";
                    }
                    return result;
                default:
                    return result;
            }

        }

        public bool ValidateErrMsgTransport(string transCondition, string meansOfTransport, string requiredDetails)
        {
            bool result = false;
            int index = 1;
            switch (meansOfTransport)
            {
                case "":
                    if (requiredDetails.Contains(""))
                    {
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    return result;
                case "Railway":
                    if (requiredDetails.Contains("Identifier"))
                    {
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    return result;
                case "Road":
                    if (requiredDetails.Contains("Vehicle registration"))
                    {
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    else if (requiredDetails.Contains("Trailer number"))
                    {
                        index = 2;
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    else if (requiredDetails.Contains("Country"))
                    {
                        index = 3;
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    return result;
                case "Airplane":
                    if (requiredDetails.Contains("Flight number"))
                    {
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    return result;
                case "Vessel":
                    if (requiredDetails.Contains("Ship name"))
                    {
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    else if (requiredDetails.Contains("Flag state"))
                    {
                        index = 2;
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    else if (requiredDetails.Contains("IMO Number"))
                    {
                        index = 3;
                        result = locatorMeansOfTrans(index).Text.Contains(ExceptedErrMsgTransportSection(transCondition, meansOfTransport, requiredDetails));
                    }
                    return result;
                default:
                    return result;
            }
        }

        public IWebElement locatorMeansOfTrans(int value)
        {
            string xpath = string.Format($"//div[@class='govuk-form-group govuk-form-group--error'][{value}]//span[@class='govuk-error-message']");
            IWebElement webElement = _driver.WaitForElement(By.XPath(xpath));
            return webElement;
        }

        public void ClickOnCommodityDetails()
        {
            AddNewLink.Click();
        }

        public bool IsSkipFunctionlityExist()
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

        public void ChangePlaceOfOrigin(string placeOfDispatch, string placeOfLoading)
        {
            ChangePlaceOfDispatch(placeOfDispatch);
            ChangePlaceOfLoading(placeOfLoading);
        }

        public void ChangePlaceOfDispatch(string placeOfDispatch)
        {
            PlaceOfDispatchRemoveLink.Click();
            PlaceOfDispatchLink.Click();
            _driver.ClickRadioButton("Search by organisation name");
            PlaceOfOriginOperatorName.SendKeys(placeOfDispatch);
            PlaceOfOrigiOperatorSearch.Click();
            _driver.ClickRadioButton(placeOfDispatch);
            SaveAndContinue.Click();
        }
        public void ChangePlaceOfLoading(string placeOfLoading)
        {
            PlaceOfLoadingRemoveLink.Click();
            PlaceOfLoadingLink.Click();
            _driver.ClickRadioButton("Search by organisation name");
            PlaceOfOriginOperatorName.SendKeys(placeOfLoading);
            PlaceOfOrigiOperatorSearch.Click();
            _driver.ClickRadioButton(placeOfLoading);
            SaveAndContinue.Click();
        }

        public bool VerifyChangedPlaceOfDispatch()
        {
            return _driver.PageSource.Contains("KARRO FOOD LTD");
        }

        public bool VerifyChangedPlaceOfLoading()
        {
            return _driver.PageSource.Contains("DFDS Logistics");
        }

        public void ChangeBorderControPostl(string countryId, string borderName)
        {

            if (!string.IsNullOrEmpty(countryId))
            {
                _driver.SelectFromDropdown(CountryElement, countryId);
            }

            if (!string.IsNullOrEmpty(borderName))
            {
                SearchInputAvlOptions.SendKeys(borderName);
                var borderElement = tableElements.Where(e => e.Text.Contains(borderName)).ToArray()[0];
                borderElement.FindElement(By.TagName("button")).Click();
            }
            SaveAndContinue.Click();
        }

        public bool VerifyChangeOfBorderControPostl()
        {
            return ChangeBCPText.Text.Contains("Larne Harbour - MEA");
        }

        public void ClickSaveAndContinue() => SaveAndContinue.Click();

        public bool ValidateIdenDataModalErrorMessages()
        {
            string errorFieldXpath, ValidationErrorElementAttr;
            foreach (var labelElement in IdentificationDataModalLabelList)
            {
                var labelElementText = labelElement.Text;
                if (!labelElementText.Contains("(Optional)"))
                {
                    errorFieldXpath = "//label[contains(text(), '" + labelElementText + "')]/following::p";
                    ValidationErrorElementAttr = _driver.FindElement(By.XPath(errorFieldXpath)).GetAttribute("class");

                    if (!ValidationErrorElementAttr.Contains("govuk-error-message"))
                        return false;
                }
            }
            return true;
        }
        #endregion Methods
    }
}