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

namespace HIS.Desktop.Plugins.ServiceExecute.ADO
{
    class ThreadSereServADO
    {
        public List<HIS_SERE_SERV> ListHisSereServ { get; set; }//out
        public Dictionary<long, List<HIS_SERE_SERV_BILL>> DictHisSersServBill { get; set; }//out, key: SERE_SERV_ID
        public Dictionary<long, List<HIS_SERE_SERV_DEPOSIT>> DictHisSereServDeposit { get; set; }//out, key: SERE_SERV_ID
        public Dictionary<long, List<HIS_SESE_DEPO_REPAY>> ListHisSeseDepoRepay { get; set; }//out, Key:SERE_SERV_DEPOSIT_ID
    }
}
