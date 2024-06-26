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

namespace HIS.Desktop.Plugins.KskContract.Validation
{
    class FromDateToDateValidationRule : DevExpress.XtraEditors.DXErrorProvider.ValidationRule
    {
        internal DevExpress.XtraEditors.DateEdit dtFromTime;
        internal DevExpress.XtraEditors.DateEdit dtToTime;

        public override bool Validate(System.Windows.Forms.Control control, object value)
        {
            bool valid = false;
            long? fromTime = null;
            long? toTime = null;
            try
            {
                if (dtFromTime == null || dtToTime == null)
                    return valid;

                if (dtFromTime.EditValue != null && dtFromTime.DateTime != DateTime.MinValue && dtToTime.EditValue != null && dtToTime.DateTime != DateTime.MinValue)
                {
                    fromTime = Inventec.Common.TypeConvert.Parse.ToInt64(
                        Convert.ToDateTime(dtFromTime.EditValue).ToString("yyyyMMdd") + "000000");

                    toTime = Inventec.Common.TypeConvert.Parse.ToInt64(
                        Convert.ToDateTime(dtToTime.EditValue).ToString("yyyyMMdd")+"235959");
                    if (fromTime > toTime)
                    {
                        valid = false;
                        this.ErrorText = "Ngày hiệu lực phải bé hơn (hoặc bằng) ngày hết hạn";
                        this.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
                        return valid;
                    }
                }

                valid = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return valid;
        }
    }
}
