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
using DevExpress.XtraEditors;
using HIS.Desktop.LocalStorage.BackendData;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS.Desktop.Plugins.Library.CheckIcd
{
    public delegate void DelegateRefeshIcd(string icdCodes, string icdNames);
    public class CheckIcdManager
    {
        private const string Seperator = ";";
        public static string IcdCodeError = null;
        private DelegateRefeshIcd delegateRefeshIcd { get; set; }
        private HIS_TREATMENT treatment { get; set; }
        private List<HIS_GENDER> genderList { get; set; }
        private List<HIS_AGE_TYPE> ageTypeList { get; set; }
        private List<V_HIS_ICD> icdList { get; set; }
        public CheckIcdManager(DelegateRefeshIcd delegateRefeshIcd, HIS_TREATMENT treatment)
        {
            try
            {
                this.delegateRefeshIcd = delegateRefeshIcd;
                this.treatment = treatment;
                this.genderList = BackendDataWorker.Get<HIS_GENDER>().ToList();
                this.ageTypeList = BackendDataWorker.Get<HIS_AGE_TYPE>().ToList();
                this.icdList = BackendDataWorker.Get<V_HIS_ICD>().ToList();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        public bool ProcessCheckIcd(string icdCodes, string icdSubCodes, ref string MessageError, bool IsCheck = false)
        {
            bool rs = true;
            bool go = true; 
            try
            {
                if (treatment == null)
                    return false;
                if (string.IsNullOrEmpty(icdCodes) && string.IsNullOrEmpty(icdSubCodes))
                    return rs;
                List<string> listIcdCode = new List<string>();
                List<string> listIcdSubCode = new List<string>();
                List<string> listIcdTotal = new List<string>();
                List<string> listIcdCodeTre = new List<string>();
                List<string> listIcdSubCodeTre = new List<string>();
                if (treatment != null)
                {
                    listIcdSubCodeTre.AddRange(treatment.ICD_SUB_CODE.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                    listIcdTotal.AddRange(listIcdSubCodeTre);
                    listIcdCodeTre.AddRange(treatment.ICD_CODE.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                    listIcdTotal.AddRange(listIcdCodeTre);
                }
               
                if (!string.IsNullOrEmpty(icdSubCodes))
                    listIcdSubCode.AddRange(icdSubCodes.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                listIcdTotal.AddRange(listIcdSubCode);
                if (!string.IsNullOrEmpty(icdCodes))
                    listIcdCode.AddRange(icdCodes.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                listIcdTotal.AddRange(listIcdCode);
                listIcdTotal = listIcdTotal.Distinct().ToList();
                foreach (var icd in listIcdTotal)
                {
                    var item = icdList.FirstOrDefault(o => o.ICD_CODE.Equals(icd));
                    if (item == null)
                        continue;
                    #region Gender
                    if (item.GENDER_ID != null && item.GENDER_ID != treatment.TDL_PATIENT_GENDER_ID)
                    {
                        var gender = genderList.FirstOrDefault(o => o.ID == item.GENDER_ID);
                        IcdCodeError = item.ICD_CODE;
                        MessageError = String.Format("Mã bệnh {0} chỉ sử dụng cho giới tính {1}", IcdCodeError, gender != null ? gender.GENDER_NAME : null);
                        return false;
                    }
                    #endregion
                    #region Age
                    if (item.AGE_TYPE_ID != null)
                    {
                        var dob = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(treatment.TDL_PATIENT_DOB);
                        int age = 0;
                        switch (item.AGE_TYPE_ID)
                        {
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__YEAR:
                                var totalDay = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
                                age = ((DateTime.Now - (dob ?? DateTime.Now)).Days) / totalDay;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__MONTH:
                                age = ((DateTime.Now - (dob ?? DateTime.Now)).Days) / 30;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__DAY:
                                age = (DateTime.Now - (dob ?? DateTime.Now)).Days;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__HOUR:
                                age = (int)(DateTime.Now - (dob ?? DateTime.Now)).TotalHours;
                                break;
                            default:
                                break;
                        }
                        if ((item.AGE_FROM != null && age < item.AGE_FROM) || (item.AGE_TO != null && age > item.AGE_TO))
                        {
                            string range = null;
                            string typeAge = item.AGE_TYPE_ID != IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__YEAR ? ageTypeList.FirstOrDefault(o => o.ID == item.AGE_TYPE_ID).AGE_TYPE_NAME : null;
                            if (item.AGE_FROM != null && item.AGE_TO != null)
                            {
                                range = string.Format("{0} - {1}", item.AGE_FROM, item.AGE_TO);
                            }
                            else if (item.AGE_FROM != null && age < item.AGE_FROM)
                            {
                                range = string.Format("trên {0}", item.AGE_FROM);
                            }
                            else if (item.AGE_TO != null && age > item.AGE_TO)
                            {
                                range = string.Format("dưới {0}", item.AGE_TO);
                            }
                            IcdCodeError = item.ICD_CODE;
                            MessageError = String.Format("Mã bệnh {0} chỉ sử dụng cho bệnh nhân {1} tuổi", IcdCodeError, !string.IsNullOrEmpty(typeAge) ? string.Format("{0} {1}", range, typeAge) : range);
                            return false;
                        }
                    }
                    #endregion
                    #region IsSubCode
                    if (listIcdCode.FirstOrDefault(o => o.Equals(item.ICD_CODE)) != null)
                    {
                        if (item.IS_SUBCODE == 1)
                        {
                            IcdCodeError = item.ICD_CODE;
                            MessageError = String.Format("Mã bệnh {0} không sử dụng là bệnh chính", IcdCodeError);
                            return false;
                        }
                        if (!string.IsNullOrEmpty(item.ATTACH_ICD_CODES))
                        {
                            var lstIcdCodeAttach = item.ATTACH_ICD_CODES.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (IsCheck)
                            {
                                bool IsExist = false;
                                foreach (var att in lstIcdCodeAttach)
                                {
                                    if (listIcdSubCode.Contains(att))
                                    {
                                        IsExist = true;
                                        break;
                                    }
                                }
                                if (!IsExist)
                                {
                                    IcdCodeError = item.ICD_CODE;
                                    MessageError = String.Format("Mã bệnh {0} thiếu thông tin bệnh kèm theo", IcdCodeError);
                                    return false;
                                }
                            }
                            else
                            {
                                frmAttachIcd frm = new frmAttachIcd(delegateRefeshIcd, HIS.Desktop.LocalStorage.ConfigApplication.ConfigApplications.NumPageSize, icdList.Where(o => lstIcdCodeAttach.Exists(p => p.Equals(o.ICD_CODE))).ToList(), item.IS_SWORD == 1, this);
                                frm.ShowDialog();
                            }
                        }
                    }
                    #endregion
                    if (item.CHECK_SAME_ICD_GROUP == 1 && go == true)
                    {
                        if (listIcdTotal != null && listIcdTotal.Count > 0)
                        {
                            var icdTreatment = icdList.Where(i => listIcdTotal.Distinct().ToList().Contains(i.ICD_CODE)).ToList();
                            if (icdTreatment.Exists(o => o.ICD_GROUP_ID == item.ICD_GROUP_ID))
                            {
                                List<string> lstICD = icdTreatment.Where(i => i.ICD_GROUP_ID == item.ICD_GROUP_ID).Where(i=>i.ICD_CODE != icd).Select(i => i.ICD_CODE).ToList();
                                if (lstICD.Count > 0)
                                {
                                    go = false;
                                    IcdCodeError = item.ICD_CODE;
                                    MessageError = String.Format("Mã bệnh {0} cùng nhóm {1} với mã bệnh {2} đã dùng trong đợt điều trị", IcdCodeError, item.ICD_GROUP_NAME, string.Join(",", lstICD));
                                    return false;
                                }
                            }
                        }
                    }

                    //var data = icdList.Where(i => i.ICD_CODE == icd || i.SUB_CODE == icd).FirstOrDefault();
                    //List<V_HIS_ICD> dataTre = new List<V_HIS_ICD>() ;
                    //string[] stringArray = treatment.ICD_SUB_CODE.Split(';');
                    //List<string> lst = new List<string>(stringArray).Where(x => !string.IsNullOrEmpty(x)).ToList();

                    //if (treatment.ICD_SUB_CODE == null && treatment.ICD_CODE != null)
                    //{
                    //    dataTre = icdList.Where(i => i.ICD_CODE == treatment.ICD_CODE).ToList();
                    //}
                    //else if (treatment.ICD_CODE == null && treatment.ICD_SUB_CODE != null)
                    //{
                    //    dataTre = icdList.Where(i => lst.Any(x => i.ICD_CODE.Contains(x))).ToList();
                    //    //dataTre = icdList.Where(i => i.ICD_CODE.Contains(lst)).ToList();
                    //}
                    //else if (treatment.ICD_CODE != null && treatment.ICD_SUB_CODE != null)
                    //{
                    //    //dataTre = icdList.Where(i => i.ICD_CODE == treatment.ICD_CODE || i.ICD_CODE.Contains(lst)).ToList();
                    //    dataTre = icdList.Where(i => i.ICD_CODE == treatment.ICD_CODE || lst.Any(x => i.ICD_CODE.Contains(x))).ToList();
                    //}
                    //else
                    //{
                    //    dataTre = null;
                    //}
                    ////foreach (var i in lst)
                    ////{
                    ////    if (data.ICD_CODE == treatment.ICD_CODE || data.ICD_CODE == i)
                    ////    {
                    ////        continue;
                    ////    }
                    ////}
                    //if (data.ICD_CODE == treatment.ICD_CODE || lst.Any(x => treatment.ICD_CODE.Contains(x)))
                    //{
                    //    continue;
                    //}
                    //if (data.CHECK_SAME_ICD_GROUP == 1)
                    //{
                    //    if (dataTre.Count() >0 )
                    //    {
                    //        List<string> lstICD = dataTre.Where(i => i.ICD_GROUP_ID == data.ICD_GROUP_ID).Select(i => i.ICD_CODE).ToList();
                    //        if (lstICD.Count > 0)
                    //        {
                    //            string fruitsString = string.Join(",", lstICD);
                    //            IcdCodeError = item.ICD_CODE;
                    //            MessageError = String.Format("Mã bệnh {0} cùng nhóm {1} với mã bệnh {2} đã dùng trong đợt điều trị", IcdCodeError, data.ICD_GROUP_NAME, fruitsString);
                    //            return false;
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageError = ex.Message;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return rs;
        }

        public bool ProcessCheckIcdWithErrorCode(string icdCodes, string icdSubCodes, ref string MessageError, ref string icd_code_error, bool IsCheck = false)
        {
            bool rs = true;
            bool go = true;
            try
            {
                if (treatment == null)
                    return false;
                if (string.IsNullOrEmpty(icdCodes) && string.IsNullOrEmpty(icdSubCodes))
                    return rs;
                List<string> listIcdCode = new List<string>();
                List<string> listIcdSubCode = new List<string>();
                List<string> listIcdTotal = new List<string>();
                List<string> listIcdCodeTre = new List<string>();
                List<string> listIcdSubCodeTre = new List<string>();
                if (treatment != null)
                {
                    listIcdCodeTre.AddRange(treatment.ICD_CODE.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                    listIcdTotal.AddRange(listIcdCodeTre);
                    listIcdSubCodeTre.AddRange(treatment.ICD_SUB_CODE.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                    listIcdTotal.AddRange(listIcdSubCodeTre);
                }
                
                if (!string.IsNullOrEmpty(icdSubCodes))
                    listIcdSubCode.AddRange(icdSubCodes.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                listIcdTotal.AddRange(listIcdSubCode);
                if (!string.IsNullOrEmpty(icdCodes))
                    listIcdCode.AddRange(icdCodes.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                listIcdTotal.AddRange(listIcdCode);
                listIcdTotal = listIcdTotal.Distinct().ToList();
                foreach (var icd in listIcdTotal)
                {
                    var item = icdList.FirstOrDefault(o => o.ICD_CODE.Equals(icd));
                    if (item == null)
                        continue;
                    #region Gender
                    if (item.GENDER_ID != null && item.GENDER_ID != treatment.TDL_PATIENT_GENDER_ID)
                    {
                        var gender = genderList.FirstOrDefault(o => o.ID == item.GENDER_ID);
                        IcdCodeError = item.ICD_CODE;
                        MessageError = String.Format("Mã bệnh {0} chỉ sử dụng cho giới tính {1}", IcdCodeError, gender != null ? gender.GENDER_NAME : null);
                        return false;
                    }
                    #endregion
                    #region Age
                    if (item.AGE_TYPE_ID != null)
                    {
                        var dob = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(treatment.TDL_PATIENT_DOB);
                        int age = 0;
                        switch (item.AGE_TYPE_ID)
                        {
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__YEAR:
                                var totalDay = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
                                age = ((DateTime.Now - (dob ?? DateTime.Now)).Days) / totalDay;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__MONTH:
                                age = ((DateTime.Now - (dob ?? DateTime.Now)).Days) / 30;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__DAY:
                                age = (DateTime.Now - (dob ?? DateTime.Now)).Days;
                                break;
                            case IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__HOUR:
                                age = (int)(DateTime.Now - (dob ?? DateTime.Now)).TotalHours;
                                break;
                            default:
                                break;
                        }
                        if ((item.AGE_FROM != null && age < item.AGE_FROM) || (item.AGE_TO != null && age > item.AGE_TO))
                        {
                            string range = null;
                            string typeAge = item.AGE_TYPE_ID != IMSys.DbConfig.HIS_RS.HIS_AGE_TYPE.ID__YEAR ? ageTypeList.FirstOrDefault(o => o.ID == item.AGE_TYPE_ID).AGE_TYPE_NAME : null;
                            if (item.AGE_FROM != null && item.AGE_TO != null)
                            {
                                range = string.Format("{0} - {1}", item.AGE_FROM, item.AGE_TO);
                            }
                            else if (item.AGE_FROM != null && age < item.AGE_FROM)
                            {
                                range = string.Format("trên {0}", item.AGE_FROM);
                            }
                            else if (item.AGE_TO != null && age > item.AGE_TO)
                            {
                                range = string.Format("dưới {0}", item.AGE_TO);
                            }
                            IcdCodeError = item.ICD_CODE;
                            MessageError = String.Format("Mã bệnh {0} chỉ sử dụng cho bệnh nhân {1} tuổi", IcdCodeError, !string.IsNullOrEmpty(typeAge) ? string.Format("{0} {1}", range, typeAge) : range);
                            return false;
                        }
                    }
                    #endregion
                    #region IsSubCode
                    if (listIcdCode.FirstOrDefault(o => o.Equals(item.ICD_CODE)) != null)
                    {
                        if (item.IS_SUBCODE == 1)
                        {
                            IcdCodeError = item.ICD_CODE;
                            MessageError = String.Format("Mã bệnh {0} không sử dụng là bệnh chính", IcdCodeError);
                            return false;
                        }
                        if (!string.IsNullOrEmpty(item.ATTACH_ICD_CODES))
                        {
                            var lstIcdCodeAttach = item.ATTACH_ICD_CODES.Split(Seperator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (IsCheck)
                            {
                                bool IsExist = false;
                                foreach (var att in lstIcdCodeAttach)
                                {
                                    if (listIcdSubCode.Contains(att))
                                    {
                                        IsExist = true;
                                        break;
                                    }
                                }
                                if (!IsExist)
                                {
                                    IcdCodeError = item.ICD_CODE;
                                    MessageError = String.Format("Mã bệnh {0} thiếu thông tin bệnh kèm theo", IcdCodeError);
                                    return false;
                                }
                            }
                            else
                            {
                                frmAttachIcd frm = new frmAttachIcd(delegateRefeshIcd, HIS.Desktop.LocalStorage.ConfigApplication.ConfigApplications.NumPageSize, icdList.Where(o => lstIcdCodeAttach.Exists(p => p.Equals(o.ICD_CODE))).ToList(), item.IS_SWORD == 1, this);
                                frm.ShowDialog();
                            }
                        }
                    }
                    #endregion
                    if (item.CHECK_SAME_ICD_GROUP == 1 && go == true)
                    {
                        if (listIcdTotal != null && listIcdTotal.Count > 0)
                        {
                            var icdTreatment = icdList.Where(i => listIcdTotal.Distinct().ToList().Contains(i.ICD_CODE)).ToList();
                            if (icdTreatment.Exists(o => o.ICD_GROUP_ID == item.ICD_GROUP_ID))
                            {
                                List<string> lstICD = icdTreatment.Where(i => i.ICD_GROUP_ID == item.ICD_GROUP_ID).Where(i => i.ICD_CODE != icd).Select(i => i.ICD_CODE).ToList();
                                if (lstICD.Count > 0)
                                {
                                    go = false;
                                    IcdCodeError = item.ICD_CODE;
                                    MessageError = String.Format("Mã bệnh {0} cùng nhóm {1} với mã bệnh {2} đã dùng trong đợt điều trị", IcdCodeError, item.ICD_GROUP_NAME, string.Join(",", lstICD));
                                    icd_code_error += ";" + IcdCodeError;
                                    return false;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageError = ex.Message;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return rs;
        }
    }
}
