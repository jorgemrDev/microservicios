using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class ShoppingCartDto
    {
        public int ShoppingCartId { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<ShoppingCartDetailDto> ProductsList { get; set; }
    }
}
