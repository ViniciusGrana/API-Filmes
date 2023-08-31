using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O titulo do filme e obrigatorio")]
        public string? Titulo { get; set; }
        public int IdGenero { get; set; }

        public GeneroDomain? Genero { get; set; }
}
}
