using BoDi;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.UI.Tests.Pages.EstablishmentLookupPage
{
    public class EstablishmentLookupPage : IEstablishmentLookupPage
    {
        private IObjectContainer _objectContainer;

        public EstablishmentLookupPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects
        private By EstablishmentLookupPageBy => By.CssSelector(".EstablishmentlookupPage .govuk-heading-l");
        private IWebElement EstablishmentLookupPageHeader => _driver.WaitForElement(EstablishmentLookupPageBy);
        private IWebElement BackLink => _driver.WaitForElement(By.CssSelector(".govuk-back-link"));
        private IWebElement HintText => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-l']/following-sibling::p"));
        private IWebElement ActivityRadioGroup => _driver.WaitForElement(By.ClassName("govuk-radios__item"));
        private IWebElement HelpAddingActivitiesLink => _driver.WaitForElement(By.ClassName("govuk-details__summary-text"));
        private IWebElement HelpAddingActivitiesDetailsText => _driver.WaitForElement(By.ClassName("govuk-details__text"));
        private IWebElement SaveAndContinueButton => _driver.WaitForElement(By.CssSelector(".govuk-grid-row .govuk-button"));
        private IWebElement ErrorSummaryBox => _driver.WaitForElement(By.Id("validation-error-summary"));
        private IWebElement ActivityErrorMessage => _driver.WaitForElement(By.Id("activity-error-message"));

        private List<IWebElement> ActivityRadioGroupList => _driver.WaitForElements(By.ClassName("govuk-radios__item")).ToList();
        #endregion

        #region Methods
        public bool IsEstablishmentLookupPage => _driver.WaitForElement(EstablishmentLookupPageBy).Text.Contains("activity");

        public string GetErrorSummaryHeader => ErrorSummaryBox.FindElement(By.TagName("h2")).Text;
        public string GetErrorSummaryMessage => ErrorSummaryBox.FindElement(By.TagName("a")).Text;
        public string GetActivityErrorMessage => ActivityErrorMessage.Text;
        public bool IsEstablishmentLookUpPageHeaderDisplayed => EstablishmentLookupPageHeader.Text.StartsWith("Select");
        public bool IsBackLinkDisplayed => BackLink.Displayed;
        public string GetHintText => HintText.Text;
        public string GetHelpAddingActivitiesLinkText => HelpAddingActivitiesLink.Text;
        public void ClickHelpAddingActivitiesLink() => HelpAddingActivitiesLink.Click();
        public string GetHelpAddingActivitiesDetailsText => HelpAddingActivitiesDetailsText.Text;
        public bool IsSaveAndContinueButtonDisplayed => SaveAndContinueButton.Displayed;
        public void ClickSaveAndContinueButton() => SaveAndContinueButton.Click();

        public bool ValidateActivityRadioElements()
        {
            foreach (var radioEle in ActivityRadioGroupList)
            {
                bool isRadioButtonDisplayed = radioEle.FindElement(By.TagName("input")).Enabled;

                string radioLabelText = radioEle.FindElement(By.TagName("label")).Text;
                bool isRadioLabelTextDisplayed = ValidateRadioLabelTextFormat(radioLabelText);

                bool isRadioOptionHintTextDisplayed = !string.IsNullOrEmpty(radioEle.FindElement(By.TagName("div")).Text);

                if (!(isRadioButtonDisplayed && isRadioLabelTextDisplayed && isRadioOptionHintTextDisplayed))
                    return false;
            }
            return true;
        }

        public bool CheckIfActivitiesInAlphabeticalOrder()
        {
            List<string> radioLabelTextListBeforeSort = new List<string>();
            List<string> radioLabelTextListAfterSort = new List<string>();

            foreach (var radioEle in ActivityRadioGroupList)
            {
                string radioLabelText = radioEle.FindElement(By.TagName("label")).Text.ToString();
                radioLabelTextListBeforeSort.Add(radioLabelText);
            }
            
            radioLabelTextListAfterSort = radioLabelTextListBeforeSort.OrderBy(q => q).ToList();

            return radioLabelTextListBeforeSort.SequenceEqual(radioLabelTextListAfterSort);
        }

        private bool ValidateRadioLabelTextFormat(string radioLabelText)
        {
            string[] splitActivityArr = radioLabelText.Split('-');
            return splitActivityArr.Count() >= 3;
        }

        #endregion
    }
}
