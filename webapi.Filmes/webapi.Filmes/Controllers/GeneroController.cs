using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Domains;
using webapi.Filmes.Interfaces;
using webapi.Filmes.Repositories;

namespace webapi.filmes.Controllers
{
    //Define que a rota de uma requisição será no seguinte formtao
    //dominio/api/nomeController
    //ex: http://localhost:500/api/genero
    [Route("api/[controller]")]
	//define que é um controlador de API
	[ApiController]

	[Produces("application/json")]

	//metodo controlador que herda da controller base
	//Onde será criando os Endpoints (rotas)


	public class GeneroController : ControllerBase
	{
		//Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
		private IGeneroRepository _generoRepository { get; set; }

		//Instancia o objeto _generoRepository para que haja referencia aos métodos no repositório

		public GeneroController()
		{
			_generoRepository = new GeneroRepository();
		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				//Cria uma lista que recebe os dados da requisição
				List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();
				return Ok(listaGeneros);


			}
			catch (Exception erro)
			{
				//Retorna um status code BadRequest(400) e a mensagem do erro
				return BadRequest(erro.Message);
			}
		}

		[HttpPost]
		public IActionResult Post(GeneroDomain novoGenero)
		{
			try
			{
				//Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
				_generoRepository.Cadastrar(novoGenero);
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
				_generoRepository.Deletar(id);
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
				GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
				if(generoBuscado ==null)
				{
					return NotFound("Nenhum genero foi encontrado!");
				}
				
				return Ok(generoBuscado);
			}
			catch (Exception erro)
			{

                return BadRequest(erro.Message);
            }
		}

		[HttpPut]
		public IActionResult AtualizarIdUrl(int id, GeneroDomain Genero)
		{
			try
			{
				_generoRepository.AtualizarIdUrl(id, Genero);
                return Ok();
            }
			catch (Exception erro)
			{
                return BadRequest(erro.Message);
            }
		}
		[HttpPut("{id}")]
		public IActionResult AtualizarIdCorpo(GeneroDomain genero)
		{
			try
			{
				GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);
				if(generoBuscado ==null)
				{
					try
					{
						_generoRepository.AtualizarIdCorpo(genero);

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