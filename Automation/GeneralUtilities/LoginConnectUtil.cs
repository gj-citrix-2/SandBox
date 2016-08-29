using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                userEmail = ConstantsUtil.defaultUserEmail;
            }
            if (userPwd == "")
            {
                userPwd = ConstantsUtil.defaultUserPwd;
            }

            Logger.log.Debug(" === LoginDA uses user email : " + userEmail.ToString());
            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
            shareConnectWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            // *** no need this WpfPane, there no ambiguity to find shareConnectWindow under it
            //WpfPane loginFramePane = new WpfPane(shareConnectWindow);
            //loginFramePane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
            //loginFramePane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "LoginFrame";

            WpfPane browserPane = new WpfPane(shareConnectWindow);
            browserPane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.HwndHost";
            browserPane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "Browser";

            WinClient itemClient = new WinClient(browserPane);
            itemClient.SearchProperties[WinControl.PropertyNames.ClassName] = "Internet Explorer_Server";

            HtmlDocument shareFileLoginDocument = new HtmlDocument(itemClient);
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.Title] = "ShareFile Login";
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/oauth/authorize";
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "https://secure.sharefiletest.com/oauth/authorize?response_type=code&client_id=RrB" +
                "QuHuM12dWToUvOHaEpNK3OTgmxGgd&redirect_uri=https:%2F%2Fi1app.sc.test.expertcity." +
                "com%2Fmembers%2FsocialLogin.tmpl%3FauthProvider%3DshareFile&state=&theme=airtop";

            HtmlEdit credentialsemailEdit = new HtmlEdit(shareFileLoginDocument);
            credentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-email";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput username input-item";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"1\" class=\"txtinput username in";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";

            HtmlEdit credentialspasswordEdit = new HtmlEdit(shareFileLoginDocument);
            credentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-password";
            credentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput password input-item";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"2\" class=\"txtinput password in";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";

            HtmlDiv applicationHostPane = new HtmlDiv(shareFileLoginDocument);
            applicationHostPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "applicationHost";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Sign In using your ShareFile account\r\n\r\n";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"applicationHost\"";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "15";

            HtmlButton signInButton = new HtmlButton(applicationHostPane);
            signInButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In  ";
            signInButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
            signInButton.FilterProperties[HtmlButton.PropertyNames.Class] = "navlink fwdlink";
            signInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "class=\"navlink fwdlink\" type=\"submit\" da";
            signInButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "1";


            // Type 'abc@gmail.com' in 'credentials-email' text box
            credentialsemailEdit.Text = userEmail;

            // Type '********' in 'credentials-password' text box
            credentialspasswordEdit.Text = userPwd;

            // Click 'Sign In' button
            Mouse.Click(signInButton, new Point(218, 21));
            Thread.Sleep(10000);

            Logger.log.Info("******  End LoginDA() ********");
        }

        public static void LoginDA_Faileure(string userEmail = "", string userPwd = "")
        {
            Logger.log.Info("******  Start LoginDA_Faileure() ********");

            if (userEmail == "")
            {
                userEmail = ConstantsUtil.defaultUserEmail;
            }
            if (userPwd == "")
            {
                userPwd = ConstantsUtil.defaultUserPwd;
            }

            Logger.log.Debug(" === LoginDA_Faileure uses user email : " + userEmail.ToString());
            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
            shareConnectWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            WpfPane browserPane = new WpfPane(shareConnectWindow);
            browserPane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.HwndHost";
            browserPane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "Browser";

            WinClient itemClient = new WinClient(browserPane);
            itemClient.SearchProperties[WinControl.PropertyNames.ClassName] = "Internet Explorer_Server";

            HtmlDocument shareFileLoginDocument = new HtmlDocument(itemClient);
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.Title] = "ShareFile Login";
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/oauth/authorize";
            shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "https://secure.sharefiletest.com/oauth/authorize?response_type=code&client_id=RrB" +
                "QuHuM12dWToUvOHaEpNK3OTgmxGgd&redirect_uri=https:%2F%2Fi1app.sc.test.expertcity." +
                "com%2Fmembers%2FsocialLogin.tmpl%3FauthProvider%3DshareFile&state=&theme=airtop";

            HtmlEdit credentialsemailEdit = new HtmlEdit(shareFileLoginDocument);
            credentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-email";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput username input-item";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"1\" class=\"txtinput username in";
            credentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";

            HtmlEdit credentialspasswordEdit = new HtmlEdit(shareFileLoginDocument);
            credentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-password";
            credentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput password input-item";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"2\" class=\"txtinput password in";
            credentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";

            HtmlDiv applicationHostPane = new HtmlDiv(shareFileLoginDocument);
            applicationHostPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "applicationHost";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Sign In using your ShareFile account\r\n\r\n";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"applicationHost\"";
            applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "15";

            HtmlDiv usernameorPasswordwaPane = new HtmlDiv(applicationHostPane);
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "error";
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"error\" data-bind=\"html: ErrorMessage\"";
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "22";

            HtmlButton signInButton = new HtmlButton(applicationHostPane);
            signInButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In  ";
            signInButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
            signInButton.FilterProperties[HtmlButton.PropertyNames.Class] = "navlink fwdlink";
            signInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "class=\"navlink fwdlink\" type=\"submit\" da";
            signInButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "1";


            // Type email in 'credentials-email' text box
            credentialsemailEdit.Text = userEmail;

            // Type pwd in 'credentials-password' text box
            credentialspasswordEdit.Text = userPwd;

            // Click 'Sign In' button
            Mouse.Click(signInButton, new Point(218, 21));
            Thread.Sleep(5000);

            Assert.AreEqual("Username or Password was incorrect.", usernameorPasswordwaPane.InnerText, "!!!! INCORRERCT ERROR MESSAGE !!!");

            Logger.log.Info("******  End LoginDA_Faileure() ********");
        }

        public static void LogoutDA()
        {
            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom bladeViewControlCustom = new WpfCustom(shareConnectWindow);
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";

            WpfImage settings_buttonImage = new WpfImage(bladeViewControlCustom);
            settings_buttonImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "Settings_button";

            Mouse.Click(settings_buttonImage, new Point(6, 6));
            Thread.Sleep(3000);

            WpfCustom settingBladeCustom = new WpfCustom(shareConnectWindow);
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";

            WpfCustom aboutBladeCustom = new WpfCustom(settingBladeCustom);
            aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AboutBlade";
            aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AboutBlade";

            Mouse.Click(aboutBladeCustom, new Point(45, 330));
            Thread.Sleep(3000);

            // Click 'Yes' button
            WpfButton yesButton = new WpfButton(shareConnectWindow);
            yesButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";

            Mouse.Click(yesButton, new Point(35, 21));
            Thread.Sleep(8000);
        }

        public static void CloseDA()
        {
            // Click 'Close' button
            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfButton closeButton = new WpfButton(shareConnectWindow);
            closeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Close";

            Mouse.Click(closeButton, new Point(35, 21));
        }

        public static void ConnectHost(string userName = "", string hostPwd = "")
        {
            Logger.log.Info("******  Start ConnectHost() ********");

            if (userName == "")
            {
                userName = ConstantsUtil.defaultHostName;
            }
            if (hostPwd == "")
            {
                hostPwd = ConstantsUtil.defaultHostPwd;
            }
            Logger.log.Debug("    ===  Connect to Host uses user name : " + userName + "  === ");

            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom settingBladeCustom = new WpfCustom(shareConnectWindow);
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

        public static void CancelConnectHost()
        {
            Logger.log.Info("******  Start CancelConnectHost() ********");

            string userName = ConstantsUtil.defaultHostName;

            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom settingBladeCustom = new WpfCustom(shareConnectWindow);
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));
            Thread.Sleep(8000);

 
            Keyboard.SendKeys(userName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys("{TAB}"); // jump to "Login" or to "Cancel" if no input of credentials
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(3000);

            // xxxx need to check bladeview is up again
            //x = settingBladeCustom.WaitForControlEnabled();

            Logger.log.Info("******  End ConnectHost() ********");
        }

        public static void DisconnectHost()
        {
            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";

            WpfCustom bladeViewControlCustom = new WpfCustom(shareConnectWindow);
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";

            Mouse.Click(bladeViewControlCustom, new Point(1869, 18));
        }
    }
}
