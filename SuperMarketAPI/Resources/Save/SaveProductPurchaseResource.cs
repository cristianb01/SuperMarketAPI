using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Resources
{
    public class SaveProductPurchaseResource
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public byte Quantity { get; set; }
    }
}
