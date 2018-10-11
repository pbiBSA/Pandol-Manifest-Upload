namespace FAPI_Inventory_Import
{
    partial class TemplateCreator
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
            this.bLoadExcelFile = new System.Windows.Forms.Button();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.lbRow = new System.Windows.Forms.Label();
            this.lbColumn = new System.Windows.Forms.Label();
            this.tbTemplateName = new System.Windows.Forms.TextBox();
            this.lbTemplateName = new System.Windows.Forms.Label();
            this.bCheckName = new System.Windows.Forms.Button();
            this.lMissingColumns = new System.Windows.Forms.Label();
            this.lbMissingColumns = new System.Windows.Forms.ListBox();
            this.bSetMissingColumnsCode = new System.Windows.Forms.Button();
            this.lMissingColumnsValue = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.lclickOnCell = new System.Windows.Forms.Label();
            this.lFieldName = new System.Windows.Forms.Label();
            this.bRestart = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tbDataSheet = new System.Windows.Forms.TextBox();
            this.lEnterDataSheetName = new System.Windows.Forms.Label();
            this.bView = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bSaveExit = new System.Windows.Forms.Button();
            this.tbDataRange = new System.Windows.Forms.TextBox();
            this.lSpecialProcessing = new System.Windows.Forms.Label();
            this.lTemplateSelected = new System.Windows.Forms.Label();
            this.tbSelectedTemplate = new System.Windows.Forms.TextBox();
            this.lbFinishedItems = new System.Windows.Forms.ListBox();
            this.lcompleteditems = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bBack = new System.Windows.Forms.Button();
            this.tcviews = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewExcel2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTemplatesView = new System.Windows.Forms.DataGridView();
            this.lTemplateIndex = new System.Windows.Forms.Label();
            this.tcviews.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplatesView)).BeginInit();
            this.SuspendLayout();
            // 
            // bLoadExcelFile
            // 
            this.bLoadExcelFile.Location = new System.Drawing.Point(47, 54);
            this.bLoadExcelFile.Name = "bLoadExcelFile";
            this.bLoadExcelFile.Size = new System.Drawing.Size(75, 23);
            this.bLoadExcelFile.TabIndex = 0;
            this.bLoadExcelFile.Text = "Load File";
            this.bLoadExcelFile.UseVisualStyleBackColor = true;
            this.bLoadExcelFile.Click += new System.EventHandler(this.bLoadExcelFile_Click);
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.Filter = "Excel Files|*.xl*";
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentFile.Location = new System.Drawing.Point(21, 18);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(241, 17);
            this.labelCurrentFile.TabIndex = 2;
            this.labelCurrentFile.Text = "Load the Excel file to create template";
            // 
            // lbRow
            // 
            this.lbRow.AutoSize = true;
            this.lbRow.Location = new System.Drawing.Point(18, 319);
            this.lbRow.Name = "lbRow";
            this.lbRow.Size = new System.Drawing.Size(29, 13);
            this.lbRow.TabIndex = 3;
            this.lbRow.Text = "Row";
            // 
            // lbColumn
            // 
            this.lbColumn.AutoSize = true;
            this.lbColumn.Location = new System.Drawing.Point(81, 319);
            this.lbColumn.Name = "lbColumn";
            this.lbColumn.Size = new System.Drawing.Size(42, 13);
            this.lbColumn.TabIndex = 4;
            this.lbColumn.Text = "Column";
            // 
            // tbTemplateName
            // 
            this.tbTemplateName.Location = new System.Drawing.Point(156, 173);
            this.tbTemplateName.Name = "tbTemplateName";
            this.tbTemplateName.Size = new System.Drawing.Size(161, 20);
            this.tbTemplateName.TabIndex = 5;
            this.tbTemplateName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbTemplateName
            // 
            this.lbTemplateName.AutoSize = true;
            this.lbTemplateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemplateName.Location = new System.Drawing.Point(44, 173);
            this.lbTemplateName.Name = "lbTemplateName";
            this.lbTemplateName.Size = new System.Drawing.Size(112, 17);
            this.lbTemplateName.TabIndex = 6;
            this.lbTemplateName.Text = "Template Name:";
            // 
            // bCheckName
            // 
            this.bCheckName.Location = new System.Drawing.Point(156, 206);
            this.bCheckName.Name = "bCheckName";
            this.bCheckName.Size = new System.Drawing.Size(109, 23);
            this.bCheckName.TabIndex = 7;
            this.bCheckName.Text = "Check Name";
            this.bCheckName.UseVisualStyleBackColor = true;
            this.bCheckName.Click += new System.EventHandler(this.bCheckName_Click);
            // 
            // lMissingColumns
            // 
            this.lMissingColumns.AutoSize = true;
            this.lMissingColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMissingColumns.Location = new System.Drawing.Point(889, 32);
            this.lMissingColumns.Name = "lMissingColumns";
            this.lMissingColumns.Size = new System.Drawing.Size(113, 17);
            this.lMissingColumns.TabIndex = 9;
            this.lMissingColumns.Text = "Missing Columns";
            // 
            // lbMissingColumns
            // 
            this.lbMissingColumns.FormattingEnabled = true;
            this.lbMissingColumns.Items.AddRange(new object[] {
            "Style & Size",
            "Grade",
            "Pallet Type",
            "Hatch & Deck",
            "Commodity",
            "Fumigation",
            "Bill of Lading",
            "Pack Code",
            "Memo"});
            this.lbMissingColumns.Location = new System.Drawing.Point(892, 54);
            this.lbMissingColumns.MultiColumn = true;
            this.lbMissingColumns.Name = "lbMissingColumns";
            this.lbMissingColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMissingColumns.Size = new System.Drawing.Size(246, 69);
            this.lbMissingColumns.TabIndex = 11;
            // 
            // bSetMissingColumnsCode
            // 
            this.bSetMissingColumnsCode.Location = new System.Drawing.Point(892, 153);
            this.bSetMissingColumnsCode.Name = "bSetMissingColumnsCode";
            this.bSetMissingColumnsCode.Size = new System.Drawing.Size(128, 23);
            this.bSetMissingColumnsCode.TabIndex = 12;
            this.bSetMissingColumnsCode.Text = "Set Missing Columns";
            this.bSetMissingColumnsCode.UseVisualStyleBackColor = true;
            this.bSetMissingColumnsCode.Click += new System.EventHandler(this.bSetMissingColumnsCode_Click);
            // 
            // lMissingColumnsValue
            // 
            this.lMissingColumnsValue.AutoSize = true;
            this.lMissingColumnsValue.Location = new System.Drawing.Point(1040, 158);
            this.lMissingColumnsValue.Name = "lMissingColumnsValue";
            this.lMissingColumnsValue.Size = new System.Drawing.Size(0, 13);
            this.lMissingColumnsValue.TabIndex = 13;
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bStart.Location = new System.Drawing.Point(614, 309);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(78, 33);
            this.bStart.TabIndex = 14;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lclickOnCell
            // 
            this.lclickOnCell.AutoSize = true;
            this.lclickOnCell.Location = new System.Drawing.Point(161, 319);
            this.lclickOnCell.Name = "lclickOnCell";
            this.lclickOnCell.Size = new System.Drawing.Size(86, 13);
            this.lclickOnCell.TabIndex = 15;
            this.lclickOnCell.Text = "Click on Cell for: ";
            // 
            // lFieldName
            // 
            this.lFieldName.AutoSize = true;
            this.lFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFieldName.Location = new System.Drawing.Point(251, 316);
            this.lFieldName.Name = "lFieldName";
            this.lFieldName.Size = new System.Drawing.Size(24, 20);
            this.lFieldName.TabIndex = 16;
            this.lFieldName.Text = "...";
            // 
            // bRestart
            // 
            this.bRestart.Location = new System.Drawing.Point(242, 54);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(75, 23);
            this.bRestart.TabIndex = 17;
            this.bRestart.Text = "Restart";
            this.bRestart.UseVisualStyleBackColor = true;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(1063, 263);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 21;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(214, 263);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 22;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbDataSheet
            // 
            this.tbDataSheet.Location = new System.Drawing.Point(164, 93);
            this.tbDataSheet.Name = "tbDataSheet";
            this.tbDataSheet.Size = new System.Drawing.Size(153, 20);
            this.tbDataSheet.TabIndex = 23;
            this.tbDataSheet.TextChanged += new System.EventHandler(this.tbDataSheet_TextChanged);
            // 
            // lEnterDataSheetName
            // 
            this.lEnterDataSheetName.AutoSize = true;
            this.lEnterDataSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnterDataSheetName.Location = new System.Drawing.Point(44, 94);
            this.lEnterDataSheetName.Name = "lEnterDataSheetName";
            this.lEnterDataSheetName.Size = new System.Drawing.Size(114, 17);
            this.lEnterDataSheetName.TabIndex = 24;
            this.lEnterDataSheetName.Text = "Datasheet Name";
            // 
            // bView
            // 
            this.bView.Location = new System.Drawing.Point(791, 261);
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(119, 23);
            this.bView.TabIndex = 26;
            this.bView.Text = "View Templates";
            this.bView.UseVisualStyleBackColor = true;
            this.bView.Click += new System.EventHandler(this.bView_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(374, 261);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(108, 23);
            this.bEdit.TabIndex = 28;
            this.bEdit.Text = "Template Editor";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(554, 261);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 29;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bSaveExit
            // 
            this.bSaveExit.Location = new System.Drawing.Point(47, 263);
            this.bSaveExit.Name = "bSaveExit";
            this.bSaveExit.Size = new System.Drawing.Size(88, 23);
            this.bSaveExit.TabIndex = 30;
            this.bSaveExit.Text = "Save and Exit";
            this.bSaveExit.UseVisualStyleBackColor = true;
            this.bSaveExit.Click += new System.EventHandler(this.bSaveExit_Click);
            // 
            // tbDataRange
            // 
            this.tbDataRange.Location = new System.Drawing.Point(992, 199);
            this.tbDataRange.Name = "tbDataRange";
            this.tbDataRange.Size = new System.Drawing.Size(100, 20);
            this.tbDataRange.TabIndex = 31;
            // 
            // lSpecialProcessing
            // 
            this.lSpecialProcessing.AutoSize = true;
            this.lSpecialProcessing.Location = new System.Drawing.Point(889, 202);
            this.lSpecialProcessing.Name = "lSpecialProcessing";
            this.lSpecialProcessing.Size = new System.Drawing.Size(68, 13);
            this.lSpecialProcessing.TabIndex = 32;
            this.lSpecialProcessing.Text = "Data Range:";
            // 
            // lTemplateSelected
            // 
            this.lTemplateSelected.AutoSize = true;
            this.lTemplateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemplateSelected.Location = new System.Drawing.Point(733, 319);
            this.lTemplateSelected.Name = "lTemplateSelected";
            this.lTemplateSelected.Size = new System.Drawing.Size(196, 17);
            this.lTemplateSelected.TabIndex = 33;
            this.lTemplateSelected.Text = "Template Selected for Delete:";
            this.lTemplateSelected.Visible = false;
            // 
            // tbSelectedTemplate
            // 
            this.tbSelectedTemplate.Enabled = false;
            this.tbSelectedTemplate.Location = new System.Drawing.Point(930, 318);
            this.tbSelectedTemplate.Name = "tbSelectedTemplate";
            this.tbSelectedTemplate.Size = new System.Drawing.Size(195, 20);
            this.tbSelectedTemplate.TabIndex = 34;
            this.tbSelectedTemplate.Visible = false;
            // 
            // lbFinishedItems
            // 
            this.lbFinishedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFinishedItems.FormattingEnabled = true;
            this.lbFinishedItems.ItemHeight = 15;
            this.lbFinishedItems.Location = new System.Drawing.Point(399, 69);
            this.lbFinishedItems.MultiColumn = true;
            this.lbFinishedItems.Name = "lbFinishedItems";
            this.lbFinishedItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbFinishedItems.Size = new System.Drawing.Size(441, 139);
            this.lbFinishedItems.TabIndex = 35;
            // 
            // lcompleteditems
            // 
            this.lcompleteditems.AutoSize = true;
            this.lcompleteditems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcompleteditems.Location = new System.Drawing.Point(396, 45);
            this.lcompleteditems.Name = "lcompleteditems";
            this.lcompleteditems.Size = new System.Drawing.Size(208, 17);
            this.lcompleteditems.TabIndex = 36;
            this.lcompleteditems.Text = "Completed Items (Row, Column)";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(47, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 38);
            this.textBox1.TabIndex = 37;
            this.textBox1.Text = "Entered value overrides datasheet name selected when excel file was loaded.";
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bBack.Enabled = false;
            this.bBack.Location = new System.Drawing.Point(500, 309);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(78, 33);
            this.bBack.TabIndex = 38;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // tcviews
            // 
            this.tcviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcviews.Controls.Add(this.tabPage1);
            this.tcviews.Controls.Add(this.tabPage2);
            this.tcviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcviews.Location = new System.Drawing.Point(2, 372);
            this.tcviews.Name = "tcviews";
            this.tcviews.SelectedIndex = 0;
            this.tcviews.Size = new System.Drawing.Size(1185, 475);
            this.tcviews.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewExcel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1177, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Spreadsheet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExcel2
            // 
            this.dataGridViewExcel2.AllowUserToAddRows = false;
            this.dataGridViewExcel2.AllowUserToDeleteRows = false;
            this.dataGridViewExcel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExcel2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewExcel2.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewExcel2.Name = "dataGridViewExcel2";
            this.dataGridViewExcel2.Size = new System.Drawing.Size(1168, 434);
            this.dataGridViewExcel2.TabIndex = 2;
            this.dataGridViewExcel2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExcel2_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTemplatesView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1177, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Template List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTemplatesView
            // 
            this.dgvTemplatesView.AllowUserToAddRows = false;
            this.dgvTemplatesView.AllowUserToDeleteRows = false;
            this.dgvTemplatesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTemplatesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplatesView.Location = new System.Drawing.Point(6, 6);
            this.dgvTemplatesView.Name = "dgvTemplatesView";
            this.dgvTemplatesView.Size = new System.Drawing.Size(1162, 434);
            this.dgvTemplatesView.TabIndex = 28;
            this.dgvTemplatesView.Visible = false;
            this.dgvTemplatesView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTemplatesView_CellMouseClick);
            // 
            // lTemplateIndex
            // 
            this.lTemplateIndex.AutoSize = true;
            this.lTemplateIndex.Location = new System.Drawing.Point(622, 356);
            this.lTemplateIndex.Name = "lTemplateIndex";
            this.lTemplateIndex.Size = new System.Drawing.Size(16, 13);
            this.lTemplateIndex.TabIndex = 40;
            this.lTemplateIndex.Text = "...";
            // 
            // TemplateCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 859);
            this.Controls.Add(this.lTemplateIndex);
            this.Controls.Add(this.tcviews);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lcompleteditems);
            this.Controls.Add(this.lbFinishedItems);
            this.Controls.Add(this.tbSelectedTemplate);
            this.Controls.Add(this.lTemplateSelected);
            this.Controls.Add(this.lSpecialProcessing);
            this.Controls.Add(this.tbDataRange);
            this.Controls.Add(this.bSaveExit);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bView);
            this.Controls.Add(this.lEnterDataSheetName);
            this.Controls.Add(this.tbDataSheet);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bRestart);
            this.Controls.Add(this.lFieldName);
            this.Controls.Add(this.lclickOnCell);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lMissingColumnsValue);
            this.Controls.Add(this.bSetMissingColumnsCode);
            this.Controls.Add(this.lbMissingColumns);
            this.Controls.Add(this.lMissingColumns);
            this.Controls.Add(this.bCheckName);
            this.Controls.Add(this.lbTemplateName);
            this.Controls.Add(this.tbTemplateName);
            this.Controls.Add(this.lbColumn);
            this.Controls.Add(this.lbRow);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.bLoadExcelFile);
            this.Name = "TemplateCreator";
            this.Text = "TemplateCreator";
            this.Load += new System.EventHandler(this.TemplateCreator_Load);
            this.tcviews.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplatesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLoadExcelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.Label lbRow;
        private System.Windows.Forms.Label lbColumn;
        private System.Windows.Forms.TextBox tbTemplateName;
        private System.Windows.Forms.Label lbTemplateName;
        private System.Windows.Forms.Button bCheckName;
        private System.Windows.Forms.Label lMissingColumns;
        private System.Windows.Forms.ListBox lbMissingColumns;
        private System.Windows.Forms.Button bSetMissingColumnsCode;
        private System.Windows.Forms.Label lMissingColumnsValue;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lclickOnCell;
        private System.Windows.Forms.Label lFieldName;
        private System.Windows.Forms.Button bRestart;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbDataSheet;
        private System.Windows.Forms.Label lEnterDataSheetName;
        private System.Windows.Forms.Button bView;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bSaveExit;
        private System.Windows.Forms.TextBox tbDataRange;
        private System.Windows.Forms.Label lSpecialProcessing;
        private System.Windows.Forms.Label lTemplateSelected;
        private System.Windows.Forms.TextBox tbSelectedTemplate;
        private System.Windows.Forms.ListBox lbFinishedItems;
        private System.Windows.Forms.Label lcompleteditems;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.TabControl tcviews;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTemplatesView;
        private System.Windows.Forms.DataGridView dataGridViewExcel2;
        private System.Windows.Forms.Label lTemplateIndex;
    }
}