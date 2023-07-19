using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.JWT.Interfaces;
using MarketManager.Application.Common.JWT.Models;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Users.Commands.RegisterUser;
public class RegisterUserCommand:IRequest<TokenResponse>
{
    public string FullName { get; set; }
    public string Username { get; set;} 
    public string Phone { get; set; }
    public string Password { get; set;}
    public string ConfirmPassword { get; set;}
}
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TokenResponse>
{
    private readonly IJwtToken _jwtToken;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public RegisterUserCommandHandler(IJwtToken jwtToken, IApplicationDbContext context, IMapper mapper)
    {
        _jwtToken = jwtToken;
        _context = context;
        _mapper = mapper;
    }
    public async Task<TokenResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request); 
        await _context.Users.AddAsync(user,cancellationToken);
        await  _context.SaveChangesAsync(cancellationToken);
        var tokenResponse = await _jwtToken.CreateTokenAsync(user.Username, user.Roles, cancellationToken);
        return tokenResponse;
    }
}
