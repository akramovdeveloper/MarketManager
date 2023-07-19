using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Commands.DeletePackage
{
    public class DeletePackageCommand:IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePackageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeletePackageCommand request, CancellationToken cancellationToken)
        {
            Package? package = await _context.Packages.FindAsync(request.Id);
            if (package is null)
                throw new NotFoundException(nameof(Package), request.Id);
        }
    }
}
