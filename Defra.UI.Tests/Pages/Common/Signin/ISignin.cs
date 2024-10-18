namespace Defra.UI.Tests.Pages.Common.Signin
{
    public interface ISignin
    {
        public bool IsPageLoaded();
        public bool IsSignedIn(string userName, string password);
        public void ClickSignedOut();
        public bool IsSignedOut();
    }
}
