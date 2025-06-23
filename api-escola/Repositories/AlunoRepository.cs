using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ProjetoP3Context _context;

        public AlunoRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Aluno? BuscarAluno(ulong id)
        {
            return _context.Set<Aluno>().FirstOrDefault(a => a.IdAluno == id);
        }

        public void CadastrarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public void DeletarAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno); 
            _context.SaveChanges();
        }

        public void EditarAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public List<Aluno> ListarAlunos()
        {
            return _context.Alunos.ToList();
        }
    }
}
