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
using AutoMapper;
using DevExpress.XtraEditors.Controls;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His.UC.UCHein.ControlProcess
{
    public class HeinCardProcess
    {
        public static void LoadDataToCombo(List<MOS.EFMODEL.DataModels.HIS_PATIENT_TYPE_ALTER> patientTypeAlters, DevExpress.XtraEditors.LookUpEdit cboSoThe)
        {
            try
            {
                cboSoThe.Properties.BeginUpdate();
                cboSoThe.Properties.DataSource = patientTypeAlters;
                cboSoThe.Properties.DisplayMember = "RENDERER_HEIN_CARD_NUMBER";
                cboSoThe.Properties.ValueMember = "ID";
                cboSoThe.Properties.ForceInitialize();
                cboSoThe.Properties.Columns.Clear();
                cboSoThe.Properties.Columns.Add(new LookUpColumnInfo("RENDERER_HEIN_CARD_NUMBER", "", 150));
                cboSoThe.Properties.Columns.Add(new LookUpColumnInfo("RENDERER_FROM_DATE_TODATE", "", 150));
                cboSoThe.Properties.Columns.Add(new LookUpColumnInfo("HEIN_MEDI_ORG_NAME", "", 150));
                cboSoThe.Properties.ShowHeader = false;
                cboSoThe.Properties.ImmediatePopup = true;
                cboSoThe.Properties.DropDownRows = 5;
                cboSoThe.Properties.PopupWidth = 500;
                cboSoThe.Properties.EndUpdate();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
        public static string ProcessHeinCardNumber(string HEIN_CARD_NUMBER)
        {
            string rs = null;
            try
            {
                if (HEIN_CARD_NUMBER != null)
                {
                    string chkhong = "", chmot = "", chhai = "", chba = "", chbon = "", chnam = "";
                    try
                    {
                        chkhong = HEIN_CARD_NUMBER.Substring(0, 2);
                        chmot = HEIN_CARD_NUMBER.Substring(2, 1);
                        chhai = HEIN_CARD_NUMBER.Substring(3, 2);
                        chba = HEIN_CARD_NUMBER.Substring(5, 2);
                        chbon = HEIN_CARD_NUMBER.Substring(7, 3);
                        chnam = HEIN_CARD_NUMBER.Substring(10, 5);
                    }
                    catch (Exception exx)
                    {
                        LogSystem.Warn("Gan chuoi RENDERER_HEIN_CARD_NUMBER the BHYT loi", exx);
                    }

                    rs = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", chkhong, chmot, chhai, chba, chbon, chnam);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            return rs;
}
    }
}
