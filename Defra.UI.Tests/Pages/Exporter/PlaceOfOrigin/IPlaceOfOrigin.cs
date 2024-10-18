namespace Defra.UI.Tests.Pages.Exporter.PlaceOfOrigin
{
    internal interface IPlaceOfOrigin
    {
        public bool IsPlaceOfOriginPage { get; }
        public void CompletePlaceOfDispatch(string PlaceOfDispatchCountry, string PlaceOfDispatch);
        public void CompletePlaceOfLoading(string PlaceOfLoadingCountry, string PlaceOfLoading);
        public void CompleteRegionOfOrigin(string CountryOfOrigin);
        public void EditRegionOfOrigin(string countryOfOrigin, string regionOfOrigin);
        public void CompletePlaceOfOrigin(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading);
        public void CompletePlaceOfOriginAndContinue(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading);
        public void CompletePlaceOfOriginByApprovalNumberAndContinue(string CountryOfOrigin, string PlaceOfDispatchCountry, string PlaceOfDispatch, string PlaceOfLoadingCountry, string PlaceOfLoading, string SearchByOpearetor = "false");
        public bool IsPlaceOfOriginPageDisplayed();
        public bool IsPlaceOfDispatchDisplayed();
        public bool IsPlaceOfLoadingDisplayed();
        public bool VerifyPlaceOfOriginStatus();
        public bool IsPlaceOfDispatchBlank();
        public bool IsPlaceOfLoadingBlank();
        public void ClickRemoveLink(string placeOfDispatchLoading);
        public bool IsSkipCheckboxVisible();
        public void SkipAndContinue();
        public bool IsSkipChecked();
        public void SaveContinue();
        public bool IsSkipError();
        public void SkipCheckbox();
        public void RemovePlaceOfLoading();
        public void RemovePlaceOfDispatch();
        public bool IsOperatorPageDisplayed(string page);
        public void ClickBackLink();
        public void RemoveRegionOfOrigin();
        public void ClickPlaceOfDispatchLink();
        public void ClickPlaceOfLoadingLink();
        public string GetPlaceOfDispatchOperatorName { get; }
        public string GetPlaceOfLoadingOperatorName { get; }
        public bool VerifyApprovalNoPresentInSearchItemsInsidePlaceOfDespatch(string countryOfOrigin, string placeOfDispatchCountry, string placeOfDispatch);
        public bool VerifyApprovalNoPresentInSearchItemsInsidePlaceOfLoading(string countryOfOrigin, string placeOfLoadingCountry, string placeOfLoading);
        public bool VerifyApprovalNoPresentInTwoTypesOfPlaceSections();
    }
}
