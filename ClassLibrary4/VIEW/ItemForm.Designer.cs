namespace S1Custom
{
    partial class ItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.RPanel = new System.Windows.Forms.Panel();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BricksDataGridView = new System.Windows.Forms.DataGridView();
            this.CCCCONNECTIONBRICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.RPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1115, 25);
            this.toolStrip1.TabIndex = 20;
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
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // RPanel
            // 
            this.RPanel.Controls.Add(this.ResultsTextBox);
            this.RPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RPanel.Location = new System.Drawing.Point(771, 25);
            this.RPanel.Name = "RPanel";
            this.RPanel.Size = new System.Drawing.Size(344, 500);
            this.RPanel.TabIndex = 22;
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ResultsTextBox.Location = new System.Drawing.Point(0, 0);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.Size = new System.Drawing.Size(344, 500);
            this.ResultsTextBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BricksDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 500);
            this.panel3.TabIndex = 23;
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
            this.BricksDataGridView.Size = new System.Drawing.Size(771, 500);
            this.BricksDataGridView.TabIndex = 1;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-6, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 61);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(884, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 95);
            this.panel2.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(181)))), ((int)(((byte)(199)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(19, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 73);
            this.button1.TabIndex = 36;
            this.button1.Text = "Web Login";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 95);
            this.panel1.TabIndex = 21;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 620);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.RPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemForm";
            this.Text = "vWeb";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.VisibleChanged += new System.EventHandler(this.ItemForm_VisibleChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.RPanel.ResumeLayout(false);
            this.RPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel RPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView BricksDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCCONNECTIONBRICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}