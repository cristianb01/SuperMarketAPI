using Microsoft.CodeAnalysis.CSharp.Syntax;
using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services.Communication
{
    public class PurchaseResponse : BaseResponse
    {
        public Purchase Purchase;
        public PurchaseResponse(bool success, string message, Purchase purchase): base(success, message)
        {
            this.Purchase = purchase;
        }

        //creates an successful message
        public PurchaseResponse(Purchase purchase): this(true, string.Empty, purchase)
        {
        }

        public PurchaseResponse(string message): this(false, message, null)
        {

        }
    }
}
