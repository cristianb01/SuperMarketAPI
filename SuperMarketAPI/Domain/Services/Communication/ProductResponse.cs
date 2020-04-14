using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services.Communication
{
    public class ProductResponse : BaseResponse
    {
        public Product product;
        public ProductResponse(bool success, string message, Product product) : base(success,message)
        {
            this.product = product;
        }
        //creates an successful message
        public ProductResponse(Product product) : this(true,string.Empty, product)
        {
        }

        //creates an error message
        public ProductResponse(string message) : this(false,message,null)
        {
        }
    }
}
