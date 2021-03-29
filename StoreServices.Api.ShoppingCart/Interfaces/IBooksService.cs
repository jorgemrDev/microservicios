using StoreServices.Api.ShoppingCart.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Interfaces
{
    public interface IBooksService
    {
        Task<(bool result, RemoteBook book, string errorMessage)> GetBook(Guid BookId);
    }
}
