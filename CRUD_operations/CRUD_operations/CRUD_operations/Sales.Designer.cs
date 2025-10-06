namespace CRUD_operations
{
    partial class Sales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxSales = new System.Windows.Forms.ListBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtInventoryCode = new System.Windows.Forms.TextBox();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.btnAddSale = new System.Windows.Forms.Button();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblInventoryCode = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnUpdateSale = new System.Windows.Forms.Button();
            this.btnDeleteSale = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSales
            // 
            this.listBoxSales.FormattingEnabled = true;
            this.listBoxSales.Location = new System.Drawing.Point(64, 198);
            this.listBoxSales.Name = "listBoxSales";
            this.listBoxSales.Size = new System.Drawing.Size(587, 199);
            this.listBoxSales.TabIndex = 0;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(122, 15);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(151, 20);
            this.txtCustomerId.TabIndex = 1;
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.Location = new System.Drawing.Point(122, 49);
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.Size = new System.Drawing.Size(151, 20);
            this.txtInventoryCode.TabIndex = 2;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Location = new System.Drawing.Point(423, 16);
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(150, 20);
            this.numericQuantity.TabIndex = 3;
            // 
            // numericPrice
            // 
            this.numericPrice.Location = new System.Drawing.Point(423, 50);
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(150, 20);
            this.numericPrice.TabIndex = 4;
            // 
            // btnAddSale
            // 
            this.btnAddSale.Location = new System.Drawing.Point(423, 102);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.Size = new System.Drawing.Size(150, 23);
            this.btnAddSale.TabIndex = 5;
            this.btnAddSale.Text = "Add";
            this.btnAddSale.UseVisualStyleBackColor = true;
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click);
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(26, 18);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(68, 13);
            this.lblCustomerId.TabIndex = 6;
            this.lblCustomerId.Text = "Customer ID:";
            this.lblCustomerId.Click += new System.EventHandler(this.lblCustomerId_Click);
            // 
            // lblInventoryCode
            // 
            this.lblInventoryCode.AutoSize = true;
            this.lblInventoryCode.Location = new System.Drawing.Point(26, 52);
            this.lblInventoryCode.Name = "lblInventoryCode";
            this.lblInventoryCode.Size = new System.Drawing.Size(82, 13);
            this.lblInventoryCode.TabIndex = 7;
            this.lblInventoryCode.Text = "Inventory Code:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(357, 18);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(357, 53);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Price:";
            // 
            // btnUpdateSale
            // 
            this.btnUpdateSale.Location = new System.Drawing.Point(305, 156);
            this.btnUpdateSale.Name = "btnUpdateSale";
            this.btnUpdateSale.Size = new System.Drawing.Size(150, 23);
            this.btnUpdateSale.TabIndex = 10;
            this.btnUpdateSale.Text = "Update";
            this.btnUpdateSale.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSale
            // 
            this.btnDeleteSale.Location = new System.Drawing.Point(487, 156);
            this.btnDeleteSale.Name = "btnDeleteSale";
            this.btnDeleteSale.Size = new System.Drawing.Size(150, 23);
            this.btnDeleteSale.TabIndex = 11;
            this.btnDeleteSale.Text = "Delete";
            this.btnDeleteSale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.lblInventoryCode);
            this.groupBox1.Controls.Add(this.lblCustomerId);
            this.groupBox1.Controls.Add(this.btnAddSale);
            this.groupBox1.Controls.Add(this.numericPrice);
            this.groupBox1.Controls.Add(this.numericQuantity);
            this.groupBox1.Controls.Add(this.txtInventoryCode);
            this.groupBox1.Controls.Add(this.txtCustomerId);
            this.groupBox1.Location = new System.Drawing.Point(64, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 136);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Sale";
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteSale);
            this.Controls.Add(this.btnUpdateSale);
            this.Controls.Add(this.listBoxSales);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Sales";
            this.Text = "Sales Entry";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSales;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtInventoryCode;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.Button btnAddSale;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblInventoryCode;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnUpdateSale;
        private System.Windows.Forms.Button btnDeleteSale;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}