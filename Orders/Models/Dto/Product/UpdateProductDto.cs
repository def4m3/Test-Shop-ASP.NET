using AutoMapper;
using Orders.Mapping;
using Orders.Products.Commands.UpdateProduct;

namespace Orders.Models.Dto.Product
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(dst => dst.Name,
                 opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description,
                 opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Id,
                 opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Price,
                 opt => opt.MapFrom(src => src.Price));
        }
    }
}
