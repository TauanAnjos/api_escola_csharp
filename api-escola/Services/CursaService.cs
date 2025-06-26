using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class CursaService : ICursaService
    {
        private readonly ICursaRepository _cursaRepository;
        private readonly IMapper _mapper;

        public CursaService(ICursaRepository cursaRepository, IMapper mapper)
        {
            _cursaRepository = cursaRepository;
            _mapper = mapper;
        }

        public CursaDtoResponse BuscarCursa(ulong idAluno, ulong idDiciplina)
        {
            var cursa = _cursaRepository.BuscarCursa(idAluno, idDiciplina);
            if (cursa == null)
            {
                throw new KeyNotFoundException("Vinculo de curso não encontrado");
            }
            return _mapper.Map<CursaDtoResponse>(cursa);
        }

        public void CriarCursa(CursaDtoRequest cursaDtoRequest)
        {
            if(cursaDtoRequest == null) 
            {
                throw new ArgumentNullException("Dados de vinculo de curso são obrigatorios."); 
            }
            var cursa = _mapper.Map<Cursa>(cursaDtoRequest);
            _cursaRepository.CriarCursa(cursa);
        }

        public void DeletarCursa(ulong idAluno, ulong idDisciplina)
        {
            var cursa = _cursaRepository.BuscarCursa(idAluno, idDisciplina);
            if(cursa == null) 
            {
                throw new KeyNotFoundException("Vinculo de curso não encontrado.");
            }
            _cursaRepository.DeletarCursa(cursa);
        }

        public void EditarCursa(ulong idAluno, ulong idDisciplina, CursaDtoRequest cursaDtoRequest)
        {
            var cursa = _cursaRepository.BuscarCursa(idAluno, idDisciplina);
            if (cursa == null)
            {
                throw new KeyNotFoundException("Vinculo de curso não encontrado.");
            }
            _mapper.Map(cursaDtoRequest, cursa);
            _cursaRepository.EditarCursa(cursa);
        }

        public List<CursaDtoResponse> ListarCursa()
        {
            var cursas = _cursaRepository.ListarCursa();

            var cursasDto = _mapper.Map<List<CursaDtoResponse>>(cursas);
            return cursasDto;
        }
    }
}
