using System;
using System.ComponentModel;
using System.Windows.Forms;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CRUD_operations
{
    public partial class Purchases : Form
    {
        private BindingList<Purchase> purchases = new BindingList<Purchase>();

        public Purchases()
        {
            InitializeComponent();
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = purchases;
            listBox1.DisplayMember = nameof(Purchase.purchase_id);
        }

        private async Task SendToKafkaAsync(Purchase purchase)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "pkc-q283m.af-south-1.aws.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "V2AFGAJLXBX443EI",
                SaslPassword = "cflt06SDf1XC+F6hi53WOlmue7Nv+6Isn0+LwLRnHonIovT1eyWaz/s3TyIJEpNA",
                Acks = Acks.All
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                string json = JsonConvert.SerializeObject(purchase);
                var result = await producer.ProduceAsync("purchases-topic", new Message<Null, string> { Value = json });
                Console.WriteLine($" Sent to Kafka: {result.TopicPartitionOffset}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var purchase = new Purchase
                {
                    purchase_id = purchase_id.Text,
                    inventory_id = inventory_id.Text,
                    supplier_id = supplier_id.Text,
                    date_id = (int)date_id.Value,
                    fin_date = fin_date.Value.ToString("yyyyMMDD"),
                    unit_cost_price = unit_cost_price.Value,
                    quantity_purchased = (int)quantity_purchased.Value,
                    total_cost = unit_cost_price.Value * quantity_purchased.Value
                };

                purchases.Add(purchase);
                _ = SendToKafkaAsync(purchase);

                MessageBox.Show(" Purchase sent to Kafka!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Error: {ex.Message}", "Kafka Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Purchase selected)
            {
                try
                {
                    selected.inventory_id = inventory_id.Text;
                    selected.supplier_id = supplier_id.Text;
                    selected.date_id = (int)date_id.Value;
                    selected.fin_date = fin_date.Value.ToString("yyyyMMDD");
                    selected.unit_cost_price = unit_cost_price.Value;
                    selected.quantity_purchased = (int)quantity_purchased.Value;
                    selected.total_cost = unit_cost_price.Value * quantity_purchased.Value;

                    purchases.ResetBindings(); // Refresh UI
                    _ = SendToKafkaAsync(selected);

                    MessageBox.Show("Purchase updated and sent to Kafka!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a purchase to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Purchase selected)
            {
                purchases.Remove(selected);
                MessageBox.Show("Purchase deleted from the list.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a purchase to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Purchase selected)
            {
                purchase_id.Text = selected.purchase_id;
                inventory_id.Text = selected.inventory_id;
                supplier_id.Text = selected.supplier_id;
                date_id.Value = selected.date_id;
                fin_date.Value = DateTime.ParseExact(selected.fin_date + "01", "yyyyMMdd", null);
                unit_cost_price.Value = selected.unit_cost_price;
                quantity_purchased.Value = selected.quantity_purchased;
            }
        }

        private void ClearInputs()
        {
            purchase_id.Clear();
            inventory_id.Clear();
            supplier_id.Clear();
            date_id.Value = 0;
            fin_date.Value = DateTime.Today;
            unit_cost_price.Value = 0;
            quantity_purchased.Value = 0;
        }

        public class Purchase
        {
            public string purchase_id { get; set; }
            public string inventory_id { get; set; }
            public string supplier_id { get; set; }
            public int date_id { get; set; }
            public string fin_date { get; set; } // stored as yyyyMM
            public decimal unit_cost_price { get; set; }
            public int quantity_purchased { get; set; }
            public decimal total_cost { get; set; }

            public override string ToString()
            {
                return $"{purchase_id} - {inventory_id} ({quantity_purchased})";
            }
        }

        private void purchase_id_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void fin_date_ValueChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
