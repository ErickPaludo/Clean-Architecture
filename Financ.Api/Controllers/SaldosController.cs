using Financ.Application.DTOs;
using Financ.Application.Queries;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldosController : ControllerBase
    {
        private readonly ICreateUseCase<TransectionOutputDTO> _criaDebUseCase;
        private readonly IReturnUseCase<CreateTransectionCommand, Result<TransectionOutputDTO>> _retornaDebUseCase;

        public SaldosController(ICreateUseCase<TransectionOutputDTO> criaDebUseCase, IReturnUseCase<CreateTransectionCommand, Result<TransectionOutputDTO>> retornaDebUseCase)
        {
            _criaDebUseCase = criaDebUseCase;
            _retornaDebUseCase = retornaDebUseCase;
        }

        [HttpPost("cadastro")]
        [ProducesResponseType(typeof(TransectionOutputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CadastroSaldo([FromBody] TransectionInputDTO debito)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Result<string> validaDebito = CreateTransectionCommand.Valida(debito);
            if (!validaDebito.IsSuccess)
            {
                return BadRequest(validaDebito);
            }
            Result<TransectionOutputDTO> debitoOutDto = await _criaDebUseCase.CreateTransactionHandler((CreateTransectionCommand)debito);
            if (debitoOutDto.IsSuccess)
                return Created(string.Empty, debitoOutDto);

            return BadRequest(debitoOutDto);
        }

        [HttpPost("retorno")]
        [ProducesResponseType(typeof(List<TransectionOutputDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSaldo([FromQuery] int idBanco, [FromQuery] GetObjQuery search)
        {
            if (idBanco <= 0)
                return BadRequest(Result<Debito>.Failure("Id inválido!"));

            var listDebito = await _retornaDebUseCase.RetornarDebito(idBanco, search);
            if (listDebito.Valeu is not null)
                return Ok(listDebito);
            return NotFound(listDebito);
        }
    }
}
