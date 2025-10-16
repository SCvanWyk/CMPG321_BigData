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
            listBoxSales.DisplayMember = "Sales for Today";
        }

        private async Task SendToKafkaAsync(Sale sale)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "pkc-q283m.af-south-1.aws.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "V2AFGAJLXBX443EI",
                SaslPassword = "cflt06SDf1XC+F6hi53WOlmue7Nv+6Isn0+LwLRnHonIovT1eyWaz/s3TyIJEpNA",
                Acks = Acks.All, // Ensure messages are fully committed
            };


            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                string json = JsonConvert.SerializeObject(sale);
                var result = await producer.ProduceAsync("sales-topic", new Message<Null, string> { Value = json });
                Console.WriteLine($"Sent to Kafka: {result.TopicPartitionOffset}");
            }
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            try
            {
                int finDateInt;
                if (!int.TryParse(txtFinDate.Text.Replace("-", ""), out finDateInt))
                {
                    MessageBox.Show("Invalid financial date. Use YYYYMM format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var sale = new Sale
                {
                    rep_id = txtRepId.Text,
                    transtype_id = (int)numTransType.Value,
                    customer_id = txtCustomerId.Text,
                    fin_date = finDateInt,
                    inventory_code = txtInventoryCode.Text,
                    quantity_sold = (int)numericQuantity.Value,
                    unit_selling_price = numericPrice.Value,
                    unit_last_cost = numLastCostPrice.Value,
                    total_line_price = numericQuantity.Value * numericPrice.Value
                };

                sales.Add(sale);
                _ = SendToKafkaAsync(sale);
                MessageBox.Show("Sale sent to Kafka", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs for next entry
                ClearInputs();
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
                txtRepId.Text = selectedSale.rep_id;
                numTransType.Value = selectedSale.transtype_id;
                txtCustomerId.Text = selectedSale.customer_id;
                txtFinDate.Text = selectedSale.fin_date.ToString();
                txtInventoryCode.Text = selectedSale.inventory_code;
                numericQuantity.Value = selectedSale.quantity_sold;
                numericPrice.Value = selectedSale.unit_selling_price;
                numLastCostPrice.Value = selectedSale.unit_last_cost;
            }
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            if (listBoxSales.SelectedItem is Sale selectedSale)
            {
                try
                {
                    selectedSale.rep_id = txtRepId.Text;
                    selectedSale.transtype_id = (int)numTransType.Value;
                    selectedSale.customer_id = txtCustomerId.Text;
                    selectedSale.fin_date = int.Parse(txtFinDate.Text.Replace("-", ""));
                    selectedSale.inventory_code = txtInventoryCode.Text;
                    selectedSale.quantity_sold = (int)numericQuantity.Value;
                    selectedSale.unit_selling_price = numericPrice.Value;
                    selectedSale.unit_last_cost = numLastCostPrice.Value;
                    selectedSale.total_line_price = numericQuantity.Value * numericPrice.Value;

                    sales.ResetBindings(); // refresh listbox
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

        private void ClearInputs()
        {
            txtRepId.Clear();
            numTransType.Value = 1;
            txtCustomerId.Clear();
            txtFinDate.Clear();
            txtInventoryCode.Clear();
            numericQuantity.Value = 0;
            numericPrice.Value = 0;
            numLastCostPrice.Value = 0;
        }

        private void lblCustomerId_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}