using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// SnackAttApp class to handle all operations
    /// </summary>
    public class SnackAttApp
    {
        private DriverHelper driverHelper;

        /// <summary>
        /// Create instance of class SnackAttApp
        /// </summary>
        public SnackAttApp()
        {
        }

        /// <summary>
        /// Start snackAttApp in android device
        /// </summary>
        public void StartApplication()
        {
            driverHelper = new DriverHelper();

            driverHelper.LaunchApplication();
        }

        /// <summary>
        /// Stop application.
        /// </summary>
        public void StopApplication()
        {
            if (this.driverHelper.Driver != null)
            {
                this.driverHelper.Driver.CloseApp();
                this.driverHelper.Driver.Quit();
            }
        }

        /// <summary>
        /// Gets menu (Veggie, Non Veggie)
        /// </summary>
        /// <param name="menuId">menu id to locate.</param>
        /// <returns></returns>
        public Menu GetMenu(string menuId)
        {
            return new Menu(this.driverHelper, menuId);
        }

        /// <summary>
        /// Gets menu items available under menu
        /// </summary>
        /// <param name="id">item id to locate</param>
        /// <returns></returns>
        public MenuItems GetMenuItems(string id)
        {
            return new MenuItems(this.driverHelper, id);
        }

        /// <summary>
        /// App submit operation.
        /// </summary>
        public void Submit()
        {
            AndroidElement submitButon = this.driverHelper.Driver.FindElement(Constants.SubmitButtonId);
            Validate(submitButon, Constants.SubmitButtonId);
            submitButon.Click();
        }

        /// <summary>
        /// Gets app alert message and close alert.
        /// </summary>
        /// <returns>The alert message</returns>
        public string GetAlertMessageAndClose()
        {
            AndroidElement alertMessage = this.driverHelper.Driver.FindElement(Constants.AlertMessageId);
            Validate(alertMessage, Constants.AlertMessageId);
            string message = alertMessage.Text;

            AndroidElement alertOkButton = this.driverHelper.Driver.FindElement(Constants.AlertMessageOkButtonId);
            Validate(alertOkButton, Constants.AlertMessageOkButtonId);
            alertOkButton.Click();

            return message;
        }

        /// <summary>
        /// Validate element and throw error, if element not available.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="id">The id of element</param>
        private void Validate(AndroidElement element, string id)
        {
            if (element == null)
                throw new SnackAttAppFrameworkException($"No element find by id: {id}");
        }
    }
}
