﻿using Inventec.Core;
using Inventec.UC.ListReports.MessageLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.ListReports.Sar.SarReportStt
{
    class SarReportSttGet : Inventec.UC.ListReports.Base.GetBase
    {
        internal SarReportSttGet()
            : base()
        {

        }

        internal SarReportSttGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<SAR.EFMODEL.DataModels.SAR_REPORT_STT> Get(SAR.Filter.SarReportSttFilter searchMVC)
        {
            List<SAR.EFMODEL.DataModels.SAR_REPORT_STT> result = null;
            try
            {
                var ro = Base.ApiConsumerStore.SarConsumer.Get<Inventec.Core.ApiResultObject<List<SAR.EFMODEL.DataModels.SAR_REPORT_STT>>>("/api/SarReportStt/Get", param, searchMVC);
                if (ro != null)
                {
                    param = ro.Param != null ? ro.Param : param;
                    result = ro.Data;
                }
            }
            catch (Inventec.Common.WebApiClient.ApiException ex)
            {
                Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => ex.StatusCode), ex.StatusCode);
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    param.Messages.Add(Base.MessageUtil.GetMessage(Message.Enum.PhanMemKhongKetNoiDuocToiMayChuHeThong));
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    param.HasException = true;
                    param.Messages.Add(Base.MessageUtil.GetMessage(Message.Enum.HeThongTBNguoiDungDaHetPhienLamViecVuiLongDangNhapLai));
                }
                else if (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    param.Messages.Add(Base.MessageUtil.GetMessage(Message.Enum.HeThongTBBanQuyenKhongHopLe));
                }
            }
            catch (AggregateException ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.Messages.Add(Base.MessageUtil.GetMessage(Message.Enum.PhanMemKhongKetNoiDuocToiMayChuHeThong));
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
    }
}
