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

namespace HIS.UC.RoomExamService.SetValueByPatient
{
    class SetValueByPatientBehaviorFactory
    {
        internal static ISetValueByPatient MakeISetValueByPatient(object data, object value)
        {
            ISetValueByPatient result = null;
            try
            {
                if (data is UCRoomExamService && value is V_HIS_PATIENT)
                {
                    result = new SetValueByPatientBehavior((UCRoomExamService)data, (V_HIS_PATIENT)value);
                }
                else if (data is UCRoomExamService1 && value is V_HIS_PATIENT)
                {
                    result = new SetValueByPatient11Behavior((UCRoomExamService1)data, (V_HIS_PATIENT)value);
                }
                else if (data is UCRoomExamService2 && value is V_HIS_PATIENT)
                {
                    result = new SetValueByPatient01Behavior((UCRoomExamService2)data, (V_HIS_PATIENT)value);
                }
                if (result == null) throw new NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                Inventec.Common.Logging.LogSystem.Error("Factory khong khoi tao duoc doi tuong." + data.GetType().ToString() + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), ex);
                result = null;
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
