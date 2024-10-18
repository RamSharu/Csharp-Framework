using BoDi;
using Defra.UI.Tests.Pages.Certifier.CertifyEHC;
using Defra.UI.Tests.Pages.Exporter.AccompanyingDocs;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Steps.Certifier
{
    [Binding]
    public class CertifierViewSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public CertifierViewSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ICertifierView? CertifierView => _objectContainer.IsRegistered<ICertifierView>() ? _objectContainer.Resolve<ICertifierView>() : null;
        private IAccompanyingDocs? AccompanyingDocs => _objectContainer.IsRegistered<IAccompanyingDocs>() ? _objectContainer.Resolve<IAccompanyingDocs>() : null;

        [Then(@"I click on the Additional Documents tab to open the documents section")]
        public void ThenIClickOnTheAdditionalDocumentsTabToOpenTheDocumentsSection()
        {
            Assert.IsTrue(CertifierView.IsCertifierViewPage, "Certify an EHC page is not displayed");
            CertifierView.ClickAdditionalDocsTabLink();
        }

        [Then(@"I click on the edit link in the documents section")]
        public void ThenIClickOnTheEditLinkInTheDocumentsSection()
        {
            CertifierView.ClickEditAdditionalDocsLink();
            Assert.IsTrue(CertifierView.IsAdditionalDocsSection, "Additional documents section is not displayed for the certifier to edit");
        }

        [Then(@"I can verify that additional document can be updated successfully through the edit link")]
        public void ThenICanVerifyThatAdditionalDocumentCanBeUpdatedSuccessfullyThroughTheEditLink()
        {
            Assert.IsTrue(AccompanyingDocs.VerifyIfDocIsAddedSuccessfully, "Adding additional document from certifier edit link is not successful");
        }

        [Then(@"I click on the edit link in the documents section and click save")]
        public void ThenIClickOnTheEditLinkInTheDocumentsSectionAndClickSave(Table table)
        {
            CertifierView.ClickEditAdditionalDocsLink();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                StringAssert.Contains(table.Rows[i][0], CertifierView.ValidateandVerifyErrorforDocuments()[i], "Additional documents error message NOT found");
            }
        }

        [When(@"click on Part1 '([^']*)' tab")]
        [Then(@"click on Part1 '([^']*)' tab")]
        public void ThenClickOnPart1Tab(string TabName)
        {
            Assert.True(CertifierView.ClickPart1Tab(TabName), "Part1 Tab not found");
        }

        [Then(@"edit Consignee details to '([^']*)','([^']*)'")]
        public void ThenEditConsigneeDetailsTo(string Country, string ConsigneeName)
        {
            Assert.True(CertifierView.EditConsigneeDetails(Country, ConsigneeName), "On Certifier Consignee not updated");
        }

        [Then(@"Verify changed Consignee '([^']*)' details")]
        public void ThenVerifyChangedConsigneeDetails(string ConsigneeName)
        {
            Assert.True(CertifierView.VerifyConsigneeDetails(ConsigneeName), "On Certifier Consignee not found");
        }

        [Then(@"edit Consignor details to '([^']*)','([^']*)'")]
        public void ThenEditConsignorDetailsTo(string Country, string ConsignorName)
        {
            Assert.True(CertifierView.EditConsignorDetails(ConsignorName), "On Certifier Consignor not updated");
        }

        [Then(@"Verify changed Consignor '([^']*)' details")]
        public void ThenVerifyChangedConsignorDetails(string ConsignorName)
        {
            Assert.True(CertifierView.VerifyConsignorDetails(ConsignorName), "On Certifier Consignor not found");
        }

        [When(@"I change Gross Weight to '([^']*)' and '([^']*)'")]
        [Then(@"I change Gross Weight to '([^']*)' and '([^']*)'")]
        public void ThenIChangeGrossWeight(string grossWeightAmount, string grossWeightUnit)
        {
            Assert.IsTrue(CertifierView.EditGrossWeightOnCertifier(grossWeightAmount, grossWeightUnit), "Gross Weight edit on certifier is not successful");
        }

        [When(@"edit the Quantity Totals in certifier commodity details and save")]
        public void WhenEditTheQuantityTotalsInCertifierCommodityDetailsAndSave(Table table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string grossWeight = table.Rows[i][0];
                string grossWeightUnit = table.Rows[i][1];
                CertifierView.EditGrossWeightOnCertifier(grossWeight, grossWeightUnit);
                var validationmessages = CertifierView.ValidateandVerifyErrorforQuantityTotal().Where(a => a != null);

                string[] errorMessage;
                if (grossWeight == "" && grossWeightUnit == "")
                {
                    errorMessage = table.Rows[i][2].Split("-");
                    
                    Assert.AreEqual(2, validationmessages.Count());
                    Assert.True(validationmessages.Contains(errorMessage[0]));
                    Assert.True(validationmessages.Contains(errorMessage[1]));
                }
                else
                {
                    Assert.AreEqual(1, validationmessages.Count());
                    Assert.AreEqual(table.Rows[i][2], validationmessages.FirstOrDefault());
                }
            }
        }

        [When(@"edit the Container Seal Number Tab delete current entry then add new entry and save '([^']*)' '([^']*)'")]
        public void WhenEditTheContainerSealNumberTabDeleteCurrentEntryThenAddNewEntryAndSave(string containerNumber, string sealNumber)
        {
            CertifierView.EditContainerSealNumberOnCertifier(containerNumber, sealNumber);
            Assert.IsTrue(CertifierView.VerifyIfContinerNumberSealNumbersAndRowCountAreValid(containerNumber, sealNumber));
        }

        [When(@"I click edit in Means of Transport Tab and click on save")]
        public void WhenIClickEditInMeansOfTransportTabAndClickOnSave()
        {
            CertifierView.EditMeansOfTransportOnCertifier();
            Assert.IsTrue(CertifierView.VerifyIfMeansOfTransportSummaryErrorFousAndAriaDescribedByValid());
        }

        [When(@"I verify changed Gross Weight as '([^']*)'")]
        [Then(@"I verify changed Gross Weight as '([^']*)'")]
        public void ThenIVerifyChangedGrossWeight(string grossWeightAmount)
        {
            Assert.IsTrue(CertifierView.VerifyIfGrossWeightUpdatedSuccessfully(grossWeightAmount), "Gross Weight not found on certifier");
        }

        [When(@"I click on Part II Certification tab")]
        [Then(@"go to Certification Part2")]
        public void ThenGoToCertificationPart()
        {
            CertifierView.ClickOnCertificationPart2();
        }

        [Then(@"sign and approve the application")]
        public void ThenSignAndApproveTheApplication()
        {
            CertifierView.ClickSignAndApprove();
        }

        [Then(@"click on check application data against Traces")]
        public void ThenClickOnCheckApplicationDataAgainstTraces()
        {
            CertifierView.ClickCheckApplicationDataTraces();
        }

        [When(@"I click edit on application gross weight")]
        public void WhenIClickEditOnApplicationGrossWeight()
        {
            CertifierView.ClickOnGrossWeightEdithLink();
        }

        [When(@"I click edit on application place of origin")]
        public void WhenIClickEditOnApplicationPlaceOfOrigin()
        {
            CertifierView.ClickOnPlaceOfOriginEditLink();
        }

        [Then(@"I click edit on application Border Control Post")]
        [When(@"I click edit on application Border Control Post")]
        public void WhenIClickEditOnApplicationBorderControlPost()
        {
            CertifierView.ClickOnBCPEditLink();
        }

        [Then(@"I can validate that disease clearance check date box is displayed")]
        public void ThenICanValidateThatDiseaseClearanceCheckDateBoxIsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(CertifierView.IsDiseaseClearancePanelDisplayed, "Disease clearance panel not displayed on part 2 certification section");
                Assert.That(CertifierView.DiseaseClearancePanelHeaderText.Contains("Disease Clearance"), "Disease clearance panel header not displayed");
                Assert.That(CertifierView.ChecksPerformedQuestionText.Contains("When were the checks performed?"), "Checks performed question is not displayed");
                Assert.IsTrue(CertifierView.ChecksPerformedHintText, "Disease clearance panel not displayed on part 2 certification section");
                Assert.IsTrue(CertifierView.IsDiseaseClearanceTextBoxDisplayed, "Disease clearance panel not displayed on part 2 certification section");
            });
        }

    }
}