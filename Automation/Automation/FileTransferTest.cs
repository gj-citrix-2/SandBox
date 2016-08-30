using Microsoft.VisualStudio.TestTools.UITesting;
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

namespace DesktopApp
{
    class FileTransferTest
    {
        private static void ConnectToHost()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.LoginConnectUtil.ConnectHost("Joker");

        }
        private static void DisconnectFromHost()
        {
            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void FileTransfer_Open_Close()
        {
            ConnectToHost();
            GeneralUtilities.FileTransferUtil.OpenFileTransfer();
            GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            DisconnectFromHost();
        }

        public static void FileTransfer_Verify_Upload()
        {
            ConnectToHost();
            GeneralUtilities.FileTransferUtil.OpenFileTransfer();

            WpfCustom appBarCustom = GeneralUtilities.ShareConnectControls.GetFileTransferAppBarCustom();

            Mouse.Click(appBarCustom, new Point(481, 28));
            Thread.Sleep(1000);

            // root folder that cannot have files uploaded
            WpfButton okButton = new WpfButton(GeneralUtilities.ShareConnectControls.GetFileTransferWindow());
            okButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";
            Thread.Sleep(1000);
            Mouse.Click(okButton, new Point(30, 19));

            // move to other folders, 1st level folder
            WpfCustom folderListCustom1 = new WpfCustom(GeneralUtilities.ShareConnectControls.GetFileTransferWindow());
            folderListCustom1.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.FolderListControl";
            folderListCustom1.SearchProperties[WpfControl.PropertyNames.AutomationId] = "FolderList";

            WpfTable fullListTable = new WpfTable(folderListCustom1);
            fullListTable.SearchProperties[WpfTable.PropertyNames.AutomationId] = "FullList";

            WpfControl itemDataItem1 = new WpfControl(fullListTable);
            itemDataItem1.SearchProperties[WpfControl.PropertyNames.ControlType] = "DataItem";
            itemDataItem1.SearchProperties[WpfControl.PropertyNames.Instance] = "3";

            WpfCell itemCell = new WpfCell(itemDataItem1);
            itemCell.SearchProperties[WpfCell.PropertyNames.ColumnHeader] = "FILE NAME";

            Mouse.DoubleClick(itemCell, new Point(33, 20));
            Thread.Sleep(2000);

            // 2nd level folder, **** need to clean the old controls (the way CodedUI/SC do) and start new ones as following
            GeneralUtilities.ShareConnectControls.ClearFileTransferControls();

            WpfCustom folderListCustom2 = new WpfCustom(GeneralUtilities.ShareConnectControls.GetFileTransferWindow());
            folderListCustom2.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.FolderListControl";
            folderListCustom2.SearchProperties[WpfControl.PropertyNames.AutomationId] = "FolderList";

            WpfTable fullListTable2 = new WpfTable(folderListCustom2);
            fullListTable2.SearchProperties[WpfTable.PropertyNames.AutomationId] = "FullList";

            WpfControl itemDataItem2 = new WpfControl(fullListTable2);
            itemDataItem2.SearchProperties[WpfControl.PropertyNames.ControlType] = "DataItem";
            itemDataItem2.SearchProperties[WpfControl.PropertyNames.Instance] = "3";

            WpfCell itemCell2 = new WpfCell(itemDataItem2);
            itemCell2.SearchProperties[WpfCell.PropertyNames.ColumnHeader] = "FILE NAME";

            Mouse.DoubleClick(itemCell2, new Point(38, 13));
            Thread.Sleep(2000);

            // click Upload button
            appBarCustom = GeneralUtilities.ShareConnectControls.GetFileTransferAppBarCustom();
            Mouse.Click(appBarCustom, new Point(481, 28));
            Thread.Sleep(1000);

            // make sure "Select File" window is up
            WinWindow selectFilesWindow = GeneralUtilities.ShareConnectControls.GetSelectFileWindow();
            Thread.Sleep(1000);
            Assert.IsTrue(selectFilesWindow.Exists, "Select File Window does not show up!");

            WinButton cancelButton = GeneralUtilities.ShareConnectControls.GetSelectFileCancelButton();
            Mouse.Click(cancelButton, new Point(53, 14));
            Thread.Sleep(1000);

            WpfButton homeButton = new WpfButton(GeneralUtilities.ShareConnectControls.GetFileTransferWindow());
            homeButton.SearchProperties[WpfButton.PropertyNames.Name] = "Home";
            Mouse.Click(homeButton, new Point(14, 9));

            Thread.Sleep(2000);

            GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            DisconnectFromHost();
        }



    }


}
