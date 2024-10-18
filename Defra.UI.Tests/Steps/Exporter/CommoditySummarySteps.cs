using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.Exporter.CommoditySummary;
using Defra.UI.Tests.Pages.Exporter.IdentificationPage;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using Defra.UI.Tests.Pages.Exporter.CheckYourAnswers;
using Defra.UI.Tests.Pages.Exporter.Commodity;

namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class CommoditySummarySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ICommoditySummary? CommoditySummary => _objectContainer.IsRegistered<ICommoditySummary>() ? _objectContainer.Resolve<ICommoditySummary>() : null;

        public CommoditySummarySteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I click '([^']*)'")]
        public void WhenIClick(string button)
        {
            switch (button)
            {
                case "Change":
                    CommoditySummary.ClickChangeLink();
                    break;
                case "Copy":
                    CommoditySummary.ClickCopyLink();
                    break;
                default:
                    break;
            }
            
        }

        [When(@"I expand the commodity record on the review commodities page")]
        public void WhenIExpandTheCommodityRecordOnTheReviewCommoditiesPage()
        {
            CommoditySummary.ClickShowDetails();
        }

        [Then(@"I can see the sections that were left blank labelled as '([^']*)'")]
        public void ThenICanSeeTheSectionsThatWereLeftBlankLabelledAs(string notEntered)
        {
            Assert.True(CommoditySummary.IsLabelTagNotEntered(), "The sections that are left blank on commodity summary page doesn't show the status {notEntered}");
        }

        [When(@"I navigate to commodities summary page")]
        public void WhenINavigateToCommoditiesSummaryPage()
        {
            Assert.True(CommoditySummary.IsCommoditySummaryPage(), "Not commodity summary page");
        }

        [When(@"I expand the commodity record on the commodities summary page")]
        public void WhenIExpandTheCommodityRecordOnTheCommoditiesSummaryPage()
        {
            CommoditySummary.ClickShowDetails();
        }

        [When(@"I click '([^']*)' to add more records on commodities summary page")]
        public void WhenIClickToAddMoreRecordsOnCommoditiesSummaryPage(string No)
        {
            CommoditySummary.ClickNoForAddMoreRecords(No);
        }

        [Then(@"I can see the sections that skipped labelled as '([^']*)'")]
        public void ThenICanSeeTheSectionsThatSkippedLabelledAs(string notEntered)
        {
            Assert.True(CommoditySummary.IsLabelTagNotEntered(), "Skipped feature shows label as not entered");
        }

        [When(@"I navigate to commodity summary page")]
        public void WhenINavigateToCommoditySummaryPage()
        {
            Assert.IsTrue(CommoditySummary.IsCommoditiesSummaryPage, "Commodities summary page is not displayed");
        }

        [When(@"I click on ""([^""]*)"" to add another commodity on summary page and continue")]
        public void WhenIClickOnToAddAnotherCommodityOnSummaryPageAndContinue(string yesOrNoRadio)
        {
            CommoditySummary.ClickRadioOptionForAnotherRecord(yesOrNoRadio);
        }
    }
}