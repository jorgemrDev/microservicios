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
        public class Author : IRequest<AuthorBook>
        {
            public string AuthorGuid { get; set; }
        }
        public class Handler : IRequestHandler<Author, AuthorBook>
        {
            public readonly ContextAuthor _context;
            public Handler(ContextAuthor context)
            {
                _context = context;
            }

            public async  Task<AuthorBook> Handle(Author request, CancellationToken cancellationToken)
            {
                var author = await _context.AuthorBook.Where(e=> e.AuthorBookGuid == request.AuthorGuid).FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception("No se enconto el autor");
                }
                return author;
            }
        }
    }
}

