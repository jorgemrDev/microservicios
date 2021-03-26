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
    public class Query
    {
        public class BookList : IRequest<List<BookDto>>
        {
        }
        public class Handler : IRequestHandler<BookList, List<BookDto>>
        {
            public readonly LibraryContext _context;
            public readonly IMapper _mapper;
            public Handler(LibraryContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await _context.Book.ToListAsync();
                var booksDto = _mapper.Map<List<Book>, List<BookDto>>(books);
                return booksDto;
            }
        }
    }
}
