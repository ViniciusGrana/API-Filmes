using webapi.Filmes.Domains;

namespace webapi.Filmes.Interfaces
{
    /// <summary>
    /// Interface Responsavel pelo repostitorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipodeRetorno NomeMetodo(tipoParametro nomeParametro)
        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"></param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar tdos os objetos cadastrados 
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando seu id pelo corpo da requisicao 
        /// </summary>
        /// <param name="genero">Objeto atualizado (novas informacoes)</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto existente passando seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="Genero">Objeto atualizado (novas informacoes)</param>
        void AtualizarIdUrl(int id, GeneroDomain Genero);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Buscar objeto atraves do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto bsucado</returns>
        GeneroDomain BuscarPorId(int id);
     
    }
}
