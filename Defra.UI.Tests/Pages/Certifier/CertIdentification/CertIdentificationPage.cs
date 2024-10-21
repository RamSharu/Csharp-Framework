using BoDi;
using Defra.UI.Tests.Data.Identification;
using Defra.UI.Tests.Pages.Certifier.ICertIdentification;
using Defra.UI.Tests.Pages.Exporter.Commodity;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using Defra.UI.Tests.Tools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Reflection;

namespace Defra.UI.Tests.Pages.Certifier.CertIdentification
{
    public class CertIdentificationPage : ICertIdentificationPage
    {
        protected IObjectContainer _objectContainer;
        private readonly object _lock = new object();
        public CertIdentificationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private ICommodity? Commodity => _objectContainer.IsRegistered<ICommodity>() ? _objectContainer.Resolve<ICommodity>() : null;

        private IIdentificationPage? Identification => _objectContainer.IsRegistered<IIdentificationPage>() ? _objectContainer.Resolve<IIdentificationPage>() : null;
        #region Page Objects

        private IWebElement AddAnotherRecordLink => _driver.WaitForElement(By.XPath("//a[contains(.,'Add another record')]"));
        private IWebElement BatchNumberElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'BATCH_NUMBER')]"));
        private IWebElement ColdStoreLink => _driver.WaitForElement(By.XPath("//a[contains(.,'cold store')]"));
        private IWebElement DateCollectionElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'COLLECTION_PRODUCTION_DATE')]"));
        private List<IWebElement> FinalConsumerRadioList => _driver.FindElements(By.ClassName("govuk-radios__input")).ToList();
        private IWebElement IdenMarkElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'IDENTIFICATION_MARK')]"));
        private IWebElement ManufacturingPlantLink => _driver.WaitForElement(By.XPath("//a[contains(.,'manufacturing plant')]"));
        private List<IWebElement> NatureOfCommDropdownElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'NATURE_OF_COMMODITY') and not(contains(@style,'display: none'))]")).ToList();
        private List<IWebElement> NatureOfCommTextBoxElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'NATURE_OF_COMMODITY')]")).ToList();
        private By PageHeadingBy => By.CssSelector("div.CommoditySummaryPage h1.govuk-heading-xl");
        private IWebElement PkgCountElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'PACKAGE_COUNT')]"));
        private IWebElement PkgUnitElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id,'PACKAGE_COUNT')]"));
        private IWebElement ProductDescElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'PRODUCT_DESCRIPTION')]"));
        private IWebElement QuantityDropdownElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id, 'QUANTITY')]"));
        private IWebElement QuantityElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'QUANTITY')]"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.XPath("//a[contains(.,'Save and continue')]"));
        private List<IWebElement> SpeciesDropdownElement => _driver.FindElements(By.XPath("//select[starts-with(@id,'TAXON_ID') and not(contains(@style,'display: none'))]")).ToList();
        private List<IWebElement> SpeciesTextBoxElement => _driver.FindElements(By.XPath("//input[starts-with(@id,'TAXON_ID')]")).ToList();
        private IWebElement TreatmentTypeElement => _driver.WaitForElement(By.XPath("//input[starts-with(@id,'TREATMENT_TYPE')]"));
        private IWebElement WeightElement => _driver.WaitForElement(By.XPath("//input[starts-with(@name,'NET_WEIGHT')]"));
        private IWebElement WeightUnitElement => _driver.WaitForElement(By.XPath("//select[starts-with(@id,'NET_WEIGHT')]"));
        #endregion

        public void ClickColdStoreLink() => ColdStoreLink.Click();

        public void ClickManufacturingPlantLink() => ManufacturingPlantLink.Click();

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
                return dataList;
            }
        }

        private void SelectFromDropdown(IWebElement pkgUnitElement, string pkgUnit)
        {
            string script = $"const element = arguments[0]; element.value = '" + pkgUnit + "'; element.dispatchEvent(new Event('change'));";
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", pkgUnitElement);
        }
    }

}

