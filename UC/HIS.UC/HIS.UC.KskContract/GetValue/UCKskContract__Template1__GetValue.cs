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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOS.Filter;
using Inventec.Core;
using Inventec.Common.Adapter;
using MOS.EFMODEL.DataModels;
using HIS.Desktop.ApiConsumer;
using Inventec.Common.Controls.EditorLoader;
using HIS.UC.KskContract.ADO;

namespace HIS.UC.KskContract.Run
{
    public partial class UCKskContract__Template1 : UserControl
    {
        public object GetValue()
        {
            object result = null;
            try
            {
                KskContractOutput outPut = new KskContractOutput();
                if (cboKskContract.EditValue != null)
                {
                    V_HIS_KSK_CONTRACT kskContract = listKskContract.FirstOrDefault(o => o.ID == Inventec.Common.TypeConvert.Parse.ToInt64(cboKskContract.EditValue.ToString()));
                    outPut.KskContract = kskContract;
                }

                outPut.IsVali = true;
                this.positionHandle = -1;
                if (!dxValidationProvider1.Validate())
                {
                    outPut.IsVali = false;
                }
                result = outPut;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }
    }
}
