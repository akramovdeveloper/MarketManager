using AutoMapper;
using MarketManager.Application.Common.Abstraction;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.ExpiredProducts.Queries
{
    public class GetByIdExpiredProductsQuery : IRequest<GetByIdExpiredProductsResponce>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdExpiredProductsResponce : ExpiredProductBaseResponce
    {

    }

    public class GetByIdExpiredProductsQueryHandler : IRequestHandler<GetByIdExpiredProductsQuery, GetByIdExpiredProductsResponce>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdExpiredProductsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetByIdExpiredProductsResponce> Handle(GetByIdExpiredProductsQuery request, CancellationToken cancellationToken)
        {
            ExpiredProduct? getByIdExpiredProducts = await _context.ExpiredProducts.FirstOrDefaultAsync(x=>x.Id== request.Id);
            GetByIdExpiredProductsResponce getByIdExpiredProductsMap = _mapper.Map<GetByIdExpiredProductsResponce>(getByIdExpiredProducts);
            return getByIdExpiredProductsMap;
        }
    }
}
