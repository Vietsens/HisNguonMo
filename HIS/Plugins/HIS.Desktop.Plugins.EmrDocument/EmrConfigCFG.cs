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
using EMR.Filter;
using HIS.Desktop.ApiConsumer;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.EmrDocument
{
    class EmrConfigCFG
    {
        private static List<EMR.EFMODEL.DataModels.EMR_CONFIG> emrConfigs;
        public static List<EMR.EFMODEL.DataModels.EMR_CONFIG> EmrConfigs
        {
            get
            {
                if (emrConfigs == null)
                {
                    CommonParam paramCommon = new CommonParam();
                    EmrConfigFilter filter = new EmrConfigFilter();
                    filter.IS_ACTIVE = IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE;
                    var rs = ApiConsumers.EmrConsumer.Get<Inventec.Core.ApiResultObject<List<EMR.EFMODEL.DataModels.EMR_CONFIG>>>(EMR.URI.EmrConfig.GET, paramCommon, filter);
                    emrConfigs = rs != null && rs.Data != null ? rs.Data : null;
                }
                return emrConfigs;
            }
            set
            {
                emrConfigs = value;
            }
        }
    }
}
