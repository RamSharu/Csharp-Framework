namespace Defra.UI.Tests.Pages.Exporter.ReviewAndCheck
{
    public interface IReviewAndCheck
    {
        public bool IsReviewAndCheckPage { get; }
        public void ClickConfirmCheckBox();
        public void ClickConfirmAndSubmitButton();
    }
}
