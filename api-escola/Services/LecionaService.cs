using api_escola.Controllers.Dtos;
using api_escola.Models;
using api_escola.Repositories.IRepositories;
using api_escola.Services.IServices;
using AutoMapper;
using System.Collections.Generic;

namespace api_escola.Services
{
    public class LecionaService : ILecionaService
    {
        private readonly ILecionaRepository _repository;
        private readonly IMapper _mapper;

        public LecionaService(ILecionaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public LecionaDtoResponse BuscarLeciona(ulong idProfessor, ulong idDisciplina)
        {
            var leciona = _repository.BuscarLeciona(idProfessor, idDisciplina);

            if (leciona == null)
            {
                throw new KeyNotFoundException("Leciona com Professor ID " + idProfessor + " e Disciplina ID " + idDisciplina + " não encontrado.");
            }
            return _mapper.Map<LecionaDtoResponse>(leciona);
        }

        public void CriarLeciona(LecionaDtoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Os dados do Leciona são obrigatórios.");
            }

            var leciona = _mapper.Map<Leciona>(request);
            _repository.CadastrarLeciona(leciona);
        }

        public void DeletarLeciona(ulong idProfessor, ulong idDisciplina)
        {
            var leciona = _repository.BuscarLeciona(idProfessor, idDisciplina);

            if (leciona == null)
            {
                throw new KeyNotFoundException("Leciona com Professor ID " + idProfessor + " e Disciplina ID " + idDisciplina + " não encontrado.");
            }
            _repository.DeletarLeciona(leciona);
        }

        public void EditarLeciona(ulong idProfessor, ulong idDisciplina, LecionaDtoRequest request)
        {
            var leciona = _repository.BuscarLeciona(idProfessor, idDisciplina);

            if (leciona == null)
            {
                throw new KeyNotFoundException("Leciona com Professor ID " + idProfessor + " e Disciplina ID " + idDisciplina + " não encontrado.");
            }

            _mapper.Map(request, leciona);
            _repository.EditarLeciona(leciona);
        }

        public List<LecionaDtoResponse> ListarLecionas()
        {
            var lecionas = _repository.ListarLecionas();

            var lecionasDto = _mapper.Map<List<LecionaDtoResponse>>(lecionas);
            return lecionasDto;
        }
    }
}
