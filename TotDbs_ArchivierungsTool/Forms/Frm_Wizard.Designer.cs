namespace TotDbs_ArchivierungsTool.Forms
{
    partial class Frm_Wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Wizard));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.Cntrl_Source = new DevExpress.XtraGrid.GridControl();
            this.grdview_Source = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_RowsCount_Source = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cmb_FromKind = new System.Windows.Forms.ComboBox();
            this.Cmb_FromServer = new System.Windows.Forms.ComboBox();
            this.Cmb_FromSchema = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_FromDb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.cntrl_Transfer = new DevExpress.XtraGrid.GridControl();
            this.grdview_Transfer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rps_ProgressBar_step = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_doTransfer = new System.Windows.Forms.Button();
            this.lbl_transfer_rowsCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_todataBase = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_fromdataBase = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl_toServer = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_fromServer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            this.Cntrl_Destination = new DevExpress.XtraGrid.GridControl();
            this.grdview_Destination = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbRep_DestSchema = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbRep_TableStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_RowsCount_Dest = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_src_db = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_src_server = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pnl_toschema = new System.Windows.Forms.Panel();
            this.Cmb_DestSchema = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Cmb_ToServer = new System.Windows.Forms.ComboBox();
            this.Cmb_ToDb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cntrl_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Source)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cntrl_Transfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Transfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rps_ProgressBar_step)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cntrl_Destination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Destination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRep_DestSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRep_TableStatus)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnl_toschema.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Controls.Add(this.wizardPage3);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage3,
            this.wizardPage2});
            this.wizardControl1.Size = new System.Drawing.Size(1223, 799);
            this.wizardControl1.Text = "Archivieren";
            this.wizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.Click += new System.EventHandler(this.wizardControl1_Click);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.Cntrl_Source);
            this.welcomeWizardPage1.Controls.Add(this.panel1);
            this.welcomeWizardPage1.Controls.Add(this.groupBox1);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(1163, 631);
            this.welcomeWizardPage1.Text = "Source Information";
            this.welcomeWizardPage1.PageCommit += new System.EventHandler(this.WelcomeWizardPage1_PageCommit);
            // 
            // Cntrl_Source
            // 
            this.Cntrl_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cntrl_Source.Location = new System.Drawing.Point(0, 69);
            this.Cntrl_Source.MainView = this.grdview_Source;
            this.Cntrl_Source.Name = "Cntrl_Source";
            this.Cntrl_Source.Size = new System.Drawing.Size(1163, 546);
            this.Cntrl_Source.TabIndex = 0;
            this.Cntrl_Source.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_Source});
            // 
            // grdview_Source
            // 
            this.grdview_Source.Appearance.Row.Options.UseTextOptions = true;
            this.grdview_Source.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdview_Source.GridControl = this.Cntrl_Source;
            this.grdview_Source.Name = "grdview_Source";
            this.grdview_Source.OptionsBehavior.Editable = false;
            this.grdview_Source.OptionsSelection.MultiSelect = true;
            this.grdview_Source.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grdview_Source.OptionsView.RowAutoHeight = true;
            this.grdview_Source.OptionsView.ShowAutoFilterRow = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_RowsCount_Source);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 615);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 16);
            this.panel1.TabIndex = 2;
            // 
            // lbl_RowsCount_Source
            // 
            this.lbl_RowsCount_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RowsCount_Source.Location = new System.Drawing.Point(68, 0);
            this.lbl_RowsCount_Source.Name = "lbl_RowsCount_Source";
            this.lbl_RowsCount_Source.Size = new System.Drawing.Size(1095, 16);
            this.lbl_RowsCount_Source.TabIndex = 1;
            this.lbl_RowsCount_Source.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rows Count:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cmb_FromKind);
            this.groupBox1.Controls.Add(this.Cmb_FromServer);
            this.groupBox1.Controls.Add(this.Cmb_FromSchema);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Cmb_FromDb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1163, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Cmb_FromKind
            // 
            this.Cmb_FromKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_FromKind.FormattingEnabled = true;
            this.Cmb_FromKind.Items.AddRange(new object[] {
            "Select Kind .....",
            "Table",
            "View",
            "Procedure",
            "Function"});
            this.Cmb_FromKind.Location = new System.Drawing.Point(434, 40);
            this.Cmb_FromKind.Name = "Cmb_FromKind";
            this.Cmb_FromKind.Size = new System.Drawing.Size(248, 21);
            this.Cmb_FromKind.TabIndex = 7;
            this.Cmb_FromKind.SelectedIndexChanged += new System.EventHandler(this.Cmb_FromKind_SelectedIndexChanged);
            // 
            // Cmb_FromServer
            // 
            this.Cmb_FromServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_FromServer.FormattingEnabled = true;
            this.Cmb_FromServer.Location = new System.Drawing.Point(65, 13);
            this.Cmb_FromServer.Name = "Cmb_FromServer";
            this.Cmb_FromServer.Size = new System.Drawing.Size(295, 21);
            this.Cmb_FromServer.Sorted = true;
            this.Cmb_FromServer.TabIndex = 4;
            this.Cmb_FromServer.Enter += new System.EventHandler(this.Cmb_FromServer_Enter);
            // 
            // Cmb_FromSchema
            // 
            this.Cmb_FromSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_FromSchema.FormattingEnabled = true;
            this.Cmb_FromSchema.Items.AddRange(new object[] {
            " All Schemas ...."});
            this.Cmb_FromSchema.Location = new System.Drawing.Point(434, 13);
            this.Cmb_FromSchema.Name = "Cmb_FromSchema";
            this.Cmb_FromSchema.Size = new System.Drawing.Size(248, 21);
            this.Cmb_FromSchema.Sorted = true;
            this.Cmb_FromSchema.TabIndex = 6;
            this.Cmb_FromSchema.SelectedIndexChanged += new System.EventHandler(this.Cmb_FromSchema_SelectedIndexChanged);
            this.Cmb_FromSchema.Enter += new System.EventHandler(this.Cmb_FromSchema_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Schema:";
            // 
            // Cmb_FromDb
            // 
            this.Cmb_FromDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_FromDb.FormattingEnabled = true;
            this.Cmb_FromDb.Location = new System.Drawing.Point(65, 40);
            this.Cmb_FromDb.Name = "Cmb_FromDb";
            this.Cmb_FromDb.Size = new System.Drawing.Size(295, 21);
            this.Cmb_FromDb.Sorted = true;
            this.Cmb_FromDb.TabIndex = 5;
            this.Cmb_FromDb.SelectedIndexChanged += new System.EventHandler(this.Cmb_FromDb_SelectedIndexChanged);
            this.Cmb_FromDb.Enter += new System.EventHandler(this.Cmb_FromDb_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBase:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kind:";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.cntrl_Transfer);
            this.wizardPage2.Controls.Add(this.panel3);
            this.wizardPage2.Controls.Add(this.groupBox3);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(1163, 631);
            this.wizardPage2.Text = "Transfer data From Source To Destination .....";
            // 
            // cntrl_Transfer
            // 
            this.cntrl_Transfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrl_Transfer.Location = new System.Drawing.Point(0, 56);
            this.cntrl_Transfer.MainView = this.grdview_Transfer;
            this.cntrl_Transfer.Name = "cntrl_Transfer";
            this.cntrl_Transfer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rps_ProgressBar_step});
            this.cntrl_Transfer.Size = new System.Drawing.Size(1163, 552);
            this.cntrl_Transfer.TabIndex = 4;
            this.cntrl_Transfer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_Transfer});
            // 
            // grdview_Transfer
            // 
            this.grdview_Transfer.GridControl = this.cntrl_Transfer;
            this.grdview_Transfer.Name = "grdview_Transfer";
            this.grdview_Transfer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdview_Transfer.OptionsSelection.MultiSelect = true;
            this.grdview_Transfer.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdview_Transfer.OptionsView.ShowAutoFilterRow = true;
            this.grdview_Transfer.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.Grdview_Transfer_RowStyle);
            this.grdview_Transfer.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.Grdview_Transfer_CustomRowCellEdit);
            // 
            // rps_ProgressBar_step
            // 
            this.rps_ProgressBar_step.AllowAnimationOnValueChanged = DevExpress.Utils.DefaultBoolean.True;
            this.rps_ProgressBar_step.FlowAnimationEnabled = true;
            this.rps_ProgressBar_step.Name = "rps_ProgressBar_step";
            this.rps_ProgressBar_step.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.Rps_ProgressBar_step_CustomDisplayText);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_doTransfer);
            this.panel3.Controls.Add(this.lbl_transfer_rowsCount);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 608);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1163, 23);
            this.panel3.TabIndex = 5;
            // 
            // btn_doTransfer
            // 
            this.btn_doTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_doTransfer.Location = new System.Drawing.Point(1065, 0);
            this.btn_doTransfer.Name = "btn_doTransfer";
            this.btn_doTransfer.Size = new System.Drawing.Size(97, 23);
            this.btn_doTransfer.TabIndex = 19;
            this.btn_doTransfer.Text = "Do Transfer ...";
            this.btn_doTransfer.UseVisualStyleBackColor = true;
            this.btn_doTransfer.Click += new System.EventHandler(this.Btn_doTransfer_Click);
            // 
            // lbl_transfer_rowsCount
            // 
            this.lbl_transfer_rowsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_transfer_rowsCount.Location = new System.Drawing.Point(68, 0);
            this.lbl_transfer_rowsCount.Name = "lbl_transfer_rowsCount";
            this.lbl_transfer_rowsCount.Size = new System.Drawing.Size(878, 23);
            this.lbl_transfer_rowsCount.TabIndex = 1;
            this.lbl_transfer_rowsCount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Rows Count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_todataBase);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lbl_fromdataBase);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lbl_toServer);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lbl_fromServer);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1163, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transfer Info.";
            // 
            // lbl_todataBase
            // 
            this.lbl_todataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_todataBase.Location = new System.Drawing.Point(545, 34);
            this.lbl_todataBase.Name = "lbl_todataBase";
            this.lbl_todataBase.Size = new System.Drawing.Size(386, 18);
            this.lbl_todataBase.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(472, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "To DataBase:";
            // 
            // lbl_fromdataBase
            // 
            this.lbl_fromdataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_fromdataBase.Location = new System.Drawing.Point(84, 34);
            this.lbl_fromdataBase.Name = "lbl_fromdataBase";
            this.lbl_fromdataBase.Size = new System.Drawing.Size(388, 18);
            this.lbl_fromdataBase.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "From DataBase:";
            // 
            // lbl_toServer
            // 
            this.lbl_toServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_toServer.Location = new System.Drawing.Point(548, 16);
            this.lbl_toServer.Name = "lbl_toServer";
            this.lbl_toServer.Size = new System.Drawing.Size(383, 18);
            this.lbl_toServer.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(472, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "To Server:";
            // 
            // lbl_fromServer
            // 
            this.lbl_fromServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_fromServer.Location = new System.Drawing.Point(87, 16);
            this.lbl_fromServer.Name = "lbl_fromServer";
            this.lbl_fromServer.Size = new System.Drawing.Size(385, 18);
            this.lbl_fromServer.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "From Server:";
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.Cntrl_Destination);
            this.wizardPage3.Controls.Add(this.panel2);
            this.wizardPage3.Controls.Add(this.groupBox2);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(1163, 631);
            this.wizardPage3.Text = "Destinatin Information";
            this.wizardPage3.PageCommit += new System.EventHandler(this.WizardPage3_PageCommit);
            // 
            // Cntrl_Destination
            // 
            this.Cntrl_Destination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cntrl_Destination.Location = new System.Drawing.Point(0, 68);
            this.Cntrl_Destination.MainView = this.grdview_Destination;
            this.Cntrl_Destination.Name = "Cntrl_Destination";
            this.Cntrl_Destination.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbRep_DestSchema,
            this.cmbRep_TableStatus});
            this.Cntrl_Destination.Size = new System.Drawing.Size(1163, 547);
            this.Cntrl_Destination.TabIndex = 3;
            this.Cntrl_Destination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdview_Destination});
            // 
            // grdview_Destination
            // 
            this.grdview_Destination.GridControl = this.Cntrl_Destination;
            this.grdview_Destination.Name = "grdview_Destination";
            this.grdview_Destination.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdview_Destination.OptionsSelection.MultiSelect = true;
            this.grdview_Destination.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdview_Destination.OptionsView.ShowAutoFilterRow = true;
            this.grdview_Destination.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.Grdview_Destination_RowStyle);
            // 
            // cmbRep_DestSchema
            // 
            this.cmbRep_DestSchema.AutoHeight = false;
            this.cmbRep_DestSchema.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRep_DestSchema.ImmediatePopup = true;
            this.cmbRep_DestSchema.Name = "cmbRep_DestSchema";
            this.cmbRep_DestSchema.Sorted = true;
            this.cmbRep_DestSchema.SelectedIndexChanged += new System.EventHandler(this.CmbRep_DestSchema_SelectedIndexChanged);
            // 
            // cmbRep_TableStatus
            // 
            this.cmbRep_TableStatus.AutoHeight = false;
            this.cmbRep_TableStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRep_TableStatus.Items.AddRange(new object[] {
            "New",
            "Exist"});
            this.cmbRep_TableStatus.Name = "cmbRep_TableStatus";
            this.cmbRep_TableStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_RowsCount_Dest);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 615);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1163, 16);
            this.panel2.TabIndex = 4;
            // 
            // lbl_RowsCount_Dest
            // 
            this.lbl_RowsCount_Dest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RowsCount_Dest.Location = new System.Drawing.Point(68, 0);
            this.lbl_RowsCount_Dest.Name = "lbl_RowsCount_Dest";
            this.lbl_RowsCount_Dest.Size = new System.Drawing.Size(1095, 16);
            this.lbl_RowsCount_Dest.TabIndex = 1;
            this.lbl_RowsCount_Dest.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Rows Count:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_src_db);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lbl_src_server);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.pnl_toschema);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Cmb_ToServer);
            this.groupBox2.Controls.Add(this.Cmb_ToDb);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1163, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // lbl_src_db
            // 
            this.lbl_src_db.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_src_db.Location = new System.Drawing.Point(87, 41);
            this.lbl_src_db.Name = "lbl_src_db";
            this.lbl_src_db.Size = new System.Drawing.Size(341, 18);
            this.lbl_src_db.TabIndex = 20;
            this.lbl_src_db.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "From DataBase:";
            // 
            // lbl_src_server
            // 
            this.lbl_src_server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_src_server.Location = new System.Drawing.Point(90, 13);
            this.lbl_src_server.Name = "lbl_src_server";
            this.lbl_src_server.Size = new System.Drawing.Size(338, 18);
            this.lbl_src_server.TabIndex = 18;
            this.lbl_src_server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "From Server:";
            // 
            // pnl_toschema
            // 
            this.pnl_toschema.Controls.Add(this.Cmb_DestSchema);
            this.pnl_toschema.Controls.Add(this.label10);
            this.pnl_toschema.Location = new System.Drawing.Point(761, 40);
            this.pnl_toschema.Name = "pnl_toschema";
            this.pnl_toschema.Size = new System.Drawing.Size(375, 22);
            this.pnl_toschema.TabIndex = 12;
            // 
            // Cmb_DestSchema
            // 
            this.Cmb_DestSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cmb_DestSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_DestSchema.FormattingEnabled = true;
            this.Cmb_DestSchema.Location = new System.Drawing.Point(49, 0);
            this.Cmb_DestSchema.Name = "Cmb_DestSchema";
            this.Cmb_DestSchema.Size = new System.Drawing.Size(326, 21);
            this.Cmb_DestSchema.Sorted = true;
            this.Cmb_DestSchema.TabIndex = 11;
            this.Cmb_DestSchema.SelectedIndexChanged += new System.EventHandler(this.Cmb_DestSchema_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 22);
            this.label10.TabIndex = 10;
            this.label10.Text = "Schema:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "To DataBase:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "To Server:";
            // 
            // Cmb_ToServer
            // 
            this.Cmb_ToServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ToServer.FormattingEnabled = true;
            this.Cmb_ToServer.Location = new System.Drawing.Point(507, 12);
            this.Cmb_ToServer.Name = "Cmb_ToServer";
            this.Cmb_ToServer.Size = new System.Drawing.Size(248, 21);
            this.Cmb_ToServer.Sorted = true;
            this.Cmb_ToServer.TabIndex = 8;
            this.Cmb_ToServer.Enter += new System.EventHandler(this.Cmb_ToServer_Enter);
            // 
            // Cmb_ToDb
            // 
            this.Cmb_ToDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ToDb.FormattingEnabled = true;
            this.Cmb_ToDb.Location = new System.Drawing.Point(507, 40);
            this.Cmb_ToDb.Name = "Cmb_ToDb";
            this.Cmb_ToDb.Size = new System.Drawing.Size(248, 21);
            this.Cmb_ToDb.Sorted = true;
            this.Cmb_ToDb.TabIndex = 9;
            this.Cmb_ToDb.SelectedIndexChanged += new System.EventHandler(this.Cmb_ToDb_SelectedIndexChanged);
            this.Cmb_ToDb.Enter += new System.EventHandler(this.Cmb_ToDb_Enter);
            // 
            // Frm_Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 799);
            this.Controls.Add(this.wizardControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Wizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Data Wizard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Wizard_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Wizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cntrl_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Source)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cntrl_Transfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Transfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rps_ProgressBar_step)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cntrl_Destination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdview_Destination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRep_DestSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRep_TableStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnl_toschema.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraWizard.WizardPage wizardPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cmb_FromKind;
        private System.Windows.Forms.ComboBox Cmb_FromServer;
        private System.Windows.Forms.ComboBox Cmb_FromSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cmb_FromDb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl Cntrl_Source;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cmb_ToServer;
        private System.Windows.Forms.ComboBox Cmb_ToDb;
        private DevExpress.XtraGrid.GridControl Cntrl_Destination;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_Destination;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_RowsCount_Source;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_RowsCount_Dest;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbRep_DestSchema;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbRep_TableStatus;
        private DevExpress.XtraGrid.GridControl cntrl_Transfer;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_Transfer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_transfer_rowsCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_toServer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_fromServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_todataBase;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_fromdataBase;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraGrid.Views.Grid.GridView grdview_Source;
        private System.Windows.Forms.ComboBox Cmb_DestSchema;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_doTransfer;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar rps_ProgressBar_step;
        private System.Windows.Forms.Panel pnl_toschema;
        private System.Windows.Forms.Label lbl_src_db;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_src_server;
        private System.Windows.Forms.Label label19;
    }
}