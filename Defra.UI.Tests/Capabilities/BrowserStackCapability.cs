﻿using Defra.UI.Tests.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Defra.UI.Tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {
        

        private static ScenarioContext _scenarioContext;

        private BaseConfiguration _configuration => ConfigSetup.BaseConfiguration;
        private Dictionary<string, object> _capDictionary;
        private readonly Dictionary<string, object> _browserstackOptions = new();

        private readonly string _target;
        private readonly string _deviceName;
        private readonly string _bs_os_version;

        public BrowserStackCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _scenarioContext = context;
            _target = _configuration.UiFrameworkConfiguration.Target;
            _deviceName = _configuration.TestConfiguration.DeviceName;
            _bs_os_version = _configuration.TestConfiguration.BSOSVersion;
        }


        public DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null)
        {
            _capDictionary = new Dictionary<string, object>();

            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();


            _capDictionary.Add("os", _deviceName);
            _capDictionary.Add("osVersion", _bs_os_version);
            _capDictionary.Add("autoGrantPermission:", true);
            _browserstackOptions.Add("acceptInsecureCerts", true);           
            _browserstackOptions.Add("os", _deviceName);
            _browserstackOptions.Add("osVersion", _bs_os_version);
            _browserstackOptions.Add("browser", _target);
            _browserstackOptions.Add("browserVersion", "latest");
            _browserstackOptions.Add("local", "false");
            _browserstackOptions.Add("seleniumVersion", "3.14.0");

            var driverOptions = new ChromeOptions();
            AddDictionaryValuesInDriverOptions(driverOptions, _capDictionary);
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

            return driverOptions;

        }



        private void GetBrowserStackConfig()
        {
            if (!_browserstackOptions.ContainsKey("debug"))
            {
                _browserstackOptions.Add("debug", true);
                _browserstackOptions.Add("userName", _configuration.BrowserStackConfiguration.CloudDeviceUserName);
                _browserstackOptions.Add("accessKey", _configuration.BrowserStackConfiguration.CloudDeviceUserKey);
                _browserstackOptions.Add("idleTimeout", 300);
            }
            _capDictionary.Add("acceptSslCerts", "true");
        }

        private void GetProjectDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("projectName"))
            {
                _browserstackOptions.Add("projectName", ConfigSetup.BaseConfiguration.TestConfiguration.Project);
                _browserstackOptions.Add("buildName", ConfigSetup.BaseConfiguration.TestConfiguration.Build);
            }
        }

        protected virtual void GetTestNameDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("sessionName"))
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName);
        }

        private void AddDictionaryValuesInDriverOptions(DriverOptions driverOptions, Dictionary<string, object> capDictionary)
        {
            if (capDictionary != null)
            {
                foreach (var androidDictionary in capDictionary)
                {
                    driverOptions.AddAdditionalOption(androidDictionary.Key.ToString(), androidDictionary.Value);
                }

            }
        }


    }
}
