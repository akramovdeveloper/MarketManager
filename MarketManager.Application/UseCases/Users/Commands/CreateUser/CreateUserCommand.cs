using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommand:IRequest<Guid>
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
