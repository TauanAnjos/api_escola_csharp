using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        private readonly ProjetoP3Context _context;

        public Titulo? BuscarTitulo(ulong id)
        {
            throw new NotImplementedException();
        }

        public void CriarTitulo(Titulo titulo)
        {
            throw new NotImplementedException();
        }

        public void DeletarTitulo(Titulo titulo)
        {
            throw new NotImplementedException();
        }

        public void EditarTitulo(Titulo titulo)
        {
            throw new NotImplementedException();
        }

        public List<Titulo> ListarTitulos()
        {
            throw new NotImplementedException();
        }
    }
}
