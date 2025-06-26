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
            CreateMap<Professor, ProfessorDtoResponse>();
            CreateMap<Titulo, TituloDtoResponse>();
            CreateMap<Instituicao, InstituicaoDtoResponse>();
            CreateMap<TipoCurso,TipoCursoDtoResponse>();
            CreateMap<TipoDisciplina,TipoDisciplinaDtoResponse>();
            CreateMap<Curso, CursoDtoResponse>();
            CreateMap<Disciplina, DisciplinaDtoResponse>();
            CreateMap<Cursa, CursaDtoResponse>();
            CreateMap<Leciona, LecionaDtoResponse>();

            //DtoRequest para entidade
            CreateMap<AlunoDtoRequest, Aluno>();
            CreateMap<ProfessorDtoRequest, Professor>();
            CreateMap<TituloDtoRequest, Titulo>();
            CreateMap<InstituicaoDtoRequest, Instituicao>();
            CreateMap<TipoCursoDtoRequest, TipoCurso>();
            CreateMap<TipoDisciplinaDtoRequest,  TipoDisciplina>();
            CreateMap<CursoDtoRequest, Curso>();
            CreateMap<DisciplinaDtoRequest, Disciplina>();
            CreateMap<CursaDtoRequest, Cursa>();
            CreateMap<LecionaDtoRequest, Leciona>();
        }
    }
}
