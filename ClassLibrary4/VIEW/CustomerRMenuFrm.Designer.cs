namespace ClassLibrary4.VIEW
{
    partial class CustomerRMenuFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerRMenuFrm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.BricksDataGridView = new System.Windows.Forms.DataGridView();
            this.CCCCONNECTIONBRICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BricksDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 494);
            this.panel2.TabIndex = 1;
            // 
            // BricksDataGridView
            // 
            this.BricksDataGridView.AllowUserToAddRows = false;
            this.BricksDataGridView.AllowUserToDeleteRows = false;
            this.BricksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BricksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCCCONNECTIONBRICK,
            this.CODE,
            this.NAME});
            this.BricksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BricksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.BricksDataGridView.Name = "BricksDataGridView";
            this.BricksDataGridView.ReadOnly = true;
            this.BricksDataGridView.Size = new System.Drawing.Size(1060, 494);
            this.BricksDataGridView.TabIndex = 4;
            this.BricksDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BricksDataGridView_CellDoubleClick);
            // 
            // CCCCONNECTIONBRICK
            // 
            this.CCCCONNECTIONBRICK.HeaderText = "CCCCONNECTIONBRICK";
            this.CCCCONNECTIONBRICK.Name = "CCCCONNECTIONBRICK";
            this.CCCCONNECTIONBRICK.ReadOnly = true;
            this.CCCCONNECTIONBRICK.Visible = false;
            // 
            // CODE
            // 
            this.CODE.HeaderText = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 600;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 76);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1060, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResultsTextBox.Location = new System.Drawing.Point(788, 25);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.Size = new System.Drawing.Size(272, 469);
            this.ResultsTextBox.TabIndex = 10;
            // 
            // CustomerRMenuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 570);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerRMenuFrm";
            this.Text = "V Web";
            this.Load += new System.EventHandler(this.CustomerRMenuFrm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.DataGridView BricksDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCCONNECTIONBRICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;

    }
}