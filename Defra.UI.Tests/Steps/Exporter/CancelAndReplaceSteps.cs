using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.DevTools.V106.Network;
using Defra.UI.Tests.Pages.Exporter.Applications;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CancelAndReplaceSteps
    {
        private readonly IObjectContainer _objectContainer;

        // Pages
        private IApplications? Applications => _objectContainer.IsRegistered<IApplications>() ? _objectContainer.Resolve<IApplications>() : null;

        public CancelAndReplaceSteps(IObjectContainer container)
        {
            _objectContainer = container;

        }

        [Then(@"I can view a link to View Original application for '([^']*)'")]
        public void ThenICanViewALinkToViewOriginalApplicationFor(string status)
        {
            Assert.True(Applications.ClickReplacingApplication(status), "Replacing application not linked");
        }

        [Then(@"I can see that a new application has been generated with the status '([^']*)'")]
        public void ThenICanSeeThatANewApplicationHasBeenGeneratedWithTheStatus(string status)
        {
            Applications.ClickShowLink();
            Assert.True(Applications.VerifyStatus(status), "Status is incorrect");
        }

        [Then(@"I can see that the original certificate is '([^']*)'")]
        public void ThenICanSeeThatTheOriginalCertificateIs(string status)
        {
            Applications.ClickShowLink();
            Assert.True(Applications.VerifyStatus(status), "Status is incorrect");
        }

        [Then(@"I can view a link to View Replacement application")]
        public void ThenICanViewALinkToViewReplacementApplication()
        {
            Assert.True(Applications.ClickReplacementApplication(), "Replacement application not linked");
        }

    }
}
