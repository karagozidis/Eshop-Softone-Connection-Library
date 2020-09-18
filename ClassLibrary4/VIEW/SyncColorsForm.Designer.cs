namespace ClassLibrary4.VIEW
{
    partial class SyncColorsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncColorsForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ΗΕΧ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GENNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(896, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.NAME,
            this.ΗΕΧ,
            this.GENNAME});
            this.DGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV1.Location = new System.Drawing.Point(0, 25);
            this.DGV1.Name = "DGV1";
            this.DGV1.Size = new System.Drawing.Size(896, 592);
            this.DGV1.TabIndex = 1;
            this.DGV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV1_MouseClick);
            // 
            // CODE
            // 
            this.CODE.HeaderText = "Κωδικός";
            this.CODE.Name = "CODE";
            // 
            // NAME
            // 
            this.NAME.HeaderText = "Περιγραφή";
            this.NAME.Name = "NAME";
            this.NAME.Width = 250;
            // 
            // ΗΕΧ
            // 
            this.ΗΕΧ.HeaderText = "Χρώμα";
            this.ΗΕΧ.Name = "ΗΕΧ";
            // 
            // GENNAME
            // 
            this.GENNAME.HeaderText = "Γενική Περιγραφή";
            this.GENNAME.Name = "GENNAME";
            this.GENNAME.Width = 200;
            // 
            // SyncColorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 617);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SyncColorsForm";
            this.Text = "SyncColorsForm";
            this.Load += new System.EventHandler(this.SyncColorsForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ΗΕΧ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GENNAME;
    }
}