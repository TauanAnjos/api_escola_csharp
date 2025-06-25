using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository professorRepository, IMapper mapper)
        {
            _professorRepository = professorRepository;
            _mapper = mapper;
        }

        public ProfessorDtoResponse BuscarProfessor(ulong id)
        {
            var professor = _professorRepository.BuscarProfessor(id);
            if (professor == null)
            {
                throw new KeyNotFoundException("Professor de ID: " + id + " não encontrado");
            }
            return _mapper.Map<ProfessorDtoResponse>(professor);
        }

        public void CriarProfessor(ProfessorDtoRequest professorDtoRequest)
        {
            if (professorDtoRequest == null) 
            {
                throw new ArgumentNullException("Dados do professor são obrigatorios");
            }
            var professor = _mapper.Map<Professor>(professorDtoRequest);
            _professorRepository.CriarProfessor(professor);
        }

        public void DeletarProfessor(ulong id)
        {
            var professor = _professorRepository.BuscarProfessor(id);
            if(professor == null) 
            {
                throw new KeyNotFoundException("Professor de ID: " + id + " não encontrado");
            }
            _professorRepository.DeleteProfessor(professor);
        }

        public void EditarProfessor(ulong id, ProfessorDtoRequest professorDtoRequest)
        {
            var professor = _professorRepository.BuscarProfessor(id);
            if (professor == null)
            {
                throw new KeyNotFoundException("Professor de ID: " + id + " não encontrado");
            }
            _mapper.Map(professorDtoRequest, professor);
            _professorRepository.EditarProfessor(professor);
        }

        public List<ProfessorDtoResponse> ListarProfessores()
        {
            var professores = _professorRepository.ListarProfessores();

            var professoresDto = _mapper.Map<List<ProfessorDtoResponse>>(professores);
            return professoresDto;
        }
    }
}
