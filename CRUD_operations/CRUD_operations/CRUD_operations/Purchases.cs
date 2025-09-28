using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CRUD_operations
{
    public partial class Purchases : Form
    {
        // === Kafka Settings ===
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "purchases";

        // === MongoDB Settings ===
        private const string MongoConnection = "mongodb://localhost:27017";
        private const string MongoDatabase = "storedb";
        private const string MongoCollection = "purchases";

        private IMongoCollection<BsonDocument> _mongoCollection;
        private CancellationTokenSource _cts;

        public Purchases()
        {
            InitializeComponent();
        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            var client = new MongoClient(MongoConnection);
            var db = client.GetDatabase(MongoDatabase);
            _mongoCollection = db.GetCollection<BsonDocument>(MongoCollection);

            LoadPurchases();
            StartConsumer();
        }

        private void Purchases_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopConsumer();
        }

        // === Load MongoDB Data into DataGridView ===
        private void LoadPurchases()
        {
            var docs = _mongoCollection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
            var list = new List<dynamic>();

            foreach (var d in docs)
            {
                list.Add(new
                {
                    purchase_id = d.GetValue("purchase_id", "").ToString(),
                    inventory_id = d.GetValue("inventory_id", "").ToString(),
                    supplier_id = d.GetValue("supplier_id", "").ToString(),
                    date_id = d.GetValue("date_id", 0).ToInt32(),
                    fin_date = d.GetValue("fin_date", "").ToString(),
                    unit_cost_price = d.GetValue("unit_cost_price", 0m).ToDecimal(),
                    quantity_purchased = d.GetValue("quantity_purchased", 0).ToInt32(),
                    total_cost = d.GetValue("total_cost", 0m).ToDecimal()
                });
            }

            dataGridView1.DataSource = list;
        }

        // === Populate Inputs on Row Click ===
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtPurchaseId.Text = row.Cells["purchase_id"].Value?.ToString();
                txtInventoryId.Text = row.Cells["inventory_id"].Value?.ToString();
                txtSupplierId.Text = row.Cells["supplier_id"].Value?.ToString();

                // NumericUpDown + DateTimePicker
                numDate.Value = Convert.ToDecimal(row.Cells["date_id"].Value ?? 0);
                dtpFinDate.Value = DateTime.TryParse(row.Cells["fin_date"].Value?.ToString(), out var fDate)
                                    ? fDate : DateTime.Now;
                numUnitCost.Value = Convert.ToDecimal(row.Cells["unit_cost_price"].Value ?? 0);
                numQuantity.Value = Convert.ToDecimal(row.Cells["quantity_purchased"].Value ?? 0);
                numTotalCost.Value = Convert.ToDecimal(row.Cells["total_cost"].Value ?? 0);
            }
        }

        // === Kafka Producer ===
        private async Task SendKafkaMessage(string key, string value)
        {
            var config = new ProducerConfig { BootstrapServers = BootstrapServers };

            using var producer = new ProducerBuilder<string, string>(config).Build();
            try
            {
                var result = await producer.ProduceAsync(
                    TopicName,
                    new Message<string, string> { Key = key, Value = value });

                MessageBox.Show($"Delivered to: {result.TopicPartitionOffset}");
            }
            catch (ProduceException<string, string> ex)
            {
                MessageBox.Show($"Delivery failed: {ex.Error.Reason}");
            }
        }

        // === Build JSON + Send Kafka Event ===
        private async Task SendCrudMessage(string action)
        {
            if (string.IsNullOrWhiteSpace(txtPurchaseId.Text))
            {
                MessageBox.Show("Purchase ID is required.");
                return;
            }

            var purchase = new
            {
                action,
                purchase_id = txtPurchaseId.Text,
                inventory_id = txtInventoryId.Text,
                supplier_id = txtSupplierId.Text,
                date_id = (int)numDate.Value,
                fin_date = dtpFinDate.Value.ToString("yyyy-MM-dd"),
                unit_cost_price = numUnitCost.Value,
                quantity_purchased = (int)numQuantity.Value,
                total_cost = numTotalCost.Value
            };

            string json = JsonConvert.SerializeObject(purchase);
            await SendKafkaMessage(purchase.purchase_id, json);
        }

        // === Kafka Consumer to Auto-Refresh Grid ===
        private void StartConsumer()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = BootstrapServers,
                    GroupId = "winforms-consumer-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
                consumer.Subscribe(TopicName);

                try
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        var cr = consumer.Consume(_cts.Token);
                        this.Invoke((MethodInvoker)(() => LoadPurchases()));
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            });
        }

        private void StopConsumer()
        {
            _cts?.Cancel();
        }

        // === Buttons ===
        private async void btnCreate_Click(object sender, EventArgs e) => await SendCrudMessage("create");
        private async void btnUpdate_Click(object sender, EventArgs e) => await SendCrudMessage("update");
        private async void btnDelete_Click(object sender, EventArgs e) => await SendCrudMessage("delete");
        private void btnRefresh_Click(object sender, EventArgs e) => LoadPurchases();
    }
}
