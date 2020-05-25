using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Resources
{
    public class PurchaseResource
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public IList<ProductPurchaseResource> Products { get; set; } = new List<ProductPurchaseResource>();

    }
}
