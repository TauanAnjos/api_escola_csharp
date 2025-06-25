using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        private readonly ProjetoP3Context _context;

        public TituloRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Titulo? BuscarTitulo(ulong id)
        {
            return _context.Set<Titulo>().FirstOrDefault(t => t.IdTitulo == id);
        }

        public void CriarTitulo(Titulo titulo)
        {
            _context.Titulos.Add(titulo);
            _context.SaveChanges();
        }

        public void DeletarTitulo(Titulo titulo)
        {
            _context.Titulos.Remove(titulo);
            _context.SaveChanges();
        }

        public void EditarTitulo(Titulo titulo)
        {
            _context.Titulos.Update(titulo);
            _context.SaveChanges();
        }

        public List<Titulo> ListarTitulos()
        {
            return _context.Titulos.ToList();
        }
    }
}
