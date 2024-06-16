using MediatR;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;
using Orders.Models.Dto;

namespace Orders.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IShopDbContext _context;

        public CreateOrderCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var productId in request.ProductIds)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), productId);
                }

                order.OrderProducts.Add(new OrderProduct
                {
                    Product = product,
                    Order = order
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);


            return order.Id;
        }
    }
}
