using api_escola.Models;
using api_escola.Repositories.IRepositories;

namespace api_escola.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly ProjetoP3Context _context;

        public InstituicaoRepository(ProjetoP3Context context)
        {
            _context = context;
        }

        public Instituicao? BuscarInstituicao(ulong id)
        {
            return _context.Instituicaos.FirstOrDefault(i => i.IdInstituicao == id);
        }

        public void CriarInstituicao(Instituicao instituicao)
        {
            _context.Instituicaos.Add(instituicao);
            _context.SaveChanges();
        }

        public void DeletarInstituicao(Instituicao instituicao)
        {
            _context.Instituicaos.Remove(instituicao);
            _context.SaveChanges();
        }

        public void EditarInstituicao(Instituicao instituicao)
        {
            _context.Instituicaos.Update(instituicao);
            _context.SaveChanges();
        }

        public List<Instituicao> ListarInstituicoes()
        {
            return _context.Instituicaos.ToList();
        }
    }
}
