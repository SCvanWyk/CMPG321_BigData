using System;
using System.ComponentModel;
using System.Windows.Forms;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CRUD_operations
{
    public partial class payments : Form
    {
        private BindingList<Payment> paymentsList = new BindingList<Payment>();

        public payments()
        {
            InitializeComponent();
        }

        private void payments_Load(object sender, EventArgs e)
        {
            listBoxPayments.DataSource = paymentsList;
            listBoxPayments.DisplayMember = "DisplayText";
        }

        private async Task SendToKafkaAsync(Payment payment)
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
                string json = JsonConvert.SerializeObject(payment);
                var result = await producer.ProduceAsync("payments-topic", new Message<Null, string> { Value = json });
                Console.WriteLine($"Sent to Kafka: {result.TopicPartitionOffset}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int finDateInt;
                if (!int.TryParse(txtFinDate.Text.Replace("-", ""), out finDateInt))
                {
                    MessageBox.Show("Invalid financial date. Use YYYYMM format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var payment = new Payment
                {
                    payment_id = txtPaymentId.Text,
                    customer_id = txtCustomerId.Text,
                    date_id = txtDateId.Text,
                    financial_period = finDateInt,
                    amount = numAmount.Value,
                    discount = numDiscount.Value
                };

                paymentsList.Add(payment);
                _ = SendToKafkaAsync(payment);
                MessageBox.Show("Payment sent to Kafka", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Kafka Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxPayments.SelectedItem is Payment selectedPayment)
            {
                try
                {
                    selectedPayment.payment_id = txtPaymentId.Text;
                    selectedPayment.customer_id = txtCustomerId.Text;
                    selectedPayment.date_id = txtDateId.Text;
                    selectedPayment.financial_period = int.Parse(txtFinDate.Text.Replace("-", ""));
                    selectedPayment.amount = numAmount.Value;
                    selectedPayment.discount = numDiscount.Value;

                    paymentsList.ResetBindings();
                    _ = SendToKafkaAsync(selectedPayment);
                    MessageBox.Show("Payment updated and sent to Kafka", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a payment from the list to update", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPayments.SelectedItem is Payment selectedPayment)
            {
                paymentsList.Remove(selectedPayment);
                MessageBox.Show("Payment deleted from list", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a payment from the list to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPayments.SelectedItem is Payment selectedPayment)
            {
                txtPaymentId.Text = selectedPayment.payment_id;
                txtCustomerId.Text = selectedPayment.customer_id;
                txtDateId.Text = selectedPayment.date_id;
                txtFinDate.Text = selectedPayment.financial_period.ToString();
                numAmount.Value = selectedPayment.amount;
                numDiscount.Value = selectedPayment.discount;
            }
        }

        private void ClearInputs()
        {
            txtPaymentId.Clear();
            txtCustomerId.Clear();
            txtDateId.Clear();
            txtFinDate.Clear();
            numAmount.Value = 0;
            numDiscount.Value = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void lblInventoryCode_Click(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Payment
    {
        public string payment_id { get; set; }
        public string customer_id { get; set; }
        public string date_id { get; set; }
        public int financial_period { get; set; }
        public decimal amount { get; set; }
        public decimal discount { get; set; }

        [JsonIgnore]
        public string DisplayText => $"PaymentID: {payment_id} | Customer: {customer_id} | Amount: {amount:C}";
    }
}
