﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 14.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace FUS
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Threading;
    
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// LoginTest - Use 'LoginTestParams' to pass parameters into this method.
        /// </summary>
        public void LoginTest()
        {
            #region Variable Declarations
            HtmlEdit uICredentialsemailEdit = this.UIShareConnectWindow.UILoginFramePane.UIBrowserPane.UIItemClient.UIShareFileLoginDocument.UICredentialsemailEdit;
            HtmlEdit uICredentialspasswordEdit = this.UIShareConnectWindow.UILoginFramePane.UIBrowserPane.UIItemClient.UIShareFileLoginDocument.UICredentialspasswordEdit;
            WpfCustom uISettingBladeCustom = this.UIShareConnectWindow1.UIBladeViewControlCustom.UISettingBladeCustom;
            WpfComboBox uIUserListComboBox = this.UIShareConnectWindow.UIMainTabControlTabList.UIWin7awsTabPage.UIWinformHostPane.UIItemClient.UIWpfWindow.UIItemCustom.UIUserListComboBox;
            WpfEdit uIPART_EditableTextBoxEdit = this.UIShareConnectWindow.UIMainTabControlTabList.UIWin7awsTabPage.UIWinformHostPane.UIItemClient.UIWpfWindow.UIItemCustom.UIUserListComboBox.UIPART_EditableTextBoxEdit;
            WpfEdit uIPasswordFieldEdit = this.UIShareConnectWindow.UIMainTabControlTabList.UIWin7awsTabPage.UIWinformHostPane.UIItemClient.UIWpfWindow.UIItemCustom.UIPasswordFieldEdit;
            WpfButton uILogInButton = this.UIShareConnectWindow.UIMainTabControlTabList.UIWin7awsTabPage.UIWinformHostPane.UIItemClient.UIWpfWindow.UIItemCustom.UILogInButton;
            WpfCustom uIBladeViewControlCustom = this.UIShareConnectWindow1.UIBladeViewControlCustom;
            WpfImage uISettings_buttonImage = this.UIShareConnectWindow1.UIBladeViewControlCustom.UISettings_buttonImage;
            WpfCustom uIAboutBladeCustom = this.UIShareConnectWindow1.UIBladeViewControlCustom.UISettingBladeCustom.UIAboutBladeCustom;
            WpfButton uIYesButton = this.UIShareConnectWindow1.UIYesButton;
            WinButton uICloseButton = this.UIShareConnectWindow.UICloseButton;
            #endregion

            // Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
            ApplicationUnderTest uIShareConnectWindow = ApplicationUnderTest.Launch(this.LoginTestParams.UIShareConnectWindowExePath, this.LoginTestParams.UIShareConnectWindowAlternateExePath);
            Thread.Sleep(5000);

            // Type 'gjwin7@grr.la' in 'credentials-email' text box
            uICredentialsemailEdit.Text = this.LoginTestParams.UICredentialsemailEditText;

            // Type '********' in 'credentials-password' text box
            uICredentialspasswordEdit.Password = this.LoginTestParams.UICredentialspasswordEditPassword;

            // Type '{Enter}' in 'credentials-password' text box
            Keyboard.SendKeys(uICredentialspasswordEdit, this.LoginTestParams.UICredentialspasswordEditSendKeys, ModifierKeys.None);
            Thread.Sleep(8000);

            // Click 'SettingBlade' custom control
            Mouse.Click(uISettingBladeCustom, new Point(44, 114));
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

            // Click 'BladeViewControl' custom control
            Mouse.Click(uIBladeViewControlCustom, new Point(1869, 18));
            Thread.Sleep(3000);

            // Click 'Settings_button' image
            Mouse.Click(uISettings_buttonImage, new Point(6, 6));
            Thread.Sleep(3000);

            // Click 'AboutBlade' custom control
            Mouse.Click(uIAboutBladeCustom, new Point(45, 330));
            Thread.Sleep(3000);

            // Click 'Yes' button
            Mouse.Click(uIYesButton, new Point(35, 21));
            Thread.Sleep(5000);

            // Click 'Close' button
            Mouse.Click(uICloseButton, new Point(31, 11));
        }
        
        #region Properties
        public virtual LoginTestParams LoginTestParams
        {
            get
            {
                if ((this.mLoginTestParams == null))
                {
                    this.mLoginTestParams = new LoginTestParams();
                }
                return this.mLoginTestParams;
            }
        }
        
        public UIShareConnectWindow UIShareConnectWindow
        {
            get
            {
                if ((this.mUIShareConnectWindow == null))
                {
                    this.mUIShareConnectWindow = new UIShareConnectWindow();
                }
                return this.mUIShareConnectWindow;
            }
        }
        
        public UIShareConnectWindow1 UIShareConnectWindow1
        {
            get
            {
                if ((this.mUIShareConnectWindow1 == null))
                {
                    this.mUIShareConnectWindow1 = new UIShareConnectWindow1();
                }
                return this.mUIShareConnectWindow1;
            }
        }
        #endregion
        
        #region Fields
        private LoginTestParams mLoginTestParams;
        
        private UIShareConnectWindow mUIShareConnectWindow;
        
        private UIShareConnectWindow1 mUIShareConnectWindow1;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'LoginTest'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class LoginTestParams
    {
        
        #region Fields
        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        public string UIShareConnectWindowExePath = "C:\\Users\\gwojiehw\\AppData\\Local\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client" +
            ".WindowsDesktop.exe";
        
        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        public string UIShareConnectWindowAlternateExePath = "%LOCALAPPDATA%\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client.WindowsDesktop.e" +
            "xe";
        
        /// <summary>
        /// Type 'gjwin7@grr.la' in 'credentials-email' text box
        /// </summary>
        public string UICredentialsemailEditText = "gjwin7@grr.la";
        
        /// <summary>
        /// Type '********' in 'credentials-password' text box
        /// </summary>
        public string UICredentialspasswordEditPassword = "96J0eqvFTZJykx+WfrWsYTgmknNMbXWD";
        
        /// <summary>
        /// Type '{Enter}' in 'credentials-password' text box
        /// </summary>
        public string UICredentialspasswordEditSendKeys = "{Enter}";
        
        /// <summary>
        /// Select 'citrite.net\gwojiehw' in 'UserList' combo box
        /// </summary>
        public string UIUserListComboBoxEditableItem = "citrite.net\\gwojiehw";
        
        /// <summary>
        /// Type '{Tab}' in 'PART_EditableTextBox' text box
        /// </summary>
        public string UIPART_EditableTextBoxEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type '********' in 'PasswordField' text box
        /// </summary>
        public string UIPasswordFieldEditSendKeys = "rr48yllHRLAfQzKZ8UWM/PCgrJxoADYj";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIShareConnectWindow : WinWindow
    {
        
        public UIShareConnectWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UILoginFramePane UILoginFramePane
        {
            get
            {
                if ((this.mUILoginFramePane == null))
                {
                    this.mUILoginFramePane = new UILoginFramePane(this);
                }
                return this.mUILoginFramePane;
            }
        }
        
        public UIMainTabControlTabList UIMainTabControlTabList
        {
            get
            {
                if ((this.mUIMainTabControlTabList == null))
                {
                    this.mUIMainTabControlTabList = new UIMainTabControlTabList(this);
                }
                return this.mUIMainTabControlTabList;
            }
        }
        
        public WinButton UICloseButton
        {
            get
            {
                if ((this.mUICloseButton == null))
                {
                    this.mUICloseButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
                    this.mUICloseButton.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUICloseButton;
            }
        }
        #endregion
        
        #region Fields
        private UILoginFramePane mUILoginFramePane;
        
        private UIMainTabControlTabList mUIMainTabControlTabList;
        
        private WinButton mUICloseButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UILoginFramePane : WpfPane
    {
        
        public UILoginFramePane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "LoginFrame";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIBrowserPane UIBrowserPane
        {
            get
            {
                if ((this.mUIBrowserPane == null))
                {
                    this.mUIBrowserPane = new UIBrowserPane(this);
                }
                return this.mUIBrowserPane;
            }
        }
        #endregion
        
        #region Fields
        private UIBrowserPane mUIBrowserPane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIBrowserPane : WpfPane
    {
        
        public UIBrowserPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.HwndHost";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "Browser";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIItemClient UIItemClient
        {
            get
            {
                if ((this.mUIItemClient == null))
                {
                    this.mUIItemClient = new UIItemClient(this);
                }
                return this.mUIItemClient;
            }
        }
        #endregion
        
        #region Fields
        private UIItemClient mUIItemClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemClient : WinClient
    {
        
        public UIItemClient(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinControl.PropertyNames.ClassName] = "Internet Explorer_Server";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIShareFileLoginDocument UIShareFileLoginDocument
        {
            get
            {
                if ((this.mUIShareFileLoginDocument == null))
                {
                    this.mUIShareFileLoginDocument = new UIShareFileLoginDocument(this);
                }
                return this.mUIShareFileLoginDocument;
            }
        }
        #endregion
        
        #region Fields
        private UIShareFileLoginDocument mUIShareFileLoginDocument;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIShareFileLoginDocument : HtmlDocument
    {
        
        public UIShareFileLoginDocument(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "ShareFile Login";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/oauth/authorize";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "https://secure.sharefiletest.com/oauth/authorize?response_type=code&client_id=RrB" +
                "QuHuM12dWToUvOHaEpNK3OTgmxGgd&redirect_uri=https:%2F%2Fi1app.sc.test.expertcity." +
                "com%2Fmembers%2FsocialLogin.tmpl%3FauthProvider%3DshareFile&state=&theme=airtop";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public HtmlEdit UICredentialsemailEdit
        {
            get
            {
                if ((this.mUICredentialsemailEdit == null))
                {
                    this.mUICredentialsemailEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUICredentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-email";
                    this.mUICredentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = null;
                    this.mUICredentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUICredentialsemailEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUICredentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUICredentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput username input-item";
                    this.mUICredentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"1\" class=\"txtinput username in";
                    this.mUICredentialsemailEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
                    this.mUICredentialsemailEdit.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUICredentialsemailEdit;
            }
        }
        
        public HtmlEdit UICredentialspasswordEdit
        {
            get
            {
                if ((this.mUICredentialspasswordEdit == null))
                {
                    this.mUICredentialspasswordEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUICredentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-password";
                    this.mUICredentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = null;
                    this.mUICredentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUICredentialspasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
                    this.mUICredentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUICredentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput password input-item";
                    this.mUICredentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"2\" class=\"txtinput password in";
                    this.mUICredentialspasswordEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";
                    this.mUICredentialspasswordEdit.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUICredentialspasswordEdit;
            }
        }
        #endregion
        
        #region Fields
        private HtmlEdit mUICredentialsemailEdit;
        
        private HtmlEdit mUICredentialspasswordEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIMainTabControlTabList : WpfTabList
    {
        
        public UIMainTabControlTabList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "MainTabControl";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIWin7awsTabPage UIWin7awsTabPage
        {
            get
            {
                if ((this.mUIWin7awsTabPage == null))
                {
                    this.mUIWin7awsTabPage = new UIWin7awsTabPage(this);
                }
                return this.mUIWin7awsTabPage;
            }
        }
        #endregion
        
        #region Fields
        private UIWin7awsTabPage mUIWin7awsTabPage;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIWin7awsTabPage : WpfTabPage
    {
        
        public UIWin7awsTabPage(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabPage.PropertyNames.Name] = "win7 aws";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIWinformHostPane UIWinformHostPane
        {
            get
            {
                if ((this.mUIWinformHostPane == null))
                {
                    this.mUIWinformHostPane = new UIWinformHostPane(this);
                }
                return this.mUIWinformHostPane;
            }
        }
        #endregion
        
        #region Fields
        private UIWinformHostPane mUIWinformHostPane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIWinformHostPane : WpfPane
    {
        
        public UIWinformHostPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.WindowsFormsHost";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "WinformHost";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIItemClient1 UIItemClient
        {
            get
            {
                if ((this.mUIItemClient == null))
                {
                    this.mUIItemClient = new UIItemClient1(this);
                }
                return this.mUIItemClient;
            }
        }
        #endregion
        
        #region Fields
        private UIItemClient1 mUIItemClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemClient1 : WinClient
    {
        
        public UIItemClient1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIWpfWindow UIWpfWindow
        {
            get
            {
                if ((this.mUIWpfWindow == null))
                {
                    this.mUIWpfWindow = new UIWpfWindow(this);
                }
                return this.mUIWpfWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIWpfWindow mUIWpfWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIWpfWindow : WpfWindow
    {
        
        public UIWpfWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Login to your server";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIItemCustom UIItemCustom
        {
            get
            {
                if ((this.mUIItemCustom == null))
                {
                    this.mUIItemCustom = new UIItemCustom(this);
                }
                return this.mUIItemCustom;
            }
        }
        #endregion
        
        #region Fields
        private UIItemCustom mUIItemCustom;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemCustom : WpfCustom
    {
        
        public UIItemCustom(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ComputerLoginControl";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIUserListComboBox UIUserListComboBox
        {
            get
            {
                if ((this.mUIUserListComboBox == null))
                {
                    this.mUIUserListComboBox = new UIUserListComboBox(this);
                }
                return this.mUIUserListComboBox;
            }
        }
        
        public WpfEdit UIPasswordFieldEdit
        {
            get
            {
                if ((this.mUIPasswordFieldEdit == null))
                {
                    this.mUIPasswordFieldEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUIPasswordFieldEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "PasswordField";
                    this.mUIPasswordFieldEdit.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUIPasswordFieldEdit;
            }
        }
        
        public WpfButton UILogInButton
        {
            get
            {
                if ((this.mUILogInButton == null))
                {
                    this.mUILogInButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUILogInButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "LoginButton";
                    this.mUILogInButton.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUILogInButton;
            }
        }
        #endregion
        
        #region Fields
        private UIUserListComboBox mUIUserListComboBox;
        
        private WpfEdit mUIPasswordFieldEdit;
        
        private WpfButton mUILogInButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIUserListComboBox : WpfComboBox
    {
        
        public UIUserListComboBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "UserList";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public WpfEdit UIPART_EditableTextBoxEdit
        {
            get
            {
                if ((this.mUIPART_EditableTextBoxEdit == null))
                {
                    this.mUIPART_EditableTextBoxEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUIPART_EditableTextBoxEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "PART_EditableTextBox";
                    this.mUIPART_EditableTextBoxEdit.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUIPART_EditableTextBoxEdit;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUIPART_EditableTextBoxEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIShareConnectWindow1 : WpfWindow
    {
        
        public UIShareConnectWindow1()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "ShareConnect";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UIBladeViewControlCustom UIBladeViewControlCustom
        {
            get
            {
                if ((this.mUIBladeViewControlCustom == null))
                {
                    this.mUIBladeViewControlCustom = new UIBladeViewControlCustom(this);
                }
                return this.mUIBladeViewControlCustom;
            }
        }
        
        public WpfButton UIYesButton
        {
            get
            {
                if ((this.mUIYesButton == null))
                {
                    this.mUIYesButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIYesButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";
                    this.mUIYesButton.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUIYesButton;
            }
        }
        #endregion
        
        #region Fields
        private UIBladeViewControlCustom mUIBladeViewControlCustom;
        
        private WpfButton mUIYesButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIBladeViewControlCustom : WpfCustom
    {
        
        public UIBladeViewControlCustom(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public UISettingBladeCustom UISettingBladeCustom
        {
            get
            {
                if ((this.mUISettingBladeCustom == null))
                {
                    this.mUISettingBladeCustom = new UISettingBladeCustom(this);
                }
                return this.mUISettingBladeCustom;
            }
        }
        
        public WpfImage UISettings_buttonImage
        {
            get
            {
                if ((this.mUISettings_buttonImage == null))
                {
                    this.mUISettings_buttonImage = new WpfImage(this);
                    #region Search Criteria
                    this.mUISettings_buttonImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "Settings_button";
                    this.mUISettings_buttonImage.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUISettings_buttonImage;
            }
        }
        #endregion
        
        #region Fields
        private UISettingBladeCustom mUISettingBladeCustom;
        
        private WpfImage mUISettings_buttonImage;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UISettingBladeCustom : WpfCustom
    {
        
        public UISettingBladeCustom(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";
            this.WindowTitles.Add("ShareConnect");
            #endregion
        }
        
        #region Properties
        public WpfCustom UIAboutBladeCustom
        {
            get
            {
                if ((this.mUIAboutBladeCustom == null))
                {
                    this.mUIAboutBladeCustom = new WpfCustom(this);
                    #region Search Criteria
                    this.mUIAboutBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AboutBlade";
                    this.mUIAboutBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AboutBlade";
                    this.mUIAboutBladeCustom.WindowTitles.Add("ShareConnect");
                    #endregion
                }
                return this.mUIAboutBladeCustom;
            }
        }
        #endregion
        
        #region Fields
        private WpfCustom mUIAboutBladeCustom;
        #endregion
    }
}
