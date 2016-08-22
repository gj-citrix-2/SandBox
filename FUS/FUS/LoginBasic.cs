using Microsoft.VisualStudio.TestTools.UITesting;
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

        public static void Host_Connect_Disconnect_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.LoginConnectUtil.ConnectHost();
            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }
    }
}
