using AutoMapper;
using NovaApi2.Data.Dto;
using NovaApi2.Models.Domain.Usuario;

namespace NovaApi2.Profiles
{

    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}