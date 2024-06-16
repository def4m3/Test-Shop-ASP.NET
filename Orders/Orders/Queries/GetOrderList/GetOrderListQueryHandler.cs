using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery,List<Order>>
    {
        private readonly IShopDbContext _context;
        public GetOrderListQueryHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderProducts) 
                .ThenInclude(op => op.Product) 
                .ToListAsync();

            return orders;
        }
    }
}
