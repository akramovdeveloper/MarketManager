using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Clients.Commands.CreateClient
{
    public class CreateClientCommand:IRequest<Guid>
    {
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
    }
    public class CreateClientCommandHandler:IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateClientCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var newClient = new Client
            {
                Id = Guid.NewGuid(),
                TotalPrice = request.TotalPrice,
                Discount = request.Discount
            };

            _dbContext.Clients.Add(newClient);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return newClient.Id;
        }
    }
}
