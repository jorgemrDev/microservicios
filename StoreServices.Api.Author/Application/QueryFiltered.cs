using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Repository;
using StoreServices.Api.Autor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.Application
{
    public class QueryFiltered
    {
        public class Author : IRequest<AuthorDTO>
        {
            public string AuthorGuid { get; set; }
        }
        public class Handler : IRequestHandler<Author, AuthorDTO>
        {
            public readonly ContextAuthor _context;
            public readonly IMapper _mapper;
            public Handler(ContextAuthor context,
                 IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async  Task<AuthorDTO> Handle(Author request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBook.Where(e=> e.AuthorBookGuid == request.AuthorGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("No se enconto el autor");
                }
                var authorDTO = _mapper.Map<AuthorBook, AuthorDTO>(author);
                return authorDTO;
            }
        }
    }
}

