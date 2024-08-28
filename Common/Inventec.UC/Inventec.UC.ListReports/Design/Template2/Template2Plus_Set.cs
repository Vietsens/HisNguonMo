﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.ListReports.Design.Template2
{
    internal partial class Template2
    {
        internal bool SetDelegateHasException(ProcessHasException hasException)
        {
            bool result = false;
            try
            {
                this._HasException = hasException;
                if (this._HasException != null)
                {
                    result = true;
                }
                else
                {
                    Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => hasException), hasException));
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        internal void ShortcutButtonSearchClick()
        {
            try
            {
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        internal void ShortcutButtonRefreshClick()
        {
            try
            {
                btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
