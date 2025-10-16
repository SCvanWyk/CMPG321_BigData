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
            this.txtFinDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numLastCostPrice = new System.Windows.Forms.NumericUpDown();
            this.numTransType = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepId = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLastCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransType)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxSales
            // 
            this.listBoxSales.FormattingEnabled = true;
            this.listBoxSales.ItemHeight = 16;
            this.listBoxSales.Location = new System.Drawing.Point(85, 459);
            this.listBoxSales.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSales.Name = "listBoxSales";
            this.listBoxSales.Size = new System.Drawing.Size(781, 84);
            this.listBoxSales.TabIndex = 0;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(163, 18);
            this.txtCustomerId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(200, 22);
            this.txtCustomerId.TabIndex = 1;
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.Location = new System.Drawing.Point(163, 68);
            this.txtInventoryCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.Size = new System.Drawing.Size(200, 22);
            this.txtInventoryCode.TabIndex = 2;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Location = new System.Drawing.Point(564, 20);
            this.numericQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(200, 22);
            this.numericQuantity.TabIndex = 3;
            // 
            // numericPrice
            // 
            this.numericPrice.Location = new System.Drawing.Point(564, 62);
            this.numericPrice.Margin = new System.Windows.Forms.Padding(4);
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(200, 22);
            this.numericPrice.TabIndex = 4;
            // 
            // btnAddSale
            // 
            this.btnAddSale.Location = new System.Drawing.Point(85, 405);
            this.btnAddSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.Size = new System.Drawing.Size(200, 28);
            this.btnAddSale.TabIndex = 5;
            this.btnAddSale.Text = "Add";
            this.btnAddSale.UseVisualStyleBackColor = true;
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click);
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(35, 22);
            this.lblCustomerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(83, 16);
            this.lblCustomerId.TabIndex = 6;
            this.lblCustomerId.Text = "Customer ID:";
            this.lblCustomerId.Click += new System.EventHandler(this.lblCustomerId_Click);
            // 
            // lblInventoryCode
            // 
            this.lblInventoryCode.AutoSize = true;
            this.lblInventoryCode.Location = new System.Drawing.Point(35, 68);
            this.lblInventoryCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInventoryCode.Name = "lblInventoryCode";
            this.lblInventoryCode.Size = new System.Drawing.Size(100, 16);
            this.lblInventoryCode.TabIndex = 7;
            this.lblInventoryCode.Text = "Inventory Code:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(476, 22);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(58, 16);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(450, 62);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(85, 16);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Selling Price:";
            // 
            // btnUpdateSale
            // 
            this.btnUpdateSale.Location = new System.Drawing.Point(371, 405);
            this.btnUpdateSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSale.Name = "btnUpdateSale";
            this.btnUpdateSale.Size = new System.Drawing.Size(200, 28);
            this.btnUpdateSale.TabIndex = 10;
            this.btnUpdateSale.Text = "Update";
            this.btnUpdateSale.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSale
            // 
            this.btnDeleteSale.Location = new System.Drawing.Point(649, 405);
            this.btnDeleteSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSale.Name = "btnDeleteSale";
            this.btnDeleteSale.Size = new System.Drawing.Size(200, 28);
            this.btnDeleteSale.TabIndex = 11;
            this.btnDeleteSale.Text = "Delete";
            this.btnDeleteSale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFinDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numLastCostPrice);
            this.groupBox1.Controls.Add(this.numTransType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRepId);
            this.groupBox1.Controls.Add(this.lblInventoryCode);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.txtInventoryCode);
            this.groupBox1.Controls.Add(this.lblCustomerId);
            this.groupBox1.Controls.Add(this.numericPrice);
            this.groupBox1.Controls.Add(this.numericQuantity);
            this.groupBox1.Controls.Add(this.txtCustomerId);
            this.groupBox1.Location = new System.Drawing.Point(85, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(781, 303);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Sale";
            // 
            // txtFinDate
            // 
            this.txtFinDate.Location = new System.Drawing.Point(564, 174);
            this.txtFinDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinDate.Name = "txtFinDate";
            this.txtFinDate.Size = new System.Drawing.Size(200, 22);
            this.txtFinDate.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Financial Period:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Last Cost Price:";
            // 
            // numLastCostPrice
            // 
            this.numLastCostPrice.Location = new System.Drawing.Point(564, 113);
            this.numLastCostPrice.Margin = new System.Windows.Forms.Padding(4);
            this.numLastCostPrice.Name = "numLastCostPrice";
            this.numLastCostPrice.Size = new System.Drawing.Size(200, 22);
            this.numLastCostPrice.TabIndex = 18;
            // 
            // numTransType
            // 
            this.numTransType.Location = new System.Drawing.Point(163, 189);
            this.numTransType.Margin = new System.Windows.Forms.Padding(4);
            this.numTransType.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTransType.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTransType.Name = "numTransType";
            this.numTransType.Size = new System.Drawing.Size(200, 22);
            this.numTransType.TabIndex = 17;
            this.numTransType.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Transtype ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rep ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRepId
            // 
            this.txtRepId.Location = new System.Drawing.Point(163, 133);
            this.txtRepId.Margin = new System.Windows.Forms.Padding(4);
            this.txtRepId.Name = "txtRepId";
            this.txtRepId.Size = new System.Drawing.Size(200, 22);
            this.txtRepId.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(885, 29);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 28);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 611);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteSale);
            this.Controls.Add(this.btnUpdateSale);
            this.Controls.Add(this.listBoxSales);
            this.Controls.Add(this.btnAddSale);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Sales";
            this.Text = "Sales Entry";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLastCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransType)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTransType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numLastCostPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinDate;
        private System.Windows.Forms.Button btnBack;
    }
}