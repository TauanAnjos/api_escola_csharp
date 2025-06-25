using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ProjetoP3Context _context;

        public DisciplinaRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Disciplina? BuscarDisciplina(ulong id)
        {
            return _context.Set<Disciplina>().FirstOrDefault(d => d.IdDisciplina == id);
        }

        public void CriarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();
        }

        public void DeletarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();
        }

        public void EditarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            _context.SaveChanges();
        }

        public List<Disciplina> ListarDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }
    }
}
