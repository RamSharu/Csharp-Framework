using BoDi;
using Defra.UI.Tests.Data.Identification;
using Defra.UI.Tests.Pages.Exporter.ColdStoreAndManufacturingPlant;
using Defra.UI.Tests.Tools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Reflection;
using Defra.UI.Framework.Object;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace Defra.UI.Tests.Pages.Exporter.IdentificationPage
{
    public class IdentificationPage : IIdentificationPage
    {
        protected IObjectContainer _objectContainer;
        private readonly object _lock = new object();
        public IdentificationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private ICommodity? Commodity => _objectContainer.IsRegistered<ICommodity>() ? _objectContainer.Resolve<ICommodity>() : null;

        #region Page Objects
        private By IdentificationPageHeaderBy => By.CssSelector(".IdentificationEntryPage .govuk-heading-xl");
        private IWebElement BatchNumberElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'BATCH_NUMBER')] |//input[starts-with(@id,'BATCH_NUMBER')]"));
        private List<IWebElement> BreedCategoryDropdownElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'BREED_CATEGORY') and not(contains(@style,'display: none'))]")).ToList();
        private List<IWebElement> BreedCategoryTextBoxElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'BREED_CATEGORY')]")).ToList();
        private IWebElement ColdStoreLink => _driver.WaitForElement(By.XPath("//a[contains(.,'cold store')]"));
        private IWebElement DateCollectionElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'COLLECTION_DATE')]"));
        private IWebElement DateCollectionProdElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'COLLECTION_PRODUCTION_DATE')]"));
        private IWebElement DateProductionElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'PRODUCTION_DATE')]"));
        private IWebElement DateStorageLifeElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'STORAGE_LIFE')]"));
        private List<IWebElement> FinalConsumerRadioList => _driver.FindElements(By.ClassName("govuk-radios__input")).ToList();
        private IWebElement IdenMarkElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'IDENTIFICATION_MARK')] | //input[starts-with(@name,'IDENTIFICATION_MARK')]"));
        private IWebElement ManufacturingPlantLink => _driver.WaitForElement(By.XPath("//a[contains(.,'manufacturing plant')]"));
        private SelectElement OperatorSearchCountryDropdown => new SelectElement(_driver.WaitForElement(OperatorSearchCountryDropdownBy));
        private IWebElement OperatorSearchCountry => _driver.WaitForElement(OperatorSearchCountryDropdownBy);

        private List<IWebElement> NatureOfCommDropdownElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'NATURE_OF_COMMODITY') and not(contains(@style,'display: none'))]")).ToList();
        private List<IWebElement> NatureOfCommTextBoxElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'NATURE_OF_COMMODITY')]")).ToList();
        private IWebElement PkgCountElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'PACKAGE_COUNT')]"));
        private IWebElement PkgUnitElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id,'PACKAGE_COUNT')]"));
        private IWebElement PlantEstablishmentCentreLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Select a plant / establishment / centre')]"));
        private IWebElement ProductDescElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'PRODUCT_DESCRIPTION')]"));
        private IWebElement QuantityDropdownElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id, 'QUANTITY')]"));
        private IWebElement QuantityElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'QUANTITY')]"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.CssSelector(".identification-questions #actions .govuk-button"));
        private IWebElement SlaughterHouseLink => _driver.WaitForElement(By.XPath("//a[contains(.,'slaughterhouse')]"));
        private List<IWebElement> SpeciesDropdownElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'TAXON_ID') and not(contains(@style,'display: none'))]")).ToList();
        private List<IWebElement> SpeciesTextBoxElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'TAXON_ID')]")).ToList();
        private List<IWebElement> TreatmentTypeDropElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'TREATMENT_TYPE')]")).ToList();
        private List<IWebElement> TreatmentTypeTextElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'TREATMENT_TYPE')]")).ToList();
        private IWebElement WeightElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'NET_WEIGHT')]"));
        private IWebElement WeightUnitElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id,'NET_WEIGHT')]"));
        private IWebElement AddAnotherRecordLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Add another record')]"));
        private By PageHeadingBy => By.CssSelector("div.CommoditySummaryPage h1.govuk-heading-xl");
        private By SkipCheckboxBy => By.XPath("//input[@id='skip-functionality']");
        private By SkipSection => By.Id("skip-functionality");
        private By OperatorSearchCountryDropdownBy => By.Id("operator-search-country");

        #endregion

        #region Methods

        public bool IsIdentificationPage => _driver.WaitForElement(IdentificationPageHeaderBy).Text.Contains("Add commodity data");

        public void AddCertifierCommodityData(List<IdentificationData> dataList)
        {
            int AddRecords = 1;
            foreach (var data in dataList)
            {
                AddCertifierCommodityData(AddRecords, data);

                Logger.LogMessage(data.PrdDesc);
                AddRecords++;
            }
        }

        public void AddCertifierCommodityData(int AddRecords, IdentificationData data)
        {
            if (AddRecords > 1)
            { AddAnotherRecordLink.Click(); }

            if (!string.IsNullOrEmpty(data.PrdDesc))
                ProductDescElement.SendKeys(data.PrdDesc);

            if (!string.IsNullOrEmpty(data.IdentificationMark))
                IdenMarkElement.SendKeys(data.IdentificationMark);

            if (!string.IsNullOrEmpty(data.PkgCount))
            {
                PkgCountElement.SendKeys(data.PkgCount);
                SelectFromDropdown(PkgUnitElement, data.PkgUnit);
            }

            if (!string.IsNullOrEmpty(data.Weight))
            {
                WeightElement.SendKeys(data.Weight);
                SelectFromDropdown(WeightUnitElement, data.WeightUnit);
            }

            if (!string.IsNullOrEmpty(data.TreatmentType))
            {
                if (TreatmentTypeTextElement.Count > 0)
                    TreatmentTypeTextElement.First().SendKeys(data.TreatmentType);
                else if (TreatmentTypeDropElement.Count > 0)
                    SelectFromDropdown(TreatmentTypeDropElement.First(), data.TreatmentType);
                else
                    throw new Exception("TreatmentType field is not visible");
            }

            if (!string.IsNullOrEmpty(data.NatureOfCommodity))
            {
                if (NatureOfCommDropdownElement.Count > 0)
                    SelectFromDropdown(NatureOfCommDropdownElement.First(), data.NatureOfCommodity);
                else if (NatureOfCommTextBoxElement.Count > 0)
                    NatureOfCommTextBoxElement.First().SendKeys(data.NatureOfCommodity);
                else
                    throw new Exception("Nature of commodity element is not visible");
            }

            if (data.FinalConsumerRadio)
            {
                if (data.FinalConsumer)
                    FinalConsumerRadioList.First().Click();
                else
                    FinalConsumerRadioList.Last().Click();
            }

            if (!string.IsNullOrEmpty(data.CollectionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateCollectionElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.CollectionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateCollectionElement);
            }

            if (!string.IsNullOrEmpty(data.Quantity))
            {
                QuantityElement.SendKeys(data.Quantity);
                SelectFromDropdown(QuantityDropdownElement, data.QuantityUnit);
            }

            if (!string.IsNullOrEmpty(data.BatchNumber))
                BatchNumberElement.SendKeys(data.BatchNumber);

            if (!string.IsNullOrEmpty(data.Species))
            {
                if (SpeciesDropdownElement.Count > 0)
                    SelectFromDropdown(SpeciesDropdownElement.First(), data.Species);
                else if (SpeciesTextBoxElement.Count > 0)
                    SpeciesTextBoxElement.First().SendKeys(data.Species);
                else
                    throw new Exception("Species field is not visible");
            }

            if (!string.IsNullOrEmpty(data.BreedCategory))
            {
                if (BreedCategoryDropdownElement.Count > 0)
                    SelectFromDropdown(BreedCategoryDropdownElement.First(), data.BreedCategory);
                else if (BreedCategoryTextBoxElement.Count > 0)
                    BreedCategoryTextBoxElement.First().SendKeys(data.BreedCategory);
                else
                    throw new Exception("Breed Category field is not visible");
            }

            if (data.FillColdStore)
            {

                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillCertifierColdStore(data.ColdStore.ApprovalNumber, data.ColdStore.ApprovalNumberInput, data.ColdStore.OperatorName, data.ColdStore.OperatorNameInput, data.ColdStore.ActivityInput);
            }

            if (data.FillManufacturingPlant)
            {
                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillCertifierManufacturingPlant(data.ManufacturingPlant.ApprovalNumber, data.ManufacturingPlant.ApprovalNumberInput, data.ManufacturingPlant.OperatorName, data.ManufacturingPlant.OperatorNameInput, data.ManufacturingPlant.ActivityInput);
            }

            if (data.FillSlaughterHouse)
            {
                ClickSlaughterHouseLink();
                var Slaughterhouse = new ColdStoreAndManufacturingPlantPage(_driver);
                Slaughterhouse.FillProcessingPlant(data.SlaughterHouse.ApprovalNumber, data.SlaughterHouse.ApprovalNumberInput, data.SlaughterHouse.OperatorName, data.SlaughterHouse.OperatorNameInput, data.SlaughterHouse.ActivityInput);
            }

            if (data.FillPlantEstablishmentCentre)
            {
                ClickPlantEstablishmentCentreLink();
                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillProcessingPlant(data.PlantEstablishmentCentre.ApprovalNumber, data.PlantEstablishmentCentre.ApprovalNumberInput, data.PlantEstablishmentCentre.OperatorName, data.PlantEstablishmentCentre.OperatorNameInput, data.PlantEstablishmentCentre.ActivityInput);
            }

            if (!string.IsNullOrEmpty(data.ProductionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateProductionElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.ProductionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateProductionElement);
            }

            if (!string.IsNullOrEmpty(data.CollectionProductionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateCollectionProdElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.CollectionProductionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateCollectionProdElement);
            }

            if (!string.IsNullOrEmpty(data.StorageLifeDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateStorageLifeElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.StorageLifeDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateStorageLifeElement);
            }
            SaveAndContinueButton.Click();
        }

        public void AddCommodityData(List<IdentificationData> dataList)
        {
            int AddRecords = 1;
            foreach (var data in dataList)
            {
                AddData(AddRecords, data);

                SaveAndContinueButton.Click();
                Logger.LogMessage(data.PrdDesc);
                AddRecords++;
            }
            _driver.WaitForElement(PageHeadingBy);
            Commodity.ClickNoRadioForAddMoreCommodity();
        }

        public void SelectOperatorSearchCountry(string operatorCountry)
        {
            _driver.WaitForElement(OperatorSearchCountryDropdownBy);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(OperatorSearchCountry, "United Kingdom"));
            OperatorSearchCountryDropdown.SelectByText(operatorCountry);
        }

        
        public void AddData(int AddRecords, IdentificationData data)
        {
            if (AddRecords > 1)
            { AddAnotherRecordLink.Click(); }

            if (!string.IsNullOrEmpty(data.PrdDesc))
                ProductDescElement.SendKeys(data.PrdDesc);

            if (!string.IsNullOrEmpty(data.IdentificationMark))
                IdenMarkElement.SendKeys(data.IdentificationMark);

            if (!string.IsNullOrEmpty(data.PkgCount))
            {
                PkgCountElement.SendKeys(data.PkgCount);
            }

            if (!string.IsNullOrEmpty(data.PkgUnit))
            {
                SelectFromDropdown(PkgUnitElement, data.PkgUnit);
            }

            if (!string.IsNullOrEmpty(data.Weight))
            {
                WeightElement.SendKeys(data.Weight);
            }


            if (!string.IsNullOrEmpty(data.WeightUnit))
            {
                SelectFromDropdown(WeightUnitElement, data.WeightUnit);
            }

            if (!string.IsNullOrEmpty(data.TreatmentType))
            {
                if (TreatmentTypeTextElement.Count > 0)
                    TreatmentTypeTextElement.First().SendKeys(data.TreatmentType);
                else if (TreatmentTypeDropElement.Count > 0)
                    SelectFromDropdown(TreatmentTypeDropElement.First(), data.TreatmentType);
                else
                    throw new Exception("TreatmentType field is not visible");
            }

            if (!string.IsNullOrEmpty(data.NatureOfCommodity))
            {
                if (NatureOfCommDropdownElement.Count > 0)
                    SelectFromDropdown(NatureOfCommDropdownElement.First(), data.NatureOfCommodity);
                else if (NatureOfCommTextBoxElement.Count > 0)
                    NatureOfCommTextBoxElement.First().SendKeys(data.NatureOfCommodity);
                else
                    throw new Exception("Nature of commodity element is not visible");
            }

            if (data.FinalConsumerRadio)
            {
                if (data.FinalConsumer)
                    FinalConsumerRadioList.First().Click();
                else
                    FinalConsumerRadioList.Last().Click();
            }

            if (!string.IsNullOrEmpty(data.CollectionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateCollectionElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.CollectionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateCollectionElement);
            }

            if (!string.IsNullOrEmpty(data.BreedCategory))
            {
                if (BreedCategoryDropdownElement.Count > 0)
                    SelectFromDropdown(BreedCategoryDropdownElement.First(), data.BreedCategory);
                else if (BreedCategoryTextBoxElement.Count > 0)
                    BreedCategoryTextBoxElement.First().SendKeys(data.BreedCategory);
                else
                    throw new Exception("Breed Category field is not visible");
            }

            if (!string.IsNullOrEmpty(data.Species))
            {
                if (SpeciesDropdownElement.Count > 0)
                    SelectFromDropdown(SpeciesDropdownElement.First(), data.Species);
                else if (SpeciesTextBoxElement.Count > 0)
                    SpeciesTextBoxElement.First().SendKeys(data.Species);
                else
                    throw new Exception("Species field is not visible");
            }

            if (!string.IsNullOrEmpty(data.Quantity))
            {
                QuantityElement.SendKeys(data.Quantity);
                SelectFromDropdown(QuantityDropdownElement, data.QuantityUnit);
            }

            if (!string.IsNullOrEmpty(data.BatchNumber))
                BatchNumberElement.SendKeys(data.BatchNumber);

            if (data.FillColdStore)
            {
                ClickColdStoreLink();
                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillProcessingPlant(data.ColdStore.ApprovalNumber, data.ColdStore.ApprovalNumberInput, data.ColdStore.OperatorName, data.ColdStore.OperatorNameInput, data.ColdStore.ActivityInput);
            }

            if (data.FillManufacturingPlant)
            {
                ClickManufacturingPlantLink();
                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillProcessingPlant(data.ManufacturingPlant.ApprovalNumber, data.ManufacturingPlant.ApprovalNumberInput, data.ManufacturingPlant.OperatorName, data.ManufacturingPlant.OperatorNameInput, data.ManufacturingPlant.ActivityInput);
            }

            if (data.FillSlaughterHouse)
            {
                ClickSlaughterHouseLink();
                var Slaughterhouse = new ColdStoreAndManufacturingPlantPage(_driver);
                Slaughterhouse.FillProcessingPlant(data.SlaughterHouse.ApprovalNumber, data.SlaughterHouse.ApprovalNumberInput, data.SlaughterHouse.OperatorName, data.SlaughterHouse.OperatorNameInput, data.SlaughterHouse.ActivityInput);
            }

            if (data.FillPlantEstablishmentCentre)
            {
                ClickPlantEstablishmentCentreLink();
                var ColdStoreManfPlant = new ColdStoreAndManufacturingPlantPage(_driver);
                ColdStoreManfPlant.FillProcessingPlant(data.PlantEstablishmentCentre.ApprovalNumber, data.PlantEstablishmentCentre.ApprovalNumberInput, data.PlantEstablishmentCentre.OperatorName, data.PlantEstablishmentCentre.OperatorNameInput, data.PlantEstablishmentCentre.ActivityInput);
            }

            if (!string.IsNullOrEmpty(data.ProductionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateProductionElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.ProductionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateProductionElement);
            }

            if (!string.IsNullOrEmpty(data.CollectionProductionDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateCollectionProdElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.CollectionProductionDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateCollectionProdElement);
            }

            if (!string.IsNullOrEmpty(data.StorageLifeDate))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                DateStorageLifeElement.Click();
                string script = $"const element = arguments[0]; element.value = '" + data.StorageLifeDate + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
                ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", DateStorageLifeElement);
            }
        }

        public void AddDecimalCommodityData(int noOfIdetifications, string certificateNum, string netWeight)
        {
            List<IdentificationData> dataList = GetData(noOfIdetifications, certificateNum);
            int AddRecords = 1;
            foreach (var data in dataList)
            {
                AddData(AddRecords, data);

                WeightElement.SendKeys(netWeight);

                SaveAndContinueButton.Click();
                Logger.LogMessage(data.PrdDesc);
                AddRecords++;
            }
            _driver.WaitForElement(PageHeadingBy);
        }

        public void AddCommodityDataWithOutSpecificField(int noOfIdentifications, string certificateNum, string fieldAttribute)
        {
            List<IdentificationData> dataList = GetData(noOfIdentifications, certificateNum);
            int AddRecords = 1;
            foreach (var data in dataList)
            {
                var propertyInfo = typeof(IdentificationData).GetProperty(fieldAttribute);
                propertyInfo.SetValue(data, null);
                AddData(AddRecords, data);
                SaveAndContinueButton.Click();
            }
        }

        public void AddIdentification(int noOfIdetifications, string certificateNum)
        {
            List<IdentificationData> dataList = GetData(noOfIdetifications, certificateNum);
            AddCommodityData(dataList);
        }

        public void ClickColdStoreLink() => ColdStoreLink.Click();

        public void ClickManufacturingPlantLink() => ManufacturingPlantLink.Click();

        public void ClickPlantEstablishmentCentreLink() => PlantEstablishmentCentreLink.Click();

        public void ClickSlaughterHouseLink() => SlaughterHouseLink.Click();

        private List<IdentificationData> GetData(int noOfIdetifications, string certificateNum)
        {
            certificateNum = certificateNum.Replace("EHC", "");
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string identificationDataJson = "IdentificationData_EHC" + certificateNum + ".json";
                var filePath = Path.Combine(jsonPath, "Data", "Identification", identificationDataJson);
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var dataList = settings.GetSection("Identification").Get<List<IdentificationData>>();
                var filterList = dataList.GetRange(0, noOfIdetifications);
                return filterList;
            }
        }

        private void SelectFromDropdown(IWebElement pkgUnitElement, string pkgUnit)
        {
            string script = $"const element = arguments[0]; element.value = '" + pkgUnit + "'; element.dispatchEvent(new Event('change')); element.dispatchEvent(new Event('blur'));";
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", pkgUnitElement);
        }

        public void SkipAndContinue()
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(SkipSection));
            var r = _driver.FindElement(SkipCheckboxBy);
            if (!r.Selected)
                r.Click();
            SaveAndContinueButton.Click();
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
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(SkipSection));
            return _driver.FindElement(SkipCheckboxBy).Selected;
        }

        #endregion
    }
}
