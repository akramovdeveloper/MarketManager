using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Roles.Commands.CreateRole;
public record CreateRoleCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public List<Guid>? PermissionsIds { get; set; }
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUser _currentUser;
    public CreateRoleCommandHandler(IApplicationDbContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var roleEntity = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        if (request.PermissionsIds is not null)
        {
            List<Permission> foundPermissions = new();
            foreach (var item in request.PermissionsIds)
            {
                var permission = await _context.Permissions.FindAsync(new object[] { item }, cancellationToken);
                foundPermissions.Add(permission);
            }
            roleEntity.Permissions = foundPermissions;
        }
        await _context.Roles.AddAsync(roleEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return roleEntity.Id;

    }
}
