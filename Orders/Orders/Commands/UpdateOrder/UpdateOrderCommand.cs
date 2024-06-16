using MediatR;
using Orders.Models;

namespace Orders.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }

        public ICollection<Guid> ProductIds { get; set; }
    }
}
