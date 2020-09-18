namespace S1Custom
{
    partial class S1CustomOrderForm
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
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewOnWeb = new System.Windows.Forms.DataGridViewButtonColumn();
            this.add_product = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.s1_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.WebLoginButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderDataGridView
            // 
            this.OrderDataGridView.AllowUserToAddRows = false;
            this.OrderDataGridView.AllowUserToDeleteRows = false;
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_date,
            this.OrderNo,
            this.customer_id,
            this.Customer,
            this.shipping,
            this.total,
            this.ViewOnWeb,
            this.add_product});
            this.OrderDataGridView.Location = new System.Drawing.Point(12, 35);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.ReadOnly = true;
            this.OrderDataGridView.Size = new System.Drawing.Size(717, 174);
            this.OrderDataGridView.TabIndex = 0;
            this.OrderDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderDataGridView_CellClick);
            // 
            // order_date
            // 
            this.order_date.HeaderText = "Ημερομηνία";
            this.order_date.Name = "order_date";
            this.order_date.ReadOnly = true;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Αριθμός Παραγγελίας";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            // 
            // customer_id
            // 
            this.customer_id.HeaderText = "Κωδικός Πελάτη";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Πελάτης";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // shipping
            // 
            this.shipping.HeaderText = "Έξοδα Αποστολής";
            this.shipping.Name = "shipping";
            this.shipping.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Σύνολο";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // ViewOnWeb
            // 
            this.ViewOnWeb.HeaderText = "Web Login";
            this.ViewOnWeb.Name = "ViewOnWeb";
            this.ViewOnWeb.ReadOnly = true;
            // 
            // add_product
            // 
            this.add_product.HeaderText = "Εισαγωγή";
            this.add_product.Name = "add_product";
            this.add_product.ReadOnly = true;
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Location = new System.Drawing.Point(52, 9);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FromDateTimePicker.TabIndex = 1;
            this.FromDateTimePicker.ValueChanged += new System.EventHandler(this.FromDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aπο:";
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Location = new System.Drawing.Point(296, 9);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.ToDateTimePicker.TabIndex = 3;
            this.ToDateTimePicker.ValueChanged += new System.EventHandler(this.ToDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Έως:";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s1_id,
            this.description,
            this.quantity,
            this.price,
            this.total_price});
            this.ProductDataGridView.Location = new System.Drawing.Point(12, 250);
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            this.ProductDataGridView.Size = new System.Drawing.Size(717, 150);
            this.ProductDataGridView.TabIndex = 5;
            // 
            // s1_id
            // 
            this.s1_id.HeaderText = "Κωδικός Προιόντος";
            this.s1_id.Name = "s1_id";
            this.s1_id.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Περιγραφή";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Ποσότητα";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Τιμή μονάδας";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // total_price
            // 
            this.total_price.HeaderText = "Συνολική Τιμή";
            this.total_price.Name = "total_price";
            this.total_price.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Προϊόντα Παραγγελίας";
            // 
            // WebLoginButton
            // 
            this.WebLoginButton.Location = new System.Drawing.Point(676, 9);
            this.WebLoginButton.Name = "WebLoginButton";
            this.WebLoginButton.Size = new System.Drawing.Size(53, 23);
            this.WebLoginButton.TabIndex = 7;
            this.WebLoginButton.Text = "Login";
            this.WebLoginButton.UseVisualStyleBackColor = true;
            this.WebLoginButton.Click += new System.EventHandler(this.WebLoginButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(544, 9);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(126, 23);
            this.InsertButton.TabIndex = 8;
            this.InsertButton.Text = "Εισαγωγή Όλων";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // S1CustomOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 488);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.WebLoginButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromDateTimePicker);
            this.Controls.Add(this.OrderDataGridView);
            this.Name = "S1CustomOrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn s1_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewButtonColumn ViewOnWeb;
        private System.Windows.Forms.DataGridViewButtonColumn add_product;
        private System.Windows.Forms.Button WebLoginButton;
        private System.Windows.Forms.Button InsertButton;


    }
}