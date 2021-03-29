using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.RemoteModel
{
    public class RemoteBook
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid? Author { get; set; }
    }
}
