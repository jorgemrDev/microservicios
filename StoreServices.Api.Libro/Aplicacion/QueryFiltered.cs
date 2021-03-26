using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Libro.Models;
using StoreServices.Api.Libro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Libro.Aplicacion
{
    public class QueryFiltered
    {
        public class BookRequest : IRequest<BookDto>
        {
            public Guid BookId { get; set; }
        }
        public class Handler : IRequestHandler<BookRequest, BookDto>
        {
            public readonly LibraryContext _context;
            public readonly IMapper _mapper;
            public Handler(LibraryContext context,
                 IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(BookRequest request, CancellationToken cancellationToken)
            {
                var book = await _context.Book.Where(e => e.BookId == request.BookId).FirstOrDefaultAsync();
                if (book == null)
                {
                    throw new Exception("No se enconto el libro");
                }
                var bookDto = _mapper.Map<Book, BookDto>(book);
                return bookDto;
            }
        }
    }
}
