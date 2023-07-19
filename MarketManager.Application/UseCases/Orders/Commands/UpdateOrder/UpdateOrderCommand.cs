using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }

    public Guid ClientId { get; set; }
    public decimal CardPriceSum { get; set; }
    public decimal CashPurchaseSum { get; set; }

    public ICollection<Guid> Carts { get; set; }

}
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public UpdateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = await FilterIfOrderExists(request.Id);
        IEnumerable<Cart> carts = FilterifCartIdsAreAvialible(request.Carts);
        _mapper.Map(request, order);
        order.Carts = carts.ToArray();
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private IEnumerable<Cart> FilterifCartIdsAreAvialible(ICollection<Guid> orderIds)
    {
        foreach (var Id in orderIds)
            yield return _dbContext.Carts.Find(Id)
                ?? throw new NotFoundException(
                    $" there is no cart with this {Id} id. ");
    }

    private async Task<Order> FilterIfOrderExists(Guid id)
     =>     await _dbContext.Orders.Include("Carts")
                .FirstOrDefaultAsync(x => x.Id == id)
                 ?? throw new NotFoundException(
                          " there is no order with this id. ");
}
