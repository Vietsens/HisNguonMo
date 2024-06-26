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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.ExecuteRoom
{
    public partial class UCExecuteRoom : HIS.Desktop.Utility.UserControlBase
    {
        public override void ProcessDisposeModuleDataAfterClose()
        {
            try
            {
                isEventPopupMenuShowing = false;
                deskList = null;
                lstPatientType = null;
                lstServiceRoom = null;
                lstPatientPrioty = null;
                lstExecuteRoom = null;
                CheckListCPA = null;
                emrMenuPopupProcessor = null;
                CheckServiceExecuteGroup = null;
                currentModule = null;
                popupMenuProcessor = null;
                _sereServRowMenu = null;
                baManagerMenu = null;
                CPALoad = false;
                isNotLoadWhileChangeControlStateInFirst = false;
                listServices = null;
                serviceSelecteds = null;
                typeCodeFind_RangeDate = null;
                typeCodeFind__InMonth = null;
                typeCodeFind_InDate = null;
                typeCodeFind__KeyWork_InDate = null;
                ModuleLinkName = null;
                lastInfoSS = null;
                lastRowHandleSS = 0;
                lastColumnSS = null;
                maxTimeReload = 0;
                timeCount = 0;
                isInit = false;
                patientTypeList = null;
                selectedPatientTypeList = null;
                SereServCurrentTreatment = null;
                ServiceReqCurrentTreatment = null;
                clienttManager = null;
                executeRoomPopupMenuProcessor = null;
                u16 = null;
                ucTreeSereServ7 = null;
                p16 = null;
                ssTreeProcessor = null;
                currentPatientTypeAlter = null;
                sereServ6s = null;
                lastInfo = null;
                lastColumn = null;
                needHandleOnClick = false;
                lastRowHandle = 0;
                numPageSize = 0;
                dataTotal = 0;
                rowCount = 0;
                executeRoom = null;
                sereServ7s = null;
                serviceReqs = null;
                serviceReqRightClick = null;
                currentHisServiceReq = null;
                //currentControlStateRDO = null;
                //controlStateWorker = null;
                roomTypeId = 0;
                roomId = 0;
                ID_ = null;
                threadCallPatient = null;
                listReplace = null;
                TreeClickData = null;
                desk = null;
                employee = null;
                serviceReqCount = 0;
                this.ckKQCLS.CheckedChanged -= new System.EventHandler(this.ckKQCLS_CheckedChanged);
                this.btnNotEnter.Click -= new System.EventHandler(this.btnNotEnter_Click);
                this.btnMissCall.Click -= new System.EventHandler(this.btnMissCall_Click);
                this.chkScreenSaver.CheckedChanged -= new System.EventHandler(this.chkScreenSaver_CheckedChanged);
                this.lblServiceReqCount.Click -= new System.EventHandler(this.lblServiceReqCount_Click);
                this.btnRecallPatient.Click -= new System.EventHandler(this.btnRecallPatient_Click);
                this.btnCallPatient.Click -= new System.EventHandler(this.btnCallPatient_Click);
                this.txtStepNumber.TextChanged -= new System.EventHandler(this.txtStepNumber_TextChanged);
                this.txtGateNumber.TextChanged -= new System.EventHandler(this.txtGateNumber_TextChanged);
                this.txtGateNumber.PreviewKeyDown -= new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtGateNumber_PreviewKeyDown);
                this.btnServiceReqList.Click -= new System.EventHandler(this.btnServiceReqList_Click);
                this.btnUnStart.Click -= new System.EventHandler(this.btnUnStart_Click);
                this.btnTreatmentHistory.Click -= new System.EventHandler(this.btnTreatmentHistory_Click);
                this.btnRoomTran.Click -= new System.EventHandler(this.btnRoomTran_Click);
                this.btnDepositReq.Click -= new System.EventHandler(this.btnDepositReq_Click);
                this.btnBordereau.Click -= new System.EventHandler(this.btnBordereau_Click);
                this.btnExecute.Click -= new System.EventHandler(this.btnExecute_Click);
                this.layoutControl3.GroupExpandChanged -= new DevExpress.XtraLayout.Utils.LayoutGroupEventHandler(this.layoutControl3_GroupExpandChanged);
                this.xtraTabControl1.SelectedPageChanged -= new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
                this.xtraTabControl1.TabIndexChanged -= new System.EventHandler(this.xtraTabControl1_TabIndexChanged);
                this.xtraTabDocument.SelectedPageChanged -= new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabDocument_SelectedPageChanged);
                this.gridViewSereServServiceReq.RowStyle -= new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewSereServServiceReq_RowStyle);
                this.gridViewSereServServiceReq.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewSereServServiceReq_PopupMenuShowing);
                this.gridViewSereServServiceReq.CustomUnboundColumnData -= new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewSereServServiceReq_CustomUnboundColumnData);
                this.gridViewSereServServiceReq.Click -= new System.EventHandler(this.gridViewSereServServiceReq_Click);
                this.gridViewSereServServiceReq.DoubleClick -= new System.EventHandler(this.gridViewSereServServiceReq_DoubleClick);
                this.repositoryItemBtnViewAccessionNumber.ButtonClick -= new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemBtnViewAccessionNumber_ButtonClick);
                this.toolTipController2.GetActiveObjectInfo -= new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController2_GetActiveObjectInfo);
                this.txtBedCodeBedName.PreviewKeyDown -= new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtBedCodeBedName_PreviewKeyDown);
                this.chkCPA.CheckedChanged -= new System.EventHandler(this.chkCPA_CheckedChanged);
                this.cboDaKe.Closed -= new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cboDaKe_Closed);
                this.cboSucKhoe.Closed -= new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cboSucKhoe_Closed);
                this.cboSucKhoe.ButtonClick -= new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboSucKhoe_ButtonClick);
                this.cboServiceRoom.Closed -= new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cboServiceRoom_Closed);
                this.cboServiceRoom.CustomDisplayText -= new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.cboServiceRoom_CustomDisplayText);
                this.btnNextIntructionDate.Click -= new System.EventHandler(this.btnNextIntructionDate_Click);
                this.btnPreviewIntructionDate.Click -= new System.EventHandler(this.btnPreviewIntructionDate_Click);
                this.txtServiceReqCode.PreviewKeyDown -= new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTreatmentCode_PreviewKeyDown);
                this.cboInDebt.SelectedIndexChanged -= new System.EventHandler(this.cboInDebt_SelectedIndexChanged);
                this.gridViewPatientType.RowCellStyle -= new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewPatientType_RowCellStyle);
                this.gridViewPatientType.RowStyle -= new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewPatientType_RowStyle);
                this.btnRefesh.Click -= new System.EventHandler(this.btnRefesh_Click);
                this.gridViewServiceReq.RowCellClick -= new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewServiceReq_RowCellClick);
                this.gridViewServiceReq.RowStyle -= new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewServiceReq_RowStyle);
                this.gridViewServiceReq.CustomRowCellEdit -= new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewServiceReq_CustomRowCellEdit);
                this.gridViewServiceReq.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewServiceReq_PopupMenuShowing);
                this.gridViewServiceReq.CustomUnboundColumnData -= new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridViewServiceReq_CustomUnboundColumnData);
                this.gridViewServiceReq.DoubleClick -= new System.EventHandler(this.gridViewServiceReq_DoubleClick);
                this.repositoryItemTextEdit.DoubleClick -= new System.EventHandler(this.repositoryItemTextEdit_DoubleClick);
                this.repositoryItemButton__Send.ButtonClick -= new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButton__Send_ButtonClick);
                this.repositoryEditServiceReq__Enable.ButtonClick -= new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryEditServiceReq__Enable_ButtonClick);
                this.btnFind.Click -= new System.EventHandler(this.btnFind_Click);
                this.cboFind.SelectedIndexChanged -= new System.EventHandler(this.cboFind_SelectedIndexChanged);
                this.txtSearchKey.PreviewKeyDown -= new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchKey_PreviewKeyDown);
                this.toolTipController1.GetActiveObjectInfo -= new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
                this.timerDoubleClick.Tick -= new System.EventHandler(this.timerDoubleClick_Tick);
                this.Load -= new System.EventHandler(this.UCExecuteRoom_Load);
                gridView1.GridControl.DataSource = null;
                gridLookUpEdit1View.GridControl.DataSource = null;
                gridViewPatientType.GridControl.DataSource = null;
                gridViewSereServServiceReq.GridControl.DataSource = null;
                gridControlSereServServiceReq.DataSource = null;
                gridViewServiceReq.GridControl.DataSource = null;
                gridControlServiceReq.DataSource = null;
                repositoryItemTextEdit = null;
                lciNote = null;
                lblNote = null;
                lciExamTreatmentEndType = null;
                lblExamTreatmentEndType = null;
                lciTransferInMediOrg = null;
                lbTransferInMediOrg = null;
                lciExamTreatmentResult = null;
                lblExamTreatmentResult = null;
                lciExamEndType = null;
                lbExamEndType = null;
                lciPhoneNumber = null;
                lbPhoneNumber = null;
                lciHopitalizeDepartment = null;
                lbHopitalizeDepartment = null;
                layoutControlItem55 = null;
                txtBedCodeBedName = null;
                gridColumn17 = null;
                repositoryItemPictureEdit7 = null;
                repositoryItemBtnDangGoi = null;
                repositoryItembtnLoaGoiNho = null;
                repositoryItembtnGoiNho = null;
                gridColumn16 = null;
                lcCkhCPA = null;
                txtCallPatientCPA = null;
                layoutControlItem54 = null;
                chkCPA = null;
                repositoryItemPictureEdit6 = null;
                repositoryItemPopupGalleryEdit1 = null;
                gridColumn15 = null;
                layoutControlItem53 = null;
                ckKQCLS = null;
                layoutControlItem51 = null;
                cboDaKe = null;
                layoutControlItem50 = null;
                gridView1 = null;
                cboSucKhoe = null;
                layoutControlItem49 = null;
                layoutControlItem48 = null;
                btnMissCall = null;
                btnNotEnter = null;
                gridColumn14 = null;
                layoutControlItem74 = null;
                layoutControlItem89 = null;
                layoutControlItem88 = null;
                layoutControlItem87 = null;
                layoutControlItem86 = null;
                layoutControlItem85 = null;
                layoutControlItem84 = null;
                layoutControlItem83 = null;
                layoutControlItem82 = null;
                layoutControlItem81 = null;
                layoutControlItem80 = null;
                layoutControlItem79 = null;
                layoutControlItem78 = null;
                layoutControlItem77 = null;
                layoutControlItem76 = null;
                layoutControlItem75 = null;
                layoutControlGroup6 = null;
                txtMach = null;
                txtNhietDo = null;
                txtHACode = null;
                txtHAName = null;
                txtNhipTho = null;
                txtCanNang = null;
                txtChieuCao = null;
                txtBMI = null;
                txtBMIDisplay = null;
                labelControl9 = null;
                labelControl10 = null;
                labelControl11 = null;
                labelControl12 = null;
                labelControl13 = null;
                labelControl14 = null;
                layoutControl7 = null;
                layoutControlItem66 = null;
                layoutControlItem65 = null;
                layoutControlItem64 = null;
                layoutControlItem63 = null;
                layoutControlItem62 = null;
                layoutControlItem61 = null;
                layoutControlItem60 = null;
                layoutControlItem59 = null;
                layoutControlItem58 = null;
                layoutControlItem57 = null;
                layoutControlItem52 = null;
                layoutControlItem47 = null;
                layoutControlItem46 = null;
                layoutControlItem45 = null;
                layoutControlItem17 = null;
                txtLyDoKham = null;
                txtQuaTrinhBenhLy = null;
                txtTienSuBenh = null;
                txtKhamToanThan = null;
                txtKhamBoPhan = null;
                txtTomTat = null;
                txtCdSoBo = null;
                txtHDTCode = null;
                txtHDTName = null;
                txtCdCode = null;
                txtCdName = null;
                txtNNNCode = null;
                txtNNNName = null;
                txtBenhPhuCode = null;
                txtBenhPhuName = null;
                xtraScrollableControl17 = null;
                xtraTabPage18 = null;
                xtraScrollableControl16 = null;
                xtraTabPage17 = null;
                xtraScrollableControl15 = null;
                xtraTabPage16 = null;
                xtraScrollableControl14 = null;
                xtraTabPage15 = null;
                xtraScrollableControl13 = null;
                xtraTabPage14 = null;
                xtraScrollableControl12 = null;
                xtraTabPage13 = null;
                xtraScrollableControl11 = null;
                xtraTabPage3 = null;
                xtraScrollableControl10 = null;
                xtraTabPage12 = null;
                xtraScrollableControl9 = null;
                xtraTabPage11 = null;
                xtraScrollableControl8 = null;
                xtraTabPage10 = null;
                xtraScrollableControl7 = null;
                xtraTabPage9 = null;
                xtraScrollableControl6 = null;
                xtraTabPage8 = null;
                xtraScrollableControl5 = null;
                xtraTabPage7 = null;
                xtraScrollableControl4 = null;
                xtraTabPage6 = null;
                xtraScrollableControl3 = null;
                xtraTabPage5 = null;
                xtraScrollableControl2 = null;
                xtraTabPage4 = null;
                xtraScrollableControl1 = null;
                layoutControlItem44 = null;
                layoutControlGroup4 = null;
                layoutControl6 = null;
                xtraTabPage2 = null;
                xtraTabPage1 = null;
                xtraTabControl1 = null;
                gridColumnServiceReqBlock = null;
                gridColumnSereServServiceReqBlock = null;
                cboServiceRoom = null;
                layoutControlItem43 = null;
                gridLookUpEdit1View = null;
                grdColPatientType = null;
                grdColFinishTime = null;
                ucViewEmrDocumentResult = null;
                ucViewEmrDocumentReq = null;
                LciGroupEmrDocument = null;
                layoutControlItem21 = null;
                layoutControlItem41 = null;
                xtraTabDocumentResult = null;
                xtraTabDocumentReq = null;
                xtraTabDocument = null;
                layoutControlItem40 = null;
                chkIsResult = null;
                emptySpaceItem4 = null;
                lciIntructionDateTo = null;
                dtIntructionDateTo = null;
                layoutControlItem42 = null;
                chkScreenSaver = null;
                gridColumn12 = null;
                repositoryItemBtnViewAccessionNumber = null;
                gridColumn13 = null;
                lciNext = null;
                lciPreview = null;
                btnPreviewIntructionDate = null;
                btnNextIntructionDate = null;
                layoutControlItem39 = null;
                dtIntructionDate = null;
                layoutControlItem38 = null;
                btnCodeFind = null;
                layoutControlItem32 = null;
                txtServiceReqCode = null;
                emptySpaceItem2 = null;
                layoutControlItem37 = null;
                cboInDebt = null;
                lciRequestAndMaxRequest = null;
                repositoryItemBtnMedisoftHistory = null;
                Gc_MedisoftHistory = null;
                gc_PatientClassify = null;
                timerReloadMachineCounter = null;
                layoutControlItem36 = null;
                gridViewPatientType = null;
                cboPatientType = null;
                layoutControlItem35 = null;
                lblSereServCount = null;
                gridColumnInstructionNote = null;
                repositoryItemPictureEdit5 = null;
                gridColumn11 = null;
                repositoryItemPictureEdit4 = null;
                toolTipController2 = null;
                repositoryItemPictureEdit3 = null;
                gridColumnStt = null;
                layoutControlItem34 = null;
                layoutControlItem33 = null;
                lblHanThe = null;
                lblLoai = null;
                lblServiceReqCount = null;
                layoutControlItem23 = null;
                btnRefesh = null;
                imageListRefesh = null;
                layoutControlItem31 = null;
                cboTreatmentType = null;
                timerAutoReload = null;
                layoutControlItem26 = null;
                lblAutoReload = null;
                gridColumn10 = null;
                gridColumn9 = null;
                pictureEditAvatar = null;
                layoutControlItem20 = null;
                lblKCBBD = null;
                gridColumnSoPhieu = null;
                timerDoubleClick = null;
                gridColumnInstructionTime = null;
                emptySpaceItem1 = null;
                layoutControlItem30 = null;
                layoutControlItem29 = null;
                layoutControlItem28 = null;
                layoutControlItem27 = null;
                txtGateNumber = null;
                txtStepNumber = null;
                btnCallPatient = null;
                btnRecallPatient = null;
                s = null;
                lblCardNumber = null;
                gridColumnBusyCount = null;
                gridColumnTreatmentCode = null;
                gridColumnGender = null;
                grdColDob = null;
                gridColumn8 = null;
                layoutControlItem25 = null;
                btnServiceReqList = null;
                imageCollection1 = null;
                repositoryEditServiceReq__Disable = null;
                repositoryEditServiceReq__Enable = null;
                repositoryItemButton__Send__Disable = null;
                repositoryItemButton__Send = null;
                layoutControlItem24 = null;
                btnUnStart = null;
                barDockControlRight = null;
                barDockControlLeft = null;
                barDockControlBottom = null;
                barDockControlTop = null;
                barManager1 = null;
                layoutControlItem9 = null;
                btnTreatmentHistory = null;
                layoutControlItem12 = null;
                btnRoomTran = null;
                lciDepositReq = null;
                btnDepositReq = null;
                layoutControlItem22 = null;
                btnBordereau = null;
                toolTipController1 = null;
                layoutControlItem11 = null;
                btnExecute = null;
                gridColumn7 = null;
                layoutControlItem19 = null;
                layoutControlItem18 = null;
                layoutControlGroup5 = null;
                layoutControl5 = null;
                gridColumn6 = null;
                gridColumn5 = null;
                gridColumn4 = null;
                gridColumn3 = null;
                gridViewSereServServiceReq = null;
                gridControlSereServServiceReq = null;
                imageCollection2 = null;
                lcgServiceReq = null;
                layoutControlItem3 = null;
                lcgPatientInfo = null;
                layoutControlItem16 = null;
                layoutControlItem15 = null;
                layoutControlItem14 = null;
                layoutControlItem13 = null;
                layoutControlItem4 = null;
                layoutControlGroup3 = null;
                lblPatientCode = null;
                lblPatientName = null;
                lblDOB = null;
                lblGender = null;
                lblAddress = null;
                layoutControl4 = null;
                lcgTreeSereServ = null;
                repositoryItemButton_CallPatient = null;
                gridColumn2 = null;
                imageListIcon = null;
                imageListPriority = null;
                grdColTRANGTHAI_IMG = null;
                layoutControlItem10 = null;
                layoutControlItem8 = null;
                layoutControlItem7 = null;
                layoutControlItem6 = null;
                layoutControlItem5 = null;
                txtSearchKey = null;
                cboFind = null;
                btnFind = null;
                grdColPatientCode = null;
                grdColVirPatientName = null;
                grdColServiceReqCode = null;
                grdColNUM_ORDER = null;
                repositoryItemPictureEdit2 = null;
                grdColPRIORIRY_DISPLAY = null;
                repositoryItemPictureEdit_Attach_STT = null;
                gridColumn1 = null;
                repositoryItemPictureEdit1 = null;
                gridViewServiceReq = null;
                gridControlServiceReq = null;
                ucPaging1 = null;
                layoutControlItem2 = null;
                layoutControlItem1 = null;
                layoutControlGroup1 = null;
                Root = null;
                layoutControl2 = null;
                layoutControlGroup2 = null;
                layoutControl3 = null;
                layoutControl1 = null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
