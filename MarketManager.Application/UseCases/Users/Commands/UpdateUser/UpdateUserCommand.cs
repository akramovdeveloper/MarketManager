using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Users.Commands.UpdateUser;
public record UpdateUserCommand:IRequest<bool>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid[]? RoleIds { get; set; }
}
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
       var roles = await _context.Roles.ToListAsync(cancellationToken);
       var foundUser = await _context.Users.FindAsync(new object[] {request.Id},cancellationToken);
        if (foundUser is null)
            throw new NotFoundException(nameof(User), request.Id);

        if(request?.RoleIds?.Length > 0)
        {
            foundUser?.Roles?.Clear();
            foreach (var roleId in request.RoleIds)
            {
                foreach (var role in roles)
                {
                    if (role.Id == roleId)
                        foundUser?.Roles?.Add(role);
                }
            }
        }
        foundUser.Username = request.Username;
        foundUser.Password = request.Password;
        foundUser.Phone = request.Phone;
        foundUser.FullName = request.FullName;

        return (await _context.SaveChangesAsync(cancellationToken)) > 0;

    }
}
