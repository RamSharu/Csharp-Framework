using BoDi;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.ExportInfo
{
    public class ExportInfo : IExportInfo
    {

        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private List<IWebElement> Expotercertifierlabel => _driver.WaitForElements(By.CssSelector("div.govuk-radios label")).ToList();
        private By ExpoterRadioButtonBy => By.Id("select-org-0");
        private By CertifierRadioButtonBy => By.Id("select-org-1");
        private By ContinueButtonBy => By.CssSelector("form button.govuk-button");
        #endregion

        public ExportInfo(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public void ClickContinueButton()
        {
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(ContinueButtonBy)).Click();
        }

        public bool IsExpoterOrCertifier(string exportcertinfo)
        {
            var exportcertText = exportcertinfo.Replace("'", "").ToLower().Trim();
            var user = _objectContainer.Resolve<User>();
            if (!user.HomePage)
                return false;

            var element = Expotercertifierlabel.SingleOrDefault(e => e.Text.ToLower().Trim().Contains(exportcertText));

            if (element != null)
            {
                var elementInfo = element.FindElement(By.XPath(".."));
                var radioButtonElement = elementInfo.FindElement(By.TagName("input"));
                radioButtonElement.Click();
                ClickContinueButton();
                return true;
            }
            return false;
        }
    }
}
