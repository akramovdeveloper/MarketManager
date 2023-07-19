using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation() 
        {
            RuleFor(x => x.TotalPrice).GreaterThanOrEqualTo(0)
                .WithMessage(" total price can't be lower than zero. ");
    
        }
    }
}
