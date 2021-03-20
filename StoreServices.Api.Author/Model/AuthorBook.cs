using System;
using System.Collections.Generic;


namespace StoreServices.Api.Autor.Model
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Grade> GradesList { get; set; }
        public string AuthorBookGuid { get; set; }
    }
}
