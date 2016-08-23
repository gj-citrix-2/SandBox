using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class FunctionalButtonsUtil
    {
        private static log4net.ILog log;

        public FunctionalButtonsUtil()
        {
            SCLogHelper myLog = new SCLogHelper(System.Reflection.MethodBase.GetCurrentMethod());
            log = myLog.Logger;
        }

        public static void OpenFileTransfer()
        {
            log.Info("******  Start OpenFileTransfer() ********");

            Mouse.Location = new Point(1500, 100);  // file transfer
            Thread.Sleep(1000);
            Mouse.Click(new Point(1500, 100));
            Thread.Sleep(3000);

            log.Info("******  End OpenFileTransfer() ********");
        }

        public static void CloseFileTransfer()
        {
            WinWindow scwin = new WinWindow();
            scwin.SearchProperties[WinWindow.PropertyNames.Name] = "win10 aws - File Transfer";
            scwin.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            WinButton closeButton = new WinButton(scwin);
            closeButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
			
			Mouse.Click(closeButton, new Point(19, 11));
            Thread.Sleep(1000);
        }

        public static void ClickFullScreenButton()
        {
            Mouse.Location = new Point(1550, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1550, 100));
            Thread.Sleep(1000);
        }

        public static void ClickExitFullScreenButton()
        {
            Mouse.Location = new Point(1550, 30);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1550, 30)); 
            Thread.Sleep(1000);
        }

        public static void ClickZoomOutButton()
        {
            Mouse.Location = new Point(1600, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1600, 100));
            Thread.Sleep(1000);
        }

        public static void ClickZoomInButton()
        {
            Mouse.Location = new Point(1670, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1670, 100));
            Thread.Sleep(1000);
        }

        public static void ClickSizeToFitButton()
        {
            Mouse.Location = new Point(1730, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1730, 100));
            Thread.Sleep(1000);
        }

        public static void ClickCtrlAltDelButton()
        {
            Mouse.Location = new Point(1785, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1785, 100));
            Thread.Sleep(1000);
        }
    }
}
