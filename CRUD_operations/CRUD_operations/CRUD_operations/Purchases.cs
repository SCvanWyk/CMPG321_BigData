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
        private BindingList<Purchase> purchasesList = new BindingList<Purchase>();
        public Purchases()
        {
            InitializeComponent();
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            listBoxPurchases.DataSource = purchasesList;
            listBoxPurchases.DisplayMember = "ToString"; // Calls Purchase.ToString()
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fin_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private BindingList<Purchase> purchases = new BindingList<Purchase>();


        private void LoadPurchases()
        {
                // Keep the same BindingList so that UI updates automatically
                purchases.Clear();

                purchases.Add(new Purchase
                {
                    purchase_id = "P001",
                    inventory_id = "INV001",
                    supplier_id = "SUP001",
                    date_id = 1,
                    fin_date = "2025-09-25",
                    unit_cost_price = 10,
                    quantity_purchased = 5,
                    total_cost = 50
                });

                purchases.Add(new Purchase
                {
                    purchase_id = "P002",
                    inventory_id = "INV002",
                    supplier_id = "SUP002",
                    date_id = 2,
                    fin_date = "2025-09-26",
                    unit_cost_price = 20,
                    quantity_purchased = 3,
                    total_cost = 60
                });

                // ✅ Bind the list once inside this method
                listBoxPurchases.DataSource = purchases;
                listBoxPurchases.DisplayMember = ""; // Uses Purchase.ToString()
            }
       





        public class Purchase
        {
            public string purchase_id { get; set; }
            public string inventory_id { get; set; }
            public string supplier_id { get; set; }
            public int date_id { get; set; }
            public string fin_date { get; set; }  // yyyy-MM-dd
            public decimal unit_cost_price { get; set; }
            public int quantity_purchased { get; set; }
            public decimal total_cost { get; set; }


            public override string ToString()
            {
                return $"{purchase_id} - {inventory_id} ({quantity_purchased})";
            }
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
                Console.WriteLine($"Sent to Kafka: {result.TopicPartitionOffset}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Build purchase object from controls
                var purchase = new Purchase
                {
                    purchase_id = purchase_id.Text,
                    inventory_id = inventory_id.Text,
                    supplier_id = supplier_id.Text,
                    date_id = (int)date_id.Value,
                    fin_date = fin_date.Value.ToString("yyyy-MM-dd"),
                    unit_cost_price = unit_cost_price.Value,
                    quantity_purchased = (int)quantity_purchased.Value,
                    total_cost = total_cost.Value
                };

                purchases.Add(purchase);

                await SendToKafkaAsync(purchase);
                MessageBox.Show("✅ Purchase sent to Kafka!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Kafka Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPurchases.SelectedItem is Purchase selected)
            {
                purchase_id.Text = selected.purchase_id;
                inventory_id.Text = selected.inventory_id;
                supplier_id.Text = selected.supplier_id;
                date_id.Value = selected.date_id;
                fin_date.Value = DateTime.Parse(selected.fin_date);
                unit_cost_price.Value = selected.unit_cost_price;
                quantity_purchased.Value = selected.quantity_purchased;
                total_cost.Value = selected.total_cost;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (listBoxPurchases.SelectedItem is Purchase selected)
            {
                // Update fields from controls
                selected.inventory_id = inventory_id.Text;
                selected.supplier_id = supplier_id.Text;
                selected.date_id = (int)date_id.Value;
                selected.fin_date = fin_date.Value.ToString("yyyy-MM-dd");
                selected.unit_cost_price = unit_cost_price.Value;
                selected.quantity_purchased = (int)quantity_purchased.Value;
                selected.total_cost = total_cost.Value;

                await SendToKafkaAsync(selected);  // ✅ Send update
                MessageBox.Show("✅ Purchase updated and sent to Kafka!", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Please select a purchase to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (listBoxPurchases.SelectedItem is Purchase selected)
            {
                var deleteMessage = new { action = "delete", purchase_id = selected.purchase_id };
                await SendDeleteToKafkaAsync(deleteMessage);

                purchases.Remove(selected);

                MessageBox.Show("✅ Purchase deleted!", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task SendDeleteToKafkaAsync(object message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                string json = JsonConvert.SerializeObject(message);
                await producer.ProduceAsync(
                    "purchases-topic",
                    new Message<Null, string> { Value = json }
                );
            }
        }

    }
}
