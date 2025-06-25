using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class TipoDisciplinaRepository : ITipoDisciplinaRepository
    {
        private readonly ProjetoP3Context _context;

        public TipoDisciplinaRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public TipoDisciplina? BuscarTipoDisciplina(ulong id)
        {
            return _context.Set<TipoDisciplina>().FirstOrDefault(t => t.IdTipoDisciplina == id);
        }

        public void CriarTipoDisciplina(TipoDisciplina tipoDisciplina)
        {
            _context.TipoDisciplinas.Add(tipoDisciplina);
            _context.SaveChanges();
        }

        public void DeletarTipoDisciplina(TipoDisciplina tipoDisciplina)
        {
            _context.TipoDisciplinas.Remove(tipoDisciplina);
            _context.SaveChanges();
        }

        public void EditarTipoDisciplina(TipoDisciplina tipoDisciplina)
        {
            _context.TipoDisciplinas.Update(tipoDisciplina);
            _context.SaveChanges();
        }

        public List<TipoDisciplina> ListarTiposDisciplina()
        {
            return _context.TipoDisciplinas.ToList();
        }
    }
}
