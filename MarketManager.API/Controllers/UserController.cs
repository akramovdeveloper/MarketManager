using MarketManager.Application.Common.JWT.Models;
using MarketManager.Application.UseCases.Users.Commands.CreateUser;
using MarketManager.Application.UseCases.Users.Commands.DeleteUser;
using MarketManager.Application.UseCases.Users.Commands.LoginUser;
using MarketManager.Application.UseCases.Users.Commands.RegisterUser;
using MarketManager.Application.UseCases.Users.Commands.UpdateUser;
using MarketManager.Application.UseCases.Users.Queries.GetAllUser;
using MarketManager.Application.UseCases.Users.Queries.GetByIdUser;
using MarketManager.Application.UseCases.Users.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseApiController
{

    [HttpGet]
    public async ValueTask<UserResponse> GetUserById(GetByIdUserQuery query)
        => await _mediator.Send(query);
   
    [HttpGet]
    public async ValueTask<List<UserResponse>> GetAllUser(GetAllUserQuery query)
     => await _mediator.Send(query);

    
    [HttpPost]
    public async ValueTask<TokenResponse> RegisterUser(RegisterUserCommand command)
        => await _mediator.Send(command);

   
    [HttpPost] 
    public async ValueTask<TokenResponse> LoginUser(LoginUserCommand command) 
        => await _mediator.Send(command);

    [HttpPost] 
    public async ValueTask<Guid> CreateUser(CreateUserCommand command) 
        => await _mediator.Send(command);

   
    [HttpPut]
    public async ValueTask<IActionResult> UpdateUser(UpdateUserCommand command)
    {
        await _mediator.Send(command); 
        return NoContent();
    }

   
    [HttpDelete] 
    public async ValueTask<IActionResult> DeleteUser(DeleteUserCommand command)
    {
        await _mediator.Send(command);  
        return NoContent();
    }

   
}
