using System;

namespace CRUD_operations
{
    public class Payment
    {
        public string payment_id { get; set; }
        public string customer_id { get; set; }
        public int date_id { get; set; }           // Numeric date reference
        public DateTime fin_date { get; set; }     // Financial date as DateTime
        public decimal bank_amt { get; set; }      // Amount deposited or paid
        public decimal discount { get; set; }      // Any discount applied

        public override string ToString()
        {
            // Display in the listbox nicely
            return $"{payment_id} - {customer_id} | Amount: {bank_amt:C} | Date: {fin_date:yyyy-MM-dd}";
        }
    }
}
