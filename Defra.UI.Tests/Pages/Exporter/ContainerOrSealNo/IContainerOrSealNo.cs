namespace Defra.UI.Tests.Pages.Exporter.ContainerOrSealNo
{
    public interface IContainerOrSealNo
    {
        public void ClearContainerSealNumber();
        public void CompleteContainerSealNumber(string containerno, string sealno);
        public void AddContainerSealNumber(string containerNo, string sealNo);
        public bool ContainerSealNoStatus();
        public bool IsContainerSealNumberPageDisplayed();
        public void ContainerAndSealNumberIsRemoved();

    }
}
