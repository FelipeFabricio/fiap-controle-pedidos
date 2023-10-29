using AutoMapper;

namespace Infra.Database.MySql.MappingProfiles;

public class DomainInfraMappingProfile : Profile
{
    public DomainInfraMappingProfile()
    {
        CreateMap<Core.Entities.Cliente, DataModels.Cliente>().ReverseMap();
        CreateMap<Core.Entities.Produto, DataModels.Produto>().ReverseMap()
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.ToString()));
        CreateMap<Core.Entities.Pedido, DataModels.Pedido>().ReverseMap();
        CreateMap<Core.Entities.ItemPedido, DataModels.ItemPedido>().ReverseMap();
    }

}