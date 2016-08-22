using Microsoft.VisualStudio.TestTools.UITesting;
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
    public class LaunchLogin
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

        private static string userEmail = "gjwin10@grr.la";
        private static string userPwd = "Test1234";

        public static void LaunchDA()
        {
            // Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
            ApplicationUnderTest uIShareConnectWindow = ApplicationUnderTest.Launch(uIShareConnectWindowExePath, uIShareConnectWindowAlternateExePath);

            LoginDA();
            ConnectHost();
            Thread.Sleep(1000);
            DisconnectHost();
            Thread.Sleep(5000);
            LogoutDA();
        }

        public static void LoginDA()
        {
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
        }

        public static void ConnectHost()
        {
            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom settingBladeCustom = new WpfCustom(scwin);
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";

            Mouse.Click(settingBladeCustom, new Point(44, 114));
            Thread.Sleep(5000);

            Keyboard.SendKeys("Tester");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys("Test1234");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to "Login", to "Cancel" if no input of credentials
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(10000);

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

            // Click 'Close' button
            scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfButton closeButton = new WpfButton(scwin);
            closeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Close";

            Mouse.Click(closeButton, new Point(35, 21));

        }
    }
}
