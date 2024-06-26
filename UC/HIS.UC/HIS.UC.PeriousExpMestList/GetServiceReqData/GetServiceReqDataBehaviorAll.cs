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
using HIS.UC.PeriousExpMestList.ADO;
using HIS.UC.PeriousExpMestList.GetServiceReqData;
using HIS.UC.PeriousExpMestList.Reload;
using HIS.UC.PeriousExpMestList.Run;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS.UC.PeriousExpMestList.GetServiceReqData
{
    class GetServiceReqDataBehaviorAll : IGetServiceReqDataAll
    {
        UserControl entity;

        internal GetServiceReqDataBehaviorAll(UserControl control)
            : base()
        {
            this.entity = control;
        }

        List<MOS.EFMODEL.DataModels.V_HIS_SERVICE_REQ_7> IGetServiceReqDataAll.Run()
        {
            List<MOS.EFMODEL.DataModels.V_HIS_SERVICE_REQ_7> result = null;
            try
            {
                if (this.entity.GetType() == typeof(UC_PeriousExpMestList))
                {
                    result = ((UC_PeriousExpMestList)this.entity).GetServiceReqDataAll();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
