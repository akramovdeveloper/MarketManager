using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Carts.Queries.GetAllCarts
{
    public record GetAllCartsQuery : IRequest<IEnumerable<GetAllCartsQueryResponse>>;

    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, IEnumerable<GetAllCartsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllCartsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<GetAllCartsQueryResponse>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Cart> carts = _context.Carts;

            return Task.FromResult(_mapper.Map<IEnumerable<GetAllCartsQueryResponse>>(carts));

        }
    }
    public class GetAllCartsQueryResponse
    {
        public Guid PackageId { get; set; }
        public Guid SoldId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }
    }
}
