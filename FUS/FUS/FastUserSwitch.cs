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
        public static void RunFUS()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickCtrlAltDelButton();

            // click Switch User
            Mouse.Location = new Point(908, 560);  // sign out
            Thread.Sleep(1000);
            Mouse.Click(new Point(908, 560));
            Thread.Sleep(3000);

            Thread.Sleep(20000);
            Mouse.Click();
            Thread.Sleep(3000);

            // logon notice
            Mouse.Location = new Point(700, 740);  
            Thread.Sleep(1000);
            Mouse.Click(new Point(700, 740));

            // Login credentials
            Thread.Sleep(5000);
            Keyboard.SendKeys("RDULGWOJIEHW02\\Tester");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys("Test1234");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(5000);

            //following is non-sense for this particulkar laptop
            Keyboard.SendKeys("{TAB}");
            Keyboard.SendKeys("{TAB}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");

            // wait for 20 seconds, should log back in again 
            //Thread.Sleep(20000);

        }
    }
}
