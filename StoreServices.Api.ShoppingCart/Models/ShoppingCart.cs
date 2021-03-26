using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public DateTime? CreationDate { get; set; }

        public ICollection<ShoppingCartDetail> DetailsList { get; set; }
    }
}
