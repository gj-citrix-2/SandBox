﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopApp
{
    class LoginBasic
    {
        public static void DA_Login_Logout_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();    // will use defaults if no arg provided.
            // GeneralUtilities.LoginConnectUtil.LoginDA("gjwin7@grr.la"); 
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void DA_Login_Error_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA_Faileure("gjwin7@grr.la", "1111");
            GeneralUtilities.LoginConnectUtil.LoginDA_Faileure("abc@grr.la", "2222");
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void DA_Verify_User_Info()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.DesktopAppHomePageUtil.VerifyUserInfo("gjwin10 wang", "gjwin10@grr.la");
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void Host_Connect_Disconnect_Test()
        {
            //GeneralUtilities.LoginConnectUtil.LaunchDA();
            //GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.LoginConnectUtil.CancelConnectHost();
            //GeneralUtilities.LoginConnectUtil.ConnectHost();
            //GeneralUtilities.LoginConnectUtil.DisconnectHost();
            //GeneralUtilities.LoginConnectUtil.LogoutDA();
            //GeneralUtilities.LoginConnectUtil.CloseDA();
        }
    }
}
