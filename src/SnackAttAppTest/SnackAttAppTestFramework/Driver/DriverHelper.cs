using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;

namespace SnackAttAppTestFramework
{
    public class DriverHelper
    {
        private AndroidDriver<AndroidElement> _remoteWebDriver;

        /// <summary>
        /// Gets AndroidDriver.
        /// </summary>
        public AndroidDriver<AndroidElement> Driver
        {
            get
            {
                return this._remoteWebDriver;
            }
        }

        /// <summary>
        /// Gets server address.
        /// </summary>
        public string ServerAddress
        {
            get
            {
                return $"http://{Constants.LocalAndroidServerAddress}/wd/hub";
            }
        }

        public DriverHelper()
        {
        }

        /// <summary>
        /// Launch application and capture Android Driver.
        /// </summary>
        public void LaunchApplication()
        {
            bool reTry = false;

            // reTry start driver, if emulator take extra time to launch
            while (true)
            {
                try
                {
                    _remoteWebDriver = new AndroidDriver<AndroidElement>(
                        new Uri(this.ServerAddress),
                        CapabilitiesForAppiumServer(), TimeSpan.FromSeconds(180));
                }
                catch (Exception ex)
                {
                    if (!reTry)
                    {
                        reTry = true;
                        continue;
                    }
                    else
                    {
                        throw new SnackAttAppFrameworkException("Launching application failed.", ex);
                    }
                }
                break;
            }
        }



        /// <summary>
        /// Get capabilities of appium for run android test on device.
        /// </summary>
        /// <returns>The DesiredCapabilities object.</returns>
        private DesiredCapabilities CapabilitiesForAppiumServer()
        {
            //Set up app capabilities
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("newCommandTimeout", "120");
            capabilities.SetCapability("deviceName", Constants.ExecutionSetting.DeviceName);
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("apppackage", Constants.AppPackage);
            capabilities.SetCapability("appActivity", Constants.AppActivity);
            capabilities.SetCapability("app", Constants.ExecutionSetting.AppPath);
            capabilities.SetCapability("udid", Constants.ExecutionSetting.UdId);

            return capabilities;
        }
    }
}
