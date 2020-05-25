using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Models
{
    public class ProductPurchase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        [Range(1,35)]
        public byte Quantity { get; set; }
    }
}
