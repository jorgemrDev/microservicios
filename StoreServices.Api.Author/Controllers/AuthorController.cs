using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Autor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data) {
            return await _mediator.Send(data);

        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorBook>>> GetAuthors() {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBook>> GetAuthor(string id)
        {
            return await _mediator.Send(new QueryFiltered.Author() { AuthorGuid = id });
        }
    }
}
