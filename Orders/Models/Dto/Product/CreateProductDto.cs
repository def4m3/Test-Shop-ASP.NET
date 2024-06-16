using AutoMapper;
using Orders.Mapping;
using Orders.Products.Commands.CreateProduct;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Dto.Product
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
