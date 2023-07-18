using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommand:IRequest<Guid>
{

}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
