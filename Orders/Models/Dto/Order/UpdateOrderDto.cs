using AutoMapper;
using Orders.Mapping;
using Orders.Orders.Commands.CreateOrder;
using Orders.Orders.Commands.UpdateOrder;

namespace Orders.Models.Dto.Order
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public List<Guid> ProductIds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(dst => dst.ProductIds, opt => opt.MapFrom(src => src.ProductIds));
        }
    }
}
