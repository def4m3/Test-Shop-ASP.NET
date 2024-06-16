using MediatR;
using Orders.Models;

namespace Orders.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<List<Product>>
    {
        
    }
}
