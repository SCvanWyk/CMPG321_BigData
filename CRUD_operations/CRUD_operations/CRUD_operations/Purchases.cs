using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace CRUD_operations
{
    public partial class Purchases : Form
    {
        private const string BootstrapServers = "localhost:9092"; // Kafka broker
        private const string TopicName = "purchases";              // Your topic name

        private CancellationTokenSource _cts;

        public Purchases()
        {
            InitializeComponent();
        }

        // === Form Events ===
        private void Purchases_Load(object sender, EventArgs e)
        {
            StartConsumer();
        }

        private void Purchases_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopConsumer();
        }

        private async Task SendCrudMessage(string action)
        {
            var purchase = new
            {
                action,
                purchase_id = txtPurchaseId.Text,
                inventory_id = txtInventoryId.Text,
                supplier_id = txtSupplierId.Text,
                date_id = int.Parse(txtDateId.Text),
                fin_date = txtFinDate.Text,
                unit_cost_price = decimal.Parse(txtUnitCost.Text),
                quantity_purchased = int.Parse(txtQuantity.Text),
                total_cost = decimal.Parse(txtTotalCost.Text)
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(purchase);
            await SendKafkaMessage(Guid.NewGuid().ToString(), json); // reuse your existing SendKafkaMessage
        }

        // === Kafka Producer ===
        private async Task SendKafkaMessage(string key, string value)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = BootstrapServers
            };

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

        // === Kafka Consumer ===
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
                        // Update UI safely
                        this.Invoke((MethodInvoker)(() =>
                        {
                            txtMessages.AppendText($"Received: {cr.Message.Value}\r\n");
                        }));
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

        private async void btnCreate_Click(object sender, EventArgs e)
            => await SendCrudMessage("create");

        private async void btnUpdate_Click(object sender, EventArgs e)
            => await SendCrudMessage("update");

        private async void btnDelete_Click(object sender, EventArgs e)
            => await SendCrudMessage("delete");

    }
}
