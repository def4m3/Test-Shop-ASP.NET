using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Exceptions;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler
        : IRequestHandler<GetProductDetailsQuery, Product>
    {
        public readonly IShopDbContext _context;

        public GetProductDetailsQueryHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) { throw new NotFoundException(nameof(Product), request.Id); }

            return entity;
        }
    }
}
