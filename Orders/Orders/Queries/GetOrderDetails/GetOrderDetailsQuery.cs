using MediatR;
using Orders.Models;

namespace Orders.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
