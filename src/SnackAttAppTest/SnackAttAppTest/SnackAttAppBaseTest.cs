using NUnit.Framework;
using SnackAttAppTestFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackAttAppTest
{
    public class SnackAttAppBaseTest
    {
        private SnackAttApp snackAttApp;

        public SnackAttApp SnackAttApp
        {
            get
            {
                return this.snackAttApp;
            }
        }

        [SetUp]
        public void TestInitialize()
        {
            snackAttApp = new SnackAttApp();
            snackAttApp.StartApplication();
        }

        [TearDown]
        public void TestCleanup()
        {
            snackAttApp.StopApplication();
        }
    }
}
