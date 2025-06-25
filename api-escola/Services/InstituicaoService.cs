using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;
using System.Collections.Generic;

namespace api_escola.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _instituicaoRepository;
        private readonly IMapper _mapper;

        public InstituicaoService(IInstituicaoRepository instituicaoRepository, IMapper mapper)
        {
            _instituicaoRepository = instituicaoRepository;
            _mapper = mapper;
        }
        public InstituicaoDtoResponse BuscarInstituicao(ulong id)
        {
            var instituicao = _instituicaoRepository.BuscarInstituicao(id);
            if (instituicao == null)
                throw new KeyNotFoundException("Instituição de ID:" + id + "não encontrada");

            return _mapper.Map<InstituicaoDtoResponse>(instituicao);
        }

        public void CriarInstituicao(InstituicaoDtoRequest instituicaoDtoRequest)
        {
            if (instituicaoDtoRequest == null)
                throw new ArgumentNullException("Dados da instituição são obrigatórios");

            var instituicao = _mapper.Map<Instituicao>(instituicaoDtoRequest);
            _instituicaoRepository.CriarInstituicao(instituicao);
        }

        public void DeletarInstituicao(ulong id)
        {
            var instituicao = _instituicaoRepository.BuscarInstituicao(id);
            if (instituicao == null)
                throw new KeyNotFoundException("Instituição de ID:" + id + "não encontrada");

            _instituicaoRepository.DeletarInstituicao(instituicao);
        }

        public void EditarInstituicao(ulong id, InstituicaoDtoRequest instituicaoDtoRequest)
        {
            var instituicao = _instituicaoRepository.BuscarInstituicao(id);
            if (instituicao == null)
                throw new KeyNotFoundException("Instituição de ID:" + id + "não encontrada");

            _mapper.Map(instituicaoDtoRequest, instituicao);
            _instituicaoRepository.EditarInstituicao(instituicao);
        }

        public List<InstituicaoDtoResponse> ListarInstituicoes()
        {
            var instituicoes = _instituicaoRepository.ListarInstituicoes();
            return _mapper.Map<List<InstituicaoDtoResponse>>(instituicoes);
        }
    }
}
