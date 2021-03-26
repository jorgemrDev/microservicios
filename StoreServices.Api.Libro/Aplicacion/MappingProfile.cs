using AutoMapper;
using StoreServices.Api.Libro.Models;

namespace StoreServices.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
