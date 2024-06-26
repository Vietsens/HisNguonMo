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
using AutoMapper;
using HIS.Desktop.LocalStorage.LocalData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS.Desktop.Plugins.CareCreate
{
    public partial class CareCreate : HIS.Desktop.Utility.FormBase
    {
        private void SaveCareProcess()
        {
            try
            {
                MOS.EFMODEL.DataModels.HIS_CARE hisCare = new MOS.EFMODEL.DataModels.HIS_CARE();

                MOS.EFMODEL.DataModels.HIS_DHST hisDHST = new MOS.EFMODEL.DataModels.HIS_DHST();

                if (this.action == GlobalVariables.ActionEdit)
                {
                    Mapper.CreateMap<MOS.EFMODEL.DataModels.HIS_CARE, MOS.EFMODEL.DataModels.HIS_CARE>();
                    hisCare = Mapper.Map<MOS.EFMODEL.DataModels.HIS_CARE, MOS.EFMODEL.DataModels.HIS_CARE>(this.hisCareCurrent);

                    Mapper.CreateMap<MOS.EFMODEL.DataModels.HIS_DHST, MOS.EFMODEL.DataModels.HIS_DHST>();
                    hisDHST = Mapper.Map<MOS.EFMODEL.DataModels.HIS_DHST, MOS.EFMODEL.DataModels.HIS_DHST>(this.currentDhst);
                }
                ProcessDataCare(ref hisCare);
                SaveDataCare(hisCare);

                ProcessDataDHST(ref hisDHST);
                SaveDataDHST(hisDHST);
                           
                
                
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
