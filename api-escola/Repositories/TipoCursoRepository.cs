using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class TipoCursoRepository : ITipoCursoRepository
    {
        private readonly ProjetoP3Context _context;

        public TipoCursoRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public TipoCurso? BuscarTipoCurso(ulong id)
        {
            return _context.Set<TipoCurso>().FirstOrDefault(t => t.IdTipoCurso == id);
        }

        public void CriarTipoCurso(TipoCurso tipoCurso)
        {
            _context.TipoCursos.Add(tipoCurso);
            _context.SaveChanges();
        }

        public void DeletarTipoCurso(TipoCurso tipoCurso)
        {
            _context.TipoCursos.Remove(tipoCurso);
            _context.SaveChanges();
        }

        public void EditarTipoCurso(TipoCurso tipoCurso)
        {
            _context.TipoCursos.Update(tipoCurso);
            _context.SaveChanges();
        }

        public List<TipoCurso> ListarTiposCurso()
        {
            return _context.TipoCursos.ToList();
        }
    }
}
