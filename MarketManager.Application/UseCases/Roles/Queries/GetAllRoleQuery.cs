using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Roles.Queries;
public record GetAllRoleQuery : IRequest<List<RoleGetDto>>
{
}

public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RoleGetDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Roles.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<RoleGetDto>>(entities);
        return result;
    }
}
