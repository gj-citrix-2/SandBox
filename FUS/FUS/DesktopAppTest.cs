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
using System.Reflection;

namespace DesktopApp
{
    public static class Logger
    {
        public static log4net.ILog log = SCLogHelper.Logger(System.Reflection.MethodBase.GetCurrentMethod());
    }

    /// <summary>
    /// Summary description for DesktopAppTest
    /// </summary>
    [CodedUITest]
    public class DesktopAppTest
    {
        public DesktopAppTest()
        {
        }

        [TestMethod]
        public void DesktopLoginLogout()
        {
            Logger.log.Info("=======================  Start DesktopLoginLogout() =======================");

            LoginBasic.DA_Login_Logout_Test();

            Logger.log.Info("=======================  End DesktopLoginLogout() =======================");
        }

        [TestMethod]
        public void DesktopLoginError()
        {
            LoginBasic.DA_Login_Error_Test();
        }

        [TestMethod]
        public void DesktopVerifyUserInfo()
        {
            LoginBasic.DA_Verify_User_Info();
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
            Logger.log.Info("=======================  Start SS_FastUserSwitch() =======================");

            GeneralUtilities.LoginConnectUtil.ConnectHost();

            Mouse.Click();  // take me out when whole sequence is executed

            for (int i = 0; i < 1; i++)
            {
                // Logger.log.Info("  === LOOP # " + i + "  ===");
                FastUserSwitch.RunFUS(i);
            }

            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            Logger.log.Info("=======================  End SS_FastUserSwitch() =======================");
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
        [TestCleanup()]
        public void MyTestCleanup()
        {
            var m_message = String.Empty; 
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                const BindingFlags getterFlags = System.Reflection.BindingFlags.GetField |
                                                 System.Reflection.BindingFlags.GetProperty |
                                                 System.Reflection.BindingFlags.NonPublic |
                                                 System.Reflection.BindingFlags.Instance |
                                                 System.Reflection.BindingFlags.FlattenHierarchy;

                // Get hold of TestContext.m_currentResult.m_errorInfo.m_stackTrace (contains the stack trace details from log)
                var field = TestContext.GetType().GetField("m_currentResult", getterFlags);
                var m_currentResult = field.GetValue(TestContext);
                Logger.log.Error("*****  Running Results: " + m_currentResult.ToString());
                field = m_currentResult.GetType().GetField("m_errorInfo", getterFlags);
                var m_errorInfo = field.GetValue(m_currentResult);
                field = m_errorInfo.GetType().GetField("m_message", getterFlags);
                m_message = field.GetValue(m_errorInfo) as string;
                Logger.log.Error("                        " + m_message.ToString());
                field = m_errorInfo.GetType().GetField("m_stackTrace", getterFlags);
                m_message = field.GetValue(m_errorInfo) as string;
                Logger.log.Error("                        Stack Trace : ");
                Logger.log.Error("                                    " + m_message.ToString());
            }
            else
            {
                Logger.log.Info("Running Results: " + TestContext.CurrentTestOutcome.ToString());
            }
        }

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
