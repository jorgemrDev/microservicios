using FluentValidation;
using MediatR;
using StoreServices.Api.ShoppingCart.Models;
using StoreServices.Api.ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class New
    {
        public class Execute : IRequest
        {            
            public DateTime CreationDate { get; set; }
            public List<string> ProductsList { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.CreationDate).NotEmpty();                
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ShoppingCartContext _context;
            public Handler(ShoppingCartContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var shoppingCart = new Models.ShoppingCart
                {
                    CreationDate = request.CreationDate
                };

                _context.ShoppingCart.Add(shoppingCart);
                var rows = await _context.SaveChangesAsync();
                if (rows == 0)
                    throw new Exception("There was an error creating Shopping Cart");                    

                int id = shoppingCart.ShoppingCartId;

                foreach (var item in request.ProductsList)
                {
                    var shoopingCartDetail = new ShoppingCartDetail
                    {
                        CreationDate = DateTime.Now,
                        ShoppingCartId = id,
                        SelectedProduct = item
                    };
                    _context.ShoppingCartDetail.Add(shoopingCartDetail);
                }

                id = await _context.SaveChangesAsync();

                if (id > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("There was an error inserting Shopping Cart details");
            }
        }

    }
}
