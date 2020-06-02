using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Resources
{
    public class SavePurchaseResource
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public IList<SaveProductPurchaseResource> Products{ get; set; }

    }
}
