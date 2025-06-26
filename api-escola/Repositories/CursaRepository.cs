using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class CursaRepository : ICursaRepository
    {
        private readonly ProjetoP3Context _context;

        public CursaRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Cursa? BuscarCursa(ulong idAluno, ulong idDisciplina)
        {
            return _context.Set<Cursa>().FirstOrDefault(c => c.IdAluno == idAluno && c.IdDisciplina == idDisciplina);
        }

        public void CriarCursa(Cursa cursa)
        {
            _context.Cursas.Add(cursa);
            _context.SaveChanges();
        }

        public void DeletarCursa(Cursa cursa)
        {
            _context.Cursas.Remove(cursa);
            _context.SaveChanges();
        }

        public void EditarCursa(Cursa cursa)
        {
            _context.Cursas.Update(cursa);
            _context.SaveChanges();
        }

        public List<Cursa> ListarCursa()
        {
            return _context.Cursas.ToList();
        }
    }
}
