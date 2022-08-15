using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phone_Book.Application.Business.UserManagement.Commands.UserLogin;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Phone_Book.Api.Endpoints.UserManagement
{
    public class UserLogin : EndpointBaseAsync
        .WithRequest<UserLoginRequest>
        .WithActionResult<UserLoginResponse> 
    {

        private readonly ILogger<CreateUserAccount> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserLogin(ILogger<CreateUserAccount> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }

        [ApiVersion("1.0")]
        [HttpPost(UserLoginRequest.Route)]
        [SwaggerOperation(Summary = "user login", Description = "to check user login by user stud code and password is national number ", OperationId = "Informatique.VerOne.User.WebApi.EndPoints.UserManagement.UserLogin", Tags = new[] { "Informatique.VerOne.User.WebApi.EndPoints.UserManagement" })]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserLoginResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        public override async Task<ActionResult<UserLoginResponse>> HandleAsync(UserLoginRequest request, CancellationToken cancellationToken = default)
        {
            var userInput = _mapper.Map<UserLoginInput>(request);
            var userOutput = await _mediator.Send(userInput, cancellationToken);
            var userResponse = _mapper.Map<UserLoginResponse>(userOutput);
            return Ok(userResponse);
        }
    }
}
