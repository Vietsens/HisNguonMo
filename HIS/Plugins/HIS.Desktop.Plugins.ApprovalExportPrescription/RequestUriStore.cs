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

namespace HIS.Desktop.Plugins.ApprovalExportPrescription
{
    class RequestUriStore
    {
        internal const string HIS_PRESCRIPTION_GET_WITH_DETAIL = "api/HisPrescription/GetWithDetail";

        internal const string HIS_EXP_MEST_MEDICINE_GET = "api/HisExpMestMedicine/Get";
        internal const string HIS_EXP_MEST_MATERIAL_GET = "api/HisExpMestMaterial/Get";
        internal const string HIS_SERVICE_REQ_GET = "api/HisServiceReq/Get";
        internal const string HIS_EXP_MEST_GET = "api/HisExpMest/Get";

        internal const string HIS_EXP_MEST_APPROVA = "api/HisExpMest/Approve";
    }
}
