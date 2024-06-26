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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.ExpMestHcsCreate.Base
{
    public class ImpDetailADO
    {
        public long ID { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string SERVICE_UNIT_NAME { get; set; }
        public decimal AMOUNT { get; set; }
        public string PACKAGE_NUMBER { get; set; }
        public bool IsMedicine { get; set; }


        public ImpDetailADO()
        {
        }

        public ImpDetailADO(V_HIS_IMP_MEST_MEDICINE data)
        {
            if (data != null)
            {
                this.ID = data.MEDICINE_TYPE_ID;
                this.AMOUNT = data.AMOUNT;
                this.CODE = data.MEDICINE_TYPE_CODE;
                this.NAME = data.MEDICINE_TYPE_NAME;
                this.SERVICE_UNIT_NAME = data.SERVICE_UNIT_NAME;
                this.PACKAGE_NUMBER = data.PACKAGE_NUMBER;
                this.IsMedicine = true;
            }
        }

        public ImpDetailADO(V_HIS_IMP_MEST_MATERIAL data)
        {
            if (data != null)
            {
                this.ID = data.MATERIAL_TYPE_ID;
                this.AMOUNT = data.AMOUNT;
                this.CODE = data.MATERIAL_TYPE_CODE;
                this.NAME = data.MATERIAL_TYPE_NAME;
                this.SERVICE_UNIT_NAME = data.SERVICE_UNIT_NAME;
                this.PACKAGE_NUMBER = data.PACKAGE_NUMBER;
                this.IsMedicine = false;
            }
        }
    }
}
