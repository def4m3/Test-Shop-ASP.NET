using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Models.Dto.Product;
using Orders.Products.Commands.CreateProduct;
using Orders.Products.Commands.DeleteProduct;
using Orders.Products.Commands.UpdateProduct;
using Orders.Products.Queries.GetProductDetails;
using Orders.Products.Queries.GetProductsList;

namespace Orders.Controllers
{
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var query = new GetProductsListQuery();
            var products = await Mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery();
            query.Id = id;

            var product = await Mediator.Send(query);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProductDto)
        {
            var cmd = _mapper.Map<CreateProductCommand>(createProductDto);
            var productId = await Mediator.Send(cmd);

            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var cmd = _mapper.Map<UpdateProductCommand>(updateProductDto);
            await Mediator.Send(cmd);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cmd = new DeleteProductCommand();
            cmd.Id = id;
            await Mediator.Send(cmd);

            return NoContent();
        }
    }
}
