using AutoMapper;
using StoreServices.Api.Autor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorDTO>();
        }
    }
}
