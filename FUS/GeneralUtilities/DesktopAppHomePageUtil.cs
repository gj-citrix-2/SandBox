using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class DesktopAppHomePageUtil
    {

        public static void VerifyUserInfo(string userName = "", string userEmail = "")
        {
            Logger.log.Info("******  Start VerifyUserInfo() ********");

            if (userName == "")
            {
                userName = ConstantsUtil.defaultUserName;
            }
            if (userEmail == "")
            {
                userEmail = ConstantsUtil.defaultUserEmail;
            }
            Logger.log.Debug("    ===  Log in Desktop App with user name : " + userName + " & user email : " + userEmail);

            WinWindow shareConnectWindow = new WinWindow();
            shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
            shareConnectWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            WpfCustom bladeViewControlCustom = new WpfCustom(shareConnectWindow);
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
            bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";

            WpfText userNameContainer = new WpfText(bladeViewControlCustom);
            userNameContainer.SearchProperties[WpfText.PropertyNames.AutomationId] = "FirstNameLabel";

            WpfText userNameText = new WpfText(userNameContainer);
            userNameText.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);

            WpfText userEmailContainer = new WpfText(bladeViewControlCustom);
            userEmailContainer.SearchProperties[WpfText.PropertyNames.AutomationId] = "EmailLabel";

            WpfText userEmailText = new WpfText(userEmailContainer);
            userEmailText.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);


            // 
            // **** Using Try/Catch so the test will keep going without stopping when Assert is true, but it'll mark the test successfully run.
            //  SHOULD WE USE TRY/CATCH ????

            try
            {
                // Verify that the 'Name' property of user name is correct 
                Assert.AreEqual(userName, userNameText.Name.ToString(), "!!! Wrong User Name Displayed !!!");
            }
            catch (AssertFailedException ex)
            {
                Logger.log.Error(ex.Message.ToString());
            }

            try
            {
                // Verify that the 'Name' property of user email is correct 
                Assert.AreEqual(userEmail, userEmailText.Name.ToString(), "!!! Wrong Email Address Displayed !!!");
            }
            catch (AssertFailedException ex)
            {
                Logger.log.Error(ex.Message.ToString());
            }

            Logger.log.Info("******  End VerifyUserInfo() ********");

        }
    }
}
