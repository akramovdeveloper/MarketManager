using MarketManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Clients.Commands.DeleteClient;

public class DeleteClientCommand:IRequest<bool>
{
    public Guid Id { get; set; }
}
public class DeleteClientCommandHandler:IRequestHandler<DeleteClientCommand, bool>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteClientCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var clientToDelete = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (clientToDelete == null)
        {
            return false;
        }

        _dbContext.Clients.Remove(clientToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
