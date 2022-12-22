using ApiService.Mapping.DTOs;
using ApiService.Mapping.Models;
using AutoMapper;

namespace ApiService.Mapping
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            ///<summary>Convert Entity from Persistance Store (db) to DTO Request Web API </summary>
            // db.model -> deploy.api.dto
            CreateMap<UserModel, UserDto>()
                .ForMember(dest => dest.Id, 
                    opt =>opt.MapFrom(src => src.Id_Usuario))
                .ForMember(dest => dest.UserName, 
                    opt => opt.MapFrom(src => src.Nombre_Usuario))
                .ForMember(dest => dest.IsSuperAdmin, 
                    opt => opt.MapFrom(src => src.Super_Admin))
                .ForMember(dest => dest.Active, 
                    opt => opt.MapFrom(src => src.Estado));

            /// <summary>Convert Entity properties from Web Response to Save Persistance Store (db) </summary>
            //deploy.api.dto ->  db.model 
            CreateMap<UserDto, UserModel>();

            CreateMap<PersonModel, PersonDto>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.Cui));

            CreateMap<PersonDto, PersonModel>();
        }
    }
}
