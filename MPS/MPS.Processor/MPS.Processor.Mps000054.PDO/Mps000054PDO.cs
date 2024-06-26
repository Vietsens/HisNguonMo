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

using MPS;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPS.ProcessorBase.Core;
using MPS.ProcessorBase;
using MPS.Processor.Mps000054.PDO;
using MOS.SDO;

namespace MPS.Processor.Mps000054.PDO
{
    public partial class Mps000054PDO : RDOBase
    {
        public Mps000054PDO(
            PatientADO patient,
            PatyAlterBhytADO PatyAlterBhyt,
            TreatmentADO currentHisTreatment,
            HIS_DHST dhsts,
            V_HIS_PRESCRIPTION serviceReq,
            List<ExeExpMestMedicineSDO> expMestMedicines,
            string medi_stock_name,
            string serviceReqCode
            )
        {
            try
            {
                this.Patient = patient;
                this.PatyAlterBhyt = PatyAlterBhyt;
                this.currentHisTreatment = currentHisTreatment;
                this.dhsts = dhsts;
                this.serviceReq = serviceReq;
                this.expMestMedicines = expMestMedicines;
                this.medi_stock_name = medi_stock_name;
                this.serviceReqCode = serviceReqCode;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
