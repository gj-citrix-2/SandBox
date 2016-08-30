using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class ShareConnectControls
    {
        // Desktop App window
        private static WinWindow _shareConnectWindow = null;
        private static WpfPane _loginFramePane = null;
        private static WpfPane _browserPanel = null;
        private static WinClient _itemClient = null;
        private static HtmlDocument _shareFileLoginDocument = null;
        private static HtmlEdit _credentialsEmailEdit = null;
        private static HtmlEdit _credentialsPasswordEdit = null;
        private static HtmlDiv _applicationHostPane = null;
        private static HtmlButton _signInButton = null;

        private static WpfCustom _bladeViewControlCustom = null;
        private static WpfImage _settings_buttonImage = null;
        private static WpfCustom _settingBladeCustom = null;
        private static WpfCustom _aboutBladeCustom = null;
        private static WpfButton _confirmSignOutYesButton = null;

        private static WpfButton _closeButton = null;

        // Screen Sharing File Transfer window
        private static WinWindow _fileTransferWindow = null;
        private static WinButton _fileTransferCloseButton = null;
        private static WpfPane _fileTransferContentFramePane = null;
        private static WpfCustom _fileTransferContentAppBarCustom = null;
        private static WinWindow _selectFileWindow = null;
        private static WinWindow _selectFileCancelWindow = null;
        private static WinButton _selectFileCancelButton = null;


        /*
         * 
         *  Desktop App windows
         *
         */

        public static WinWindow GetShareConnectWindow()
        {
            if (_shareConnectWindow == null)
            {
                _shareConnectWindow = new WinWindow();
                _shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
                _shareConnectWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            }
            return _shareConnectWindow;
        }

        public static WpfPane GetLoginFramePane()
        {
            if (_loginFramePane == null)
            {
                _loginFramePane = new WpfPane(GetShareConnectWindow());
                _loginFramePane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
                _loginFramePane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "LoginFrame";

            }
            return _loginFramePane;
        }

        public static WpfPane GetBrowserPanel()
        {
            if (_browserPanel == null)
            {
                _browserPanel = new WpfPane(GetLoginFramePane());
                _browserPanel.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.HwndHost";
                _browserPanel.SearchProperties[WpfPane.PropertyNames.AutomationId] = "Browser";
            }
            return _browserPanel;
        }

        public static WinClient GetItemClient()
        {
            if (_itemClient == null)
            {
                _itemClient = new WinClient(GetBrowserPanel());
                _itemClient.SearchProperties[WinControl.PropertyNames.ClassName] = "Internet Explorer_Server";
            }
            return _itemClient;
        }

        public static HtmlDocument GetShareFileLoginDocument()
        {
            if (_shareFileLoginDocument == null)
            {
                _shareFileLoginDocument = new HtmlDocument(GetItemClient());
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.Title] = "ShareFile Login";
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/oauth/authorize";
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "https://secure.sharefiletest.com/oauth/authorize?response_type=code&client_id=RrB" +
                    "QuHuM12dWToUvOHaEpNK3OTgmxGgd&redirect_uri=https:%2F%2Fi1app.sc.test.expertcity." +
                    "com%2Fmembers%2FsocialLogin.tmpl%3FauthProvider%3DshareFile&state=&theme=airtop";
            }
            return _shareFileLoginDocument;
        }

        public static HtmlEdit GetCredentialsEmailEdit()
        {
            if (_credentialsEmailEdit == null)
            {
                _credentialsEmailEdit = new HtmlEdit(GetShareFileLoginDocument());
                _credentialsEmailEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-email";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput username input-item";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"1\" class=\"txtinput username in";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
            }
            return _credentialsEmailEdit;
        }

        public static HtmlEdit GetCredentialsPasswordEdit()
        {
            if (_credentialsPasswordEdit == null)
            {
                _credentialsPasswordEdit = new HtmlEdit(GetShareFileLoginDocument());
                _credentialsPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-password";
                _credentialsPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput password input-item";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"2\" class=\"txtinput password in";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";
            }
            return _credentialsPasswordEdit;
        }

        public static HtmlDiv GetApplicationHostPane()
        {
            if (_applicationHostPane == null)
            {
                _applicationHostPane = new HtmlDiv(GetShareFileLoginDocument());
                _applicationHostPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "applicationHost";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Sign In using your ShareFile account\r\n\r\n";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"applicationHost\"";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "15";

            }
            return _applicationHostPane;
        }

        public static HtmlButton GetSignInButton()
        {
            if (_signInButton == null)
            {
                _signInButton = new HtmlButton(GetApplicationHostPane());
                _signInButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In  ";
                _signInButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.Class] = "navlink fwdlink";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "class=\"navlink fwdlink\" type=\"submit\" da";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "1";

            }
            return _signInButton;
        }

        public static WpfButton GetDesktopAppCloseButtonX()
        {
            if (_closeButton == null)
            {
                _closeButton = new WpfButton(GetShareConnectWindow());
                _closeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Close";
            }
            return _closeButton;
        }

        public static WpfCustom GetBladeViewControlCustom()
        {
            if (_bladeViewControlCustom == null)
            {
                _bladeViewControlCustom = new WpfCustom(GetShareConnectWindow());
                _bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
                _bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";
            }
            return _bladeViewControlCustom;
        }

        public static WpfImage GetSettings_buttonImage()
        {
            if (_settings_buttonImage == null)
            {
                _settings_buttonImage = new WpfImage(GetBladeViewControlCustom());
                _settings_buttonImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "Settings_button";
            }
            return _settings_buttonImage;
        }

        public static WpfCustom GetSettingBladeCustom()
        {
            if (_settingBladeCustom == null)
            {
                _settingBladeCustom = new WpfCustom(GetShareConnectWindow());
                _settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
                _settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";
            }
            return _settingBladeCustom;
        }

        public static WpfCustom GetAboutBladeCustom()
        {
            if (_aboutBladeCustom == null)
            {
                _aboutBladeCustom = new WpfCustom(GetSettingBladeCustom());
                _aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AboutBlade";
                _aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AboutBlade";

            }
            return _aboutBladeCustom;
        }

        public static WpfButton GetConfirmSignOutYesButton()
        {
            if (_confirmSignOutYesButton == null)
            {
                _confirmSignOutYesButton = new WpfButton(GetShareConnectWindow());
                _confirmSignOutYesButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";

            }
            return _confirmSignOutYesButton;
        }


        /*
         * 
         *  File Transfer windows
         *
         */

        public static WinWindow GetFileTransferWindow()
        {
            if (_fileTransferWindow == null)
            {
                _fileTransferWindow = new WinWindow();
                _fileTransferWindow.SearchProperties[WinWindow.PropertyNames.Name] = "win10 aws - File Transfer";
                _fileTransferWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            }
            return _fileTransferWindow;
        }

        public static WinButton GetFileTransferCloseButton()
        {
            if (_fileTransferCloseButton == null)
            {
                _fileTransferCloseButton = new WinButton(GetFileTransferWindow());
                _fileTransferCloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
            }
            return _fileTransferCloseButton;
        }

        public static WpfPane GetFileTransferContentFramePane()
        {
            if (_fileTransferContentFramePane == null)
            {
                _fileTransferContentFramePane = new WpfPane(GetFileTransferWindow());
                _fileTransferContentFramePane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
                _fileTransferContentFramePane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "ContentFrame";
            }
            return _fileTransferContentFramePane;
        }

        public static WpfCustom GetFileTransferAppBarCustom()
        {
            if (_fileTransferContentAppBarCustom == null)
            {
                _fileTransferContentAppBarCustom = new WpfCustom(GetFileTransferContentFramePane());
                _fileTransferContentAppBarCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AppBar";
                _fileTransferContentAppBarCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AppBar";
            }
            return _fileTransferContentAppBarCustom;
        }

        public static void ClearFileTransferControls()
        {
            _fileTransferContentAppBarCustom = null;
            _fileTransferContentFramePane = null;
            _fileTransferCloseButton = null;
            _fileTransferWindow = null;
        }

        public static WinWindow GetSelectFileWindow()
        {
            if (_selectFileWindow == null)
            {
                _selectFileWindow = new WinWindow();
                _selectFileWindow.SearchProperties[WinWindow.PropertyNames.Name] = "Select Files";
                _selectFileWindow.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            }
            return _selectFileWindow;
        }

        public static WinWindow GetSelectFileCancelWindow()
        {
            if (_selectFileCancelWindow == null)
            {
                _selectFileCancelWindow = new WinWindow(GetSelectFileWindow());
                _selectFileCancelWindow.SearchProperties[WinWindow.PropertyNames.ControlId] = "2";
            }
            return _selectFileCancelWindow;
        }

        public static WinButton GetSelectFileCancelButton()
        {
            if (_selectFileCancelButton == null)
            {
                _selectFileCancelButton = new WinButton(GetSelectFileCancelWindow());
                _selectFileCancelButton.SearchProperties[WinButton.PropertyNames.Name] = "Cancel";
            }
            return _selectFileCancelButton;
        }


    }
}
