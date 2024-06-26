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

namespace HIS.UC.ExamServiceAdd.ADO
{
    public class ExamServiceAddInitADO
    {
        public long? ServiceReqId { get; set; }
        public long? roomId { get; set; }
        public bool IsMainExam { get; set; }
        public long? treatmentId { get; set; }
        public long? FinishTime { get; set; }// thoi gian ket thuc kham
        public long? StartTime { get; set; }
        public long? InTime { get; set; }
        public long? OutTime { get; set; } // TG ket thuc dieu tri
        public bool IsNotRequiredFee { get; set; }
        public bool IsBlockNumOrder { get; set; }
        public long? DefaultIdRoom { get; set; }
        public long? NumOrderBlockId { get; set; }
        public string AppointmentDesc { get; set; }
        public long? AppointmentTime { get; set; }
        public string Note { get; set; }
    }
}
