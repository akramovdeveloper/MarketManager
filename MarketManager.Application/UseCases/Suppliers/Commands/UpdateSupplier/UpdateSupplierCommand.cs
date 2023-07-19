using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Users.Commands.UpdateUser;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Suppliers.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSupplierCommandHandler(IApplicationDbContext context)
                => _context = context;
        public async Task<bool> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var foundSupplier = await _context.Suppliers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (foundSupplier is null)
                throw new NotFoundException(nameof(Supplier), request.Id);

            foundSupplier.Name = request.Name;
            foundSupplier.Phone = request.Phone;

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;

        }
    }
}
