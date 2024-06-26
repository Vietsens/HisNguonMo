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
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000066.PDO
{
	public partial class Mps000066PDO : RDOBase
	{
		public PatientADO Patient { get; set; }
		public PatyAlterBhytADO PatyAlterBhyt { get; set; }
		public DepartmentTranADO departmentTran { get; set; }
		public List<HIS_DEBATE_USER> lstHisDebateUser { get; set; }
		public List<HIS_DEBATE_USER> lstHisDebateUserTGia { get; set; }
		public HIS_DEBATE HisDebateRow { get; set; }
		public string bedRoomName;
	}

	public class PatientADO : V_HIS_PATIENT
	{
		public string AGE { get; set; }
		public string DOB_STR { get; set; }
		public string CMND_DATE_STR { get; set; }
		public string DOB_YEAR { get; set; }
		public string GENDER_MALE { get; set; }
		public string GENDER_FEMALE { get; set; }

		public PatientADO()
		{

		}

		public PatientADO(V_HIS_PATIENT data)
		{
			try
			{
				if (data != null)
				{
					System.Reflection.PropertyInfo[] pi = Inventec.Common.Repository.Properties.Get<V_HIS_PATIENT>();
					foreach (var item in pi)
					{
						item.SetValue(this, item.GetValue(data));
					}

					this.AGE = AgeUtil.CalculateFullAge(this.DOB);
					this.DOB_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(this.DOB);
					string temp = this.DOB.ToString();
					if (temp != null && temp.Length >= 8)
					{
						this.DOB_YEAR = temp.Substring(0, 4);
					}
				}
			}
			catch (Exception ex)
			{
				Inventec.Common.Logging.LogSystem.Error(ex);
			}
		}
	}
	public class PatyAlterBhytADO : V_HIS_PATY_ALTER_BHYT
	{
		public string PATIENT_TYPE_NAME { get; set; }
		public string HEIN_CARD_NUMBER_SEPARATE { get; set; }
		public string IS_HEIN { get; set; }
		public string IS_VIENPHI { get; set; }
		public string STR_HEIN_CARD_FROM_TIME { get; set; }
		public string STR_HEIN_CARD_TO_TIME { get; set; }
		public string RATIO { get; set; }
		public string HEIN_CARD_NUMBER_1 { get; set; }
		public string HEIN_CARD_NUMBER_2 { get; set; }
		public string HEIN_CARD_NUMBER_3 { get; set; }
		public string HEIN_CARD_NUMBER_4 { get; set; }
		public string HEIN_CARD_NUMBER_5 { get; set; }
		public string HEIN_CARD_NUMBER_6 { get; set; }
		public long TIME_IN_TREATMENT { get; set; }
	}

	public class DepartmentTranADO : V_HIS_DEPARTMENT_TRAN
	{
		public string OPEN_TIME_SEPARATE_STR { get; set; }
		public string OPEN_DATE_SEPARATE_STR { get; set; }
		public string CLOSE_TIME_SEPARATE_STR { get; set; }
		public string CLOSE_TIME_SEPARATE_FROM_TIME_STR { get; set; }
		public string CLOSE_DATE_SEPARATE_FROM_TIME_STR { get; set; }
		public string CLOSE_DATE_SEPARATE_STR { get; set; }
		public string DEPARTMENT_NAME_CLOSE { get; set; }
	}
}
