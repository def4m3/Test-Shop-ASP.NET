using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IShopDbContext _context;
        public UpdateOrderCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == request.Id);

            if (order == null) { throw new NotFoundException(nameof(Product), request.Id); }

            var existingOrderProducts = order.OrderProducts.ToList();
            foreach (var orderProduct in existingOrderProducts)
            {
                _context.OrderProducts.Remove(orderProduct);
            }

            foreach (var productId in request.ProductIds)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                order.OrderProducts.Add(new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = productId
                });
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
