using BoDi;
using Defra.UI.Tests.Pages.FindAnExporterOrConsignor;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class FindAnExporterOrConsignorSteps
    {
        private readonly IObjectContainer _objectContainer;

        private IFindAnExporterOrConsignor? FindAnExporterOrConsignor => _objectContainer.IsRegistered<IFindAnExporterOrConsignor>() ? _objectContainer.Resolve<IFindAnExporterOrConsignor>() : null;

        public FindAnExporterOrConsignorSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I validate the fields on '([^']*)' page")]
        public void ThenIValidateTheFieldsOnPage(string pageName)
        {
            Assert.True(FindAnExporterOrConsignor.IsFindAnExporterOrConsignorPage, "Find an exporter or consignor page is not displayed");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(FindAnExporterOrConsignor.IsBackLinkDisplayed, $"Back link is not displayed on {pageName}");
                Assert.That(FindAnExporterOrConsignor.GetFindExporterConsignorDesc.Contains("consignment"), $"Description doesn't have the expected text on {pageName}");
                Assert.IsTrue(FindAnExporterOrConsignor.GetFindExporterConsignorLabelText.StartsWith("Exporter"), $"Label text doesn't have the expected text on {pageName}");
                Assert.IsFalse(FindAnExporterOrConsignor.IsHintTextDisplayed, $"Hint text is not displayed on {pageName}");
                Assert.IsTrue(FindAnExporterOrConsignor.IsSearchBoxDisplayed, $"Searchbox is not displayed on {pageName}");
                Assert.IsTrue(FindAnExporterOrConsignor.IsSearchButtonDisplayed, $"Search button is not displayed on {pageName}");
            });
        }

        [Then(@"I search and select the consignor '([^']*)' to continue")]
        public void ThenISearchAndSelectTheConsignorToContinue(string consignorName)
        {
            FindAnExporterOrConsignor.SearchConsignor(consignorName);
            FindAnExporterOrConsignor.ClickSearchButton();
            FindAnExporterOrConsignor.SelectConsignorRadioOption(consignorName);
            FindAnExporterOrConsignor.ClickSaveAndContinueButton();
        }
    }
}
