using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand>
    {
        private readonly IShopDbContext _context;
        public DeleteProductCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) { throw new NotFoundException(nameof(Product), request.Id); }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
