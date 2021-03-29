using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class ShoppingCartDetailDto
    {
        public Guid? BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
