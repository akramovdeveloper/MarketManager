using MarketManager.Application.UseCases.Orders.Commands.CreateOrder;
using MarketManager.Application.UseCases.Orders.Commands.UpdateOrder;
using MarketManager.Application.UseCases.Orders.Queries.GetAllOrders;
using MarketManager.Application.UseCases.Orders.Queries.GetOrder;
using Microsoft.AspNetCore.Mvc;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.API.Controllers
{
    public class OrderController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllOrderQueryResponse>> GetAllOrders()
        {
            return await _mediator.Send(new GetAllOrderQuery());
        }

        [HttpGet]
        public async ValueTask<GetOrderByIdResponse> GetOrderById(Guid Id)
        {
            return await _mediator.Send(new GetOrderQuery(Id));
        }

        [HttpPost]
        public async ValueTask<Guid> CreateOrder(CreateOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
