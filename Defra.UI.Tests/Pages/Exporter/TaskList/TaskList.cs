using BoDi;
using Defra.UI.Framework.Driver;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.TaskList
{
    public class TaskList : ITaskList
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By TaskListHeaderBy => By.CssSelector(".EhcTaskList .govuk-heading-xl");
        private By ConfirmPreviewDownloadLinkBy => By.XPath("//a[contains(@href,'data:application/pdf')]");
        private IWebElement ManageCommoditiesLink => _driver.WaitForElement(By.XPath("//div[@id='manage-commodities']/dt/a"));
        private IWebElement GrossWeightLink => _driver.WaitForElement(By.CssSelector("#gross-weight a"));
        private IWebElement AccompanyingDocLink => _driver.WaitForElement(By.CssSelector("#accompanying-documents a"));
        private IWebElement DepartureAndArrivalLink => _driver.WaitForElement(By.CssSelector("#departure-and-arrival a"));
        private IWebElement PlaceOfOriginLink => _driver.WaitForElement(By.CssSelector("#place-of-origin a"));
        private IWebElement MeansOfTransportLink => _driver.WaitForElement(By.CssSelector("#means-of-transport a"));
        private IWebElement PreviewCertificateLink => _driver.WaitForElement(By.ClassName("govuk-details__summary-text"));
        private IWebElement PreviewSummaryText => _driver.WaitForElement(By.ClassName("govuk-summary-list__value"));
        private IWebElement DownloadLink => _driver.WaitForElement(By.CssSelector(".govuk-details__text .govuk-summary-list__actions a"));
        private IWebElement ConfirmPreviewDownloadLink => _driver.FindElement(ConfirmPreviewDownloadLinkBy);
        private IWebElement ReviewYourAnswers => _driver.WaitForElement(By.XPath("//a[contains(text(),'Review')]"));
        private IWebElement ChangeApplicationReference => _driver.WaitForElement(By.XPath("//button[contains(text(),'Change')]"));
        private By ApplicationReferenceBy => By.Id("application-reference");
        private By ReviewAndSubmitStatusBy => By.XPath("//div[@id='review-and-submit-application']/dd/span");
        private By SkipHeaderBy => By.CssSelector(".CertificateWeightPage .govuk-heading-m");
        private IWebElement SkipFunction => _driver.WaitForElementExists(By.CssSelector("#skip-question"));
        private IWebElement ExporterOrConsignorLink => _driver.WaitForElement(By.CssSelector("#exporter-or-consignor a"));

        #endregion

        public TaskList(ObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Methods

        public bool IsTaskListPage
        {
            get => _driver.WaitForElement(TaskListHeaderBy).Text.Contains("Apply for an export health certificate");
        }

        public bool SearchOnPage(string text)
        {
            return _driver.WaitForElement(By.XPath("//body")).Text.Contains(text);
        }

        public string GetApplySectionStatus()
        {
            return _driver.WaitForElement(ReviewAndSubmitStatusBy).Text;

        }

        public void ClickManageCommoditiesLink() => ManageCommoditiesLink.Click();
        public void ClickGrossWeightLink() => GrossWeightLink.Click();
        public void ClickAccompanyingDocsLink() => AccompanyingDocLink.Click();
        public void ClickDepartureAndArrivalLink() => DepartureAndArrivalLink.Click();
        public void ClickPlaceOfOriginLink() => PlaceOfOriginLink.Click();
        public void ClickMeansOfTransportLink() => MeansOfTransportLink.Click();
        public void ClickChangeApplicationReference() => ChangeApplicationReference.Click();

        public string GetApplicationReference()
        {
            var element = _driver.WaitForElementCondition(ExpectedConditions.ElementExists(ApplicationReferenceBy));
            return element.GetAttribute("value");
        }

        public void ClickPreviewCertificateLink() => PreviewCertificateLink.Click();

        public bool ValidatePreviewSummary => !string.IsNullOrEmpty(PreviewSummaryText.Text);
        public bool ValidateDownloadLink => DownloadLink.Enabled;

        //TODO: The methods ClickDownloadLink() and ConfirmPreviewCertDownload will be called when all the sections are completed
        public void ClickDownloadLink() => DownloadLink.Click();

        public bool ConfirmPreviewCertDownload()
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementExists(ConfirmPreviewDownloadLinkBy));
            return ConfirmPreviewDownloadLink.Displayed;
        }

        public void ClickReviewAnswersLink() => ReviewYourAnswers.Click();

        public void ClickExporterOrConsignorLink() => ExporterOrConsignorLink.Click();

        public void ClickSkipFunctionCheckBox() => _driver.ClickRadioButton(" I've entered as much information as I can ");

        public void ClickOnSkipFunction()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SkipFunction);
        }
        #endregion
    }
}
