using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Models.Dto.Order;
using Orders.Orders.Commands.CreateOrder;
using Orders.Orders.Commands.DeleteOrder;
using Orders.Orders.Commands.UpdateOrder;
using Orders.Orders.Queries.GetOrderDetails;
using Orders.Orders.Queries.GetOrderList;


namespace Orders.Controllers
{
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var query = new GetOrderListQuery();
            var orders = await Mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery();
            query.Id = id;

            var order = await Mediator.Send(query);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var cmd = _mapper.Map<CreateOrderCommand>(createOrderDto);
            var orderId = await Mediator.Send(cmd);

            return Ok(orderId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
        {
            var cmd = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            await Mediator.Send(cmd);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cmd = new DeleteOrderCommand();
            cmd.Id = id;
            await Mediator.Send(cmd);

            return NoContent();
        }
    }
}
