using MediatR;
using Orders.Interfaces;
using Orders.Models;

namespace Orders.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IShopDbContext _context;

        public CreateProductCommandHandler(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                
                Name = request.Name,

                Description = request.Description,

                Price = request.Price
            };

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }

    }
}
