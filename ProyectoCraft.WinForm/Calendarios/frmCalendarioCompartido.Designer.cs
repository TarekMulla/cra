namespace ProyectoCraft.WinForm.Calendarios
{
    partial class frmCalendarioCompartido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendarioCompartido));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.viewNavigatorBar1 = new DevExpress.XtraScheduler.UI.ViewNavigatorBar();
            this.viewNavigatorBackwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem();
            this.viewNavigatorForwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem();
            this.viewNavigatorTodayItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem();
            this.viewNavigatorZoomInItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem();
            this.viewNavigatorZoomOutItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem();
            this.MenuCalendario = new DevExpress.XtraBars.BarButtonItem();
            this.viewSelectorBar1 = new DevExpress.XtraScheduler.UI.ViewSelectorBar();
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.viewNavigator1 = new DevExpress.XtraScheduler.UI.ViewNavigator(this.components);
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.viewSelector1 = new DevExpress.XtraScheduler.UI.ViewSelector(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.resourcesCheckedListBoxControl1 = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSelector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentDeleting);
            this.schedulerStorage1.AppointmentInserting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentInserting);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.viewNavigatorBar1,
            this.viewSelectorBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.viewNavigatorBackwardItem1,
            this.viewNavigatorForwardItem1,
            this.viewNavigatorTodayItem1,
            this.viewNavigatorZoomInItem1,
            this.viewNavigatorZoomOutItem1,
            this.viewSelectorItem1,
            this.viewSelectorItem2,
            this.viewSelectorItem3,
            this.viewSelectorItem4,
            this.viewSelectorItem5,
            this.MenuCalendario});
            this.barManager1.MaxItemId = 21;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // viewNavigatorBar1
            // 
            this.viewNavigatorBar1.DockCol = 1;
            this.viewNavigatorBar1.DockRow = 0;
            this.viewNavigatorBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.viewNavigatorBar1.FloatLocation = new System.Drawing.Point(1624, 214);
            this.viewNavigatorBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.viewNavigatorBackwardItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewNavigatorForwardItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewNavigatorTodayItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewNavigatorZoomInItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewNavigatorZoomOutItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuCalendario)});
            this.viewNavigatorBar1.Offset = 361;
            // 
            // viewNavigatorBackwardItem1
            // 
            this.viewNavigatorBackwardItem1.Caption = "Retroceder";
            this.viewNavigatorBackwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.Glyph")));
            this.viewNavigatorBackwardItem1.GroupIndex = 1;
            this.viewNavigatorBackwardItem1.Id = 10;
            this.viewNavigatorBackwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.LargeGlyph")));
            this.viewNavigatorBackwardItem1.Name = "viewNavigatorBackwardItem1";
            // 
            // viewNavigatorForwardItem1
            // 
            this.viewNavigatorForwardItem1.Caption = "Avanzar";
            this.viewNavigatorForwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.Glyph")));
            this.viewNavigatorForwardItem1.GroupIndex = 1;
            this.viewNavigatorForwardItem1.Id = 11;
            this.viewNavigatorForwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.LargeGlyph")));
            this.viewNavigatorForwardItem1.Name = "viewNavigatorForwardItem1";
            // 
            // viewNavigatorTodayItem1
            // 
            this.viewNavigatorTodayItem1.Caption = "Hoy";
            this.viewNavigatorTodayItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.Glyph")));
            this.viewNavigatorTodayItem1.GroupIndex = 1;
            this.viewNavigatorTodayItem1.Id = 12;
            this.viewNavigatorTodayItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.LargeGlyph")));
            this.viewNavigatorTodayItem1.Name = "viewNavigatorTodayItem1";
            // 
            // viewNavigatorZoomInItem1
            // 
            this.viewNavigatorZoomInItem1.Caption = "Acercar";
            this.viewNavigatorZoomInItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.Glyph")));
            this.viewNavigatorZoomInItem1.GroupIndex = 1;
            this.viewNavigatorZoomInItem1.Id = 13;
            this.viewNavigatorZoomInItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add));
            this.viewNavigatorZoomInItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.LargeGlyph")));
            this.viewNavigatorZoomInItem1.Name = "viewNavigatorZoomInItem1";
            // 
            // viewNavigatorZoomOutItem1
            // 
            this.viewNavigatorZoomOutItem1.Caption = "Alejar";
            this.viewNavigatorZoomOutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.Glyph")));
            this.viewNavigatorZoomOutItem1.GroupIndex = 1;
            this.viewNavigatorZoomOutItem1.Id = 14;
            this.viewNavigatorZoomOutItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract));
            this.viewNavigatorZoomOutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.LargeGlyph")));
            this.viewNavigatorZoomOutItem1.Name = "viewNavigatorZoomOutItem1";
            // 
            // MenuCalendario
            // 
            this.MenuCalendario.Caption = "Calendario";
            this.MenuCalendario.Glyph = ((System.Drawing.Image)(resources.GetObject("MenuCalendario.Glyph")));
            this.MenuCalendario.Id = 20;
            this.MenuCalendario.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("MenuCalendario.LargeGlyph")));
            this.MenuCalendario.Name = "MenuCalendario";
            this.MenuCalendario.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.MenuCalendario.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuCalendario_ItemClick);
            // 
            // viewSelectorBar1
            // 
            this.viewSelectorBar1.DockCol = 0;
            this.viewSelectorBar1.DockRow = 0;
            this.viewSelectorBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.viewSelectorBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.viewSelectorItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewSelectorItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewSelectorItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewSelectorItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.viewSelectorItem5)});
            // 
            // viewSelectorItem1
            // 
            this.viewSelectorItem1.Caption = "Día";
            this.viewSelectorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.Glyph")));
            this.viewSelectorItem1.GroupIndex = 1;
            this.viewSelectorItem1.Id = 15;
            this.viewSelectorItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D1));
            this.viewSelectorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.LargeGlyph")));
            this.viewSelectorItem1.Name = "viewSelectorItem1";
            this.viewSelectorItem1.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            // 
            // viewSelectorItem2
            // 
            this.viewSelectorItem2.Caption = "Semana Laboral";
            this.viewSelectorItem2.Checked = true;
            this.viewSelectorItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.Glyph")));
            this.viewSelectorItem2.GroupIndex = 1;
            this.viewSelectorItem2.Id = 16;
            this.viewSelectorItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D2));
            this.viewSelectorItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.LargeGlyph")));
            this.viewSelectorItem2.Name = "viewSelectorItem2";
            this.viewSelectorItem2.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            // 
            // viewSelectorItem3
            // 
            this.viewSelectorItem3.Caption = "Semana";
            this.viewSelectorItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.Glyph")));
            this.viewSelectorItem3.GroupIndex = 1;
            this.viewSelectorItem3.Id = 17;
            this.viewSelectorItem3.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D3));
            this.viewSelectorItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.LargeGlyph")));
            this.viewSelectorItem3.Name = "viewSelectorItem3";
            this.viewSelectorItem3.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week;
            // 
            // viewSelectorItem4
            // 
            this.viewSelectorItem4.Caption = "Mes";
            this.viewSelectorItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.Glyph")));
            this.viewSelectorItem4.GroupIndex = 1;
            this.viewSelectorItem4.Id = 18;
            this.viewSelectorItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D4));
            this.viewSelectorItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.LargeGlyph")));
            this.viewSelectorItem4.Name = "viewSelectorItem4";
            this.viewSelectorItem4.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            // 
            // viewSelectorItem5
            // 
            this.viewSelectorItem5.Caption = "Linea de Tiempo";
            this.viewSelectorItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.Glyph")));
            this.viewSelectorItem5.GroupIndex = 1;
            this.viewSelectorItem5.Id = 19;
            this.viewSelectorItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D5));
            this.viewSelectorItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.LargeGlyph")));
            this.viewSelectorItem5.Name = "viewSelectorItem5";
            this.viewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            // 
            // viewNavigator1
            // 
            this.viewNavigator1.BarManager = this.barManager1;
            this.viewNavigator1.SchedulerControl = this.schedulerControl1;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            this.schedulerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.schedulerControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.schedulerControl1.MenuManager = this.barManager1;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsBehavior.SelectOnRightClick = true;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerControl1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.PaintStyleName = "WindowsXP";
            this.schedulerControl1.Size = new System.Drawing.Size(757, 460);
            this.schedulerControl1.Start = new System.DateTime(2011, 5, 2, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 4;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.ShowWorkTimeOnly = true;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.DayView.WorkTime.End = System.TimeSpan.Parse("23:00:00");
            this.schedulerControl1.Views.DayView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.schedulerControl1.Views.TimelineView.WorkTime.End = System.TimeSpan.Parse("19:00:00");
            this.schedulerControl1.Views.TimelineView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.schedulerControl1.Views.WorkWeekView.ShowWorkTimeOnly = true;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WorkWeekView.WorkTime.End = System.TimeSpan.Parse("23:00:00");
            this.schedulerControl1.Views.WorkWeekView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.schedulerControl1.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.schedulerControl1_PreparePopupMenu);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            this.schedulerControl1.AppointmentResized += new DevExpress.XtraScheduler.AppointmentResizeEventHandler(this.schedulerControl1_AppointmentResized);
            // 
            // viewSelector1
            // 
            this.viewSelector1.BarManager = this.barManager1;
            this.viewSelector1.SchedulerControl = this.schedulerControl1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.resourcesCheckedListBoxControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.popupControlContainer1);
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(988, 460);
            this.splitContainerControl1.SplitterPosition = 225;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSalir);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 383);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(225, 77);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(59, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 66);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // resourcesCheckedListBoxControl1
            // 
            this.resourcesCheckedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourcesCheckedListBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.resourcesCheckedListBoxControl1.Name = "resourcesCheckedListBoxControl1";
            this.resourcesCheckedListBoxControl1.SchedulerControl = this.schedulerControl1;
            this.resourcesCheckedListBoxControl1.Size = new System.Drawing.Size(225, 460);
            this.resourcesCheckedListBoxControl1.TabIndex = 0;
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.simpleButton1);
            this.popupControlContainer1.Controls.Add(this.dateNavigator1);
            this.popupControlContainer1.Location = new System.Drawing.Point(529, -3);
            this.popupControlContainer1.Manager = this.barManager1;
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Size = new System.Drawing.Size(174, 192);
            this.popupControlContainer1.TabIndex = 5;
            this.popupControlContainer1.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(122, 166);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(49, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "cerrar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Location = new System.Drawing.Point(3, 7);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(168, 162);
            this.dateNavigator1.TabIndex = 1;
            // 
            // frmCalendarioCompartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 508);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCalendarioCompartido";
            this.Load += new System.EventHandler(this.frmCalendarioCompartido_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCalendarioCompartido_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSelector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraScheduler.UI.ViewNavigator viewNavigator1;
        private DevExpress.XtraScheduler.UI.ViewSelector viewSelector1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraScheduler.UI.ViewNavigatorBar viewNavigatorBar1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem viewNavigatorBackwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem viewNavigatorForwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem viewNavigatorTodayItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem viewNavigatorZoomInItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem viewNavigatorZoomOutItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorBar viewSelectorBar1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem2;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem3;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem4;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem5;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl resourcesCheckedListBoxControl1;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraBars.BarButtonItem MenuCalendario;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
    }
}