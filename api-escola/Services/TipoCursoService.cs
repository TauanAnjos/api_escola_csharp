using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class TipoCursoService : ITipoCursoService
    {
        private readonly ITipoCursoRepository _tipoCursoRepository;
        private readonly IMapper _mapper;

        public TipoCursoService(ITipoCursoRepository tipoCursoRepository, IMapper mapper)
        {
            _tipoCursoRepository = tipoCursoRepository;
            _mapper = mapper;
        }

        public TipoCursoDtoResponse BuscarTipoCurso(ulong id)
        {
            var tipoCurso = _tipoCursoRepository.BuscarTipoCurso(id);
            if (tipoCurso == null)
            {
                throw new KeyNotFoundException("TipoCurso de ID: " + id + " não encontrado");
            }
            return _mapper.Map<TipoCursoDtoResponse>(tipoCurso);
        }

        public void CriarTipoCurso(TipoCursoDtoRequest tipoCursoDtoRequest)
        {
            if (tipoCursoDtoRequest == null)
            {
                throw new ArgumentNullException("Dados do TipoCurso são obrigatórios");
            }
            var tipoCurso = _mapper.Map<TipoCurso>(tipoCursoDtoRequest);
            _tipoCursoRepository.CriarTipoCurso(tipoCurso);
        }

        public void DeletarTipoCurso(ulong id)
        {
            var tipoCurso = _tipoCursoRepository.BuscarTipoCurso(id);
            if (tipoCurso == null)
            {
                throw new KeyNotFoundException("TipoCurso de ID: " + id + " não encontrado");
            }
            _tipoCursoRepository.DeletarTipoCurso(tipoCurso);
        }

        public void EditarTipoCurso(ulong id, TipoCursoDtoRequest tipoCursoDtoRequest)
        {
            var tipoCurso = _tipoCursoRepository.BuscarTipoCurso(id);
            if (tipoCurso == null)
            {
                throw new KeyNotFoundException("TipoCurso de ID: " + id + " não encontrado");
            }
            _mapper.Map(tipoCursoDtoRequest, tipoCurso);
            _tipoCursoRepository.EditarTipoCurso(tipoCurso);
        }

        public List<TipoCursoDtoResponse> ListarTiposCurso()
        {
            var tiposCurso = _tipoCursoRepository.ListarTiposCurso();
            return _mapper.Map<List<TipoCursoDtoResponse>>(tiposCurso);
        }
    }
}
