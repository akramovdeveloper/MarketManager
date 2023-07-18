using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Users.Commands.CreateUser;
public record CreateUserCommand:IRequest<Guid>
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid[]? RoleIds { get; set; }


}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
            => _context = context;
    
    

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var roles = await _context.Roles.ToListAsync(cancellationToken);
        var userRole = new List<Role>();
        if(request?.RoleIds?.Length > 0)
        {
            foreach (var roleId in request.RoleIds)
            {
                foreach (var role in roles)
                {
                    if(role.Id == roleId)
                    {
                        userRole.Add(role);
                    }
                }
            }
        }
            
        User user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Password = request.Password,
            Phone = request.Phone,
            Roles = userRole
        };
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;

        
    }
}
