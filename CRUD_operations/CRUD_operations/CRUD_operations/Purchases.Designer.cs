
namespace CRUD_operations
{
    partial class Purchases
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date_id = new System.Windows.Forms.NumericUpDown();
            this.unit_cost_price = new System.Windows.Forms.NumericUpDown();
            this.quantity_purchased = new System.Windows.Forms.NumericUpDown();
            this.fin_date = new System.Windows.Forms.DateTimePicker();
            this.inventory_id = new System.Windows.Forms.TextBox();
            this.supplier_id = new System.Windows.Forms.TextBox();
            this.purchase_id = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_cost_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_purchased)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(537, 203);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 22);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(703, 203);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(161, 22);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(52, 238);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(826, 260);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.date_id);
            this.groupBox1.Controls.Add(this.unit_cost_price);
            this.groupBox1.Controls.Add(this.quantity_purchased);
            this.groupBox1.Controls.Add(this.fin_date);
            this.groupBox1.Controls.Add(this.inventory_id);
            this.groupBox1.Controls.Add(this.supplier_id);
            this.groupBox1.Controls.Add(this.purchase_id);
            this.groupBox1.Location = new System.Drawing.Point(52, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(826, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Purchase";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Quantity Purchased:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Unit Cost Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Financial Period:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Date ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Supplier ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Iventory ID:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Purchase ID:";
            // 
            // date_id
            // 
            this.date_id.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.date_id.Location = new System.Drawing.Point(136, 127);
            this.date_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_id.Name = "date_id";
            this.date_id.Size = new System.Drawing.Size(107, 22);
            this.date_id.TabIndex = 15;
            // 
            // unit_cost_price
            // 
            this.unit_cost_price.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.unit_cost_price.Location = new System.Drawing.Point(507, 62);
            this.unit_cost_price.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.unit_cost_price.Name = "unit_cost_price";
            this.unit_cost_price.Size = new System.Drawing.Size(107, 22);
            this.unit_cost_price.TabIndex = 14;
            // 
            // quantity_purchased
            // 
            this.quantity_purchased.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.quantity_purchased.Location = new System.Drawing.Point(507, 93);
            this.quantity_purchased.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantity_purchased.Name = "quantity_purchased";
            this.quantity_purchased.Size = new System.Drawing.Size(107, 22);
            this.quantity_purchased.TabIndex = 13;
            // 
            // fin_date
            // 
            this.fin_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin_date.Location = new System.Drawing.Point(507, 26);
            this.fin_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fin_date.Name = "fin_date";
            this.fin_date.Size = new System.Drawing.Size(178, 22);
            this.fin_date.TabIndex = 10;
            this.fin_date.ValueChanged += new System.EventHandler(this.fin_date_ValueChanged);
            // 
            // inventory_id
            // 
            this.inventory_id.Location = new System.Drawing.Point(136, 62);
            this.inventory_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventory_id.Name = "inventory_id";
            this.inventory_id.Size = new System.Drawing.Size(89, 22);
            this.inventory_id.TabIndex = 8;
            // 
            // supplier_id
            // 
            this.supplier_id.Location = new System.Drawing.Point(136, 94);
            this.supplier_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.supplier_id.Name = "supplier_id";
            this.supplier_id.Size = new System.Drawing.Size(89, 22);
            this.supplier_id.TabIndex = 7;
            // 
            // purchase_id
            // 
            this.purchase_id.Location = new System.Drawing.Point(136, 28);
            this.purchase_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.purchase_id.Name = "purchase_id";
            this.purchase_id.Size = new System.Drawing.Size(89, 22);
            this.purchase_id.TabIndex = 6;
            this.purchase_id.TextChanged += new System.EventHandler(this.purchase_id_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(370, 203);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 22);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(903, 13);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 28);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 522);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Purchases";
            this.Text = "Purchases";
            this.Load += new System.EventHandler(this.Purchases_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_cost_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_purchased)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown date_id;
        private System.Windows.Forms.NumericUpDown unit_cost_price;
        private System.Windows.Forms.NumericUpDown quantity_purchased;
        private System.Windows.Forms.DateTimePicker fin_date;
        private System.Windows.Forms.TextBox inventory_id;
        private System.Windows.Forms.TextBox supplier_id;
        private System.Windows.Forms.TextBox purchase_id;
        private System.Windows.Forms.Button btnBack;
    }
}