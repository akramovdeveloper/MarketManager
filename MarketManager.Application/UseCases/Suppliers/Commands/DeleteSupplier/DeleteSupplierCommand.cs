using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Users.Commands.DeleteUser;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Suppliers.Commands.DeleteSupplier
{
    public record DeleteSupplierCommand(Guid Id) : IRequest<bool>;

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSupplierCommandHandler(IApplicationDbContext context)
                => _context = context;


        public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {

            var foundSupplier = await _context.Suppliers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (foundSupplier is null)
                throw new NotFoundException(nameof(Supplier), request.Id);
            _context.Suppliers.Remove(foundSupplier);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;


        }
    }
}
