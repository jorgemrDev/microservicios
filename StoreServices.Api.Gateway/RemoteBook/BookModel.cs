using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Gateway.RemoteBook
{
    public class BookModel
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid? Author { get; set; }

        public AuthorModelRemote AuthorData { get; set; }
    }
}
