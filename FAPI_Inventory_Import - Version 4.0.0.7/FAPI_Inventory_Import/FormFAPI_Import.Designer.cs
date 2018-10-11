namespace FAPI_Inventory_Import
{
    partial class FormFAPI_Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFAPI_Import));
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.bindingSourceWarehouseCodes = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet = new FAPI_Inventory_Import.ApplicationSettingsDataSet();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.officeDataSourceObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventory_Warehouse_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSetTableAdapters.Inventory_Warehouse_CodesTableAdapter();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelExporter = new System.Windows.Forms.Label();
            this.textBoxExporter = new System.Windows.Forms.TextBox();
            this.panelVesselInformation = new System.Windows.Forms.Panel();
            this.labelVesselInfoTITLE = new System.Windows.Forms.Label();
            this.textBoxPalletPrefix = new System.Windows.Forms.TextBox();
            this.labelPalletPrefix = new System.Windows.Forms.Label();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxVesselName = new System.Windows.Forms.TextBox();
            this.labelVesselName = new System.Windows.Forms.Label();
            this.textBoxVesselNumber = new System.Windows.Forms.TextBox();
            this.labelVesselNumber = new System.Windows.Forms.Label();
            this.textBoxDepartureDate = new System.Windows.Forms.TextBox();
            this.labelDepartureDate = new System.Windows.Forms.Label();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.menuStripExportApp = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.famousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTranslationValidationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCodeEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoneFruitListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelRegion = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.regionIDCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet1 = new FAPI_Inventory_Import.ApplicationSettingsDataSet1();
            this.region_ID_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet1TableAdapters.Region_ID_CodesTableAdapter();
            this.labelGrowerBlock = new System.Windows.Forms.Label();
            this.comboBoxGrowerBlock = new System.Windows.Forms.ComboBox();
            this.growerNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet17 = new FAPI_Inventory_Import.ApplicationSettingsDataSet17();
            this.growerBlockIDCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSetGrowersBlock = new FAPI_Inventory_Import.ApplicationSettingsDataSetGrowersBlock();
            this.applicationSettingsDataSet2 = new FAPI_Inventory_Import.ApplicationSettingsDataSet2();
            this.commodityCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet9 = new FAPI_Inventory_Import.ApplicationSettingsDataSet9();
            this.applicationSettingsDataSet3 = new FAPI_Inventory_Import.ApplicationSettingsDataSet3();
            this.methodIDCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet4 = new FAPI_Inventory_Import.ApplicationSettingsDataSet4();
            this.storageIDCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSetStorageID = new FAPI_Inventory_Import.ApplicationSettingsDataSetStorageID();
            this.labelReceivingDate = new System.Windows.Forms.Label();
            this.dateTimePickerReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.method_ID_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet4TableAdapters.Method_ID_CodesTableAdapter();
            this.grower_Block_ID_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet6TableAdapters.Grower_Block_ID_CodesTableAdapter();
            this.storage_ID_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSetStorageIDTableAdapters.Storage_ID_CodesTableAdapter();
            this.grower_Block_ID_CodesTableAdapter1 = new FAPI_Inventory_Import.ApplicationSettingsDataSetGrowersBlockTableAdapters.Grower_Block_ID_CodesTableAdapter();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.labelCurrentTemplate = new System.Windows.Forms.Label();
            this.buttonFamousExport = new System.Windows.Forms.Button();
            this.buttonAdamsExport = new System.Windows.Forms.Button();
            this.applicationSettingsDataSetCommodityCodes = new FAPI_Inventory_Import.ApplicationSettingsDataSetCommodityCodes();
            this.commodity_CodesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet9TableAdapters.Commodity_CodesTableAdapter();
            this.labelTransactionType = new System.Windows.Forms.Label();
            this.comboBoxTransactionType = new System.Windows.Forms.ComboBox();
            this.labelData = new System.Windows.Forms.Label();
            this.checkBoxAvailable = new System.Windows.Forms.CheckBox();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.buttonTranslateOld = new System.Windows.Forms.Button();
            this.labelTranslated = new System.Windows.Forms.Label();
            this.saveFileDialogSaveExportFile = new System.Windows.Forms.SaveFileDialog();
            this.labelMode = new System.Windows.Forms.Label();
            this.applicationSettingsDataSetWarehouseCodes = new FAPI_Inventory_Import.ApplicationSettingsDataSet();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.bindingSourceImportTemplates = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSetImportTemplate = new FAPI_Inventory_Import.ApplicationSettingsDataSetImportTemplate();
            this.fAPI_Import_TemplatesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSetImportTemplateTableAdapters.FAPI_Import_TemplatesTableAdapter();
            this.comboBoxMethodID = new System.Windows.Forms.ComboBox();
            this.labelMethodID = new System.Windows.Forms.Label();
            this.labelStorageID = new System.Windows.Forms.Label();
            this.comboBoxStorageID = new System.Windows.Forms.ComboBox();
            this.grower_NameTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet17TableAdapters.Grower_NameTableAdapter();
            this.labelExportFile = new System.Windows.Forms.Label();
            this.labelExportAdamsFile = new System.Windows.Forms.Label();
            this.Button4Transalation = new System.Windows.Forms.Button();
            this.checkBoxXMLExport = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWarehouseCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSourceObjectBindingSource)).BeginInit();
            this.panelVesselInformation.SuspendLayout();
            this.menuStripExportApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionIDCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.growerNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.growerBlockIDCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetGrowersBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.methodIDCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageIDCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetStorageID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetCommodityCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetWarehouseCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceImportTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetImportTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.AllowDrop = true;
            this.comboBoxWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxWarehouse.DataSource = this.bindingSourceWarehouseCodes;
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.DropDownWidth = 150;
            this.comboBoxWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(120, 70);
            this.comboBoxWarehouse.MaxDropDownItems = 10;
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(152, 21);
            this.comboBoxWarehouse.TabIndex = 0;
            this.comboBoxWarehouse.ValueMember = "Code";
            this.comboBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouse_SelectedIndexChanged);
            // 
            // bindingSourceWarehouseCodes
            // 
            this.bindingSourceWarehouseCodes.DataMember = "Inventory_Warehouse_Codes";
            this.bindingSourceWarehouseCodes.DataSource = this.applicationSettingsDataSet;
            // 
            // applicationSettingsDataSet
            // 
            this.applicationSettingsDataSet.DataSetName = "ApplicationSettingsDataSet";
            this.applicationSettingsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewExcel
            // 
            this.dataGridViewExcel.AllowUserToOrderColumns = true;
            this.dataGridViewExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel.Location = new System.Drawing.Point(12, 338);
            this.dataGridViewExcel.Name = "dataGridViewExcel";
            this.dataGridViewExcel.Size = new System.Drawing.Size(1160, 388);
            this.dataGridViewExcel.TabIndex = 14;
            // 
            // inventory_Warehouse_CodesTableAdapter
            // 
            this.inventory_Warehouse_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarehouse.Location = new System.Drawing.Point(35, 70);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(85, 17);
            this.labelWarehouse.TabIndex = 50;
            this.labelWarehouse.Text = "Warehouse:";
            // 
            // labelExporter
            // 
            this.labelExporter.AutoSize = true;
            this.labelExporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExporter.Location = new System.Drawing.Point(25, 42);
            this.labelExporter.Name = "labelExporter";
            this.labelExporter.Size = new System.Drawing.Size(69, 17);
            this.labelExporter.TabIndex = 62;
            this.labelExporter.Text = "Exporter: ";
            // 
            // textBoxExporter
            // 
            this.textBoxExporter.Location = new System.Drawing.Point(90, 42);
            this.textBoxExporter.Name = "textBoxExporter";
            this.textBoxExporter.Size = new System.Drawing.Size(162, 20);
            this.textBoxExporter.TabIndex = 8;
            this.textBoxExporter.TextChanged += new System.EventHandler(this.textBoxExporter_TextChanged);
            // 
            // panelVesselInformation
            // 
            this.panelVesselInformation.Controls.Add(this.labelVesselInfoTITLE);
            this.panelVesselInformation.Controls.Add(this.textBoxPalletPrefix);
            this.panelVesselInformation.Controls.Add(this.labelPalletPrefix);
            this.panelVesselInformation.Controls.Add(this.textBoxDestination);
            this.panelVesselInformation.Controls.Add(this.labelDestination);
            this.panelVesselInformation.Controls.Add(this.textBoxVesselName);
            this.panelVesselInformation.Controls.Add(this.labelVesselName);
            this.panelVesselInformation.Controls.Add(this.textBoxVesselNumber);
            this.panelVesselInformation.Controls.Add(this.labelVesselNumber);
            this.panelVesselInformation.Controls.Add(this.textBoxDepartureDate);
            this.panelVesselInformation.Controls.Add(this.labelDepartureDate);
            this.panelVesselInformation.Controls.Add(this.labelExporter);
            this.panelVesselInformation.Controls.Add(this.textBoxExporter);
            this.panelVesselInformation.Location = new System.Drawing.Point(782, 54);
            this.panelVesselInformation.Name = "panelVesselInformation";
            this.panelVesselInformation.Size = new System.Drawing.Size(373, 235);
            this.panelVesselInformation.TabIndex = 8;
            // 
            // labelVesselInfoTITLE
            // 
            this.labelVesselInfoTITLE.AutoSize = true;
            this.labelVesselInfoTITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVesselInfoTITLE.Location = new System.Drawing.Point(111, 13);
            this.labelVesselInfoTITLE.Name = "labelVesselInfoTITLE";
            this.labelVesselInfoTITLE.Size = new System.Drawing.Size(142, 20);
            this.labelVesselInfoTITLE.TabIndex = 68;
            this.labelVesselInfoTITLE.Text = "Vessel Information";
            // 
            // textBoxPalletPrefix
            // 
            this.textBoxPalletPrefix.Location = new System.Drawing.Point(116, 192);
            this.textBoxPalletPrefix.Name = "textBoxPalletPrefix";
            this.textBoxPalletPrefix.Size = new System.Drawing.Size(137, 20);
            this.textBoxPalletPrefix.TabIndex = 13;
            this.textBoxPalletPrefix.TextChanged += new System.EventHandler(this.textBoxPalletPrefix_TextChanged);
            // 
            // labelPalletPrefix
            // 
            this.labelPalletPrefix.AutoSize = true;
            this.labelPalletPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPalletPrefix.Location = new System.Drawing.Point(25, 192);
            this.labelPalletPrefix.Name = "labelPalletPrefix";
            this.labelPalletPrefix.Size = new System.Drawing.Size(90, 17);
            this.labelPalletPrefix.TabIndex = 67;
            this.labelPalletPrefix.Text = "Pallet Prefix: ";
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(116, 162);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(137, 20);
            this.textBoxDestination.TabIndex = 12;
            this.textBoxDestination.TextChanged += new System.EventHandler(this.textBoxDestination_TextChanged);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestination.Location = new System.Drawing.Point(25, 162);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(87, 17);
            this.labelDestination.TabIndex = 66;
            this.labelDestination.Text = "Destination: ";
            // 
            // textBoxVesselName
            // 
            this.textBoxVesselName.Location = new System.Drawing.Point(126, 132);
            this.textBoxVesselName.Name = "textBoxVesselName";
            this.textBoxVesselName.Size = new System.Drawing.Size(127, 20);
            this.textBoxVesselName.TabIndex = 11;
            this.textBoxVesselName.TextChanged += new System.EventHandler(this.textBoxVesselName_TextChanged);
            // 
            // labelVesselName
            // 
            this.labelVesselName.AutoSize = true;
            this.labelVesselName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVesselName.Location = new System.Drawing.Point(25, 132);
            this.labelVesselName.Name = "labelVesselName";
            this.labelVesselName.Size = new System.Drawing.Size(99, 17);
            this.labelVesselName.TabIndex = 65;
            this.labelVesselName.Text = "Vessel Name: ";
            // 
            // textBoxVesselNumber
            // 
            this.textBoxVesselNumber.Location = new System.Drawing.Point(140, 102);
            this.textBoxVesselNumber.Name = "textBoxVesselNumber";
            this.textBoxVesselNumber.Size = new System.Drawing.Size(113, 20);
            this.textBoxVesselNumber.TabIndex = 10;
            this.textBoxVesselNumber.TextChanged += new System.EventHandler(this.textBoxVesselNumber_TextChanged);
            // 
            // labelVesselNumber
            // 
            this.labelVesselNumber.AutoSize = true;
            this.labelVesselNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVesselNumber.Location = new System.Drawing.Point(25, 102);
            this.labelVesselNumber.Name = "labelVesselNumber";
            this.labelVesselNumber.Size = new System.Drawing.Size(115, 17);
            this.labelVesselNumber.TabIndex = 64;
            this.labelVesselNumber.Text = "Lot/Vessel Num: ";
            // 
            // textBoxDepartureDate
            // 
            this.textBoxDepartureDate.Location = new System.Drawing.Point(140, 72);
            this.textBoxDepartureDate.Name = "textBoxDepartureDate";
            this.textBoxDepartureDate.Size = new System.Drawing.Size(113, 20);
            this.textBoxDepartureDate.TabIndex = 9;
            this.textBoxDepartureDate.TextChanged += new System.EventHandler(this.textBoxDepartureDate_TextChanged);
            // 
            // labelDepartureDate
            // 
            this.labelDepartureDate.AutoSize = true;
            this.labelDepartureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDepartureDate.Location = new System.Drawing.Point(25, 72);
            this.labelDepartureDate.Name = "labelDepartureDate";
            this.labelDepartureDate.Size = new System.Drawing.Size(114, 17);
            this.labelDepartureDate.TabIndex = 63;
            this.labelDepartureDate.Text = "Departure Date: ";
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.Filter = "Excel Files|*.xl*";
            // 
            // menuStripExportApp
            // 
            this.menuStripExportApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItemTemplate,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripExportApp.Location = new System.Drawing.Point(0, 0);
            this.menuStripExportApp.Name = "menuStripExportApp";
            this.menuStripExportApp.Size = new System.Drawing.Size(1192, 24);
            this.menuStripExportApp.TabIndex = 7;
            this.menuStripExportApp.Text = "menuStrip2";
            this.menuStripExportApp.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripExportApp_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.famousToolStripMenuItem,
            this.adamsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // famousToolStripMenuItem
            // 
            this.famousToolStripMenuItem.Name = "famousToolStripMenuItem";
            this.famousToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.famousToolStripMenuItem.Text = "Famous";
            this.famousToolStripMenuItem.Click += new System.EventHandler(this.famousToolStripMenuItem_Click);
            // 
            // adamsToolStripMenuItem
            // 
            this.adamsToolStripMenuItem.Name = "adamsToolStripMenuItem";
            this.adamsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.adamsToolStripMenuItem.Text = "Adams";
            this.adamsToolStripMenuItem.Click += new System.EventHandler(this.adamsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItemTemplate
            // 
            this.toolStripMenuItemTemplate.Name = "toolStripMenuItemTemplate";
            this.toolStripMenuItemTemplate.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItemTemplate.Text = "Templates";
            this.toolStripMenuItemTemplate.Click += new System.EventHandler(this.toolStripMenuItemTemplate_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTranslationValidationToolStripMenuItem1,
            this.updateTablesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // editTranslationValidationToolStripMenuItem1
            // 
            this.editTranslationValidationToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateTranslationsToolStripMenuItem,
            this.exportCodeEditorToolStripMenuItem,
            this.stoneFruitListToolStripMenuItem,
            this.templateCreatorToolStripMenuItem});
            this.editTranslationValidationToolStripMenuItem1.Name = "editTranslationValidationToolStripMenuItem1";
            this.editTranslationValidationToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.editTranslationValidationToolStripMenuItem1.Text = "Edit Tables";
            // 
            // updateTranslationsToolStripMenuItem
            // 
            this.updateTranslationsToolStripMenuItem.Name = "updateTranslationsToolStripMenuItem";
            this.updateTranslationsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.updateTranslationsToolStripMenuItem.Text = "Update Translations";
            this.updateTranslationsToolStripMenuItem.Click += new System.EventHandler(this.updateTranslationsToolStripMenuItem_Click);
            // 
            // exportCodeEditorToolStripMenuItem
            // 
            this.exportCodeEditorToolStripMenuItem.Name = "exportCodeEditorToolStripMenuItem";
            this.exportCodeEditorToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportCodeEditorToolStripMenuItem.Text = "Export Code Editor";
            this.exportCodeEditorToolStripMenuItem.Click += new System.EventHandler(this.exportCodeEditorToolStripMenuItem_Click);
            // 
            // stoneFruitListToolStripMenuItem
            // 
            this.stoneFruitListToolStripMenuItem.Name = "stoneFruitListToolStripMenuItem";
            this.stoneFruitListToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.stoneFruitListToolStripMenuItem.Text = "Stone Fruit List";
            this.stoneFruitListToolStripMenuItem.Click += new System.EventHandler(this.stoneFruitListToolStripMenuItem_Click);
            // 
            // templateCreatorToolStripMenuItem
            // 
            this.templateCreatorToolStripMenuItem.Name = "templateCreatorToolStripMenuItem";
            this.templateCreatorToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.templateCreatorToolStripMenuItem.Text = "Template Creator";
            this.templateCreatorToolStripMenuItem.Click += new System.EventHandler(this.templateCreatorToolStripMenuItem_Click);
            // 
            // updateTablesToolStripMenuItem
            // 
            this.updateTablesToolStripMenuItem.Name = "updateTablesToolStripMenuItem";
            this.updateTablesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.updateTablesToolStripMenuItem.Text = "Update From Famous";
            this.updateTablesToolStripMenuItem.Click += new System.EventHandler(this.updateTablesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegion.Location = new System.Drawing.Point(35, 143);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(61, 17);
            this.labelRegion.TabIndex = 53;
            this.labelRegion.Text = "Region: ";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DataSource = this.regionIDCodesBindingSource;
            this.comboBoxRegion.DisplayMember = "Region_Description";
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(100, 143);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(172, 21);
            this.comboBoxRegion.TabIndex = 3;
            this.comboBoxRegion.ValueMember = "Region_Code";
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
            // 
            // regionIDCodesBindingSource
            // 
            this.regionIDCodesBindingSource.DataMember = "Region_ID_Codes";
            this.regionIDCodesBindingSource.DataSource = this.applicationSettingsDataSet1;
            // 
            // applicationSettingsDataSet1
            // 
            this.applicationSettingsDataSet1.DataSetName = "ApplicationSettingsDataSet1";
            this.applicationSettingsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // region_ID_CodesTableAdapter
            // 
            this.region_ID_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // labelGrowerBlock
            // 
            this.labelGrowerBlock.AutoSize = true;
            this.labelGrowerBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrowerBlock.Location = new System.Drawing.Point(35, 105);
            this.labelGrowerBlock.Name = "labelGrowerBlock";
            this.labelGrowerBlock.Size = new System.Drawing.Size(69, 17);
            this.labelGrowerBlock.TabIndex = 51;
            this.labelGrowerBlock.Text = "Exporter: ";
            // 
            // comboBoxGrowerBlock
            // 
            this.comboBoxGrowerBlock.DataSource = this.growerNameBindingSource;
            this.comboBoxGrowerBlock.DisplayMember = "Grower_Name";
            this.comboBoxGrowerBlock.FormattingEnabled = true;
            this.comboBoxGrowerBlock.Location = new System.Drawing.Point(100, 105);
            this.comboBoxGrowerBlock.Name = "comboBoxGrowerBlock";
            this.comboBoxGrowerBlock.Size = new System.Drawing.Size(172, 21);
            this.comboBoxGrowerBlock.TabIndex = 1;
            this.comboBoxGrowerBlock.ValueMember = "Grower_Name_ID";
            this.comboBoxGrowerBlock.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrowerBlock_SelectedIndexChanged);
            // 
            // growerNameBindingSource
            // 
            this.growerNameBindingSource.DataMember = "Grower_Name";
            this.growerNameBindingSource.DataSource = this.applicationSettingsDataSet17;
            // 
            // applicationSettingsDataSet17
            // 
            this.applicationSettingsDataSet17.DataSetName = "ApplicationSettingsDataSet17";
            this.applicationSettingsDataSet17.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // growerBlockIDCodesBindingSource
            // 
            this.growerBlockIDCodesBindingSource.DataMember = "Grower_Block_ID_Codes";
            this.growerBlockIDCodesBindingSource.DataSource = this.applicationSettingsDataSetGrowersBlock;
            // 
            // applicationSettingsDataSetGrowersBlock
            // 
            this.applicationSettingsDataSetGrowersBlock.DataSetName = "ApplicationSettingsDataSetGrowersBlock";
            this.applicationSettingsDataSetGrowersBlock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // applicationSettingsDataSet2
            // 
            this.applicationSettingsDataSet2.DataSetName = "ApplicationSettingsDataSet2";
            this.applicationSettingsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commodityCodesBindingSource
            // 
            this.commodityCodesBindingSource.DataMember = "Commodity_Codes";
            this.commodityCodesBindingSource.DataSource = this.applicationSettingsDataSet9;
            // 
            // applicationSettingsDataSet9
            // 
            this.applicationSettingsDataSet9.DataSetName = "ApplicationSettingsDataSet9";
            this.applicationSettingsDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // applicationSettingsDataSet3
            // 
            this.applicationSettingsDataSet3.DataSetName = "ApplicationSettingsDataSet3";
            this.applicationSettingsDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // methodIDCodesBindingSource
            // 
            this.methodIDCodesBindingSource.DataMember = "Method_ID_Codes";
            this.methodIDCodesBindingSource.DataSource = this.applicationSettingsDataSet4;
            // 
            // applicationSettingsDataSet4
            // 
            this.applicationSettingsDataSet4.DataSetName = "ApplicationSettingsDataSet4";
            this.applicationSettingsDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // storageIDCodesBindingSource
            // 
            this.storageIDCodesBindingSource.DataMember = "Storage_ID_Codes";
            this.storageIDCodesBindingSource.DataSource = this.applicationSettingsDataSetStorageID;
            // 
            // applicationSettingsDataSetStorageID
            // 
            this.applicationSettingsDataSetStorageID.DataSetName = "ApplicationSettingsDataSetStorageID";
            this.applicationSettingsDataSetStorageID.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelReceivingDate
            // 
            this.labelReceivingDate.AutoSize = true;
            this.labelReceivingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceivingDate.Location = new System.Drawing.Point(413, 109);
            this.labelReceivingDate.Name = "labelReceivingDate";
            this.labelReceivingDate.Size = new System.Drawing.Size(112, 17);
            this.labelReceivingDate.TabIndex = 58;
            this.labelReceivingDate.Text = "Receiving Date: ";
            // 
            // dateTimePickerReceiveDate
            // 
            this.dateTimePickerReceiveDate.CustomFormat = "MM/dd/yyyy";
            this.dateTimePickerReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReceiveDate.Location = new System.Drawing.Point(528, 105);
            this.dateTimePickerReceiveDate.Name = "dateTimePickerReceiveDate";
            this.dateTimePickerReceiveDate.Size = new System.Drawing.Size(156, 20);
            this.dateTimePickerReceiveDate.TabIndex = 5;
            this.dateTimePickerReceiveDate.ValueChanged += new System.EventHandler(this.dateTimePickerReceiveDate_ValueChanged);
            // 
            // method_ID_CodesTableAdapter
            // 
            this.method_ID_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // grower_Block_ID_CodesTableAdapter
            // 
            this.grower_Block_ID_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // storage_ID_CodesTableAdapter
            // 
            this.storage_ID_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // grower_Block_ID_CodesTableAdapter1
            // 
            this.grower_Block_ID_CodesTableAdapter1.ClearBeforeFill = true;
            // 
            // labelTemplate
            // 
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplate.Location = new System.Drawing.Point(176, 33);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(235, 17);
            this.labelTemplate.TabIndex = 20;
            this.labelTemplate.Text = "Current selected import template is: ";
            // 
            // labelCurrentTemplate
            // 
            this.labelCurrentTemplate.AutoSize = true;
            this.labelCurrentTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTemplate.ForeColor = System.Drawing.Color.Red;
            this.labelCurrentTemplate.Location = new System.Drawing.Point(408, 33);
            this.labelCurrentTemplate.Name = "labelCurrentTemplate";
            this.labelCurrentTemplate.Size = new System.Drawing.Size(213, 17);
            this.labelCurrentTemplate.TabIndex = 21;
            this.labelCurrentTemplate.Text = "No Template has been selected.";
            // 
            // buttonFamousExport
            // 
            this.buttonFamousExport.Enabled = false;
            this.buttonFamousExport.Location = new System.Drawing.Point(41, 216);
            this.buttonFamousExport.Name = "buttonFamousExport";
            this.buttonFamousExport.Size = new System.Drawing.Size(90, 23);
            this.buttonFamousExport.TabIndex = 18;
            this.buttonFamousExport.Text = "Famous Export";
            this.buttonFamousExport.UseVisualStyleBackColor = true;
            this.buttonFamousExport.Click += new System.EventHandler(this.buttonFamousExport_Click);
            // 
            // buttonAdamsExport
            // 
            this.buttonAdamsExport.Enabled = false;
            this.buttonAdamsExport.Location = new System.Drawing.Point(182, 216);
            this.buttonAdamsExport.Name = "buttonAdamsExport";
            this.buttonAdamsExport.Size = new System.Drawing.Size(90, 23);
            this.buttonAdamsExport.TabIndex = 19;
            this.buttonAdamsExport.Text = "Export";
            this.buttonAdamsExport.UseVisualStyleBackColor = true;
            this.buttonAdamsExport.Click += new System.EventHandler(this.buttonAdamsExport_Click);
            // 
            // applicationSettingsDataSetCommodityCodes
            // 
            this.applicationSettingsDataSetCommodityCodes.DataSetName = "ApplicationSettingsDataSetCommodityCodes";
            this.applicationSettingsDataSetCommodityCodes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commodity_CodesTableAdapter
            // 
            this.commodity_CodesTableAdapter.ClearBeforeFill = true;
            // 
            // labelTransactionType
            // 
            this.labelTransactionType.AutoSize = true;
            this.labelTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionType.Location = new System.Drawing.Point(413, 80);
            this.labelTransactionType.Name = "labelTransactionType";
            this.labelTransactionType.Size = new System.Drawing.Size(127, 17);
            this.labelTransactionType.TabIndex = 57;
            this.labelTransactionType.Text = "Transaction Type: ";
            // 
            // comboBoxTransactionType
            // 
            this.comboBoxTransactionType.FormattingEnabled = true;
            this.comboBoxTransactionType.Items.AddRange(new object[] {
            "Receiving",
            "Packing"});
            this.comboBoxTransactionType.Location = new System.Drawing.Point(546, 75);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new System.Drawing.Size(138, 21);
            this.comboBoxTransactionType.TabIndex = 4;
            this.comboBoxTransactionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransactionType_SelectedIndexChanged);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(12, 315);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(191, 20);
            this.labelData.TabIndex = 26;
            this.labelData.Text = "Data Imported/Translated";
            // 
            // checkBoxAvailable
            // 
            this.checkBoxAvailable.AutoSize = true;
            this.checkBoxAvailable.Checked = true;
            this.checkBoxAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAvailable.Location = new System.Drawing.Point(38, 179);
            this.checkBoxAvailable.Name = "checkBoxAvailable";
            this.checkBoxAvailable.Size = new System.Drawing.Size(69, 17);
            this.checkBoxAvailable.TabIndex = 28;
            this.checkBoxAvailable.Text = "Available";
            this.checkBoxAvailable.UseVisualStyleBackColor = true;
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(546, 216);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(75, 23);
            this.buttonValidate.TabIndex = 16;
            this.buttonValidate.Text = "Validate";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // buttonTranslateOld
            // 
            this.buttonTranslateOld.Location = new System.Drawing.Point(38, 285);
            this.buttonTranslateOld.Name = "buttonTranslateOld";
            this.buttonTranslateOld.Size = new System.Drawing.Size(114, 23);
            this.buttonTranslateOld.TabIndex = 15;
            this.buttonTranslateOld.Text = "Translate Old";
            this.buttonTranslateOld.UseVisualStyleBackColor = true;
            this.buttonTranslateOld.Click += new System.EventHandler(this.buttonTranslate_Click);
            // 
            // labelTranslated
            // 
            this.labelTranslated.AutoSize = true;
            this.labelTranslated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslated.ForeColor = System.Drawing.Color.Red;
            this.labelTranslated.Location = new System.Drawing.Point(869, 33);
            this.labelTranslated.Name = "labelTranslated";
            this.labelTranslated.Size = new System.Drawing.Size(194, 17);
            this.labelTranslated.TabIndex = 31;
            this.labelTranslated.Text = "Data Has not been translated";
            // 
            // saveFileDialogSaveExportFile
            // 
            this.saveFileDialogSaveExportFile.DefaultExt = "txt";
            this.saveFileDialogSaveExportFile.FileName = "Famous_Export_File";
            this.saveFileDialogSaveExportFile.InitialDirectory = "C:\\";
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.ForeColor = System.Drawing.Color.Magenta;
            this.labelMode.Location = new System.Drawing.Point(9, 33);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(150, 17);
            this.labelMode.TabIndex = 62;
            this.labelMode.Text = "Running in Test Mode!";
            // 
            // applicationSettingsDataSetWarehouseCodes
            // 
            this.applicationSettingsDataSetWarehouseCodes.DataSetName = "ApplicationSettingsDataSetWarehouseCodes";
            this.applicationSettingsDataSetWarehouseCodes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.Location = new System.Drawing.Point(779, 310);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(64, 13);
            this.labelCurrentFile.TabIndex = 63;
            this.labelCurrentFile.Text = "Import File:  ";
            // 
            // bindingSourceImportTemplates
            // 
            this.bindingSourceImportTemplates.DataMember = "FAPI_Import_Templates";
            this.bindingSourceImportTemplates.DataSource = this.applicationSettingsDataSetImportTemplate;
            // 
            // applicationSettingsDataSetImportTemplate
            // 
            this.applicationSettingsDataSetImportTemplate.DataSetName = "ApplicationSettingsDataSetImportTemplate";
            this.applicationSettingsDataSetImportTemplate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fAPI_Import_TemplatesTableAdapter
            // 
            this.fAPI_Import_TemplatesTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxMethodID
            // 
            this.comboBoxMethodID.DataSource = this.methodIDCodesBindingSource;
            this.comboBoxMethodID.DisplayMember = "Method_Description";
            this.comboBoxMethodID.FormattingEnabled = true;
            this.comboBoxMethodID.Location = new System.Drawing.Point(477, 175);
            this.comboBoxMethodID.Name = "comboBoxMethodID";
            this.comboBoxMethodID.Size = new System.Drawing.Size(144, 21);
            this.comboBoxMethodID.TabIndex = 65;
            this.comboBoxMethodID.ValueMember = "Method_Code";
            this.comboBoxMethodID.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethodID_SelectedIndexChanged);
            // 
            // labelMethodID
            // 
            this.labelMethodID.AutoSize = true;
            this.labelMethodID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMethodID.Location = new System.Drawing.Point(411, 182);
            this.labelMethodID.Name = "labelMethodID";
            this.labelMethodID.Size = new System.Drawing.Size(67, 17);
            this.labelMethodID.TabIndex = 66;
            this.labelMethodID.Text = "Method:  ";
            // 
            // labelStorageID
            // 
            this.labelStorageID.AutoSize = true;
            this.labelStorageID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStorageID.Location = new System.Drawing.Point(411, 146);
            this.labelStorageID.Name = "labelStorageID";
            this.labelStorageID.Size = new System.Drawing.Size(70, 17);
            this.labelStorageID.TabIndex = 67;
            this.labelStorageID.Text = "Storage:  ";
            // 
            // comboBoxStorageID
            // 
            this.comboBoxStorageID.DataSource = this.storageIDCodesBindingSource;
            this.comboBoxStorageID.DisplayMember = "Storage_Description";
            this.comboBoxStorageID.FormattingEnabled = true;
            this.comboBoxStorageID.Location = new System.Drawing.Point(477, 142);
            this.comboBoxStorageID.Name = "comboBoxStorageID";
            this.comboBoxStorageID.Size = new System.Drawing.Size(144, 21);
            this.comboBoxStorageID.TabIndex = 68;
            this.comboBoxStorageID.ValueMember = "Storage_Code";
            this.comboBoxStorageID.SelectedIndexChanged += new System.EventHandler(this.comboBoxStorageID_SelectedIndexChanged);
            // 
            // grower_NameTableAdapter
            // 
            this.grower_NameTableAdapter.ClearBeforeFill = true;
            // 
            // labelExportFile
            // 
            this.labelExportFile.AutoSize = true;
            this.labelExportFile.Location = new System.Drawing.Point(232, 276);
            this.labelExportFile.Name = "labelExportFile";
            this.labelExportFile.Size = new System.Drawing.Size(72, 13);
            this.labelExportFile.TabIndex = 69;
            this.labelExportFile.Text = "Famous File:  ";
            // 
            // labelExportAdamsFile
            // 
            this.labelExportAdamsFile.AutoSize = true;
            this.labelExportAdamsFile.Location = new System.Drawing.Point(232, 310);
            this.labelExportAdamsFile.Name = "labelExportAdamsFile";
            this.labelExportAdamsFile.Size = new System.Drawing.Size(67, 13);
            this.labelExportAdamsFile.TabIndex = 70;
            this.labelExportAdamsFile.Text = "Adams File:  ";
            // 
            // Button4Transalation
            // 
            this.Button4Transalation.Location = new System.Drawing.Point(416, 216);
            this.Button4Transalation.Name = "Button4Transalation";
            this.Button4Transalation.Size = new System.Drawing.Size(75, 23);
            this.Button4Transalation.TabIndex = 71;
            this.Button4Transalation.Text = "Translate";
            this.Button4Transalation.UseVisualStyleBackColor = true;
            this.Button4Transalation.Click += new System.EventHandler(this.Button4Transalation_Click);
            // 
            // checkBoxXMLExport
            // 
            this.checkBoxXMLExport.AutoSize = true;
            this.checkBoxXMLExport.Checked = true;
            this.checkBoxXMLExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxXMLExport.Location = new System.Drawing.Point(45, 256);
            this.checkBoxXMLExport.Name = "checkBoxXMLExport";
            this.checkBoxXMLExport.Size = new System.Drawing.Size(81, 17);
            this.checkBoxXMLExport.TabIndex = 72;
            this.checkBoxXMLExport.Text = "XML Export";
            this.checkBoxXMLExport.UseVisualStyleBackColor = true;
            // 
            // FormFAPI_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 750);
            this.Controls.Add(this.checkBoxXMLExport);
            this.Controls.Add(this.Button4Transalation);
            this.Controls.Add(this.labelExportAdamsFile);
            this.Controls.Add(this.labelExportFile);
            this.Controls.Add(this.comboBoxStorageID);
            this.Controls.Add(this.labelStorageID);
            this.Controls.Add(this.labelMethodID);
            this.Controls.Add(this.comboBoxMethodID);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.labelTranslated);
            this.Controls.Add(this.buttonTranslateOld);
            this.Controls.Add(this.buttonValidate);
            this.Controls.Add(this.checkBoxAvailable);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.comboBoxTransactionType);
            this.Controls.Add(this.labelTransactionType);
            this.Controls.Add(this.buttonAdamsExport);
            this.Controls.Add(this.buttonFamousExport);
            this.Controls.Add(this.labelCurrentTemplate);
            this.Controls.Add(this.labelTemplate);
            this.Controls.Add(this.dateTimePickerReceiveDate);
            this.Controls.Add(this.labelReceivingDate);
            this.Controls.Add(this.comboBoxGrowerBlock);
            this.Controls.Add(this.labelGrowerBlock);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.panelVesselInformation);
            this.Controls.Add(this.labelWarehouse);
            this.Controls.Add(this.dataGridViewExcel);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.menuStripExportApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFAPI_Import";
            this.Text = "FAPI Inventory Import Version 4.0";
            this.Load += new System.EventHandler(this.FormFAPI_Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWarehouseCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSourceObjectBindingSource)).EndInit();
            this.panelVesselInformation.ResumeLayout(false);
            this.panelVesselInformation.PerformLayout();
            this.menuStripExportApp.ResumeLayout(false);
            this.menuStripExportApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionIDCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.growerNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.growerBlockIDCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetGrowersBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.methodIDCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageIDCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetStorageID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetCommodityCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetWarehouseCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceImportTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetImportTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
        private System.Windows.Forms.BindingSource bindingSourceWarehouseCodes;
        private ApplicationSettingsDataSet applicationSettingsDataSet;
        private FAPI_Inventory_Import.ApplicationSettingsDataSetTableAdapters.Inventory_Warehouse_CodesTableAdapter inventory_Warehouse_CodesTableAdapter;
        private System.Windows.Forms.BindingSource officeDataSourceObjectBindingSource;
        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.Label labelExporter;
        private System.Windows.Forms.TextBox textBoxExporter;
        private System.Windows.Forms.Panel panelVesselInformation;
        private System.Windows.Forms.Label labelDepartureDate;
        private System.Windows.Forms.Label labelVesselName;
        private System.Windows.Forms.TextBox textBoxVesselNumber;
        private System.Windows.Forms.Label labelVesselNumber;
        private System.Windows.Forms.TextBox textBoxDepartureDate;
        private System.Windows.Forms.TextBox textBoxVesselName;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxPalletPrefix;
        private System.Windows.Forms.Label labelPalletPrefix;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.MenuStrip menuStripExportApp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private ApplicationSettingsDataSet1 applicationSettingsDataSet1;
        private System.Windows.Forms.BindingSource regionIDCodesBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet1TableAdapters.Region_ID_CodesTableAdapter region_ID_CodesTableAdapter;
        private System.Windows.Forms.Label labelGrowerBlock;
        private System.Windows.Forms.ComboBox comboBoxGrowerBlock;
        private ApplicationSettingsDataSet2 applicationSettingsDataSet2;
        private System.Windows.Forms.Label labelReceivingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerReceiveDate;
        private ApplicationSettingsDataSet3 applicationSettingsDataSet3;
        private ApplicationSettingsDataSet4 applicationSettingsDataSet4;
        private System.Windows.Forms.BindingSource methodIDCodesBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet4TableAdapters.Method_ID_CodesTableAdapter method_ID_CodesTableAdapter;
        private System.Windows.Forms.BindingSource growerBlockIDCodesBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet6TableAdapters.Grower_Block_ID_CodesTableAdapter grower_Block_ID_CodesTableAdapter;
        private ApplicationSettingsDataSetGrowersBlock applicationSettingsDataSetGrowersBlock;
        private System.Windows.Forms.BindingSource storageIDCodesBindingSource;
        private ApplicationSettingsDataSetStorageID applicationSettingsDataSetStorageID;
        private FAPI_Inventory_Import.ApplicationSettingsDataSetStorageIDTableAdapters.Storage_ID_CodesTableAdapter storage_ID_CodesTableAdapter;
        private FAPI_Inventory_Import.ApplicationSettingsDataSetGrowersBlockTableAdapters.Grower_Block_ID_CodesTableAdapter grower_Block_ID_CodesTableAdapter1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTemplate;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Label labelCurrentTemplate;
        private System.Windows.Forms.Label labelVesselInfoTITLE;
        private System.Windows.Forms.Button buttonFamousExport;
        private System.Windows.Forms.Button buttonAdamsExport;
        private ApplicationSettingsDataSetCommodityCodes applicationSettingsDataSetCommodityCodes;
        private ApplicationSettingsDataSet9 applicationSettingsDataSet9;
        private System.Windows.Forms.BindingSource commodityCodesBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet9TableAdapters.Commodity_CodesTableAdapter commodity_CodesTableAdapter;
        private System.Windows.Forms.Label labelTransactionType;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.CheckBox checkBoxAvailable;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Button buttonTranslateOld;
        private System.Windows.Forms.Label labelTranslated;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveExportFile;
        private System.Windows.Forms.Label labelMode;
        private ApplicationSettingsDataSet applicationSettingsDataSetWarehouseCodes;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.BindingSource bindingSourceImportTemplates;
        private ApplicationSettingsDataSetImportTemplate applicationSettingsDataSetImportTemplate;
        private FAPI_Inventory_Import.ApplicationSettingsDataSetImportTemplateTableAdapters.FAPI_Import_TemplatesTableAdapter fAPI_Import_TemplatesTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem famousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTranslationValidationToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBoxMethodID;
        private System.Windows.Forms.Label labelMethodID;
        private System.Windows.Forms.Label labelStorageID;
        private System.Windows.Forms.ComboBox comboBoxStorageID;
        private ApplicationSettingsDataSet17 applicationSettingsDataSet17;
        private System.Windows.Forms.BindingSource growerNameBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet17TableAdapters.Grower_NameTableAdapter grower_NameTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem updateTablesToolStripMenuItem;
        private System.Windows.Forms.Label labelExportFile;
        private System.Windows.Forms.Label labelExportAdamsFile;
        private System.Windows.Forms.ToolStripMenuItem updateTranslationsToolStripMenuItem;
        private System.Windows.Forms.Button Button4Transalation;
        private System.Windows.Forms.ToolStripMenuItem stoneFruitListToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxXMLExport;
        private System.Windows.Forms.ToolStripMenuItem templateCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCodeEditorToolStripMenuItem;
    }
}

