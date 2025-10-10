using System;

namespace CRUD_operations
{
    public class Sale
    {
        public string rep_id { get; set; }
        public int transtype_id { get; set; }
        public string customer_id { get; set; }
        public int date_id { get; set; }
        public int fin_date { get; set; }
        public string inventory_code { get; set; }
        public int quantity_sold { get; set; }
        public decimal unit_selling_price { get; set; }
        public decimal unit_last_cost { get; set; }
        public decimal total_line_price { get; set; }

        public override string ToString()
        {
            return $"{customer_id} - {inventory_code} (Qty: {quantity_sold})";
        }
    }
}