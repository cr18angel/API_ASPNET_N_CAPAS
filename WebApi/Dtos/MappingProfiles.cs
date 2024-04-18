using AutoMapper;
using Core.Entities;

namespace WebApi.Dtos
{
    public class MappingProfiles: Profile
    {

        public MappingProfiles() 
        {
            //CreateMap<ProductoVenta, ProductoDto>()
            //     .ForMember(x => x.MarcaRepuesto, p => p.MapFrom(a => a.MarcaRepuesto.NombreMarca));

            CreateMap<Producto, ProductoDto>()

                //#1 producto Dto                           //#2  aca es ya la propia entidad relacionada
                .ForMember(x => x.Marca, p => p.MapFrom(a => a.Marca.NombreMarca) );

        }
    }
}
