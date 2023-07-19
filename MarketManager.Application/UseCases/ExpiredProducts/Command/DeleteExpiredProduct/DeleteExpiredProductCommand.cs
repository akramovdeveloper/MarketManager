using MarketManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.ExpiredProducts.Command.DeleteExpiredProduct
{
    public class DeleteExpiredProductCommand : IRequest<bool>
    {
        
    }

    public class DeleteExpiredProductHandler : IRequestHandler<DeleteExpiredProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExpiredProductHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(DeleteExpiredProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }



}
