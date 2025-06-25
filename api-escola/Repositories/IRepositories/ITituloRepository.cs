using api_escola.Models;

namespace api_escola.Repositories.IRepositories
{
    public interface ITituloRepository
    {
        void CriarTitulo(Titulo titulo);
        void EditarTitulo(Titulo titulo);
        Titulo? BuscarTitulo(ulong id);
        List<Titulo> ListarTitulos();
        void DeletarTitulo(Titulo titulo);
    }
}
