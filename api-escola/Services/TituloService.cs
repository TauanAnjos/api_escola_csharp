using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;

namespace api_escola.Services
{
    public class TituloService : ITituloService
    {
        private readonly ITituloRepository _tituloRepository;
        private readonly IMapper _mapper;

        public TituloService(ITituloRepository tituloRepository, IMapper mapper)
        {
            _tituloRepository = tituloRepository;
            _mapper = mapper;
        }

        public TituloDtoResponse BuscarTitulo(ulong id)
        {
            var titulo = _tituloRepository.BuscarTitulo(id);
            if (titulo == null)
            {
                throw new KeyNotFoundException("Título de ID: " + id + " não encontrado");
            }
            return _mapper.Map<TituloDtoResponse>(titulo);
        }

        public void CriarTitulo(TituloDtoRequest tituloDtoRequest)
        {
            if (tituloDtoRequest == null)
            {
                throw new ArgumentNullException("Dados do título são obrigatórios");
            }
            var titulo = _mapper.Map<Titulo>(tituloDtoRequest);
            _tituloRepository.CriarTitulo(titulo);
        }

        public void DeletarTitulo(ulong id)
        {
            var titulo = _tituloRepository.BuscarTitulo(id);
            if (titulo == null)
            {
                throw new KeyNotFoundException("Título de ID: " + id + " não encontrado");
            }
            _tituloRepository.DeletarTitulo(titulo);
        }

        public void EditarTitulo(ulong id, TituloDtoRequest tituloDtoRequest)
        {
            var titulo = _tituloRepository.BuscarTitulo(id);
            if (titulo == null)
            {
                throw new KeyNotFoundException("Título de ID: " + id + " não encontrado");
            }
            _mapper.Map(tituloDtoRequest, titulo);
            _tituloRepository.EditarTitulo(titulo);
        }

        public List<TituloDtoResponse> ListarTitulos()
        {
            var titulos = _tituloRepository.ListarTitulos();
            return _mapper.Map<List<TituloDtoResponse>>(titulos);
        }
    }
}
