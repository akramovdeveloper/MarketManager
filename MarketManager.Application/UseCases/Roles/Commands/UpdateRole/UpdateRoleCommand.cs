using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Roles.Commands.UpdateRole;
public class UpdateRoleCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Guid>? PermissionsIds { get; set; }
}

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Role), request.Id);

        entity.Name = request.Name;
        if (request.PermissionsIds is not null)
        {
            List<Permission> permissions = new();
            foreach (var item in request.PermissionsIds)
            {
                var permission = await _context.Permissions.FindAsync(new object[] { item }, cancellationToken);
                permissions.Add(permission);
            }
            entity.Permissions = permissions;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}
