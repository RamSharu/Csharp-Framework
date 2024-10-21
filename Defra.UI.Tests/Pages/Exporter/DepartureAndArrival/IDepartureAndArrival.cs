namespace Defra.UI.Tests.Pages.Exporter.DepartureAndArrival
{
    public interface IDepartureAndArrival
    {
        public bool IsDepartureArrivalPage { get; }
        public void CompleteDepartureAndArrivalDate();
        public void EditDepartureAndArrivalDates();
        public bool VerifyDepartureAndArrivalDateStatus();
        public bool IsDepartureAndArrivalDatePageDisplayed();
        public void CompleteSkipDepartureAndArrivalDate(string skipcheckbox);
        public bool VerifySkipValidationInformation();
        public void ClickSaveAndContinue();
        public bool IsSkipChecked();
        public bool VerifyValidationError(string validationError);
        public void EnterDepartureDate(string departureDate);
        public void EnterArrivalDate(string arrivalDate);
        public void CompleteDepartureDate();
        public void CompleteArrivalDate();
        public void AddDepartureDate();
        public void AddArrivalDate();

    }
}