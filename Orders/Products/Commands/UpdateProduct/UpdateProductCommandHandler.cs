using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;
using System.Threading;

namespace Orders.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IShopDbContext _context;

        public UpdateProductCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) { throw new NotFoundException(nameof(Product), request.Id); }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
