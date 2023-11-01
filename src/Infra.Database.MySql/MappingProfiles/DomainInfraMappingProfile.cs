using AutoMapper;
using Core.Enums;

namespace Infra.Database.MySql.MappingProfiles;

public class DomainInfraMappingProfile : Profile
{
    public DomainInfraMappingProfile()
    {
        CreateMap<CategoriaProduto, short>().ConvertUsing(source => (short)source);
        CreateMap<Core.Entities.Cliente, DataModels.Cliente>().ReverseMap();
        CreateMap<Core.Entities.Produto, DataModels.Produto>()
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria));
        CreateMap<DataModels.Produto, Core.Entities.Produto>()
            .ForMember((dest) => dest.Categoria, opt => opt.MapFrom(src => (CategoriaProduto)src.Categoria));
        CreateMap<Core.Entities.Pedido, DataModels.Pedido>().ReverseMap();
        CreateMap<Core.Entities.ItemPedido, DataModels.ItemPedido>().ReverseMap();
    }

}