using BoDi;
using Defra.UI.Tests.Pages.Exporter.CertificateLookupPage;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CertificateLookupSteps
    {
        private readonly IObjectContainer _objectContainer;
        public CertificateLookupSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private ICertificateLookup CertificateLookup => _objectContainer.IsRegistered<ICertificateLookup>() ? _objectContainer.Resolve<ICertificateLookup>() : null;

    }
}
