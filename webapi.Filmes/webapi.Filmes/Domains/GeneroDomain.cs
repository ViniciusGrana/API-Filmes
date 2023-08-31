using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.Domains
{
    /// <summary>
    /// Classe que representa entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O genero do filme e obrigatorio")]
        public string Nome { get; set; }

    }
}
