using System;

namespace CRUD_operations
{
    public class Purchase
    {
        public string purchase_id { get; set; }
        public string inventory_id { get; set; }
        public string supplier_id { get; set; }
        public int date_id { get; set; }
        public string fin_date { get; set; }
        public decimal unit_cost_price { get; set; }
        public int quantity_purchased { get; set; }
        public decimal total_cost { get; set; }

        public override string ToString()
        {
            return $"{purchase_id} - {inventory_id} (Qty: {quantity_purchased})";
        }
    }
} 