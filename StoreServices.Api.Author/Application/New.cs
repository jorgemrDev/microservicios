using MediatR;
using StoreServices.Api.Author.Repository;
using StoreServices.Api.Autor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextAuthor _context;
            public Handler(ContextAuthor context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var BookAuthor = new AuthorBook
                {
                    Name = request.Name,
                    BirthDate = request.BirthDate,
                    LastName = request.LastName,
                    AuthorBookGuid = Guid.NewGuid().ToString()
                };

                _context.AuthorBook.Add(BookAuthor);
                var rows = await _context.SaveChangesAsync();
                if (rows > 0)
                    return Unit.Value;

                throw new Exception("There was an error inseting Author");
            }
        }

    }
}
