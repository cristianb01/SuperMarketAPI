using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Resources
{
    public class ProductPurchaseResource
    {
        //public int ProductId { get; set; }
        [Range(1, 35)]
        public byte Quantity { get; set; }
        public ProductResource Product { get; set; }
        //public int PurchaseId { get; set; }
        //public PurchaseResource Purchase { get; set; }

    }
}
