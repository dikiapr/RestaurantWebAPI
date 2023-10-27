using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public decimal Harga { get; set; }
    }
}
