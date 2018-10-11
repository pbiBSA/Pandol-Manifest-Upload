namespace FAPI_Inventory_Import
{
    partial class CombinedMixedBoxesDataViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombinedMixedBoxesDataViewForm));
            this.dataGridViewCombinedBoxesView = new System.Windows.Forms.DataGridView();
            this.labelEdit = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCombinedBoxesView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCombinedBoxesView
            // 
            this.dataGridViewCombinedBoxesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCombinedBoxesView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewCombinedBoxesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCombinedBoxesView.Location = new System.Drawing.Point(12, 35);
            this.dataGridViewCombinedBoxesView.Name = "dataGridViewCombinedBoxesView";
            this.dataGridViewCombinedBoxesView.Size = new System.Drawing.Size(960, 500);
            this.dataGridViewCombinedBoxesView.TabIndex = 0;
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.Location = new System.Drawing.Point(12, 13);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(125, 13);
            this.labelEdit.TabIndex = 1;
            this.labelEdit.Text = "Maybe Edited as needed";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(655, 8);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 2;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // CombinedMixedBoxesDataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 577);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.dataGridViewCombinedBoxesView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CombinedMixedBoxesDataViewForm";
            this.Text = "Combined Mixed Boxes Data After Combining";
            this.Load += new System.EventHandler(this.CombinedMixedBoxesDataViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCombinedBoxesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCombinedBoxesView;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.Button buttonDone;
    }
}