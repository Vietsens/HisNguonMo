﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;
using DevExpress.XtraEditors;
using His.UC.LibraryMessage;

namespace HIS.UC.FormType.Medicin
{
    public partial class UCMedicin : DevExpress.XtraEditors.XtraUserControl
    {
        int positionHandleControl = -1;
        bool isValidData = false;
        bool sample = true;
        SAR.EFMODEL.DataModels.V_SAR_RETY_FOFI config;
        //public static bool exitclick = false;
        SAR.EFMODEL.DataModels.V_SAR_REPORT report;

        public UCMedicin(SAR.EFMODEL.DataModels.V_SAR_RETY_FOFI config, object paramRDO)
        {
            try
            {
                InitializeComponent();
                //FormTypeConfig.ReportHight += 25;

                this.config = config;
                if (paramRDO is GenerateRDO)
                {
                    this.report = (paramRDO as GenerateRDO).Report;
                }
                this.isValidData = (this.config != null && this.config.IS_REQUIRE == IMSys.DbConfig.SAR_RS.COMMON.IS_ACTIVE__TRUE);
                Init();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        void Init()
        {
            try
            {
                SetTitle();//Inventec.Common.Logging.LogSystem.Info(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => report), report));

                if (this.isValidData)
                {


                    Validation();
                    layoutControlItem1.AppearanceItemCaption.ForeColor = Color.Maroon;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        void SetTitle()
        {
            try
            {
                if (this.config != null && !String.IsNullOrEmpty(this.config.DESCRIPTION))
                {
                    layoutControlItem1.Text = this.config.DESCRIPTION;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        //private void txtTreatmentTypeCode_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        //{
        //    try
        //    {
        //        var mediStocks = FormTypeConfig.HisTreatments;//.Where(f => f.TREATMENT_TYPE_CODE.Contains(txtTreatmentTypeCode.Text.Trim())).ToList();
        //        if (mediStocks != null)
        //        {
        //            if (mediStocks.Count == 1)
        //            {
        //                //txtTreatmentTypeCode.Text = mediStocks[0].TREATMENT_TYPE_CODE;
        //                cboTreatmentType.EditValue = mediStocks[0].ID;
        //                System.Windows.Forms.SendKeys.Send("{TAB}");
        //            }
        //            else
        //            {
        //                cboTreatmentType.ShowPopup();
        //                cboTreatmentType.Focus();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Warn(ex);
        //    }
        //}

        private void cboTreatmentType_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.Normal)
                {
                    if (Medicin.EditValue != null)
                    {

                        var department = Config.HisFormTypeConfig.VHisMedicineTypes.FirstOrDefault(f => f.ID == long.Parse(Medicin.EditValue.ToString()));
                        if (department != null)
                        {
                            //txtTreatmentTypeCode.Text = EXE.LOGIC.LocalStore.HisDataLocalStore.
                        }
                    }
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void cboTreatmentType_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    if (Medicin.EditValue != null)
                    {
                        var department = Config.HisFormTypeConfig.VHisMedicineTypes.FirstOrDefault(f => f.ID == long.Parse(Medicin.EditValue.ToString()));
                        if (department != null)
                        {
                            //txtTreatmentTypeCode.Text = department.TREATMENT_TYPE_CODE;
                        }
                        System.Windows.Forms.SendKeys.Send("{TAB}");
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public string GetValue()
        {
            string value = "";
            try
            {
                List<long> aaa = new List<long>();
                string HeinNumberCode;
                SetTitle();
                if (this.config.JSON_OUTPUT == "\"MEDICINE_TYPE_ID\":{0}")
                    aaa = Config.HisFormTypeConfig.VHisMedicineTypes.Where(o => o.MEDICINE_TYPE_CODE == Medicin.Text).Select(o => o.ID).ToList();
                if (this.config.JSON_OUTPUT == "\"MATERIAL_TYPE_ID\":{0}")
                    aaa = Config.HisFormTypeConfig.VHisMaterialTypes.Where(o => o.MATERIAL_TYPE_CODE == Medicin.Text).Select(o => o.ID).ToList();

                //Validation();
                long? departmentId;
                if (aaa.Count() == 0 && this.config.JSON_OUTPUT != "\"HEIN_NUMBER_CODE\":{0}")
                {
                    if (this.config.JSON_OUTPUT == "\"MEDICINE_TYPE_ID\":{0}")
                    {
                        System.Windows.Forms.MessageBox.Show("Nhập mã thuốc chưa đúng");
                        sample = false;
                    }

                    if (this.config.JSON_OUTPUT == "\"MATERIAL_TYPE_ID\":{0}")
                    {
                        System.Windows.Forms.MessageBox.Show("Nhập mã vật tư chưa đúng");
                        sample = false;
                    }


                    //exitclick = true;
                    departmentId = 0;
                }
                else
                {
                    if (this.config.JSON_OUTPUT != "\"HEIN_NUMBER_CODE\":{0}")
                    {
                        departmentId = (long?)aaa[0];
                        value = String.Format(this.config.JSON_OUTPUT, ConvertUtils.ConvertToObjectFilter(departmentId));
                    }
                    if (this.config.JSON_OUTPUT == "\"HEIN_NUMBER_CODE\":{0}")
                    {
                        if (Medicin.Text == "")
                        {
                            System.Windows.Forms.MessageBox.Show("Nhập 3 kí tự đầu của mã thẻ bảo hiểm!");
                            sample = false;
                        }
                        HeinNumberCode = "\"" + Medicin.Text + "\"";
                        value = String.Format(this.config.JSON_OUTPUT, ConvertUtils.ConvertToObjectFilter(HeinNumberCode));

                    }

                }
            }
            catch (Exception ex)
            {
                value = null;
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }

            return value;
        }

        public void SetValue()
        {
            try
            {
                if (this.config.JSON_OUTPUT != null && this.report.JSON_FILTER != null)
                {
                    string value = HIS.UC.FormType.CopyFilter.CopyFilter.CopyFilterProcess(this.config, this.config.JSON_OUTPUT, this.report.JSON_FILTER);
                    if (value != null && value != "null" && Inventec.Common.TypeConvert.Parse.ToInt64(value) > 0)
                    {

                        if (this.config.JSON_OUTPUT == "\"MEDICINE_TYPE_ID\":{0}" || this.config.JSON_OUTPUT == "\"MATERIAL_TYPE_ID\":{0}")
                        {
                            Medicin.EditValue = Inventec.Common.TypeConvert.Parse.ToInt64(value);
                        }


                    }
                    else if (value != null && value != "null")
                    {
                        Medicin.Text = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public bool Valid()
        {
            bool result = true;
            try
            {
                if (this.isValidData != null && this.isValidData)
                {
                    this.positionHandleControl = -1;
                    result = dxValidationProvider1.Validate();
                }
                result = result & sample;
            }
            catch (Exception ex)
            {
                result = false;
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        #region Validation
        private void ValidateMedicin()
        {
            try
            {
                HIS.UC.FormType.Medicin.Validation.MedicinValidationRule validRule = new HIS.UC.FormType.Medicin.Validation.MedicinValidationRule();
                //validRule.txtTreatmentTypeCode = txtTreatmentTypeCode;
                validRule.Medicin = Medicin;
                validRule.ErrorText = HIS.UC.FormType.Base.MessageUtil.GetMessage(Message.Enum.ThieuTruongDuLieuBatBuoc);
                validRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
                dxValidationProvider1.SetValidationRule(Medicin, validRule);

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void Validation()
        {
            try
            {
                ValidateMedicin();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void dxValidationProvider1_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            try
            {
                BaseEdit edit = e.InvalidControl as BaseEdit;
                if (edit == null)
                    return;

                DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo viewInfo = edit.GetViewInfo() as DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo;
                if (viewInfo == null)
                    return;

                if (positionHandleControl == -1)
                {
                    positionHandleControl = edit.TabIndex;
                    if (edit.Visible)
                    {
                        edit.SelectAll();
                        edit.Focus();
                    }
                }
                if (positionHandleControl > edit.TabIndex)
                {
                    positionHandleControl = edit.TabIndex;
                    if (edit.Visible)
                    {
                        edit.SelectAll();
                        edit.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        private void UCMedicin_Load(object sender, EventArgs e)
        {
            try
            {
                layoutControlItem1.Text = this.config.DESCRIPTION; //Inventec.Common.Resource.Get.Value("IVT_LANGUAGE_KEY_UC_MEDICIN_LAYOUT_CONTROL_ITEM1", Resources.ResourceLanguageManager.LanguageUCMedicin, Base.LanguageManager.GetCulture());
                if (this.report != null)
                {
                    SetValue();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
