using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository, IMapper mapper)
        {
            _disciplinaRepository = disciplinaRepository;
            _mapper = mapper;
        }

        public DisciplinaDtoResponse BuscarDisciplina(ulong id)
        {
            var disciplina = _disciplinaRepository.BuscarDisciplina(id);
            if (disciplina == null)
            {
                throw new KeyNotFoundException("Disciplina de ID: " + id + " não encontrada");
            }
            return _mapper.Map<DisciplinaDtoResponse>(disciplina);
        }

        public void CriarDisciplina(DisciplinaDtoRequest disciplinaDtoRequest)
        {
            if (disciplinaDtoRequest == null)
            {
                throw new ArgumentNullException("Dados da disciplina são obrigatórios");
            }
            var disciplina = _mapper.Map<Disciplina>(disciplinaDtoRequest);
            _disciplinaRepository.CriarDisciplina(disciplina);
        }

        public void DeletarDisciplina(ulong id)
        {
            var disciplina = _disciplinaRepository.BuscarDisciplina(id);
            if (disciplina == null)
            {
                throw new KeyNotFoundException("Disciplina de ID: " + id + " não encontrada");
            }
            _disciplinaRepository.DeletarDisciplina(disciplina);
        }

        public void EditarDisciplina(ulong id, DisciplinaDtoRequest disciplinaDtoRequest)
        {
            var disciplina = _disciplinaRepository.BuscarDisciplina(id);
            if (disciplina == null)
            {
                throw new KeyNotFoundException("Disciplina de ID: " + id + " não encontrada");
            }
            _mapper.Map(disciplinaDtoRequest, disciplina);
            _disciplinaRepository.EditarDisciplina(disciplina);
        }

        public List<DisciplinaDtoResponse> ListarDisciplinas()
        {
            var disciplinas = _disciplinaRepository.ListarDisciplinas();
            return _mapper.Map<List<DisciplinaDtoResponse>>(disciplinas);
        }
    }
}
