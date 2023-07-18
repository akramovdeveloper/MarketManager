using MarketManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
    }
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateClientCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            clientToUpdate.TotalPrice = request.TotalPrice;
            clientToUpdate.Discount = request.Discount;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
