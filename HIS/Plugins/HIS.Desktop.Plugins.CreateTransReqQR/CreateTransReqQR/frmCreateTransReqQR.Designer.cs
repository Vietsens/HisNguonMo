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
namespace HIS.Desktop.Plugins.CreateTransReqQR.CreateTransReqQR
{
    partial class frmCreateTransReqQR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.cboCom = new DevExpress.XtraEditors.GridLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.PRINT = new DevExpress.XtraBars.BarButtonItem();
            this.NEW = new DevExpress.XtraBars.BarButtonItem();
            this.CREATE = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblStt = new DevExpress.XtraEditors.LabelControl();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.DropDownButton();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.pbQr = new DevExpress.XtraEditors.PictureEdit();
            this.panelControlTreeSereServ = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layouc = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.timerInitForm = new System.Windows.Forms.Timer(this.components);
            this.timerReloadTransReq = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTreeSereServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layouc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnConnect);
            this.layoutControl1.Controls.Add(this.cboCom);
            this.layoutControl1.Controls.Add(this.lblStt);
            this.layoutControl1.Controls.Add(this.btnCreate);
            this.layoutControl1.Controls.Add(this.btnNew);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.lblAmount);
            this.layoutControl1.Controls.Add(this.pbQr);
            this.layoutControl1.Controls.Add(this.panelControlTreeSereServ);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 29);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1097, 517);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(871, 467);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 22);
            this.btnConnect.StyleController = this.layoutControl1;
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboCom
            // 
            this.cboCom.Location = new System.Drawing.Point(754, 467);
            this.cboCom.MenuManager = this.barManager1;
            this.cboCom.Name = "cboCom";
            this.cboCom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.cboCom.Properties.NullText = "";
            this.cboCom.Properties.View = this.gridLookUpEdit1View;
            this.cboCom.Size = new System.Drawing.Size(113, 20);
            this.cboCom.StyleController = this.layoutControl1;
            this.cboCom.TabIndex = 12;
            this.cboCom.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboCom_ButtonClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.PRINT,
            this.NEW,
            this.CREATE});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.PRINT),
            new DevExpress.XtraBars.LinkPersistInfo(this.NEW),
            new DevExpress.XtraBars.LinkPersistInfo(this.CREATE)});
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // PRINT
            // 
            this.PRINT.Caption = "barButtonItem1";
            this.PRINT.Id = 0;
            this.PRINT.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.PRINT.Name = "PRINT";
            this.PRINT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PRINT_ItemClick);
            // 
            // NEW
            // 
            this.NEW.Caption = "barButtonItem2";
            this.NEW.Id = 1;
            this.NEW.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.NEW.Name = "NEW";
            this.NEW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NEW_ItemClick);
            // 
            // CREATE
            // 
            this.CREATE.Caption = "barButtonItem3";
            this.CREATE.Id = 2;
            this.CREATE.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.CREATE.Name = "CREATE";
            this.CREATE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CREATE_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1097, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Size = new System.Drawing.Size(1097, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 517);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1097, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 517);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblStt
            // 
            this.lblStt.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStt.Location = new System.Drawing.Point(754, 443);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(98, 20);
            this.lblStt.StyleController = this.layoutControl1;
            this.lblStt.TabIndex = 10;
            this.lblStt.Text = "Đang chờ";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1000, 493);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(95, 22);
            this.btnCreate.StyleController = this.layoutControl1;
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Tạo (Ctrl S)";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(889, 493);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(107, 22);
            this.btnNew.StyleController = this.layoutControl1;
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Mới (Ctrl N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(785, 493);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "In (Ctrl P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAmount.Location = new System.Drawing.Point(941, 443);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblAmount.Size = new System.Drawing.Size(154, 20);
            this.lblAmount.StyleController = this.layoutControl1;
            this.lblAmount.TabIndex = 6;
            // 
            // pbQr
            // 
            this.pbQr.Location = new System.Drawing.Point(677, 50);
            this.pbQr.Name = "pbQr";
            this.pbQr.Properties.NullText = " ";
            this.pbQr.Properties.Padding = new System.Windows.Forms.Padding(15);
            this.pbQr.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbQr.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pbQr.Size = new System.Drawing.Size(410, 341);
            this.pbQr.StyleController = this.layoutControl1;
            this.pbQr.TabIndex = 5;
            // 
            // panelControlTreeSereServ
            // 
            this.panelControlTreeSereServ.Location = new System.Drawing.Point(2, 2);
            this.panelControlTreeSereServ.Name = "panelControlTreeSereServ";
            this.panelControlTreeSereServ.Size = new System.Drawing.Size(663, 513);
            this.panelControlTreeSereServ.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layouc,
            this.layoutControlItem8,
            this.layoutControlItem7,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1097, 517);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControlTreeSereServ;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(667, 517);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pbQr;
            this.layoutControlItem2.Location = new System.Drawing.Point(667, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 50, 50);
            this.layoutControlItem2.Size = new System.Drawing.Size(430, 441);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.lblAmount;
            this.layoutControlItem3.Location = new System.Drawing.Point(854, 441);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem3.Text = "Số tiền:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnPrint;
            this.layoutControlItem4.Location = new System.Drawing.Point(783, 491);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnNew;
            this.layoutControlItem5.Location = new System.Drawing.Point(887, 491);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(111, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCreate;
            this.layoutControlItem6.Location = new System.Drawing.Point(998, 491);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(99, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(667, 491);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(116, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layouc
            // 
            this.layouc.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layouc.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layouc.Control = this.lblStt;
            this.layouc.Location = new System.Drawing.Point(667, 441);
            this.layouc.Name = "layouc";
            this.layouc.Size = new System.Drawing.Size(187, 24);
            this.layouc.Text = "Trạng thái:";
            this.layouc.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layouc.TextSize = new System.Drawing.Size(80, 20);
            this.layouc.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem8.Control = this.cboCom;
            this.layoutControlItem8.Location = new System.Drawing.Point(667, 465);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(202, 26);
            this.layoutControlItem8.Text = "Màn hình QR:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnConnect;
            this.layoutControlItem7.Location = new System.Drawing.Point(869, 465);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(116, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(985, 465);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(112, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // timerReloadTransReq
            // 
            this.timerReloadTransReq.Interval = 10000;
            this.timerReloadTransReq.Tick += new System.EventHandler(this.timerReloadTransReq_Tick);
            // 
            // frmCreateTransReqQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 546);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmCreateTransReqQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo QR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateTransReqQR_FormClosing);
            this.Load += new System.EventHandler(this.frmCreateTransReqQR_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTreeSereServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layouc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControlTreeSereServ;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.PictureEdit pbQr;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.DropDownButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem PRINT;
        private DevExpress.XtraBars.BarButtonItem NEW;
        private DevExpress.XtraBars.BarButtonItem CREATE;
        private System.Windows.Forms.Timer timerInitForm;
        private System.Windows.Forms.Timer timerReloadTransReq;
        private DevExpress.XtraEditors.LabelControl lblStt;
        private DevExpress.XtraLayout.LayoutControlItem layouc;
        private DevExpress.XtraEditors.GridLookUpEdit cboCom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
