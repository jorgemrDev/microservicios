using StoreServices.Api.Gateway.RemoteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Gateway.Interfaces
{
   public  interface IAuthorRemote
    {
        Task<(bool result, AuthorModelRemote author, string errorMessage)> GetAuthor(Guid AuthorId);
    }
}
