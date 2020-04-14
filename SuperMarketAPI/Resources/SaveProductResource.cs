using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Resources
{
    public class SaveProductResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityInPackage { get; set; }
        [Required]
        public int  CategoryId { get; set; }
    }
}
