using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Threading;
using System.Drawing;

namespace DesktopApp
{
    class FastUserSwitch
    {
        private static string[] userNameAry = { "RDULGWOJIEHW02\\Tester", "RDULGWOJIEHW02\\Joker", "RDULGWOJIEHW02\\Joker", "RDULGWOJIEHW02\\Tester", "RDULGWOJIEHW02\\Tester" };
        private static string pwd = "Test1234";

        public static void RunFUS(int loopCnt)
        {
            Logger.log.Info("******  Start RunFUS() with loopCnt = " + loopCnt + "  ********");

            GeneralUtilities.FunctionalButtonsUtil.ClickCtrlAltDelButton();

            // click Switch User
            // Mouse.Location = new Point(908, 560);  // sign out
            Mouse.Location = new Point(908, 480);   // switch user
            Thread.Sleep(1000);
            Mouse.Click(new Point(908, 480));

            Thread.Sleep(60000);
            Mouse.Click();   // ??? need this
            Thread.Sleep(3000);

            // logon notice
            Mouse.Location = new Point(700, 740);  
            Thread.Sleep(1000);
            Mouse.Click(new Point(700, 740));

            // Login credentials
            int idx = loopCnt % userNameAry.Length;
            string uName = userNameAry[idx];
            Logger.log.Info("    ===  Connect to Host uses user name : " + uName + "  === ");

            Thread.Sleep(5000);
            Keyboard.SendKeys(uName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys(pwd);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(3000);

            //following is non-sense for this particulkar win10 laptop
            Keyboard.SendKeys("{TAB}");
            Keyboard.SendKeys("{TAB}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");

            // wait for 20 seconds, should log back in again 
            Thread.Sleep(30000);

            GeneralUtilities.FunctionalButtonsUtil.OpenFileTransfer();
            Thread.Sleep(5000);
            GeneralUtilities.FunctionalButtonsUtil.CloseFileTransfer();
            Thread.Sleep(1000);

            Logger.log.Info("******  End RunFUS() ********");

        }
    }
}
