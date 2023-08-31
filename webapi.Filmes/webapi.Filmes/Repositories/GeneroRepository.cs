using System.Data.SqlClient;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;

namespace webapi.Filmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com banco de dados que recebe os seguintes parametros
        /// Data Source : Nome do servidor 
        /// Initial Catalog : Nome do banco de dados
        /// Autenticacao:
        ///     -Windows : Integrated Security = true
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>

        private string StringConexao = "Data Source = DESKTOP-ONQ7S9F; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open(); 
                using(SqlCommand cmd = new SqlCommand(queryUpdateIdBody,con)) 
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain Genero)
        {
                using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizeIdByUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";


                using (SqlCommand cmd = new SqlCommand(queryAtualizeIdByUrl, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("Nome", Genero.Nome);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string querySelectById= $"SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                    //Abre a conexão com o banco de dados
                    con.Open();

                    SqlDataReader rdr;

       
                    using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                    {
                        cmd.Parameters.AddWithValue("IdGenero", id);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read()) 
                        {
                            GeneroDomain generoBuscado = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            };
                            return generoBuscado;
                        }
                        return null;
                            
                    }

                }
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con  = new SqlConnection(StringConexao))
            {
            string queryInsert =   "INSERT INTO Genero(Nome) VALUES (@Nome)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                       //Abre a conexão com o banco de dados
                    con.Open();

                    //executar a query (queryInsert)
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parametro @Id
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executar a query (queryDelete)
                    cmd.ExecuteNonQuery();

                }

            }
        }


        public List<GeneroDomain> ListarTodos()
        {
            //criar uma lista de objetos do tipo genero 
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();
            //Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection con =  new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con)) 
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read()) 
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };
                        ListaGeneros.Add(genero);
                    }
                }
            }
            return ListaGeneros;
        }
    }
}
