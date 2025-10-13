
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.purchase_id = new System.Windows.Forms.TextBox();
            this.supplier_id = new System.Windows.Forms.TextBox();
            this.inventory_id = new System.Windows.Forms.TextBox();
            this.fin_date = new System.Windows.Forms.DateTimePicker();
            this.quantity_purchased = new System.Windows.Forms.NumericUpDown();
            this.unit_cost_price = new System.Windows.Forms.NumericUpDown();
            this.date_id = new System.Windows.Forms.NumericUpDown();
            this.total_cost = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_purchased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_cost_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_cost)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(604, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(791, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(58, 298);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(929, 324);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.total_cost);
            this.groupBox1.Controls.Add(this.date_id);
            this.groupBox1.Controls.Add(this.unit_cost_price);
            this.groupBox1.Controls.Add(this.quantity_purchased);
            this.groupBox1.Controls.Add(this.fin_date);
            this.groupBox1.Controls.Add(this.inventory_id);
            this.groupBox1.Controls.Add(this.supplier_id);
            this.groupBox1.Controls.Add(this.purchase_id);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(58, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 223);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Purchase";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(733, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // purchase_id
            // 
            this.purchase_id.Location = new System.Drawing.Point(153, 35);
            this.purchase_id.Name = "purchase_id";
            this.purchase_id.Size = new System.Drawing.Size(100, 26);
            this.purchase_id.TabIndex = 6;
            // 
            // supplier_id
            // 
            this.supplier_id.Location = new System.Drawing.Point(153, 118);
            this.supplier_id.Name = "supplier_id";
            this.supplier_id.Size = new System.Drawing.Size(100, 26);
            this.supplier_id.TabIndex = 7;
            // 
            // inventory_id
            // 
            this.inventory_id.Location = new System.Drawing.Point(153, 77);
            this.inventory_id.Name = "inventory_id";
            this.inventory_id.Size = new System.Drawing.Size(100, 26);
            this.inventory_id.TabIndex = 8;
            // 
            // fin_date
            // 
            this.fin_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin_date.Location = new System.Drawing.Point(570, 33);
            this.fin_date.Name = "fin_date";
            this.fin_date.Size = new System.Drawing.Size(200, 26);
            this.fin_date.TabIndex = 10;
            this.fin_date.ValueChanged += new System.EventHandler(this.fin_date_ValueChanged);
            // 
            // quantity_purchased
            // 
            this.quantity_purchased.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.quantity_purchased.Location = new System.Drawing.Point(570, 116);
            this.quantity_purchased.Name = "quantity_purchased";
            this.quantity_purchased.Size = new System.Drawing.Size(120, 26);
            this.quantity_purchased.TabIndex = 13;
            // 
            // unit_cost_price
            // 
            this.unit_cost_price.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.unit_cost_price.Location = new System.Drawing.Point(570, 77);
            this.unit_cost_price.Name = "unit_cost_price";
            this.unit_cost_price.Size = new System.Drawing.Size(120, 26);
            this.unit_cost_price.TabIndex = 14;
            // 
            // date_id
            // 
            this.date_id.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.date_id.Location = new System.Drawing.Point(153, 159);
            this.date_id.Name = "date_id";
            this.date_id.Size = new System.Drawing.Size(120, 26);
            this.date_id.TabIndex = 15;
            // 
            // total_cost
            // 
            this.total_cost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.total_cost.Location = new System.Drawing.Point(570, 157);
            this.total_cost.Name = "total_cost";
            this.total_cost.Size = new System.Drawing.Size(120, 26);
            this.total_cost.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "label8";
            // 
            // Purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Purchases";
            this.Text = "Purchases";
            this.Load += new System.EventHandler(this.Purchases_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_purchased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_cost_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_cost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown total_cost;
        private System.Windows.Forms.NumericUpDown date_id;
        private System.Windows.Forms.NumericUpDown unit_cost_price;
        private System.Windows.Forms.NumericUpDown quantity_purchased;
        private System.Windows.Forms.DateTimePicker fin_date;
        private System.Windows.Forms.TextBox inventory_id;
        private System.Windows.Forms.TextBox supplier_id;
        private System.Windows.Forms.TextBox purchase_id;
    }
}