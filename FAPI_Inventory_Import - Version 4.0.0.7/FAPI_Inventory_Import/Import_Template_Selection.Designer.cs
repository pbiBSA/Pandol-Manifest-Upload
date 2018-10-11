namespace FAPI_Inventory_Import
{
    partial class Import_Template_Selection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import_Template_Selection));
            this.labelSelectImportTemplate = new System.Windows.Forms.Label();
            this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
            this.bindingSourceImport_Templates = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSetImportTemplateSettings = new FAPI_Inventory_Import.ApplicationSettingsDataSet14();
            this.buttonDone = new System.Windows.Forms.Button();
            this.fAPI_Import_TemplatesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet14TableAdapters.FAPI_Import_TemplatesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceImport_Templates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetImportTemplateSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectImportTemplate
            // 
            this.labelSelectImportTemplate.AutoSize = true;
            this.labelSelectImportTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectImportTemplate.Location = new System.Drawing.Point(142, 78);
            this.labelSelectImportTemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectImportTemplate.Name = "labelSelectImportTemplate";
            this.labelSelectImportTemplate.Size = new System.Drawing.Size(178, 20);
            this.labelSelectImportTemplate.TabIndex = 0;
            this.labelSelectImportTemplate.Text = "Select Import Template ";
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.DataSource = this.bindingSourceImport_Templates;
            this.comboBoxTemplate.DisplayMember = "Template_Name";
            this.comboBoxTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTemplate.FormattingEnabled = true;
            this.comboBoxTemplate.Location = new System.Drawing.Point(45, 145);
            this.comboBoxTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            this.comboBoxTemplate.Size = new System.Drawing.Size(400, 28);
            this.comboBoxTemplate.TabIndex = 1;
            this.comboBoxTemplate.ValueMember = "Template_Name";
            this.comboBoxTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemplate_SelectedIndexChanged);
            // 
            // bindingSourceImport_Templates
            // 
            this.bindingSourceImport_Templates.DataMember = "FAPI_Import_Templates";
            this.bindingSourceImport_Templates.DataSource = this.applicationSettingsDataSetImportTemplateSettings;
            // 
            // applicationSettingsDataSetImportTemplateSettings
            // 
            this.applicationSettingsDataSetImportTemplateSettings.DataSetName = "ApplicationSettingsDataSetImportTemplateSettinmgs";
            this.applicationSettingsDataSetImportTemplateSettings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(190, 243);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(100, 35);
            this.buttonDone.TabIndex = 2;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // fAPI_Import_TemplatesTableAdapter
            // 
            this.fAPI_Import_TemplatesTableAdapter.ClearBeforeFill = true;
            // 
            // Import_Template_Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.comboBoxTemplate);
            this.Controls.Add(this.labelSelectImportTemplate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Import_Template_Selection";
            this.Text = "Import Template Selection";
            this.Load += new System.EventHandler(this.Import_Template_Selection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceImport_Templates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSetImportTemplateSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectImportTemplate;
        private System.Windows.Forms.ComboBox comboBoxTemplate;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.BindingSource bindingSourceImport_Templates;
        private ApplicationSettingsDataSet14 applicationSettingsDataSetImportTemplateSettings;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet14TableAdapters.FAPI_Import_TemplatesTableAdapter fAPI_Import_TemplatesTableAdapter;
    }
}