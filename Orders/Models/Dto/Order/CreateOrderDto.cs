using AutoMapper;
using Orders.Mapping;
using Orders.Models.Dto.Product;
using Orders.Orders.Commands.CreateOrder;
using Orders.Products.Commands.CreateProduct;

namespace Orders.Models.Dto.Order
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public List<Guid> ProductIds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(dst => dst.ProductIds, opt => opt.MapFrom(src => src.ProductIds));
        }
    }
}
