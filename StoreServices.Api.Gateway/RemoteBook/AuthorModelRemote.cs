using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Gateway.RemoteBook
{
    public class AuthorModelRemote
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
