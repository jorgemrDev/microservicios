using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Interfaces;
using StoreServices.Api.ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class Query
    {
        public class Execute : IRequest<ShoppingCartDto>{
            public int ShoppingCartId { get; set; }
        }


        public class Handler : IRequestHandler<Execute, ShoppingCartDto>
        {
            public readonly ShoppingCartContext _context;
            public readonly IBooksService _booksService;
            public Handler(ShoppingCartContext context,
                 IBooksService booksService)
            {
                _context = context;
                _booksService = booksService;
            }


            public async Task<ShoppingCartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shoppingCart = await _context.ShoppingCart.FirstOrDefaultAsync(x => x.ShoppingCartId == request.ShoppingCartId);
                var shoppingCartDetail = await _context.ShoppingCartDetail.Where(x => x.ShoppingCartId == request.ShoppingCartId).ToListAsync();

                var shoppingCartDetailDtoList = new List<ShoppingCartDetailDto>();
                
                foreach (var book in shoppingCartDetail)
                {
                  var response = await _booksService.GetBook(new Guid(book.SelectedProduct));
                    if (response.result)
                    {
                        var bookObject = response.book;
                        var cartDetail = new ShoppingCartDetailDto
                        {
                            BookTitle = bookObject.Title,
                            BookId = bookObject.BookId,
                            ReleaseDate = bookObject.ReleaseDate,
                        };
                        shoppingCartDetailDtoList.Add(cartDetail);
                    }
                }

                var shoppinggCartDto = new ShoppingCartDto
                {
                    ProductsList = shoppingCartDetailDtoList,
                    ShoppingCartId = shoppingCart.ShoppingCartId,
                    CreationDate = shoppingCart.CreationDate
                };

                return shoppinggCartDto;
            }
        }
    }
}
