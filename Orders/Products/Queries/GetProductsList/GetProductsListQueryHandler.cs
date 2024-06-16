using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler
        : IRequestHandler<GetProductsListQuery, List<Product>>
    {
        private readonly IShopDbContext _context;
        public GetProductsListQueryHandler(IShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
    }
}
