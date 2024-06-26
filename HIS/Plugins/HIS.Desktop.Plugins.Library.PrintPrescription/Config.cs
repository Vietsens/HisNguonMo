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

namespace HIS.Desktop.Plugins.Library.PrintPrescription
{
    class Config
    {
        internal const string mps = "HIS.Desktop.Plugins.Library.PrintPrescription.Mps";

        internal const string CONFIG_KEY__PRINT_BARCODE_NO_ZERO = "HIS.Desktop.Library.Print.BacodeNoZero";

        internal const string TAKE_INFO_TT_CLS = "HIS.DESKTOP.PRINT_PRESCRIPTION.TAKE_INFO_TT_CLS";

        internal const string KEY_IsPrintPrescriptionNoThread = "HIS.Desktop.IsPrintPrescriptionNoThread";

        internal const string ASSIGN_PRESCRIPTION_ODER_OPTION = "HIS.Desktop.Plugins.AssignPrescription.OderOption";
   
        internal static bool IsmergePrint
        {
            get
            {
                return HIS.Desktop.LocalStorage.HisConfig.HisConfigs.Get<string>("HIS.Desktop.Plugins.OptionMergePrint.Ismerge") == "1";
            }
        }
    }
}
