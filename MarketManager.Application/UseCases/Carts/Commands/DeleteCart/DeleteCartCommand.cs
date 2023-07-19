using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Carts.Commands.DeleteCart
{
    public class DeleteCartCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _context.Carts.FindAsync(request.Id);
            if (cart is null)
                throw new NotFoundException(nameof(Cart), request.Id);
        }
    }
}
