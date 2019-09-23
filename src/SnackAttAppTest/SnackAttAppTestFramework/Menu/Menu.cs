using OpenQA.Selenium.Appium.Android;
using System;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// Class to represent App menu (Veggie and Non Veggie)
    /// </summary>
    public class Menu
    {
        private AndroidElement menuElement;

        public Menu(DriverHelper driverHelper, string id)
        {
            menuElement = driverHelper.Driver.FindElement(id);

            if (menuElement == null)
            {
                throw new SnackAttAppFrameworkException($"Failed to find element by id: {id}");
            }
        }

        public Menu(AndroidElement element)
        {
            this.menuElement = element;
        }

        /// <summary>
        /// Gets title (Text) of menu
        /// </summary>
        public string MenuTitle
        {
            get
            {
                return this.menuElement.Text;
            }
        }

        /// <summary>
        /// Check menu selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                string checkValue = this.menuElement.GetAttribute("checked");
                return Convert.ToBoolean(checkValue);
            }
        }

        /// <summary>
        /// Click menu to toggle (select/UnSelect).
        /// </summary>
        public void Click()
        {
            this.menuElement.Click();
        }
    }
}
