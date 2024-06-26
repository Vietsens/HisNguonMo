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
using HIS.Desktop.LocalStorage.HisConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.HisRadixChangeCabinetList.Base
{
    class HisConfigCFG
    {
        /// <summary>
        /// Phải thanh toán mới cho phép thực xuất phiếu xuất bán
        /// </summary>
        private const string CONFIG_KEY__EXP_MEST_SALE__MUST_BILL = "MOS.EXP_MEST.EXPORT_SALE.MUST_BILL";
        private const string CONFIG_KEY__ALLOW_THER_LOGINNAME = "HIS.HIS_TRANSACTION.TRANSACTION_CANCEL.ALLOW_OTHER_LOGINNAME";

        internal static bool EXPORT_SALE__MUST_BILL;
        internal static bool CANCEL_ALLOW_OTHER_LOGINNAME;

        internal static void LoadConfig()
        {
            try
            {
                EXPORT_SALE__MUST_BILL = HisConfigs.Get<string>(CONFIG_KEY__EXP_MEST_SALE__MUST_BILL) == "1";
                CANCEL_ALLOW_OTHER_LOGINNAME = HisConfigs.Get<string>(CONFIG_KEY__ALLOW_THER_LOGINNAME) == "1";
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
