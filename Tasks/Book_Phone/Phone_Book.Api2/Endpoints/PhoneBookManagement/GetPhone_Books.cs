using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Business.Phone_Book_Management.Queries.GetPhone_Books;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api2.Endpoints.PhoneBookManagement
{
    public class GetPhone_Books : EndpointBaseAsync
        .WithRequest<GetPhone_BooksRequest>
        .WithActionResult<GetPhone_BooksResponse>
    {

        private readonly ILogger<GetPhone_Books> _logger;
        private IMapper _mapper;
        private readonly IMediator _mediator;
        public GetPhone_Books(ILogger<GetPhone_Books> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("1.0")]
        [HttpGet(GetPhone_BooksRequest.Route)]
        [SwaggerOperation(Summary = "Create User Account", Description = "Create User Account ", OperationId = "Informatique.VerOne.User.WebApi.EndPoints.UserManagement.UserLogin", Tags = new[] { "Informatique.VerOne.User.WebApi.EndPoints.UserManagement" })]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetPhone_BooksResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]

        public override async Task<ActionResult<GetPhone_BooksResponse>> HandleAsync([FromQuery] GetPhone_BooksRequest request,CancellationToken cancellationToken = default)
        { 
            var input = _mapper.Map<GetPhone_BooksInput>(request);
            var result = await _mediator.Send(input, cancellationToken);
            var Response = _mapper.Map<IEnumerable<GetPhone_BooksOutput>>(result);

            return Ok(Response);
        }
    }
}
