﻿using HIS.Desktop.Plugins.MonitorMediStockDataError.MonitorMediStockDataError;
using Inventec.Core;
using Inventec.Desktop.Common.Modules;
using Inventec.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.MonitorMediStockDataError
{
    [ExtensionOf(typeof(DesktopRootExtensionPoint),
       "HIS.Desktop.Plugins.MonitorMediStockDataError",
       "Thiết lập",
       "Common",
       14,
       "phe-duyet.png",
       "A",
       Module.MODULE_TYPE_ID__UC,
       true,
       true
       )
    ]

    class MonitorMediStockDataErrorProcessor : ModuleBase, IDesktopRoot
    {
          CommonParam param;
        public MonitorMediStockDataErrorProcessor()
        {
            param = new CommonParam();
        }
        public MonitorMediStockDataErrorProcessor(CommonParam paramBusiness)          
        {
            param = (paramBusiness != null ? paramBusiness : new CommonParam());
        }

        public object Run(object[] args)
        {
            object result = null;
            try
            {
                IMonitorMediStockDataError behavior = MonitorMediStockDataErrorFactory.MakeIExecuteRoom(param, args);
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
            return true;
        }
    }
}
