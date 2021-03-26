using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Libro.Aplicacion
{
    public class BookDto
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid? Author { get; set; }
    }
}
