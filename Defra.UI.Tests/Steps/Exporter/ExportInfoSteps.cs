using BoDi;
using Defra.UI.Tests.Pages.Exporter.ExportInfo;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class ExportInfoSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IExportInfo? ExportInfo => _objectContainer.IsRegistered<IExportInfo>() ? _objectContainer.Resolve<IExportInfo>() : null;

        public ExportInfoSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"check the user is (.*)")]
        [When(@"check the user is (.*)")]
        [Then(@"check the user is (.*)")]
        public void ThenCheckTheUserIsExpoter(string exportcertinfo)
        {
            Assert.True(ExportInfo.IsExpoterOrCertifier(exportcertinfo), $"The user is not {exportcertinfo}");
        }
    }
}