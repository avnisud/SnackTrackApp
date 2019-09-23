using NUnit.Framework;
using SnackAttAppTestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackAttAppTest
{
    [TestFixture]
    class SnackAttAppTest : SnackAttAppBaseTest
    {
        [OneTimeSetUp]
        public static void ClassInitialize()
        {
            EmulatorHelper.StartEmulator();
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            EmulatorHelper.StopEmulator();
        }
        #region Submit order tests
        /// <summary>
        /// Test to validate alert windows popup when no snack option selected
        /// </summary>
        [TestCase]
        public void SubmitOrder_UsingNoSelection_WarningDialog()
        {
            this.SnackAttApp.Submit();
            string message = this.SnackAttApp.GetAlertMessageAndClose();

            Assert.AreEqual(Constants.AlertMessageText, message, "Alert message did not showing correct message.");
        }
        /// <summary>
        /// Test to validate veggie  snacks can be selected and order is submitted
        /// </summary>
        [TestCase]
        public void SubmitOrder_Veggie()
        {
            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            menuItems.Find("French Fries").Click();
            menuItems.Find("Veggieburger").Click();
            this.SnackAttApp.Submit();

            string message = this.SnackAttApp.GetAlertMessageAndClose();

            Assert.IsTrue(message.Contains("French Fries"), "Selected menu not available in alert message.");
            Assert.IsTrue(message.Contains("Veggieburger"), "Selected menu not available in alert message.");
        }
        /// <summary>
        /// Test to validate non-veggie snacks can be selected and order is submitted
        /// </summary>
        [TestCase]
        public void SubmitOrder_NonVeggie()
        {
            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            menuItems.Find("Hamburger").Click();
            menuItems.Find("Cheeseburger").Click();
            this.SnackAttApp.Submit();

            string message = this.SnackAttApp.GetAlertMessageAndClose();

            Assert.IsTrue(message.Contains("Hamburger"), "Selected menu not available in alert message.");
            Assert.IsTrue(message.Contains("Cheeseburger"), "Selected menu not available in alert message.");
        }
        /// <summary>
        /// Test to validate veggie and non-veggie snacks can be selected and order is submitted
        /// </summary>
        [TestCase]
        public void SubmitOrder_VeggieAndNonVeggie()
        {
            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            menuItems.Find("French Fries").Click();
            menuItems.Find("Hamburger").Click();
            this.SnackAttApp.Submit();

            string message = this.SnackAttApp.GetAlertMessageAndClose();

            Assert.IsTrue(message.Contains("French Fries"), "Selected menu not available in alert message.");
            Assert.IsTrue(message.Contains("Hamburger"), "Selected menu not available in alert message.");
        }

        #endregion
        #region Filter snack tests
        /// <summary>
        /// Test to validate if filter for veggie is working
        /// </summary>
        [TestCase]
        public void Filter_ShowOnlyVeggieOptions()
        {
            Menu veggie = this.SnackAttApp.GetMenu(Constants.VeggieCheckboxId);
            Menu nonVeggie = this.SnackAttApp.GetMenu(Constants.NonVeggieCheckboxId);

            // Remove default selection
            if (veggie.IsSelected)
                veggie.Click();

            if (nonVeggie.IsSelected)
                nonVeggie.Click();

            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            if (menuItems.TotalMenu == 0)
            {
                // Select Veggie
                veggie.Click();
                menuItems.Refresh();

                Assert.AreEqual(menuItems.TotalMenu, 6, "Veggie checkbox not select only Veggie Options.");
            }
            else
            {
                Assert.Fail("After unselect Veggie and Non-Veggie, App still showing some options.");
            }
        }
        /// <summary>
        /// Test to validate if filter for non-veggie is working
        /// </summary>
        [TestCase]
        public void Filter_ShowOnlyNonVeggieOptions()
        {
            Menu veggie = this.SnackAttApp.GetMenu(Constants.VeggieCheckboxId);
            Menu nonVeggie = this.SnackAttApp.GetMenu(Constants.NonVeggieCheckboxId);

            // Remove default selection
            if (veggie.IsSelected)
                veggie.Click();

            if (nonVeggie.IsSelected)
                nonVeggie.Click();

            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            if (menuItems.TotalMenu == 0)
            {
                // Select Non-Veggie
                nonVeggie.Click();
                menuItems.Refresh();

                Assert.AreEqual(menuItems.TotalMenu, 3, "NonVeggie checkbox do not select only NonVeggie Options.");
            }
            else
            {
                Assert.Fail("After unselect Veggie and Non-Veggie, App still showing some options.");
            }
        }
            /// <summary>
            /// Test to validate if filter for veggie and non-veggie is working
            /// </summary>
        [TestCase]
        public void Filter_ShowBothVeggieAndNonVeggieOptions()
        {
            Menu veggie = this.SnackAttApp.GetMenu(Constants.VeggieCheckboxId);
            Menu nonVeggie = this.SnackAttApp.GetMenu(Constants.NonVeggieCheckboxId);

            // Remove default selection
            if (veggie.IsSelected)
                veggie.Click();

            if (nonVeggie.IsSelected)
                nonVeggie.Click();

            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            if (menuItems.TotalMenu == 0)
            {
                // Select Veggie
                veggie.Click();
                // Select Non-Veggie
                nonVeggie.Click();
                menuItems.Refresh();

                Assert.AreEqual(menuItems.TotalMenu, 9, "Veggie and NonVeggie checkbox do not select both Options.");
            }
            else
            {
                Assert.Fail("After unselect Veggie and Non-Veggie, App still showing some options.");
            }
        }
        #endregion
        #region Add new snack
        /// <summary>
        /// Test to validate Add new Veggie menu item
        /// </summary>
        [TestCase]
        public void Add_NewVeggieItem()
        {
            string menuTitle = "Veg Sandwich";
            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            menuItems.AddNew(menuTitle,"Veggie");

            Assert.IsTrue(menuItems.Find(menuTitle) != null, $"New menu item {menuTitle} not added.");
        }

        /// <summary>
        /// Test to validate Add new NonVeggie menu item
        /// </summary>
        [TestCase]
        public void Add_NewNonVeggieItem()
        {
            string menuTitle = "Non Veg Sandwich";
            MenuItems menuItems = this.SnackAttApp.GetMenuItems(Constants.MenuItemDisplayTextId);
            menuItems.AddNew(menuTitle, "NonVeggie");

            Assert.IsTrue(menuItems.Find(menuTitle) != null, $"New menu item {menuTitle} not added.");
        }
        #endregion
    }
}
