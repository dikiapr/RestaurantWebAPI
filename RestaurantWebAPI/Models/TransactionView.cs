using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Models
{
    public class TransactionView
    {
        public Transaction Transaction { get; set; }
        public TransactionDetail TransactionDetail { get; set; }
    }
}
