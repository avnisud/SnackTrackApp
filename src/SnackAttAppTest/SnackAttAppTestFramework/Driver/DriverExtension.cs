using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// Driver extension method to wait till element available.
    /// </summary>
    public static class DriverExtension
    {
        public static ReadOnlyCollection<AndroidElement> FindElements(this AndroidDriver<AndroidElement> driver, string id)
        {
            var wait = new DefaultWait<AndroidDriver<AndroidElement>>(driver)
            {
                Timeout = new TimeSpan(0, 0, 30),
                PollingInterval = TimeSpan.FromSeconds(10)
            };
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            ReadOnlyCollection<AndroidElement> searchElements = null;

            wait.Until(Driver =>
            {
                searchElements = Driver.FindElements(By.Id(id));

                return searchElements != null;
            });

            return searchElements;
        }

        public static AndroidElement FindElement(this AndroidDriver<AndroidElement> driver, string id)
        {
            var wait = new DefaultWait<AndroidDriver<AndroidElement>>(driver)
            {
                Timeout = new TimeSpan(0, 0, 30),
                PollingInterval = TimeSpan.FromSeconds(10)
            };
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            AndroidElement searchElement = null;

            wait.Until(Driver =>
            {
                searchElement = Driver.FindElement(By.Id(id));

                return searchElement != null;
            });

            return searchElement;
        }
    }
}
