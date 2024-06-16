using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, Order>
    {
        public readonly IShopDbContext _context;

        public GetOrderDetailsQueryHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                 .Include(o => o.OrderProducts)
                 .ThenInclude(op => op.Product)
                 .FirstOrDefaultAsync(o => o.Id == request.Id);

            if (order == null) { throw new NotFoundException(nameof(Product), request.Id); }

            return order;
        }
    }
}
