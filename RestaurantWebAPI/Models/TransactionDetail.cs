using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Models
{
    public class TransactionDetail
    {
        public int TransactionDetailId { get; set; }
        public int TransactionId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
