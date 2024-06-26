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
using Inventec.Desktop.Core;
using Inventec.Desktop.Common.Modules;
using Inventec.Core;
using SAR.Desktop.Plugins.SarImportReportTemplate.SarImportReportTemplate;

namespace SAR.Desktop.Plugins.SarImportReportTemplate
{
     [ExtensionOf(typeof(DesktopRootExtensionPoint),
       "SAR.Desktop.Plugins.SarImportReportTemplate",
       "Import",
       "Common",
       14,
       "bao-cao.png",
       "A",
       Module.MODULE_TYPE_ID__FORM,
       true,
       true
       )
    ]
    public class SarImportReportTemplateProcessor : ModuleBase, IDesktopRoot
    {
        CommonParam param;
        public SarImportReportTemplateProcessor()
        {
            param = new CommonParam();
        }
        public SarImportReportTemplateProcessor(CommonParam paramBusiness)
        {
            param = (paramBusiness != null ? paramBusiness : new CommonParam());
        }

        public object Run(object[] args)
        {
            object result = null;
            try
            {
                IImportReportTemplate behavior = ImportReportTemplateFactory.MakeIHisImportBed(param, args);
                result = behavior != null ? (behavior.Run()) : null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        public override bool IsEnable()
        {
            bool result = false;
            try
            {
                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }

            return result;
        }
    }
}

