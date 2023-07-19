using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid Id) : IRequest;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private IApplicationDbContext _dbContext;
    private IMapper _mapper;

    public DeleteOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = FilterIfOrderExsists(request.Id);

        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private Order FilterIfOrderExsists(Guid id)
        => _dbContext.Orders
        .FirstOrDefault(c => c.Id == id)
            ?? throw new NotFoundException(
                " There is no order with id. ");

}
