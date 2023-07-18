using MarketManager.Application.Common.Interfaces;
using MediatR;

namespace MarketManager.Application.UseCases.Roles.Commands.DeleteRole;
public record DeleteRoleCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles.FindAsync(new object[] { request.Id });

    }
}
