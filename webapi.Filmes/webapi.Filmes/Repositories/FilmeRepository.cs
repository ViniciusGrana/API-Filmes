using System.Data.SqlClient;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;

namespace webapi.Filmes.Repositories
{

    public class FilmeRepository : IFilmeRepository 
    {
        private string StringConexao = "Data Source = DESKTOP-ONQ7S9F; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "Filme SET Titulo = @Titulo WHERE IdFilme = @IdFilme";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizeIdByUrl = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @IdFilme";


                using (SqlCommand cmd = new SqlCommand(queryAtualizeIdByUrl, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("Titulo", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = $"SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                //Abre a conexão com o banco de dados
                con.Open();

                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("IdFilme", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdFilme"]),

                            Titulo = rdr["Titulo"].ToString()

                        };
                        return filmeBuscado;
                    }
                    return null;

                }

            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(IdGenero,Titulo) VALUES (@IdGenero,@Titulo)";
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    //Abre a conexão com o banco de dados

                    //executar a query (queryInsert)
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parametro @Id
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executar a query (queryDelete)
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Filme.IdFilme, Filme.IdGenero, Filme.Titulo, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmeDomain Filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]), 

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain() 
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }


                        };
                        ListaFilme.Add(Filme);
                    }
                }
            }
            return ListaFilme;
        }
    }
}

