using FluentValidation;
using MediatR;
using StoreServices.Api.Libro.Models;
using StoreServices.Api.Libro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Libro.Aplicacion
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public Guid? Author { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.ReleaseDate).NotEmpty();
                RuleFor(x => x.Author).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly LibraryContext _context;
            public Handler(LibraryContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new Book
                {
                    Title = request.Title,
                    ReleaseDate = request.ReleaseDate,
                    Author = request.Author
                };

                _context.Book.Add(book);
                var rows = await _context.SaveChangesAsync();
                if (rows > 0)
                    return Unit.Value;

                throw new Exception("There was an error inserting Book");
            }
        }


    }
}
