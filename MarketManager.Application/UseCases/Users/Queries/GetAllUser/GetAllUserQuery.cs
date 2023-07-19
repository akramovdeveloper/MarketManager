using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Users.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketManager.Application.UseCases.Users.Queries.GetAllUser;
public record GetAllUserQuery:IRequest<List<UserResponse>>;
public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUserQueryHandler(IApplicationDbContext context, IMapper mapper)
            =>( _context ,_mapper) =(context,mapper);
    
    public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var allUser = await _context.Users.ToListAsync(cancellationToken);  
        var result = _mapper.Map<List<UserResponse>>(allUser);
        return result;  
    }
}


