using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Users.Commands.CreateUser;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateSupplierCommandHandler(IApplicationDbContext context)
                => _context = context;

        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier supplier = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone
            };
            await _context.Suppliers.AddAsync(supplier, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return supplier.Id;
        }
    }

}
