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
using MOS.EFMODEL.DataModels;
using MPS.Processor.Mps000046.PDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000046
{
    class ExpMestADO : Mps000046ADO
    {
        public string TDL_PATIENT_ADDRESS { get; set; }
        public string TDL_PATIENT_CODE { get; set; }
        public long? TDL_PATIENT_DOB { get; set; }
        public string TDL_PATIENT_FIRST_NAME { get; set; }
        public string TDL_PATIENT_GENDER_NAME { get; set; }
        public string TDL_PATIENT_LAST_NAME { get; set; }
        public string TDL_PATIENT_NAME { get; set; }

        public ExpMestADO(
            V_HIS_EXP_MEST _aggrExpMest,
            List<V_HIS_EXP_MEST_MEDICINE> _expMestMedicines,
            long _expMesttSttId__Approval,
            long _expMesttSttId__Export,
            HIS_EXP_MEST ExpMest)
            : base(_aggrExpMest, _expMestMedicines, _expMesttSttId__Approval, _expMesttSttId__Export)
        {
            if (ExpMest != null)
            {
                this.TDL_PATIENT_ADDRESS = ExpMest.TDL_PATIENT_ADDRESS;
                this.TDL_PATIENT_CODE = ExpMest.TDL_PATIENT_CODE;
                this.TDL_PATIENT_DOB = ExpMest.TDL_PATIENT_DOB;
                this.TDL_PATIENT_FIRST_NAME = ExpMest.TDL_PATIENT_FIRST_NAME;
                this.TDL_PATIENT_GENDER_NAME = ExpMest.TDL_PATIENT_GENDER_NAME;
                this.TDL_PATIENT_LAST_NAME = ExpMest.TDL_PATIENT_LAST_NAME;
                this.TDL_PATIENT_NAME = ExpMest.TDL_PATIENT_NAME;
                
            }

            if (_expMestMedicines != null && _expMestMedicines.Count > 0)
            {
                this.REQ_LOGINNAME = _expMestMedicines[0].REQ_LOGINNAME;
                this.REQ_USERNAME = _expMestMedicines[0].REQ_USERNAME;
            }
        }

        public ExpMestADO(
            V_HIS_EXP_MEST _aggrExpMest,
            List<V_HIS_EXP_MEST_MATERIAL> _expMestMaterials,
            long _expMesttSttId__Approval,
            long _expMesttSttId__Export,
            HIS_EXP_MEST ExpMest)
            : base(_aggrExpMest, _expMestMaterials, _expMesttSttId__Approval, _expMesttSttId__Export)
        {
            if (ExpMest != null)
            {
                this.TDL_PATIENT_ADDRESS = ExpMest.TDL_PATIENT_ADDRESS;
                this.TDL_PATIENT_CODE = ExpMest.TDL_PATIENT_CODE;
                this.TDL_PATIENT_DOB = ExpMest.TDL_PATIENT_DOB;
                this.TDL_PATIENT_FIRST_NAME = ExpMest.TDL_PATIENT_FIRST_NAME;
                this.TDL_PATIENT_GENDER_NAME = ExpMest.TDL_PATIENT_GENDER_NAME;
                this.TDL_PATIENT_LAST_NAME = ExpMest.TDL_PATIENT_LAST_NAME;
                this.TDL_PATIENT_NAME = ExpMest.TDL_PATIENT_NAME;
            }

            if (_expMestMaterials != null && _expMestMaterials.Count > 0)
            {
                this.REQ_LOGINNAME = _expMestMaterials[0].REQ_LOGINNAME;
                this.REQ_USERNAME = _expMestMaterials[0].REQ_USERNAME;
            }
        }
    }
}
