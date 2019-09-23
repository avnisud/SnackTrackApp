using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// The menu item class
    /// </summary>
    public class MenuItems
    {
        private readonly List<Menu> items = new List<Menu>();
        private readonly DriverHelper driverHelper;
        private readonly string id;
        public MenuItems(DriverHelper driverHelper, string id)
        {
            this.driverHelper = driverHelper;
            this.id = id;
            Refresh();
        }

        /// <summary>
        /// Gets count of available snacks item.
        /// </summary>
        public int TotalMenu
        {
            get
            {
                return this.items.Count();
            }
        }

        /// <summary>
        /// Find menu from menu items
        /// </summary>
        /// <param name="menuTitle">The menu title.</param>
        /// <returns></returns>
        public Menu Find(string menuTitle)
        {
            return this.items.Find(item => item.MenuTitle == menuTitle);
        }

        /// <summary>
        /// Refresh (reload) menu
        /// </summary>
        public void Refresh()
        {
            this.items.Clear();
            var options = this.driverHelper.Driver.FindElements(id);

            foreach (AndroidElement element in options)
            {
                this.items.Add(new Menu(element));
            }
        }

        /// <summary>
        /// Add new menu item
        /// </summary>
        /// <param name="menuTitle">The title of new menu item</param>
        /// <param name="itemType">The menu item type (Veggie/Non Veggie).</param>
        public void AddNew(string menuTitle,string itemType)
        {
            // Click Add menu item
            this.driverHelper.Driver.FindElement(Constants.AddMenuItemButtonId).Click();
            if(itemType=="NonVeggie")
            {
                this.driverHelper.Driver.FindElement(Constants.MenuItemWindowSnackType).Click();
                var dropbox = this.driverHelper.Driver.FindElements(Constants.MenuItemWindowSnackType);
                foreach(AndroidElement menuitem in dropbox)
                {
                    if (menuitem.Text == "Non-Veggie")
                        menuitem.Click();
                }
            }
            var textElement = this.driverHelper.Driver.FindElement(By.ClassName(Constants.MenuItemWindowTextClassName));
            textElement.Click();
            textElement.SendKeys(menuTitle);

            this.driverHelper.Driver.FindElement(Constants.MenuItemWindowSaveButtonId).Click();

            this.Refresh();
        }
    }
}
