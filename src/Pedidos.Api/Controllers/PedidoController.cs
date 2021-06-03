using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Command.Commands.CriarPedido;
using Pedidos.Domain.Command.Commands.DeletarPedido;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Query.Queries.ObterPedidoPorCodigo;
using Pedidos.Domain.Query.Queries.ObterPedidos;
using System.Threading.Tasks;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PedidoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtem todos os pedidos
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult<ObterPedidosQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new ObterPedidosQuery());

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtem pedido por codigo
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult<ObterPedidoPorCodigoQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> GetById(string codigo)
        {
            var result = await _mediator.Send(new ObterPedidoPorCodigoQuery(codigo));

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Insere pedido
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult<CriarPedidoCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> Post([FromBody] CriarPedidoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);

        }

        /// <summary>
        /// Atualiza pedido (item/pedido)
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult<AtualizarPedidoCommandResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> Put([FromBody] AtualizarPedidoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Exclui pedido
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> Delete(string codigo)
        {
            var result = await _mediator.Send(new DeletarPedidoCommand(codigo));

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
