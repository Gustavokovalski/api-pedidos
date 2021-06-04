using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.Command.Commands.AtualizarPedido;
using Pedidos.Domain.Command.Result;
using Pedidos.Domain.Query.Queries.AtualizarStatus;
using System.Threading.Tasks;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class StatusController : ControllerBase
    {

        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Atualiza pedido (item/pedido)
        /// </summary>
        /// <response code="200">Retorno OK</response>
        /// <response code="400">Validation error</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationResult<AtualizarStatusQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApplicationResult<dynamic>))]
        public async Task<IActionResult> Put([FromBody] AtualizarStatusQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
