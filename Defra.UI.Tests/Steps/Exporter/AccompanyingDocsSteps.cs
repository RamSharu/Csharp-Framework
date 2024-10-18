using BoDi;
using Defra.UI.Tests.Pages.Exporter.AccompanyingDocs;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace Defra.UI.Tests.Steps.Exporter
{
    [Binding]
    public class AccompanyingDocsSteps
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IAccompanyingDocs? AccompanyingDocs => _objectContainer.IsRegistered<IAccompanyingDocs>() ? _objectContainer.Resolve<IAccompanyingDocs>() : null;

        public AccompanyingDocsSteps(ScenarioContext context, IObjectContainer container)
        {
            _objectContainer = container;
        }

        [When(@"I am on accompanying documents page")]
        public void WhenIAmOnAccompanyingDocumentsPage()
        {
            Assert.IsTrue(AccompanyingDocs.IsAccompanyingDocsPage(), "Accompanying documents page is not displayed");
        }

        [Then(@"I can add document details '([^']*)' '([^']*)' and attach documents in the documents section")]
        public void ThenICanAddDocumentDetailsAndAttachDocumentsInTheDocumentsSection(string docType, string docRef)
        {
            Assert.IsTrue(AccompanyingDocs.AddDocument(docType, docRef), "Document details are not added successfully");
        }

        [Then(@"I can verify that the document is added successfully by the certifier")]
        public void ThenICanVerifyThatTheDocumentWithReferenceIsAddedSuccessfully()
        {
            Assert.IsTrue(AccompanyingDocs.VerifyIfDocIsAddedSuccessfully, "Adding additional document from certifier edit link is not successful");
        }

        [Then(@"I can verify that the accompanying document is added successfully")]
        public void ThenICanVerifyThatTheAccompanyingDocumentIsAddedSuccessfully()
        {
            Assert.IsTrue(AccompanyingDocs.VerifyAccompanyingDocStatus(), "Document is not added successfully");
        }
    }
}
