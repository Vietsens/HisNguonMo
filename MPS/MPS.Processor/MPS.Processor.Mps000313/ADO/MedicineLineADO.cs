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

namespace MPS.Processor.Mps000313.ADO
{
    public class MedicineLineADO
    {
        public long? ID { get; set; }
        public int ROW_POS { get; set; }
        public string MEDICINE_LINE_CODE { get; set; }
        public string MEDICINE_LINE_NAME { get; set; }
        public decimal? TOTAL_PRICE_MEDICINE_LINE { get; set; }
        public decimal? TOTAL_HEIN_PRICE_MEDICINE_LINE { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_MEDICINE_LINE { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_SELF_MEDICINE_LINE { get; set; }
        public long? HEIN_SERVICE_TYPE_ID { get; set; }
        public long? REMEDY_COUNT { get; set; }
        public string KEY_PATY_ALTER { get; set; }
    }
}
