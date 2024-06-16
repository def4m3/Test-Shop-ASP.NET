using MediatR;

namespace Orders.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public List<Guid> ProductIds { get; set; }
    }
}
