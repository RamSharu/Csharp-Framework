using System.Reflection;
using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.WaitHelpers;

namespace Defra.UI.Tests.Pages.Exporter.AccompanyingDocs
{
    public class AccompanyingDocs : IAccompanyingDocs
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private readonly object _lock = new object();

        #region Page Objects
        private IWebElement AccompanyingDocsPageHeaderBy => _driver.WaitForElement(By.CssSelector(".AccompanyingDocuments .govuk-heading-xl"));
        private By AddAnotherDocLinkBy => By.Id("button-add-additional-document");
        private List<IWebElement> AddAnotherDocLinkList => _driver.FindElements(AddAnotherDocLinkBy).ToList();
        private List<IWebElement> AdditionalDocsTableHeaderRowList => _driver.FindElements(By.XPath("//*[@id='additional-documents-table']/thead/tr/th")).ToList();
        private IWebElement AdditionalDocsTable => _driver.FindElement(By.Id("additional-documents-table"));
        private IWebElement AddAnotherDocLink => _driver.WaitForElement(AddAnotherDocLinkBy);
        private List<IWebElement> AdditionalDocsTotalRowsList => _driver.FindElements(By.XPath("//table[@id='additional-documents-table']//tbody/tr")).ToList();
        private List<IWebElement> AdditionalDocsTableRowList => _driver.FindElements(By.XPath("//table[@id='additional-documents-table']/tbody/tr/td")).ToList();
        private int docTypeColumnId => GetTableColumnId("document-type");
        private int docReferenceColumnId => GetTableColumnId("document-ref");
        private int dateOfIssueColumnId => GetTableColumnId("document-date");
        private int sendToTracesColumnId => GetTableColumnId("document-send-to-traces");
        private int attachmentsColumnId => GetTableColumnId("document-file");
        private int UploadedByColumnId => GetTableColumnId("document-uploaded");
        private IWebElement ViewDocumentLink => _driver.WaitForElement(By.XPath("//td/a[contains(text(), 'View document')]"));
        private IWebElement AccompanyindDocStatus => _driver.WaitForElement(By.XPath("//a[contains(text(),'Accompanying documents')]/../following-sibling::dd/span/span"));
        private IWebElement RemoveButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Remove')]"));
        private IWebElement Return => _driver.WaitForElement(By.XPath("//button[contains(text(),'Return')]"));
        #endregion

        public AccompanyingDocs(ObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsAccompanyingDocsPage()
        {
            return AccompanyingDocsPageHeaderBy.Text.Contains("Accompanying documents");
        }

        public bool IsAccompanyingDocAdded => _driver.WaitForElementCondition(ExpectedConditions.ElementExists(AddAnotherDocLinkBy)).Text.Contains("Add");

        public int GetTableColumnId(string idAttribute)
        {
            for (int i = 0; i < AdditionalDocsTableHeaderRowList.Count; i++)
            {
                if (AdditionalDocsTableHeaderRowList.ElementAt(i).GetAttribute("id").Contains(idAttribute))
                    return i;
            }
            throw new Exception("The column is not available in the table");
        }

        public void CheckIfDocAlreadyAdded()
        {
            if(AddAnotherDocLinkList.Count > 0)
            {
                RemoveButton.Click();
                _driver.WaitForElement(AddAnotherDocLinkBy).Click();
            }
        }

        public bool AddDocument(string docType, string docRef)
        {
            bool AccompanyingDocAddedStatus = false;
            var docTypeLocator = AdditionalDocsTableRowList.ElementAt(docTypeColumnId).FindElement(By.TagName("select"));
            SelectFromDropdown(docTypeLocator, docType);

            var docRefLocator = AdditionalDocsTableRowList.ElementAt(docReferenceColumnId).FindElement(By.TagName("input"));
            docRefLocator.SendKeys(docRef);

            var dateOfIssueLocator = AdditionalDocsTableRowList.ElementAt(dateOfIssueColumnId).FindElement(By.TagName("input"));
            var dateOfIssue = GetFutureDate();
            dateOfIssueLocator.Clear();
            dateOfIssueLocator.SendKeys(dateOfIssue);

            var attachmentsLocator = AdditionalDocsTableRowList.ElementAt(attachmentsColumnId).FindElement(By.TagName("input"));
            lock (_lock)
            {
                string dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var docPath = Path.Combine(dirPath, "Data", "AccompanyingDocsFile", "AccompanyingDocsFileToUpload.txt");

                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)_driver;
                allowsDetection.FileDetector = new LocalFileDetector();

                attachmentsLocator.SendKeys(docPath);
            }

            var saveButtonColumnId = AdditionalDocsTableRowList.Count - 1;
            var saveButtonLocator = AdditionalDocsTableRowList.ElementAt(saveButtonColumnId).FindElement(By.TagName("button"));
            saveButtonLocator.Click();
            AccompanyingDocAddedStatus = IsAccompanyingDocAdded;
            Return.Click();
            return AccompanyingDocAddedStatus;
        }

        private string GetFutureDate()
        {
            DateTime todaysDate = DateTime.Now;
            DateTime futureDateForDateOfIssue = todaysDate.AddDays(5);
            return futureDateForDateOfIssue.ToString("dd/MM/yyyy");
        }

        private void SelectFromDropdown(IWebElement docRefElement, string docRef)
        {
            string script = $"const element = arguments[0]; element.value = '" + docRef + "'; element.dispatchEvent(new Event('input')); element.dispatchEvent(new Event('change'));";
            ((IJavaScriptExecutor)_driver).ExecuteScript($"{script}", docRefElement);
        }

        public bool VerifyIfDocIsAddedSuccessfully => ViewDocumentLink.Displayed;

        public bool VerifyAccompanyingDocStatus()
        {
            return AccompanyindDocStatus.Text.Contains("COMPLETE");
        }
    }
}