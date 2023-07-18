using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.DeleteUser;
public record DeleteUserCommand(Guid Id):IRequest<bool>;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
            => _context = context;
        
    
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
     
        var foundUser = await _context.Users.FindAsync(new object[] {request.Id},cancellationToken);
        if (foundUser is null)
            throw new NotFoundException(nameof(User), request.Id);
        _context.Users.Remove(foundUser);

        return (await _context.SaveChangesAsync(cancellationToken)) > 0;


    }
}
