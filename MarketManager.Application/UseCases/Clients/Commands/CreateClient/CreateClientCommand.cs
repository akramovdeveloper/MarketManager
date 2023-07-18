using MediatR;
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
        public Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
