using Agencia.Models;
using Agencia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoApiController : ControllerBase
    {
        private IDestinoService _destinoService;

        public DestinoApiController(IDestinoService destinoService)
        {
            _destinoService = destinoService;
        }

        //Buscar todos os destinos.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<IAsyncEnumerable<Destino>>> GetDestinos()
        {
            try
            {
                var destinos = await _destinoService.GetDestinos();
                return Ok(destinos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter destinos");
            }
        }

        //Busca por nome.
        [HttpGet("DestinoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Destino>>> GetDestinosByNome([FromQuery] string nome)
        {
            try
            {
                var destinos = await _destinoService.GetDestinosByNome(nome);

                if (destinos == null)
                    return NotFound($"Não existe destino com o nome: {nome}");

                return Ok(destinos);
            }
            catch
            {
                return BadRequest("Request inválido");
            }

        }

        //Buscar por Id.
        [HttpGet("{id:int}", Name="GetDestino")]
        public async Task<ActionResult<IAsyncEnumerable<Destino>>> GetDestino(int id)
        {
            try
            {
                var destino = await _destinoService.GetDestino(id);

                if (destino == null)
                    return NotFound($"Não existe destino com o id: {id}");

                return Ok(destino);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        //Criar 
        [HttpPost]
        public async Task<ActionResult> Create(Destino destino)
        {
            try
            {
                await _destinoService.CreateDestino(destino);
                return CreatedAtRoute(nameof(GetDestino), new {id=destino.Id}, destino);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        //Atualizar
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Destino destino)
        {
            try
            {
                if(destino.Id == id)
                {
                    await _destinoService.UpdateDestino(destino);
                    return Ok($"Destino com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        //Apagar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               var destino = await _destinoService.GetDestino(id);
                if(destino != null)
                {
                    await _destinoService.DeleteDestino(destino);
                    return Ok($"Destino com id={id} foi excluido com sucesso.");
                }
                else
                {
                    return NotFound($"Destino com id={id} não encontrado.");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }   
     }
}
