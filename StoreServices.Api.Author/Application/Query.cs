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
using static StoreServices.Api.Author.Application.New;

namespace StoreServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDTO>> { 
        }
        public class Handler : IRequestHandler<AuthorList, List<AuthorDTO>>
        {
            public readonly ContextAuthor _context;
            public readonly IMapper _mapper;
            public Handler(ContextAuthor context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }          

            public async Task<List<AuthorDTO>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var bookAuthors = await _context.AuthorBook.ToListAsync();
                var authoresDTO = _mapper.Map<List<AuthorBook>, List<AuthorDTO>>(bookAuthors);
                return authoresDTO;
            }
        }
    }
}
