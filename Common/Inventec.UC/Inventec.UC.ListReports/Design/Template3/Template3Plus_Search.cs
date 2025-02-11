﻿using DevExpress.Utils;
using Inventec.Core;
using Inventec.Desktop.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventec.UC.ListReports.Design.Template3
{
    internal partial class Template3
    {
        private void txtSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //ButtonSearchAndPagingClick(true);
                    SetInitPaging();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SetInitPaging();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                SetDefaultControl();
                //ButtonSearchAndPagingClick(true);
                SetInitPaging();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void ButtonSearchAndPagingClick(bool flag)
        {
            try
            {
                CommonParam param;
                WaitingManager.Show();
                //if (flag)
                //{
                //    param = new CommonParam(0, Convert.ToInt32(txtPageSize.Text));
                //}
                //else
                //{
                //    param = new CommonParam(pagingGrid.RecNo, Convert.ToInt32(txtPageSize.Text));
                //}
                SAR.Filter.SarReportViewFilter filter = new SAR.Filter.SarReportViewFilter();
                try
                {
                    if (dtTimeForm.EditValue != null && dtTimeForm.DateTime != DateTime.MinValue)
                    {
                        filter.CREATE_TIME_FROM = Inventec.Common.TypeConvert.Parse.ToInt64(Convert.ToDateTime(dtTimeForm.EditValue).ToString("yyyyMMdd") + "000000");
                    }
                    if (dtTimeTo.EditValue != null && dtTimeTo.DateTime != DateTime.MinValue)
                    {
                        filter.CREATE_TIME_TO = Inventec.Common.TypeConvert.Parse.ToInt64(Convert.ToDateTime(dtTimeTo.EditValue).ToString("yyyyMMdd") + "235959");
                    }
                    //if (checkNoProcess.Checked)
                    //{
                    //    if (filter.REPORT_STT_IDs == null) filter.REPORT_STT_IDs = new List<long>();
                    //    filter.REPORT_STT_IDs.Add(Config.SarReportSttCFG.REPORT_STT_ID__WAIT);
                    //}
                    //if (checkProcessing.Checked)
                    //{
                    //    if (filter.REPORT_STT_IDs == null) filter.REPORT_STT_IDs = new List<long>();
                    //    filter.REPORT_STT_IDs.Add(Config.SarReportSttCFG.REPORT_STT_ID__PROCESSING);
                    //}
                    //if (checkFinish.Checked)
                    //{
                    //    if (filter.REPORT_STT_IDs == null) filter.REPORT_STT_IDs = new List<long>();
                    //    filter.REPORT_STT_IDs.Add(Config.SarReportSttCFG.REPORT_STT_ID__DONE);
                    //}
                    //if (checkCancel.Checked)
                    //{
                    //    if (filter.REPORT_STT_IDs == null) filter.REPORT_STT_IDs = new List<long>();
                    //    filter.REPORT_STT_IDs.Add(Config.SarReportSttCFG.REPORT_STT_ID__CANCEL);
                    //}
                    //if (checkError.Checked)
                    //{
                    //    if (filter.REPORT_STT_IDs == null) filter.REPORT_STT_IDs = new List<long>();
                    //    filter.REPORT_STT_IDs.Add(Config.SarReportSttCFG.REPORT_STT_ID__ERROR);
                    //}
                    filter.KEY_WORD = txtSearch.Text.Trim();
                    var Data = new Sar.SarReport.Get.SarReportGet().GetView(filter);
                    if (Data != null)
                    {
                        rowCount = Data.Param.Count ?? 0;
                        ListReport.Clear();
                        if (Data.Data != null) ListReport = (List<SAR.EFMODEL.DataModels.V_SAR_REPORT>)Data.Data;
                        var recordData = (ListReport == null ? 0 : ListReport.Count);
                        //if (flag)
                        //{
                        //    pagingGrid.Innitial(lblDisplayPageNo, txtPageSize, txtCurrentPage, lblTotalPage, btnLastPage, btnPreviousPage, btnFirstPage, btnNextPage, rowCount, recordData);
                        //}
                    }
                    gridViewListReports.BeginUpdate();
                    gridViewListReports.GridControl.DataSource = ListReport;
                    gridViewListReports.EndUpdate();
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                #region Process Has Exception
                //if (_HasException != null) _HasException(param);
                #endregion
                WaitingManager.Hide();
            }
            catch (Exception ex)
            {
                WaitingManager.Hide();
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
