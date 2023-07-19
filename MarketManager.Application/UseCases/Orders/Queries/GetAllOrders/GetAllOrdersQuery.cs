using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.UseCases.Orders.Queries.GetAllOrders;

public record GetAllOrderQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<GetAllOrderQueryResponse>>;

public class GetallOrderCommmandHandler : IRequestHandler<GetAllOrderQuery, List<GetAllOrderQueryResponse>>
{

    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public GetallOrderCommmandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        Order[] candidates = await _dbContext.Orders.ToArrayAsync();

        List<GetAllOrderQueryResponse> dtos = _mapper.Map<GetAllOrderQueryResponse[]>(candidates).ToList();

        return dtos;
    }
    public class GetAllOrderQueryResponse
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid ClientId { get; set; }
        public decimal CardPriceSum { get; set; }
        public decimal CashPurchaseSum { get; set; }
    }
}
