using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Models
{
    public class ShoppingCartDetail
    {
        public int ShoppingCartDetailId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string SelectedProduct { get; set; }
        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
