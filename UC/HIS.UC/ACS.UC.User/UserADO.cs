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
using ACS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.UC.User
{
    public class UserADO : ACS.EFMODEL.DataModels.ACS_USER
    {
        public UserADO() { }
        public UserADO(ACS_USER data)
        {
            if (data != null)
            {
                Inventec.Common.Mapper.DataObjectMapper.Map<UserADO>(this, data);
            }
        }
        public bool checkMedi { get; set; }
        public bool isKeyChooseMedi { get; set; }
        public bool radioMedi { get; set; }
        public decimal? EXPEND_PRICE_STR { get; set; }
        public decimal EXPEND_AMOUNT_STR { get; set; }
    }
}
