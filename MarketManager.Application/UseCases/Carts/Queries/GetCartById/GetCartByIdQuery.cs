using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Carts.Queries.GetCartById
{
    public record GetCartByIdQuery(Guid Id) : IRequest<GetCartByIdQueryResponse>;

    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, GetCartByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCartByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetCartByIdQueryResponse> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            Cart? cart = await _context.Carts.FindAsync(request.Id);

            if (cart is null)
                throw new NotFoundException(nameof(Cart), request.Id);

            return _mapper.Map<GetCartByIdQueryResponse>(cart);
        }
    }
    public class GetCartByIdQueryResponse
    {
        public Guid Id { get; set; }
    }
}
