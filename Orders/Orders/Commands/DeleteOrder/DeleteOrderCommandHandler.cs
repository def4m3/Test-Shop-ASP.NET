using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;
using Orders.Products.Commands.DeleteProduct;

namespace Orders.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IShopDbContext _context;
        public DeleteOrderCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefaultAsync(o => o.Id == request.Id);

            if (entity == null) { throw new NotFoundException(nameof(Product), request.Id); }

            _context.OrderProducts.RemoveRange(entity.OrderProducts);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
