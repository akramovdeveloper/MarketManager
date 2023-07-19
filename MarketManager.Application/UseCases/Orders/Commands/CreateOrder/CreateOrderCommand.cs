using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Orders.Commands.CreateOrder
{

    public class CreateOrderCommand : IRequest<Guid>
    {
        public decimal TotalPrice { get; set; }

        public Guid ClientId { get; set; }
        public decimal CardPriceSum { get; set; }
        public decimal CashPurchaseSum { get; set; }

        public ICollection<Guid> Carts { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            IEnumerable<Cart>? carts = FilterIfAllCartsExsist(request.Carts);
            
            Order order= _mapper.Map<Order>(request);
            order.Carts = carts.ToList();
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }

        private IEnumerable<Cart> FilterIfAllCartsExsist(ICollection<Guid> carts)
        {
            foreach (Guid Id in carts)
               yield return _dbContext.Carts.FirstOrDefault(c => c.Id == Id)
                    ?? throw new NotFoundException($" There is no cart with this {Id} id. ");
        }
    }
}
