using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class TipoDisciplinaService : ITipoDisciplinaService
    {
        private readonly ITipoDisciplinaRepository _tipoDisciplinaRepository;
        private readonly IMapper _mapper;

        public TipoDisciplinaService(ITipoDisciplinaRepository tipoDisciplinaRepository, IMapper mapper)
        {
            _tipoDisciplinaRepository = tipoDisciplinaRepository;
            _mapper = mapper;
        }

        public TipoDisciplinaDtoResponse BuscarTipoDisciplina(ulong id)
        {
            var tipo = _tipoDisciplinaRepository.BuscarTipoDisciplina(id);
            if (tipo == null)
            {
                throw new KeyNotFoundException("TipoDisciplina de ID: " + id + " não encontrado");
            }
            return _mapper.Map<TipoDisciplinaDtoResponse>(tipo);
        }

        public void CriarTipoDisciplina(TipoDisciplinaDtoRequest tipoDisciplinaDtoRequest)
        {
            if (tipoDisciplinaDtoRequest == null)
            {
                throw new ArgumentNullException("Dados do TipoDisciplina são obrigatórios");
            }
            var tipoDisciplina = _mapper.Map<TipoDisciplina>(tipoDisciplinaDtoRequest);
            _tipoDisciplinaRepository.CriarTipoDisciplina(tipoDisciplina);
        }

        public void DeletarTipoDisciplina(ulong id)
        {
            var tipo = _tipoDisciplinaRepository.BuscarTipoDisciplina(id);
            if (tipo == null)
            {
                throw new KeyNotFoundException("TipoDisciplina de ID: " + id + " não encontrado");
            }
            _tipoDisciplinaRepository.DeletarTipoDisciplina(tipo);
        }

        public void EditarTipoDisciplina(ulong id, TipoDisciplinaDtoRequest tipoDisciplinaDtoRequest)
        {
            var tipo = _tipoDisciplinaRepository.BuscarTipoDisciplina(id);
            if (tipo == null)
            {
                throw new KeyNotFoundException("TipoDisciplina de ID: " + id + " não encontrado");
            }
            _mapper.Map(tipoDisciplinaDtoRequest, tipo);
            _tipoDisciplinaRepository.EditarTipoDisciplina(tipo);
        }

        public List<TipoDisciplinaDtoResponse> ListarTiposDisciplina()
        {
            var tipos = _tipoDisciplinaRepository.ListarTiposDisciplina();
            return _mapper.Map<List<TipoDisciplinaDtoResponse>>(tipos);
        }
    }
}
