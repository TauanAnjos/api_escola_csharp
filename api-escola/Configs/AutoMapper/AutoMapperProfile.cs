using api_escola.Controllers.Dtos;
using api_escola.Models;
using AutoMapper;

namespace api_escola.Configs.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            //Entidade para DtoResponse
            CreateMap<Aluno, AlunoDtoResponse>();

            //DtoRequest para entidade
            CreateMap<AlunoDtoRequest, Aluno>();
        }
    }
}
