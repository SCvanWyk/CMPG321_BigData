using System;
using System.ComponentModel;
using System.Windows.Forms;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CRUD_operations
{
    public partial class Sales : Form
    {
        private BindingList<Sale> sales = new BindingList<Sale>();

        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            listBoxSales.DataSource = sales;
            listBoxSales.DisplayMember = "";
        }

        private async Task SendToKafkaAsync(Sale sale)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                string json = JsonConvert.SerializeObject(sale);
                await producer.ProduceAsync("sales-topic", new Message<Null, string> { Value = json });
            }
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            try
            {
                var sale = new Sale
                {
                    customer_id = txtCustomerId.Text,
                    inventory_code = txtInventoryCode.Text,
                    quantity_sold = (int)numericQuantity.Value,
                    unit_selling_price = (int)numericPrice.Value
                };
                sales.Add(sale);
                _ = SendToKafkaAsync(sale);
                MessageBox.Show("Sale sent to Kafka", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Kafka Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSales.SelectedItem is Sale selectedSale)
            {
                txtCustomerId.Text = selectedSale.customer_id;
                txtInventoryCode.Text = selectedSale.inventory_code;
                numericQuantity.Value = selectedSale.quantity_sold;
                numericPrice.Value = selectedSale.unit_selling_price;
            }
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            if (listBoxSales.SelectedItem is Sale selectedSale)
            {
                try
                {
                    selectedSale.customer_id = txtCustomerId.Text;
                    selectedSale.inventory_code = txtInventoryCode.Text;
                    selectedSale.quantity_sold = (int)numericQuantity.Value;
                    selectedSale.unit_selling_price = (int)numericPrice.Value;

                    sales.ResetBindings(); 

                    _ = SendToKafkaAsync(selectedSale);
                    MessageBox.Show("Sale updated and sent to Kafka", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a sale from the list to update", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (listBoxSales.SelectedItem is Sale selectedSale)
            {
                sales.Remove(selectedSale);
                MessageBox.Show("Sale deleted from the list", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a sale from the list to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblCustomerId_Click(object sender, EventArgs e)
        {

        }
    }
}