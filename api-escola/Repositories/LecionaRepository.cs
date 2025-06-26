using api_escola.Models;
using api_escola.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace api_escola.Repositories
{
    public class LecionaRepository : ILecionaRepository
    {
        private readonly ProjetoP3Context _context;

        public LecionaRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Leciona? BuscarLeciona(ulong idProfessor, ulong idDisciplina)
        {
            return _context.Set<Leciona>().FirstOrDefault(l => l.IdProfessor == idProfessor && l.IdDisciplina == idDisciplina);
        }

        public void CadastrarLeciona(Leciona leciona)
        {
            _context.Set<Leciona>().Add(leciona);
            _context.SaveChanges();
        }

        public void DeletarLeciona(Leciona leciona)
        {
            _context.Set<Leciona>().Remove(leciona);
            _context.SaveChanges();
        }

        public void EditarLeciona(Leciona leciona)
        {
            _context.Set<Leciona>().Update(leciona);
            _context.SaveChanges();
        }

        public List<Leciona> ListarLecionas()
        {
            return _context.Set<Leciona>().ToList();
        }
    }
}
