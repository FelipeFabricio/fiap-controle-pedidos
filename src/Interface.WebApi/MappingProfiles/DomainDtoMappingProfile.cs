using AutoMapper;

namespace Interface.WebApi.MappingProfiles;

public class DomainDtoMappingProfile : Profile
{
    public DomainDtoMappingProfile()
    {
        CreateMap<Core.Entities.Produto, Application.Dtos.ProdutoDto>()
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.ToString()))
            .ReverseMap();
        CreateMap<Core.Entities.Pedido, Application.Dtos.PedidoDto>().ReverseMap();
        CreateMap<Core.Entities.ItemPedido, Application.Dtos.ItemPedidoDto>().ReverseMap();
        CreateMap<Core.Entities.Cliente, Application.Dtos.ClienteDto>().ReverseMap();
    }
}