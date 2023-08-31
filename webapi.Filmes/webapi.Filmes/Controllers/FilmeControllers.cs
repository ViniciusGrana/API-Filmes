using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;
using webapi.Filmes.Repositories;


namespace webapi.Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    //metodo controlador que herda da controller base
    //Onde será criando os Endpoints (rotas)

    public class FilmeController : ControllerBase
    {

        private IFilmeRepository _filmeRepository { get; set; }


        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<FilmeDomain> listaGeneros = _filmeRepository.ListarTodos();
                return Ok(listaGeneros);


            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _filmeRepository.Cadastrar(novoFilme);
                //Retorna um status code 201 - created 
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400(BadRequest) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscadoId(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum filme foi encontrado!");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        [HttpPut]
        public IActionResult AtualizarIdUrl(int id, FilmeDomain Filme)
        {
            try
            {
                _filmeRepository.AtualizarIdUrl(id, Filme);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarIdCorpo(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);
                if (filmeBuscado == null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);

                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Genero não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }



    }
}
