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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UC.FormType.Loader
{
    class ServiceTypeLoader
    {
        public static void LoadDataToCombo(DevExpress.XtraEditors.GridLookUpEdit cboServiceType)
        {
            try
            {
                cboServiceType.Properties.DataSource = Config.HisFormTypeConfig.HisServiceTypes;
                cboServiceType.Properties.DisplayMember = "SERVICE_TYPE_NAME";
                cboServiceType.Properties.ValueMember = "ID";

                cboServiceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cboServiceType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                cboServiceType.Properties.ImmediatePopup = true;
                cboServiceType.ForceInitialize();
                cboServiceType.Properties.View.Columns.Clear();
                cboServiceType.Properties.View.OptionsView.ShowColumnHeaders = false;

                GridColumn aColumnCode = cboServiceType.Properties.View.Columns.AddField("SERVICE_TYPE_CODE");
                aColumnCode.Caption = "Mã";
                aColumnCode.Visible = true;
                aColumnCode.VisibleIndex = 1;
                aColumnCode.Width = 50;

                GridColumn aColumnName = cboServiceType.Properties.View.Columns.AddField("SERVICE_TYPE_NAME");
                aColumnName.Caption = "Tên";
                aColumnName.Visible = true;
                aColumnName.VisibleIndex = 2;
                aColumnName.Width = 100;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public static void LoadDataToCombo(DevExpress.XtraEditors.GridLookUpEdit cboServiceType, List<MOS.EFMODEL.DataModels.HIS_SERVICE_TYPE> listData)
        {
            try
            {
                cboServiceType.Properties.DataSource = listData;
                cboServiceType.Properties.DisplayMember = "SERVICE_TYPE_NAME";
                cboServiceType.Properties.ValueMember = "ID";

                cboServiceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cboServiceType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                cboServiceType.Properties.ImmediatePopup = true;
                cboServiceType.ForceInitialize();
                cboServiceType.Properties.View.Columns.Clear();
                cboServiceType.Properties.View.OptionsView.ShowColumnHeaders = false;

                GridColumn aColumnCode = cboServiceType.Properties.View.Columns.AddField("SERVICE_TYPE_CODE");
                aColumnCode.Caption = "Mã";
                aColumnCode.Visible = true;
                aColumnCode.VisibleIndex = 1;
                aColumnCode.Width = 50;

                GridColumn aColumnName = cboServiceType.Properties.View.Columns.AddField("SERVICE_TYPE_NAME");
                aColumnName.Caption = "Tên";
                aColumnName.Visible = true;
                aColumnName.VisibleIndex = 2;
                aColumnName.Width = 100;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        internal static void LoadDataToCombo(DevExpress.XtraEditors.LookUpEdit cboServiceType)
        {
            try
            {
                cboServiceType.Properties.DataSource = Config.HisFormTypeConfig.HisServiceTypes;
                cboServiceType.Properties.DisplayMember = "SERVICE_TYPE_NAME";
                cboServiceType.Properties.ValueMember = "ID";
                cboServiceType.Properties.ForceInitialize();
                cboServiceType.Properties.Columns.Clear();
                cboServiceType.Properties.Columns.Add(new LookUpColumnInfo("SERVICE_TYPE_CODE", "", 100));
                cboServiceType.Properties.Columns.Add(new LookUpColumnInfo("SERVICE_TYPE_NAME", "", 200));
                cboServiceType.Properties.ShowHeader = false;
                cboServiceType.Properties.ImmediatePopup = true;
                cboServiceType.Properties.DropDownRows = 10;
                cboServiceType.Properties.PopupWidth = 300;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        internal static void LoadDataToCombo(DevExpress.XtraEditors.LookUpEdit cboServiceType, List<MOS.EFMODEL.DataModels.HIS_SERVICE_TYPE> listData)
        {
            try
            {
                cboServiceType.Properties.DataSource = listData;
                cboServiceType.Properties.DisplayMember = "SERVICE_TYPE_NAME";
                cboServiceType.Properties.ValueMember = "ID";
                cboServiceType.Properties.ForceInitialize();
                cboServiceType.Properties.Columns.Clear();
                cboServiceType.Properties.Columns.Add(new LookUpColumnInfo("SERVICE_TYPE_CODE", "", 100));
                cboServiceType.Properties.Columns.Add(new LookUpColumnInfo("SERVICE_TYPE_NAME", "", 200));
                cboServiceType.Properties.ShowHeader = false;
                cboServiceType.Properties.ImmediatePopup = true;
                cboServiceType.Properties.DropDownRows = 10;
                cboServiceType.Properties.PopupWidth = 300;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
