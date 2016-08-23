using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using GeneralUtilities;
using System.Threading;

namespace DesktopApp
{
    /// <summary>
    /// Summary description for DesktopAppTest
    /// </summary>
    [CodedUITest]
    public class DesktopAppTest
    {
        private static log4net.ILog log;

        public DesktopAppTest()
        {
            SCLogHelper myLog = new SCLogHelper(System.Reflection.MethodBase.GetCurrentMethod());
            log = myLog.Logger;
        }

        [TestMethod]
        public void DesktopLoginLogout()
        {
            LoginBasic.DA_Login_Logout_Test();
        }

        [TestMethod]
        public void HostConnectDisconnect()
        {
            LoginBasic.Host_Connect_Disconnect_Test();
        }

        [TestMethod]
        public void SS_FunctionalButtons()
        {
            Mouse.Click();  // take me out when whole sequence is executed
            FunctionButtonsBasic.Click_FileTransfer_Button();

            FunctionButtonsBasic.Click_FullScreen_Button();
            FunctionButtonsBasic.Click_ExitFullScreen_Button();
        }

        [TestMethod]
        public void SS_FastUserSwitch()
        {
            log.Info("******  Start SS_FastUserSwitch() ********");

            //GeneralUtilities.LoginConnectUtil.ConnectHost();

            Mouse.Click();  // take me out when whole sequence is executed
            FastUserSwitch.RunFUS();

            log.Info("******  End SS_FastUserSwitch() ********");
        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
