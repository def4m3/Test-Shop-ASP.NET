using MediatR;
using Orders.Models;

namespace Orders.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<Product>
    {
        public Guid Id { get; set; }

    }
}
