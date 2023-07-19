using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.DeleteUser;
public record DeleteUserCommand(Guid Id):IRequest;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
            => _context = context;
        
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
     
        var foundUser = await _context.Users.FindAsync(new object[] {request.Id},cancellationToken);
        if (foundUser is null)
            throw new NotFoundException(nameof(User), request.Id);
        _context.Users.Remove(foundUser);

       await _context.SaveChangesAsync(cancellationToken);
        

    }
}
