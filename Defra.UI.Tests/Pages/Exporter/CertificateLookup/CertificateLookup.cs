using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.Exporter.CertificateLookupPage
{
    public class CertificateLookup : ICertificateLookup
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By CertificateLookupPageHeaderBy => By.CssSelector(".CertificateLookupPage h1.govuk-fieldset__heading");
        #endregion

        #region Methods

        public CertificateLookup(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsCertificateLookupPage
        {
            get => _driver.WaitForElement(CertificateLookupPageHeaderBy).Text.Contains("Select a certificate");
        }
        #endregion
    }
}
