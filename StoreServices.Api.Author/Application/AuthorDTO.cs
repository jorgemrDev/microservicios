using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.Application
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
