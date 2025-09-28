
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFinDate = new System.Windows.Forms.DateTimePicker();
            this.numTotalCost = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numUnitCost = new System.Windows.Forms.NumericUpDown();
            this.numDate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtInventoryId = new System.Windows.Forms.TextBox();
            this.txtPurchaseId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(855, 219);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(220, 41);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(855, 137);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(220, 41);
            this.btnCreate.TabIndex = 41;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(855, 263);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(220, 41);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 327);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1087, 326);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFinDate);
            this.groupBox1.Controls.Add(this.numTotalCost);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.numUnitCost);
            this.groupBox1.Controls.Add(this.numDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSupplierId);
            this.groupBox1.Controls.Add(this.txtInventoryId);
            this.groupBox1.Controls.Add(this.txtPurchaseId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 292);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Details";
            // 
            // dtpFinDate
            // 
            this.dtpFinDate.Location = new System.Drawing.Point(585, 34);
            this.dtpFinDate.Name = "dtpFinDate";
            this.dtpFinDate.Size = new System.Drawing.Size(169, 26);
            this.dtpFinDate.TabIndex = 60;
            // 
            // numTotalCost
            // 
            this.numTotalCost.DecimalPlaces = 2;
            this.numTotalCost.Location = new System.Drawing.Point(585, 226);
            this.numTotalCost.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numTotalCost.Name = "numTotalCost";
            this.numTotalCost.Size = new System.Drawing.Size(169, 26);
            this.numTotalCost.TabIndex = 59;
            // 
            // numQuantity
            // 
            this.numQuantity.DecimalPlaces = 2;
            this.numQuantity.Location = new System.Drawing.Point(585, 162);
            this.numQuantity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(169, 26);
            this.numQuantity.TabIndex = 58;
            // 
            // numUnitCost
            // 
            this.numUnitCost.DecimalPlaces = 2;
            this.numUnitCost.Location = new System.Drawing.Point(585, 103);
            this.numUnitCost.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numUnitCost.Name = "numUnitCost";
            this.numUnitCost.Size = new System.Drawing.Size(169, 26);
            this.numUnitCost.TabIndex = 57;
            // 
            // numDate
            // 
            this.numDate.DecimalPlaces = 2;
            this.numDate.Location = new System.Drawing.Point(199, 222);
            this.numDate.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numDate.Name = "numDate";
            this.numDate.Size = new System.Drawing.Size(169, 26);
            this.numDate.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 55;
            this.label5.Text = "total_cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "quantity_purchased";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "unit_cost_price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "fin_date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "date_id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "supplier_id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "inventory_id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "purchase_id";
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.Location = new System.Drawing.Point(199, 161);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(169, 26);
            this.txtSupplierId.TabIndex = 42;
            // 
            // txtInventoryId
            // 
            this.txtInventoryId.Location = new System.Drawing.Point(199, 103);
            this.txtInventoryId.Name = "txtInventoryId";
            this.txtInventoryId.Size = new System.Drawing.Size(169, 26);
            this.txtInventoryId.TabIndex = 41;
            // 
            // txtPurchaseId
            // 
            this.txtPurchaseId.Location = new System.Drawing.Point(199, 34);
            this.txtPurchaseId.Name = "txtPurchaseId";
            this.txtPurchaseId.Size = new System.Drawing.Size(169, 26);
            this.txtPurchaseId.TabIndex = 40;
            // 
            // Purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Name = "Purchases";
            this.Text = "Purchases";
            this.Load += new System.EventHandler(this.Purchases_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierId;
        private System.Windows.Forms.TextBox txtInventoryId;
        private System.Windows.Forms.TextBox txtPurchaseId;
        private System.Windows.Forms.NumericUpDown numTotalCost;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numUnitCost;
        private System.Windows.Forms.NumericUpDown numDate;
        private System.Windows.Forms.DateTimePicker dtpFinDate;
    }
}