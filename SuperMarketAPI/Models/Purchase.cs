using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;

namespace SuperMarketAPI.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public IList<ProductPurchase> Products { get; set; } = new List<ProductPurchase>();
    }
}
