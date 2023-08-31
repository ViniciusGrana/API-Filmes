using webapi.Filmes.Domains;

namespace webapi.Filmes.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(FilmeDomain novoFilme);
        List<FilmeDomain> ListarTodos();
        void AtualizarIdCorpo(FilmeDomain filme);
        void AtualizarIdUrl(int id, FilmeDomain filme);
        void Deletar(int id);
        FilmeDomain BuscarPorId(int id);
    }
}
