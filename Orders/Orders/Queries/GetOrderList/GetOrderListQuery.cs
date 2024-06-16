using MediatR;
using Orders.Models;

namespace Orders.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<Order>>
    {

    }
}
