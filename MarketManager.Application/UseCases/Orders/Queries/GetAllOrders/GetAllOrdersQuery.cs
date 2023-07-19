﻿using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Orders.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Orders.Queries.GetAllOrders;

public record GetAllOrderQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<OrderDto>>;

public class GetallOrderCommmandHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
{

    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public GetallOrderCommmandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        Order[] candidates = await _dbContext.Orders.ToArrayAsync();

        List<OrderDto> dtos = _mapper.Map<OrderDto[]>(candidates).ToList();

        return dtos;
    }
}