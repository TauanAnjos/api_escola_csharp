using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AlunoDtoResponse BuscarAluno(ulong id)
        {
            var aluno = _repository.BuscarAluno(id);

            if (aluno == null)
            {
                throw new KeyNotFoundException("Aluno de ID: " + id + " não encontrado.");
            }
            return _mapper.Map<AlunoDtoResponse>(aluno);
        }

        public void CriarAluno(AlunoDtoRequest request)
        {
            if (request == null) 
            {
                throw new ArgumentNullException("Os dados do aluno são obrigatorios.");
            }
            var aluno = _mapper.Map<Aluno>(request);
            _repository.CadastrarAluno(aluno);
        }

        public void DeletarAluno(ulong id)
        {
            var aluno = _repository.BuscarAluno(id);

            if(aluno == null)
            {
                throw new KeyNotFoundException("Aluno de ID: " + id + " não encontrado.");
            }
            _repository.DeletarAluno(aluno);
        }

        public void EditarAluno(ulong id, AlunoDtoRequest request)
        {
            var aluno = _repository.BuscarAluno(id);

            if( aluno == null)
            {
                throw new KeyNotFoundException("Aluno de ID: " + id + " não encontrado.");
            }
            _mapper.Map(request, aluno);
            _repository.EditarAluno(aluno);
        }

        public List<AlunoDtoResponse> ListarAlunos()
        {
            var alunos = _repository.ListarAlunos();

            var alunosDto = _mapper.Map<List<AlunoDtoResponse>>(alunos);
            return alunosDto;
        }
    }
}
