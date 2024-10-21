namespace Defra.UI.Tests.Pages.Exporter.WhichSectionsToCopy
{
    public interface IWhichSectionsToCopy
    {
        public bool IsWhichSectionsToCopyPage { get; }
        public void ClickSelectAllCheckbox();
        public void ClickSecondCheckbox();
        public void ClickContinueButton();
    }
}
