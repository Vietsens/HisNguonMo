﻿using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.Login.Base
{
    public abstract class BusinessBase : EntityBase
    {
        public BusinessBase()
            : base()
        {
            param = new CommonParam();
            try
            {
                UserName = ClientTokenManagerStore.ClientTokenManager.GetLoginName();
            }
            catch (Exception)
            {
            }
        }

        public BusinessBase(CommonParam paramBusiness)
            : base()
        {
            param = (paramBusiness != null ? paramBusiness : new CommonParam());
            try
            {
                UserName = ClientTokenManagerStore.ClientTokenManager.GetLoginName();
            }
            catch (Exception)
            {
            }
        }

        protected CommonParam param { get; set; }

        protected void TroubleCheck()
        {
            try
            {
                if (param.HasException || (param.BugCodes != null && param.BugCodes.Count > 0))
                {
                    MethodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    TroubleCache.Add(GetInfoProcess() + (param.HasException ? "param.HasException." : "") + param.GetBugCode());
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        protected void TroubleCheck(object data)
        {
            try
            {
                MethodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                if (param.HasException || (data == null) || (data is Boolean && (bool)data == false))
                {
                    TroubleCache.Add(GetInfoProcess() + (param.HasException ? "param.HasException." : "") + param.GetBugCode());
                    //MessageUtil.SetParamFirstPostion(param, LibraryMessage.Message.Enum.HeThongTBKQXLYCCuaFrontendThatBai);
                    Inventec.Common.Logging.LogUtil.LogActionFail(this.GetType().Name, MethodName, ClientTokenManagerStore.ClientTokenManager.GetLoginName());
                }
                else
                {
                    //MessageUtil.SetParamFirstPostion(param, LibraryMessage.Message.Enum.HeThongTBKQXLYCCuaFrontendThanhCong);
                    Inventec.Common.Logging.LogUtil.LogActionSuccess(this.GetType().Name, MethodName, ClientTokenManagerStore.ClientTokenManager.GetLoginName());
                }
                if ((param.BugCodes != null && param.BugCodes.Count > 0) || (param.Messages != null && param.Messages.Count > 0))
                {
                    Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => param), param), LogType.Info);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
