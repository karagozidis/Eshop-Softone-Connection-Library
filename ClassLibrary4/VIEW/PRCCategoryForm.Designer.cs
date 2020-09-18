namespace S1Custom
{
    partial class PRCCategoryForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.ResultsTextBox = new System.Windows.Forms.RichTextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(95, 41);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(422, 23);
            this.LoginButton.TabIndex = 19;
            this.LoginButton.Text = "Web Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Enabled = false;
            this.ResultsTextBox.Location = new System.Drawing.Point(12, 84);
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.Size = new System.Drawing.Size(505, 282);
            this.ResultsTextBox.TabIndex = 18;
            this.ResultsTextBox.Text = "";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(13, 372);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(505, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "Διαγραφή Απο Web";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.Location = new System.Drawing.Point(95, 12);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(423, 23);
            this.SyncButton.TabIndex = 14;
            this.SyncButton.Text = "Συγχρονισμός με Web";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // PRCCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 531);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SyncButton);
            this.Name = "PRCCategoryForm";
            this.Text = "PRCCategoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.RichTextBox ResultsTextBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SyncButton;
    }
}