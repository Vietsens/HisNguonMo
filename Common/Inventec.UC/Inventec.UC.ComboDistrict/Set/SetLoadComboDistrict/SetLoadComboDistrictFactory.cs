﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventec.UC.ComboDistrict.Set.SetLoadComboDistrict
{
    class SetLoadComboDistrictFactory
    {
        internal static ISetLoadComboDistrict MakeISetLoadComboDistrict()
        {
            ISetLoadComboDistrict result = null;
            try
            {
                result = new SetLoadComboDistrict();
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
