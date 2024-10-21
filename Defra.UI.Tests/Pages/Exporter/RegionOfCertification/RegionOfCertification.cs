using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.RegionOfCertification
{
    public class RegionOfCertification : IRegionOfCertification
    {
        private IObjectContainer _objectContainer;

        public RegionOfCertification(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private IWebElement RegionOfCertificationLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Region of certification']"));
        private IWebElement RegionOfCertificationPageHeader => _driver.WaitForElement(By.CssSelector("div.RegionOfCertification h1.govuk-heading-xl"));
        private IWebElement SaveAndReturnButton => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and return']"));
        private IWebElement RegionOfCertificationStatusText => _driver.WaitForElement(By.XPath("//div[@id='region-of-certification']//span[contains(text(),'COMPLETE')]"));
        #endregion

        #region Methods
        public bool IsRegionOfCertificationDisplayed()
        {
            RegionOfCertificationLink.Click();
            var pageHeaderText = RegionOfCertificationPageHeader.Text;
            return pageHeaderText.Contains("In which region ");
        }

        public void RegionOfCertificationtButton(string region)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.XPath($"//label[contains(text(),'{region}')]")).Text.Contains(region));
            ClickRegionOfCertRadio(region);
            SaveAndReturnButton.Click();
        }

        public bool RegionOfCertificationStatus()
        {
            var regionOfCertificationStatus = RegionOfCertificationStatusText.Text;
            return regionOfCertificationStatus.Contains("COMPLETE");
        }

        private void ClickRegionOfCertRadio(string region)
        {
            var regionAttr = GetRegionAttribute(region);

            var element = _driver.WaitForElementCondition(ExpectedConditions.ElementExists(By.TagName("input")));
            var inputsRadios = _driver.FindElements(By.TagName("input"));
            var radio = inputsRadios.FirstOrDefault(e => e.GetAttribute("value").Equals(regionAttr));

            Actions action = new Actions(_driver);
            action.MoveToElement(radio);
            action.Perform();
            radio.Click();

            if (!radio.Selected)
                radio.Click();
        }
        
        private string GetRegionAttribute(string region)
        {
            string regionAttr = "";
            switch (region)
            {
                case "England":
                    regionAttr = "GB-ENG";
                    break;
                case "Scotland":
                    regionAttr = "GB-SCT";
                    break;
                case "Wales":
                    regionAttr = "GB-WLS";
                    break;
                default:
                    break;
            }
            return regionAttr;
        }
        #endregion  
    }
}