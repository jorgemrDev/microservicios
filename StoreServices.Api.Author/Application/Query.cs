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
        public class AuthorList : IRequest<List<AuthorBook>> { 
        }
        public class Handler : IRequestHandler<AuthorList, List<AuthorBook>>
        {
            public readonly ContextAuthor _context;
            public Handler(ContextAuthor context)
            {
                _context = context;
            }          

            public async Task<List<AuthorBook>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var bookAuthors = await _context.AuthorBook.ToListAsync();
                return bookAuthors;
            }
        }
    }
}
