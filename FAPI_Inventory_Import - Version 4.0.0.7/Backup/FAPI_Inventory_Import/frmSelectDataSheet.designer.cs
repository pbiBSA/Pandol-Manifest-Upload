namespace FAPI_Inventory_Import
{
    partial class frmSelectDataSheet
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
            this.lSelectDataSheet = new System.Windows.Forms.Label();
            this.cbDataSheetList = new System.Windows.Forms.ComboBox();
            this.bOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lSelectDataSheet
            // 
            this.lSelectDataSheet.AutoSize = true;
            this.lSelectDataSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSelectDataSheet.Location = new System.Drawing.Point(67, 13);
            this.lSelectDataSheet.Name = "lSelectDataSheet";
            this.lSelectDataSheet.Size = new System.Drawing.Size(185, 20);
            this.lSelectDataSheet.TabIndex = 0;
            this.lSelectDataSheet.Text = "Select Datasheet to use.";
            // 
            // cbDataSheetList
            // 
            this.cbDataSheetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataSheetList.FormattingEnabled = true;
            this.cbDataSheetList.Location = new System.Drawing.Point(96, 62);
            this.cbDataSheetList.Name = "cbDataSheetList";
            this.cbDataSheetList.Size = new System.Drawing.Size(121, 24);
            this.cbDataSheetList.TabIndex = 1;
            this.cbDataSheetList.SelectedIndexChanged += new System.EventHandler(this.cbDataSheetList_SelectedIndexChanged);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(120, 125);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // frmSelectDataSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 217);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.cbDataSheetList);
            this.Controls.Add(this.lSelectDataSheet);
            this.Name = "frmSelectDataSheet";
            this.Text = "frmSelectDataSheet";
            this.Load += new System.EventHandler(this.frmSelectDataSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSelectDataSheet;
        private System.Windows.Forms.ComboBox cbDataSheetList;
        private System.Windows.Forms.Button bOK;
    }
}