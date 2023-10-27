using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
    }
}
