﻿namespace ClassLibrary4.VIEW
{
    partial class ItemRMenuFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemRMenuFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
         
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.RPanel = new System.Windows.Forms.Panel();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BricksDataGridView = new System.Windows.Forms.DataGridView();
            this.CCCCONNECTIONBRICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

            this.toolStrip1.SuspendLayout();
            this.RPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 66);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 61);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(969, 25);
            this.toolStrip1.TabIndex = 7;
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
            this.RPanel.Location = new System.Drawing.Point(697, 25);
            this.RPanel.Name = "RPanel";
            this.RPanel.Size = new System.Drawing.Size(272, 457);
            this.RPanel.TabIndex = 8;
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTextBox.Location = new System.Drawing.Point(0, 0);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.Size = new System.Drawing.Size(272, 457);
            this.ResultsTextBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BricksDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 457);
            this.panel2.TabIndex = 9;
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
            this.BricksDataGridView.Size = new System.Drawing.Size(697, 457);
            this.BricksDataGridView.TabIndex = 0;
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
            // ItemRMenuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 548);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.RPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemRMenuFrm";
            this.Text = "vWeb";
            this.Load += new System.EventHandler(this.ItemRMenuFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.RPanel.ResumeLayout(false);
            this.RPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BricksDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel RPanel;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView BricksDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCCONNECTIONBRICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
    }
}