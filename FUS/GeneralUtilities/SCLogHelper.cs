using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace GeneralUtilities
{
    public class SCLogHelper
    {
        private static log4net.ILog m_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SCLogHelper()
        {
            m_logger = log4net.LogManager.GetLogger("");
        }

        public SCLogHelper(System.Reflection.MethodBase methbase)
        {
            m_logger = log4net.LogManager.GetLogger(methbase.DeclaringType);
        }

        public log4net.ILog Logger
        {
             get { return m_logger; }
        } 
    }
}
