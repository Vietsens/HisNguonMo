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
using Inventec.Common.Logging;
using Inventec.Core;
using MOS.Filter;
using System;
using System.Linq;
using System.Collections.Generic;
using HIS.Desktop.LocalStorage.BackendData;
using MOS.EFMODEL.DataModels;

namespace HIS.Desktop.Plugins.Library.PrintOtherForm.Config
{
    public class HisPatientTypeCFG
    {
        private const string SDA_CONFIG__PATIENT_TYPE_CODE__BHYT = "MOS.HIS_PATIENT_TYPE.PATIENT_TYPE_CODE.BHYT";//Doi tuong BHYT
        private const string SDA_CONFIG__PATIENT_TYPE_CODE__HOSPITAL_FEE = "MOS.HIS_PATIENT_TYPE.PATIENT_TYPE_CODE.HOSPITAL_FEE";//Doi tuong vien phi
        private const string SDA_CONFIG__PATIENT_TYPE_CODE__IS_FREE = "MRS.HIS_RS.HIS_PATIENT_TYPE.PATIENT_TYPE_CODE.IS_FREE";//Doi tuong mien phi

        private static long patientTypeIdIsHein;
        public static long PATIENT_TYPE_ID__BHYT
        {
            get
            {
                if (patientTypeIdIsHein == 0)
                {
                    patientTypeIdIsHein = GetId(HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__BHYT));
                }
                return patientTypeIdIsHein;
            }
            set
            {
                patientTypeIdIsHein = value;
            }
        }

        private static long patientTypeIdIsFree;
        public static long PATIENT_TYPE_ID__IS_FREE
        {
            get
            {
                if (patientTypeIdIsFree == 0)
                {
                    patientTypeIdIsFree = GetId(HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__IS_FREE));
                }
                return patientTypeIdIsFree;
            }
            set
            {
                patientTypeIdIsFree = value;
            }
        }

        private static long patientTypeIdHospitalFee;
        public static long PATIENT_TYPE_ID__HOSPITAL_FEE
        {
            get
            {
                if (patientTypeIdHospitalFee == 0)
                {
                    patientTypeIdHospitalFee = GetId(HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__HOSPITAL_FEE));
                }
                return patientTypeIdHospitalFee;
            }
            set
            {
                patientTypeIdHospitalFee = value;
            }
        }

        //Code
        private static string patientTypeCodeIsHein;
        public static string PATIENT_TYPE_CODE__BHYT
        {
            get
            {
                if (String.IsNullOrEmpty(patientTypeCodeIsHein))
                {
                    patientTypeCodeIsHein = HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__BHYT);
                }
                return patientTypeCodeIsHein;
            }
            set
            {
                patientTypeCodeIsHein = value;
            }
        }

        private static string patientTypeCodeIsFree;
        public static string PATIENT_TYPE_CODE__IS_FREE
        {
            get
            {
                if (String.IsNullOrEmpty(patientTypeCodeIsFree))
                {
                    patientTypeCodeIsFree = HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__IS_FREE);
                }
                return patientTypeCodeIsFree;
            }
            set
            {
                patientTypeCodeIsFree = value;
            }
        }

        private static string patientTypeCodeHospitalFee;
        public static string PATIENT_TYPE_CODE__HOSPITAL_FEE
        {
            get
            {
                if (String.IsNullOrEmpty(patientTypeCodeHospitalFee))
                {
                    patientTypeCodeHospitalFee = HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>(SDA_CONFIG__PATIENT_TYPE_CODE__HOSPITAL_FEE);
                }
                return patientTypeCodeHospitalFee;
            }
            set
            {
                patientTypeCodeHospitalFee = value;
            }
        }

        private static long GetId(string code)
        {
            long result = 0;
            try
            {
                var data = BackendDataWorker.Get<HIS_PATIENT_TYPE>().FirstOrDefault(o => o.PATIENT_TYPE_CODE == code);
                if (!(data != null && data.ID > 0)) throw new ArgumentNullException(code + LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => code), code));
                result = data.ID;
            }
            catch (Exception ex)
            {
                LogSystem.Debug(ex);
                result = 0;
            }
            return result;
        }

    }
}
