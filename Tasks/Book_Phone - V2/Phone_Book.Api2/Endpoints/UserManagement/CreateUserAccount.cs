using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class CreateUserAccount : EndpointBaseAsync
        .WithRequest<CreateUserAccountRequest>
        .WithActionResult<CreateUserAccountResponse>
    {
        private readonly ILogger<CreateUserAccount> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateUserAccount(ILogger<CreateUserAccount> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [ApiVersion("1.0")]
        [HttpPost(CreateUserAccountRequest.Route)]
        [SwaggerOperation(Summary = "Create User Account", Description = "Create User Account ", OperationId = "Informatique.VerOne.User.WebApi.EndPoints.UserManagement.UserLogin", Tags = new[] { "Informatique.VerOne.User.WebApi.EndPoints.UserManagement" })]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreateUserAccountResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        public override async Task<ActionResult<CreateUserAccountResponse>> HandleAsync(CreateUserAccountRequest request, CancellationToken cancellationToken = default)
        {
            var userInput =  _mapper.Map<CreateUserAccountInput>(request);
            
            var userOutput = await _mediator.Send(userInput, cancellationToken);
            var userResponse = _mapper.Map<CreateUserAccountResponse>(userOutput);

            return Ok(userResponse);
        }
    }
}
