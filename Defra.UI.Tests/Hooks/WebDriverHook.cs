using BoDi;
using Defra.UI.Framework.Object;
using Defra.UI.Test.Data.Application;
using Defra.UI.Tests.Capabilities;
using Defra.UI.Tests.Configuration;
using OpenQA.Selenium;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Net.Http.Headers;
using System.Reflection;

namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver Driver { get; set; }
        private static string Target => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.Target;
        private static string SeleniumGrid => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public WebDriverHook(ScenarioContext context, ObjectContainer container,
            ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = container;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario(Order = (int)HookRunOrder.WebDriver)]
        public void BeforeTestScenario()
        {

            Logger.Debug("Starting set Capability");

            var site = new Site();
            site.With(GetDriverOptions());
            Driver = site.WebDriver.Driver;
            if(ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.IsDebug)
                PrintNodeInfo("http://localhost:4444/status");
            _objectContainer.RegisterInstanceAs(Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            bool takeScreenShot = false;
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    takeScreenShot = true;
                    var error = _scenarioContext.TestError;
                    Logger.LogMessage("An error ocurred:" + error.Message);
                    Logger.Debug("It was of type:" + error.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Not able to take screenshot" + ex.Message);
            }
            finally
            {
                if (takeScreenShot)
                {
                    AttachScreenShotToXmlReport();
                }
                Driver.Close();
                Driver.Quit();
                if (!ConfigSetup.BaseConfiguration.TestConfiguration.Environment.Contains("pre"))
                {
                    DeleteApplicationViaBackend();
                }
            }
        }

        private void AttachScreenShotToXmlReport()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = Path.Combine(filePath, "TestResults");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Logger.Debug($"{filePath} directory created....");
            }

            var fileTitle = _scenarioContext.ScenarioInfo.Title;
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);

            _specFlowOutputHelper.AddAttachment(fileName);
            Logger.Debug($"SCREENSHOT {fileName} ");
        }

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

        private void DeleteApplicationViaBackend()
        {
            if (_scenarioContext.Count > 0 &&
                _scenarioContext.ContainsKey("AppDispId"))
            {
                var applicationres = (ApplicationResponse)_scenarioContext["AppDispId"];
                if(applicationres != null && 
                    !string.IsNullOrEmpty(applicationres.ApplicationId)) {
                    _objectContainer.Resolve<ApplicationData>().DeleteApplication(applicationres.ApplicationId);
                }

            }
            

        }

        public void PrintNodeInfo(string gridIpAddress)
        {
            string endpoint = string.Empty;
            try
            {
                var remoteWebDriver = (RemoteWebDriver)Driver;
                var sessionId = remoteWebDriver.SessionId.ToString();
                gridIpAddress = gridIpAddress.Replace("/wd/hub", "");
                endpoint = $"{gridIpAddress}status";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                var resp = client.GetAsync(new Uri(endpoint)).Result.Content.ReadAsStringAsync().Result;
                Logger.Debug($"Appium node details: {resp}");
                
            }
            catch (Exception)
            {
                Logger.LogMessage($"Not able to print Node information for {endpoint}, most likely running against manually started appium server.");
            }
        }

    }
}
