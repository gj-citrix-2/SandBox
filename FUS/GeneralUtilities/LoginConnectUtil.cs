﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public static class Logger
    {
        public static log4net.ILog log = SCLogHelper.Logger(System.Reflection.MethodBase.GetCurrentMethod());
    }

    public class LoginConnectUtil
    {
        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        private static string uIShareConnectWindowExePath = "C:\\Users\\gwojiehw\\AppData\\Local\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client" +
            ".WindowsDesktop.exe";

        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        private static string uIShareConnectWindowAlternateExePath = "%LOCALAPPDATA%\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client.WindowsDesktop.e" +
            "xe";

        private static string defaultUserEmail = "gjwin10@grr.la";
        private static string defaultUserPwd = "Test1234";

        private static string defaultHostName = "Tester";
        private static string defaultHostPwd = "Test1234";

        public static void LaunchDA()
        {
            Logger.log.Info("******  Start LaunchDA() ********");
            
            // Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
            ApplicationUnderTest uIShareConnectWindow = ApplicationUnderTest.Launch(uIShareConnectWindowExePath, uIShareConnectWindowAlternateExePath);

            Logger.log.Info("******  Start LaunchDA() ********");
        }

        public static void LoginDA(string userEmail = "", string userPwd = "")
        {
            Logger.log.Info("******  Start LoginDA() ********");

            if (userEmail == "")
            {
                userEmail = defaultUserEmail;
            }
            if (userPwd == "")
            {
                userPwd = defaultUserPwd;
            }
            Logger.log.Debug(" === LoginDA uses user email : " + userEmail.ToString());

            Keyboard.SendKeys("{TAB}"); // jump to email
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}");
            Thread.Sleep(1000);
            Keyboard.SendKeys(userEmail);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys(userPwd);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(10000);

            Logger.log.Info("******  End LoginDA() ********");
        }

        public static void LogoutDA()
        {
            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom bladeViewControlCustom = new WpfCustom(scwin);
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";

            WpfImage settings_buttonImage = new WpfImage(bladeViewControlCustom);
            settings_buttonImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "Settings_button";

            Mouse.Click(settings_buttonImage, new Point(6, 6));
            Thread.Sleep(3000);

            WpfCustom settingBladeCustom = new WpfCustom(scwin);
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";

            WpfCustom aboutBladeCustom = new WpfCustom(settingBladeCustom);
            aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AboutBlade";
            aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AboutBlade";

            Mouse.Click(aboutBladeCustom, new Point(45, 330));
            Thread.Sleep(3000);

            // Click 'Yes' button
            WpfButton yesButton = new WpfButton(scwin);
            yesButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";

            Mouse.Click(yesButton, new Point(35, 21));
            Thread.Sleep(5000);

//          CloseDA();
        }

        public static void CloseDA()
        {
            // Click 'Close' button
            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfButton closeButton = new WpfButton(scwin);
            closeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Close";

            Mouse.Click(closeButton, new Point(35, 21));
        }

        public static void ConnectHost(string userName = "", string hostPwd = "")
        {
            Logger.log.Info("******  Start ConnectHost() ********");

            if (userName == "")
            {
                userName = defaultHostName;
            }
            if (hostPwd == "")
            {
                hostPwd = defaultHostPwd;
            }
            Logger.log.Debug("    ===  Connect to Host uses user name : " + userName + "  === ");

            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom settingBladeCustom = new WpfCustom(scwin);
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));
            Thread.Sleep(8000);

            Keyboard.SendKeys(userName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys(hostPwd);
            Thread.Sleep(1000);
            //Keyboard.SendKeys("{TAB}"); // jump to "Login", to "Cancel" if no input of credentials
            //Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(20000);

            Mouse.Click(); // ??? need this
            Thread.Sleep(1000);

            Logger.log.Info("******  End ConnectHost() ********");
        }

        public static void DisconnectHost()
        {
            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom bladeViewControlCustom = new WpfCustom(scwin);
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";

            Mouse.Click(bladeViewControlCustom, new Point(1869, 18));
        }
    }
}
