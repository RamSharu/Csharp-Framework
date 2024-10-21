using BoDi;
using Defra.UI.Tests.Pages.Exporter.Consignee;
using Defra.UI.Tests.Pages.Exporter.Consignor;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Certifier.CertifyEHC
{
    public class CertifierView : ICertifierView
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public CertifierView(IObjectContainer container)
        {
            _objectContainer = container;
        }

        //Pages
        private IConsigneePage Consignee => _objectContainer.IsRegistered<IConsigneePage>() ? _objectContainer.Resolve<IConsigneePage>() : null;

        private IConsignorPage Consignor => _objectContainer.IsRegistered<IConsignorPage>() ? _objectContainer.Resolve<IConsignorPage>() : null;

        #region Page Objects

        private By CertifierViewPageHeaderBy => By.CssSelector(".CertifierView .govuk-heading-xl");
        private By AdditionalDocsSectionBy => By.XPath("//*[@id='additional-documents-table']/caption");
        private IWebElement BackButtonLink => _driver.WaitForElement(By.ClassName("govuk-back-link"));
        private IWebElement AdditionalDocsTabLink => _driver.WaitForElement(By.XPath("//span[contains(.,'Additional Documents')]/parent::a"));
        private IWebElement EditAdditionalDocsLink => _driver.WaitForElement(By.XPath("//h2[contains(text(),'Additional documents')]//button"));
        private IWebElement AppSummaryPageHeading => _driver.WaitForElement(By.CssSelector("div.CertifierView h2.govuk-heading-l"));
        private IWebElement ConsigneePart => _driver.WaitForElement(By.XPath("//h2[contains(text(), 'Consignee')]"));
        private By ConsigneePartHeading => By.XPath("//h1[text()=' Consignee or importer ']");
        private IWebElement ConsigneeChange => _driver.WaitForElement(By.XPath("//span[contains(text(),'Importer or Consignee')]/.."));
        private IWebElement ConsigneeEdit => _driver.WaitForElement(By.XPath("//span[contains(text(),'Importer or Consignee')]/../../following-sibling::div//button[text()='Edit']"));
        private IWebElement Remove => _driver.WaitForElement(By.XPath("//a[text()='Remove']"));
        private IWebElement ConsigneeNameElement => _driver.WaitForElement(By.XPath("//span[contains(text(),'Importer or Consignee')]/../../following-sibling::div//li[1]"));
        private IWebElement ConsignorPart => _driver.WaitForElement(By.XPath("//h2[contains(text(), 'Consignor')]"));
        private By ConsignorPartHeading => By.XPath("//h1[text()=' Exporter or consignor ']");
        private IWebElement ConsignorEdit => _driver.WaitForElement(By.XPath("//span[contains(text(),'Exporter or Consignor')]/../../following-sibling::div//button[text()='Edit']"));
        private IWebElement EditExporterOrConsignorLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[1]"));
        private IWebElement EditImporterOrConsigneeLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement ConsignorNameElement => _driver.WaitForElement(By.XPath("//span[contains(text(),'Exporter or Consignor')]/../../following-sibling::div//li[1]"));
        private IWebElement EditContainerAndSealNumberLink => _driver.WaitForElement(By.XPath("//h2[contains(text(),' Container and Seal Numbers ')]/..//button"));
        private IWebElement EditMeansOfTransportLink => _driver.WaitForElement(By.XPath("//h2[contains(text(),'Means of Transport')]/..//button"));
        private By RemoveContainerAndASealNumberRowBy => By.CssSelector("#container-seal > div > div > table > tbody > tr.govuk-table__row > td:nth-child(3) > button");
        private IWebElement RemoveContainerAndASealNumberRow => _driver.WaitForElement(RemoveContainerAndASealNumberRowBy);
        private By AddNewContainerAndSelNumberRowBy => By.XPath("//td/a[text()='Add a new row']");
        private IWebElement AddNewContainerAndSelNumberRow => _driver.WaitForElement(AddNewContainerAndSelNumberRowBy);
        private By ContainerNumberBy => By.XPath("//tr[2]//input[@name='containerNumber']");
        private IWebElement ContainerNumberElement => _driver.WaitForElement(ContainerNumberBy);
        private By SealNumberBy => By.XPath("//tr[2]//input[@name='sealNumber']");
        private IWebElement SealNumberElement => _driver.WaitForElement(SealNumberBy);
        private IWebElement SaveAndReturnToTaskList => _driver.WaitForElement(By.XPath("//button[contains(text(),' Save and return to task list ')]"));
        private IWebElement SaveAndContinueMeansOfTransport => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement RoadRemoveRowLink => _driver.WaitForElement(By.XPath("//a[.='Remove row']"));
        private IWebElement ContainerSealNumberTableBody => _driver.WaitForElement(By.XPath("//*[@id='container-seal']/div/div/table/tbody"));
        private IWebElement EditGrossWeightLink => _driver.WaitForElement(By.XPath("//h2[contains(text(),'Commodity')]/..//button"));
        private IWebElement GrossWeightAmount => _driver.WaitForElement(By.Id("gross-weight"));
        private IWebElement GrossWeightUnit => _driver.WaitForElement(By.Id("units-for-gross-weight"));
        private IWebElement Save => _driver.WaitForElement(By.XPath("//button[text()='Save']"));
        private IWebElement DocumentsSave => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save']"));
        private IList<IWebElement> DocummentErrors => _driver.FindElements(By.XPath("//span[@class='govuk-error-message' and not(@class='govuk-visually-hidden')]"));
        private By MeansOfTransportSummaryErrorBy => By.XPath("//div[@id='error-message']");
        private IWebElement MeansOfTransportSummaryError => _driver.FindElement(MeansOfTransportSummaryErrorBy);
        private IWebElement CertifierPart2 => _driver.WaitForElement(By.XPath("//small[contains(text(),'Ready to certify')]"));
        private By CheckApplDataTraces => By.XPath("//button[contains(text(),'Check application data against TRACES')]");
        private IWebElement SignAndApprove => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign and approve')]"));
        private IWebElement SelectYes => _driver.WaitForElement(By.XPath("//button[contains(text(),'Yes')]"));
        private IWebElement Return => _driver.WaitForElement(By.XPath("//button[contains(text(),'Return')]"));
        private IWebElement PlaceOfOriginTab => _driver.WaitForElement(By.XPath("//span[normalize-space()='Place of Origin']"));
        private IWebElement EditLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[2]"));
        private IWebElement EditBorderControlPostLink => _driver.WaitForElement(By.XPath("(//button[contains(.,'Edit')])[4]"));

        private IWebElement BorderControlPostTab => _driver.WaitForElement(By.XPath("//span[normalize-space()='Border Control Post']"));

        //Disease clearance fields
        private IWebElement DiseaseClearancePanel => _driver.WaitForElement(By.XPath("//div[@class='message-panel']/following-sibling::div[@id='certificate-panel']"));
        private IWebElement DiseaseClearancePanelHeader => _driver.WaitForElement(By.XPath("//div[@class='message-panel']/following-sibling::div[@id='certificate-panel']"));
        private IWebElement ChecksPerformedQuestion => _driver.WaitForElement(By.XPath("//*[@aria-describedby='disease-clearance-checked-hint']//h2"));
        private IWebElement ChecksPerformedHint => _driver.WaitForElement(By.Id("disease-clearance-checked-hint"));
        private IWebElement DiseaseClearanceCheckedDateTextBox => _driver.WaitForElement(By.XPath("//input[@data-testid='diseaseClearanceChecked']"));

        #endregion

        #region Methods

        public bool IsCertifierViewPage
        {
            get => _driver.WaitForElement(CertifierViewPageHeaderBy).Text.Contains("Certify an export health certificate");
        }

        public bool IsAdditionalDocsSection
        {
            get => _driver.WaitForElement(AdditionalDocsSectionBy).Text.Contains("Additional documents");
        }

        public void ClickAdditionalDocsTabLink() => AdditionalDocsTabLink.Click();

        public void ClickEditAdditionalDocsLink() => EditAdditionalDocsLink.Click();

        public bool IsApplicationsSummaryPage()
        {
            return AppSummaryPageHeading.Text.Contains("Application summary");
        }

        public bool ClickPart1Tab(string TabName)
        {
            string Tablink = "//span[contains(text(),'" + TabName + "')]/..";
            if (IsApplicationsSummaryPage())
            {
                _driver.WaitForElement(By.XPath(Tablink)).Click();
            }
            return true;
        }

        public bool EditConsigneeDetails(string Country, string ConsigneeName)
        {
            if (IsApplicationsSummaryPage())
            {
                if (ConsigneePart.Text.Contains("Consignee"))
                {
                    EditImporterOrConsigneeLink.Click();
                    Remove.Click();
                    Consignee.SelectConsigneeImporter(ConsigneeName, Country);
                }
            }
            return true;
        }

        public bool VerifyConsigneeDetails(string ConsigneeName)
        {
            bool status = false;
            if (ConsigneeNameElement.Text.Contains(ConsigneeName))
                status = true;

            return status;
        }

        public bool EditConsignorDetails(string ConsignorName)
        {
            if (IsApplicationsSummaryPage())
            {
                if (ConsignorPart.Text.Contains("Consignor"))
                {
                    EditExporterOrConsignorLink.Click();
                    Remove.Click();
                    Consignor.SelectExporterOrConsignor(ConsignorName);
                }
            }
            return true;
        }

        public bool VerifyConsignorDetails(string ConsignorName)
        {
            bool status = false;
            if (ConsignorNameElement.Text.Contains(ConsignorName))
                status = true;

            return status;
        }

        public bool EditGrossWeightOnCertifier(string grossWeightAmount, string grossWeightUnit)
        {
            if (IsCertifierViewPage)
            {
                EditGrossWeightLink.Click();
                GrossWeightAmount.Click();
                GrossWeightAmount.Clear();
                if (string.IsNullOrEmpty(grossWeightAmount) || string.IsNullOrWhiteSpace(grossWeightAmount))
                {
                    GrossWeightAmount.SendKeys(Keys.Space);
                    GrossWeightAmount.SendKeys(Keys.Backspace);
                }
                else
                {
                    GrossWeightAmount.SendKeys(grossWeightAmount);
                }

                if (grossWeightUnit == "")
                {
                    SelectFromDropdown(GrossWeightUnit, grossWeightUnit);
                }
                else 
                {
                    SelectElement dropDown = new SelectElement(GrossWeightUnit);
                    dropDown.SelectByValue(grossWeightUnit);
                }
                Save.Click();
            }
            return true;
        }

        public bool EditContainerSealNumberOnCertifier(string containeNumber, string sealNumber)
        {
            EditContainerAndSealNumberLink.Click();
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(RemoveContainerAndASealNumberRowBy)).Click();
            _driver.WaitForElementCondition(ExpectedConditions.InvisibilityOfElementLocated(RemoveContainerAndASealNumberRowBy));
            AddNewContainerAndSelNumberRow.Click();
            ContainerNumberElement.SendKeys(containeNumber);
            SealNumberElement.SendKeys(sealNumber);
            SaveAndReturnToTaskList.Click();

            return true;
        }


        public bool VerifyIfContinerNumberSealNumbersAndRowCountAreValid(string containerNumber, string sealNumber)
        {
            Thread.Sleep(1000);
            EditContainerAndSealNumberLink.Click();
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(RemoveContainerAndASealNumberRowBy));
            var tableRows = ContainerSealNumberTableBody.FindElements(By.XPath("tr[contains(@class, 'govuk-table__row')]"));
            bool isValidContainerNumber = ContainerNumberElement.GetAttribute("value").Contains(containerNumber);
            bool isSealNumberValid = SealNumberElement.GetAttribute("value").Contains(sealNumber);

            SaveAndReturnToTaskList.Click();

            return (isValidContainerNumber && isSealNumberValid && (tableRows.Count == 1));
        }

        public bool EditMeansOfTransportOnCertifier()
        {
            EditMeansOfTransportLink.Click();
            if (RoadRemoveRowLink.Displayed)
            {
                RoadRemoveRowLink.Click();
            }
            SaveAndContinueMeansOfTransport.Click();

            return true;
        }

        public bool VerifyIfMeansOfTransportSummaryErrorFousAndAriaDescribedByValid()
        {
            _driver.WaitForElement(MeansOfTransportSummaryErrorBy, true);
            bool isSummaryErrorMessageFocus = MeansOfTransportSummaryError.Equals(_driver.SwitchTo().ActiveElement());

            var meansOfTransportDropdown = _driver.WaitForElement(By.XPath("//select[@id='meansOfTransportSelection']"));
            bool ismeansOfTransportDropdown = meansOfTransportDropdown.GetAttribute("aria-describedby") == "meansOfTransport" ? true : false;

            var conditionOfTransport = _driver.WaitForElement(By.XPath("//fieldset[@id='conditionsOfStorage']"));
            bool isconditionOfTransport = conditionOfTransport.GetAttribute("aria-describedby") == "conditionsOfStorage" ? true : false;

            return (isSummaryErrorMessageFocus && ismeansOfTransportDropdown && isconditionOfTransport);
        }

      

        public bool VerifyIfGrossWeightUpdatedSuccessfully(string grossWeightAmount)
        {
            return GrossWeightAmount.GetAttribute("value").Equals(grossWeightAmount);
        }

        public string[] ValidateandVerifyErrorforDocuments()
        {
            DocumentsSave.Click();
            string[] str = new string[4];
            for (int i = 0; i < DocummentErrors.Count; i++)
            {
                str[i] = DocummentErrors[i].Text.Trim();
            }
            return str;
        }

        public string[] ValidateandVerifyErrorforQuantityTotal()
        {
            string[] str = new string[4];
            for (int i = 0; i < DocummentErrors.Count; i++)
            {
                str[i] = DocummentErrors[i].Text.Split(":")[1].Trim();
            }
            return str;
        }

        public void ClickOnCertificationPart2()
        {
            CertifierPart2.Click();
        }

        public void ClickSignAndApprove()
        {
            SignAndApprove.Click();
            SelectYes.Click();
            Return.Click();
        }

        public void ClickCheckApplicationDataTraces()
        {
            _driver.WaitForElement(CheckApplDataTraces).Click();
            _driver.WaitForSpinnerToAppearAndDisappear(CheckApplDataTraces);
        }

        public void ClickBackButtonOnApplicationSummary()
        {
            BackButtonLink.Click();
        }

        private void SelectFromDropdown(IWebElement pkgUnitElement, string pkgUnit)
        {
            string script = $"const element = arguments[0]; element.value = '" + pkgUnit + "'; element.dispatchEvent(new Event('change')); element.dispatchEvent(new Event('blur'));";
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", pkgUnitElement);
        }

        public void ClickOnGrossWeightEdithLink()
        {
            EditGrossWeightLink.Click();
        }

        public void ClickOnPlaceOfOriginEditLink()
        {
            PlaceOfOriginTab.Click();
            EditLink.Click();
        }

        public void ClickOnBCPEditLink()
        {
            EditBorderControlPostLink.Click();
        }

        public bool IsDiseaseClearancePanelDisplayed => DiseaseClearancePanel.Displayed;
        public string DiseaseClearancePanelHeaderText => DiseaseClearancePanelHeader.Text;
        public string ChecksPerformedQuestionText => ChecksPerformedQuestion.Text;
        public bool ChecksPerformedHintText => ChecksPerformedHint.Displayed;
        public bool IsDiseaseClearanceTextBoxDisplayed => DiseaseClearanceCheckedDateTextBox.Displayed;
        #endregion
    }
}