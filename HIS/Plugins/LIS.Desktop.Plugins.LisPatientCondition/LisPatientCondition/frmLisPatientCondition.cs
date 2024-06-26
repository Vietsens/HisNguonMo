/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventec.Desktop.Common.Modules;
using Inventec.UC.Paging;
using Inventec.Common.Logging;

using HIS.Desktop.LocalStorage.LocalData;
using Inventec.Desktop.Common.Message;
using Inventec.Core;
using Inventec.Common.Adapter;
using HIS.Desktop.ApiConsumer;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using HIS.Desktop.LocalStorage.BackendData;
using LIS.EFMODEL.DataModels;
using LIS.Filter;

namespace LIS.Desktop.Plugins.LisPatientCondition
{
    public partial class frmLisPatientCondition : HIS.Desktop.Utility.FormBase
    {
        #region ---Decalre
        PagingGrid pagingGrid;
        Module moduleData;
        int ActionType = -1;
        int startPage = 0;
        int dataTotal = 0;
        int rowCount = 0;
        LIS_PATIENT_CONDITION CurrentData;

        #endregion
        public frmLisPatientCondition()
        {
            InitializeComponent();
        }
        public frmLisPatientCondition(Module module)
            : base(module)
        {
            try
            {
                InitializeComponent();

                pagingGrid = new PagingGrid();
                this.moduleData = module;
                try
                {
                    string iconPath = System.IO.Path.Combine(HIS.Desktop.LocalStorage.Location.ApplicationStoreLocation.ApplicationStartupPath, System.Configuration.ConfigurationSettings.AppSettings["Inventec.Desktop.Icon"]);
                    this.Icon = Icon.ExtractAssociatedIcon(iconPath);

                }
                catch (Exception ex)
                {
                    LogSystem.Warn(ex);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void frmHisAccidentBodyPart_Load(object sender, EventArgs e)
        {
            try
            {
                SetDefautData();
                EnableControlChanged(this.ActionType);
                SetCaptionByLanguageKey();
                FillDataToGridControl();
                ValidateText(txtLisPatientConditionCode, 10);
                ValidateText(txtLisPatientConditionName, 100);
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #region ---Set data
        private void SetDefautData()
        {
            try
            {
                this.ActionType = GlobalVariables.ActionAdd;
                txtLisPatientConditionCode.Text = "";
                txtLisPatientConditionName.Text = "";
                txtSearch.Text = "";
                txtSearch.Focus();
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void EnableControlChanged(int actiontype)
        {
            try
            {
                btnAdd.Enabled = (actiontype == GlobalVariables.ActionAdd);
                btnEdit.Enabled = (actiontype == GlobalVariables.ActionEdit);

            }
            catch (Exception ex)
            {

                LogAction.Warn(ex);
            }
        }

        private void SetCaptionByLanguageKey()
        {
            try
            {
                if (this.moduleData != null && !String.IsNullOrEmpty(this.moduleData.text))
                {
                    this.Text = moduleData.text;
                }
            }
            catch (Exception ex)
            {

                LogAction.Warn(ex);
            }
        }

        private void ChangeDataRow(LIS_PATIENT_CONDITION datarow)
        {
            try
            {
                if (datarow != null)
                {
                    FillDataEditorControl(datarow);
                    this.ActionType = GlobalVariables.ActionEdit;
                    EnableControlChanged(this.ActionType);
                    if (datarow != null)
                    {
                        btnEdit.Enabled = (datarow.IS_ACTIVE == 1);
                    }

                    Inventec.Desktop.Controls.ControlWorker.ValidationProviderRemoveControlError(dxValidationProvider1, dxErrorProvider1);

                }

            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void FillDataEditorControl(LIS_PATIENT_CONDITION datarow)
        {
            try
            {
                
                txtLisPatientConditionCode.Text = datarow.PATIENT_CONDITION_CODE;
                txtLisPatientConditionName.Text = datarow.PATIENT_CONDITION_NAME;
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void UpdateDataFromform(LIS_PATIENT_CONDITION updateDTO)
        {
            try
            {
                updateDTO.PATIENT_CONDITION_CODE = txtLisPatientConditionCode.Text.Trim();
                updateDTO.PATIENT_CONDITION_NAME = txtLisPatientConditionName.Text.Trim();
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void RestFromData()
        {
            try
            {
                if (!lcEditorInfo.IsInitialized)
                    return;
                lcEditorInfo.BeginUpdate();
                try
                {
                    foreach (DevExpress.XtraLayout.BaseLayoutItem item in lcEditorInfo.Items)
                    {
                        DevExpress.XtraLayout.LayoutControlItem lci = item as DevExpress.XtraLayout.LayoutControlItem;
                        if (lci != null && lci.Control != null && lci.Control is DevExpress.XtraEditors.BaseEdit)
                        {
                            DevExpress.XtraEditors.BaseEdit fomatFrm = lci.Control as DevExpress.XtraEditors.BaseEdit;
                            fomatFrm.ResetText();
                            fomatFrm.EditValue = null;
                            txtLisPatientConditionCode.Focus();
                            txtLisPatientConditionCode.SelectAll();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Warn(ex);
                }
                finally
                {
                    lcEditorInfo.EndUpdate();
                }
            }
            catch (Exception ex)
            {

                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }


        private void ValidateText(DevExpress.XtraEditors.TextEdit textcontrol, int maxlangth)
        {
            try
            {
                ValidateMaxLength vali = new ValidateMaxLength();
                vali.txtEdit = textcontrol;
                vali.Maxlength = maxlangth;
                vali.ErrorText = HIS.Desktop.LibraryMessage.MessageUtil.GetMessage(HIS.Desktop.LibraryMessage.Message.Enum.TruongDuLieuBatBuoc);
                vali.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
                dxValidationProvider1.SetValidationRule(textcontrol, vali);
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void SaveProcessor()
        {
            try
            {
                bool success = false;
                if (!btnAdd.Enabled && !btnEdit.Enabled)
                    return;
                if (!dxValidationProvider1.Validate())
                    return;
                WaitingManager.Show();
                CommonParam param = new CommonParam();
                LIS_PATIENT_CONDITION UpdateDTO = new LIS_PATIENT_CONDITION();
                UpdateDataFromform(UpdateDTO);
                if (this.ActionType == GlobalVariables.ActionAdd)
                {
                    var ResultData = new BackendAdapter(param).Post<LIS_PATIENT_CONDITION>(HisRequestUriStore.LisPatientCondition_Create, ApiConsumers.LisConsumer, UpdateDTO, param);
                    if (ResultData != null)
                    {
                        BackendDataWorker.Reset<LIS_PATIENT_CONDITION>();
                        FillDataToGridControl();
                        success = true;
                        RestFromData();
                    }
                }
                else
                {
                    if (CurrentData != null)
                    {
                        UpdateDTO.ID = CurrentData.ID;
                        var ResultData = new BackendAdapter(param).Post<LIS_PATIENT_CONDITION>(HisRequestUriStore.LisPatientCondition_Update, ApiConsumers.LisConsumer, UpdateDTO, param);
                        if (ResultData != null)
                        {
                            BackendDataWorker.Reset<LIS_PATIENT_CONDITION>();
                            FillDataToGridControl();
                            success = true;

                        }
                    }
                }
                WaitingManager.Hide();
                MessageManager.Show(this.ParentForm, param, success);
                HIS.Desktop.Controls.Session.SessionManager.ProcessTokenLost(param);
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
                WaitingManager.Hide();
            }
        }

        #region ---Load data to gridcontrol
        private void FillDataToGridControl()
        {
            try
            {
                WaitingManager.Show();
                int pagingSize = 0;
                if (ucPaging2.pagingGrid != null)
                {
                    pagingSize = ucPaging2.pagingGrid.PageSize;
                }
                else
                {
                    pagingSize = HIS.Desktop.LocalStorage.ConfigApplication.ConfigApplicationWorker.Get<int>("CONFIG_KEY__NUM_PAGESIZE");
                }
                LoadPaging(new CommonParam(0, pagingSize));
                CommonParam param = new CommonParam();
                param.Limit = rowCount;
                param.Count = dataTotal;
                ucPaging2.Init(LoadPaging, param, pagingSize, this.gridControlHisVaccineType);
                WaitingManager.Hide();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                WaitingManager.Hide();
            }
        }

        private void LoadPaging(object commonParam)
        {
            try
            {
                startPage = ((CommonParam)commonParam).Start ?? 0;
                int limit = ((CommonParam)commonParam).Limit ?? 0;
                CommonParam paramcommon = new CommonParam(startPage, limit);
                ApiResultObject<List<LIS_PATIENT_CONDITION>> apiResult = null;
                LisPatientConditionFilter filter = new LisPatientConditionFilter();
                filter.ORDER_DIRECTION = "DESC";
                filter.ORDER_FIELD = "MODIFY_TIME";
               // SetFilter(ref filter);
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    filter.ORDER_DIRECTION = "DESC";
                    filter.ORDER_FIELD = "MODIFY_TIME";
                    filter.KEY_WORD = txtSearch.Text.Trim();
                }
                gridControlHisVaccineType.DataSource = null;
                gridViewHisVaccineType.BeginUpdate();
                apiResult = new BackendAdapter(paramcommon).GetRO<List<LIS_PATIENT_CONDITION>>(HisRequestUriStore.LisPatientCondition_Get, ApiConsumers.LisConsumer, filter, paramcommon);
                Inventec.Common.Logging.LogSystem.Debug(Inventec.Common.Logging.LogUtil.TraceData("apiResult--------------------" + Inventec.Common.Logging.LogUtil.GetMemberName(() => apiResult), apiResult));
                if (apiResult != null)
                {
                    var data = (List<LIS_PATIENT_CONDITION>)apiResult.Data;
                    if (data != null && data.Count > 0)
                    {
                        gridControlHisVaccineType.DataSource = data;
                        rowCount = (data == null ? 0 : data.Count);
                        dataTotal = (apiResult.Param == null ? 0 : apiResult.Param.Count ?? 0);
                    }

                }

                gridViewHisVaccineType.EndUpdate();
                #region Process has exception
                HIS.Desktop.Controls.Session.SessionManager.ProcessTokenLost(paramcommon);
                #endregion

            }
            catch (Exception ex)
            {

                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        private void SetFilter(ref LisPatientConditionFilter filter)
        {
            try
            {
                filter.ORDER_DIRECTION = "DESC";
                filter.ORDER_FIELD = "MODIFY_TIME";
                filter.KEY_WORD = txtSearch.Text.Trim();
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        #endregion

        private void gridViewAccidentBodyPart_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle >= 0)
                {
                    var data = (LIS_PATIENT_CONDITION)gridViewHisVaccineType.GetRow(e.RowHandle);
                    if (e.Column.FieldName == "IS_ACTIVE_STR")
                    {
                        if (data.IS_ACTIVE == 0)
                            e.Appearance.ForeColor = Color.Red;
                        else
                            e.Appearance.ForeColor = Color.Green;
                    }
                }

            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #endregion
        #region ---Even gridControl
        private void gridViewAccidentBodyPart_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData && e.Column.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                {
                    LIS_PATIENT_CONDITION DataRow = (LIS_PATIENT_CONDITION)((IList)((BaseView)sender).DataSource)[e.ListSourceRowIndex];
                    if (DataRow != null)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        if (e.Column.FieldName == "STT")
                        {
                            e.Value = e.ListSourceRowIndex + 1 + startPage;
                        }
                        else if (e.Column.FieldName == "CREATE_TIME_STR")
                        {
                            e.Value = Inventec.Common.DateTime.Convert.TimeNumberToTimeString(DataRow.CREATE_TIME ?? 0);
                        }
                        else if (e.Column.FieldName == "MODIFY_TIME_STR")
                        {
                            e.Value = Inventec.Common.DateTime.Convert.TimeNumberToTimeString(DataRow.MODIFY_TIME ?? 0);
                        }
                        else if (e.Column.FieldName == "IS_ACTIVE_STR")
                        {
                            e.Value = (DataRow.IS_ACTIVE == 1 ? "Hoạt động" : "Tạm khóa");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void gridViewAccidentBodyPart_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle >= 0)
                {
                    var dataRow = (LIS_PATIENT_CONDITION)((IList)((BaseView)sender).DataSource)[e.RowHandle];
                    if (dataRow != null)
                    {
                        if (e.Column.FieldName == "DELETE")
                        {
                            e.RepositoryItem = (dataRow.IS_ACTIVE == 0 ? btnEnableDelete : btnDelete);
                        }
                        if (e.Column.FieldName == "LOCK")
                        {
                            e.RepositoryItem = (dataRow.IS_ACTIVE == 0 ? btnUnLock : btnLock);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void gridViewAccidentBodyPart_Click(object sender, EventArgs e)
        {
            try
            {
                var datarow = (LIS_PATIENT_CONDITION)gridViewHisVaccineType.GetFocusedRow();
                if (datarow != null)
                {
                    this.CurrentData = datarow;
                    ChangeDataRow(datarow);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #endregion
        #region ---Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProcessor();
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProcessor();
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActionType = GlobalVariables.ActionAdd;
                EnableControlChanged(this.ActionType);
                RestFromData();
                Inventec.Desktop.Controls.ControlWorker.ValidationProviderRemoveControlError(dxValidationProvider1, dxErrorProvider1);

            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataToGridControl();
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #region ---ItemClick
        private void bbtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.ActionType == GlobalVariables.ActionEdit && btnEdit.Enabled)
                {
                    btnEdit_Click(null, null);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void bbtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.ActionType == GlobalVariables.ActionAdd && btnAdd.Enabled)
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void bbtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void bbtnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnCancel_Click(null, null);
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #endregion

        #endregion
        #region ---PreviewKeyDown
        private void txtAccidentBodyPartCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLisPatientConditionName.Focus();
                    txtLisPatientConditionName.SelectAll();
                }
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }

        private void txtAccidentBodyPartName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void txtSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FillDataToGridControl();
                }
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }
        #endregion
        #region ButtonClick
        private void btnLock_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CommonParam param = new CommonParam();
                var rowData = (LIS_PATIENT_CONDITION)gridViewHisVaccineType.GetFocusedRow();
                bool success = false;
                if (MessageBox.Show(HIS.Desktop.LibraryMessage.MessageUtil.GetMessage(HIS.Desktop.LibraryMessage.Message.Enum.HeThongTBCuaSoThongBaoBanCoMuonKhoaDuLieuKhong), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (rowData != null)
                    {
                        LIS_PATIENT_CONDITION Result = new BackendAdapter(param).Post<LIS_PATIENT_CONDITION>(HisRequestUriStore.LisPatientCondition_Changelock, ApiConsumers.LisConsumer, rowData, param);
                        if (Result!=null)
                        {
                            success = true;
                            FillDataToGridControl();
                            btnEdit.Enabled = false;
                        }
                    }
                    MessageManager.Show(this, param, success);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void btnUnLock_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CommonParam param = new CommonParam();
                var rowData = (LIS_PATIENT_CONDITION)gridViewHisVaccineType.GetFocusedRow();
                bool success = false;
                if (MessageBox.Show(HIS.Desktop.LibraryMessage.MessageUtil.GetMessage(HIS.Desktop.LibraryMessage.Message.Enum.HeThongTBCuaSoThongBaoBanCoMuonBoKhoaDuLieuKhong), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (rowData != null)
                    {
                        LIS_PATIENT_CONDITION Result = new BackendAdapter(param).Post<LIS_PATIENT_CONDITION>(HisRequestUriStore.LisPatientCondition_Changelock, ApiConsumers.LisConsumer, rowData, param);
                        if (Result != null)
                        {
                            success = true;
                            FillDataToGridControl();
                            btnEdit.Enabled = true;
                        }
                    }
                    MessageManager.Show(this, param, success);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CommonParam param = new CommonParam();
                var rowData = (LIS_PATIENT_CONDITION)gridViewHisVaccineType.GetFocusedRow();
                bool success = false;
                if (MessageBox.Show(HIS.Desktop.LibraryMessage.MessageUtil.GetMessage(HIS.Desktop.LibraryMessage.Message.Enum.HeThongTBCuaSoThongBaoBanCoMuonXoaDuLieuKhong), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (rowData != null)
                    {
                        success = new BackendAdapter(param).Post<bool>(HisRequestUriStore.LisPatientCondition_Delete, ApiConsumers.LisConsumer, rowData.ID, param);
                        if (success)
                        {
                            FillDataToGridControl();
                            btnCancel_Click(null, null);
                        }
                    }
                    MessageManager.Show(this, param, success);
                }
            }
            catch (Exception ex)
            {

                LogSystem.Error(ex);
            }
        }
        #endregion

        private void txtAccidentBodyPartName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.ActionType == GlobalVariables.ActionAdd && btnAdd.Enabled)
                    {
                        btnAdd.Focus();
                    }
                    else if (this.ActionType == GlobalVariables.ActionEdit && btnEdit.Enabled)
                    {
                        btnEdit.Focus();
                    }
                    else
                        btnCancel.Focus();
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {

                LogSystem.Warn(ex);
            }
        }
    }
}
