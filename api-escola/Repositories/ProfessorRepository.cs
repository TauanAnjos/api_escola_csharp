using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ProjetoP3Context _context;

        public ProfessorRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Professor? BuscarProfessor(ulong id)
        {
            return _context.Set<Professor>().FirstOrDefault(p => p.IdProfessor == id);
        }

        public void CriarProfessor(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
        }

        public void DeleteProfessor(Professor professor)
        {
           _context.Remove(professor);
            _context.SaveChanges();
        }

        public void EditarProfessor(Professor professor)
        {
            _context.Professors.Update(professor);
        }

        public List<Professor> ListarProfessores()
        {
            return _context.Professors.ToList();
        }
    }
}
