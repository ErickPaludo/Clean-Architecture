using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Domain.Entities;
using Financ.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Financ.Api.Controllers
{
    [Route("api/debito")]
    [ApiController]
    public class DebitosController : ControllerBase
    {
        private readonly ICriaDebUseCase _criaDebUseCase;
        private readonly IRetornaDebUseCase _retornaDebUseCase;

        public DebitosController(ICriaDebUseCase criaDebUseCase, IRetornaDebUseCase retornaDebUseCase)
        {
            _criaDebUseCase = criaDebUseCase;
            _retornaDebUseCase = retornaDebUseCase;
        }

        [HttpPost("cadastro")]
        [ProducesResponseType(typeof(DebitoOutputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CadastraDebito([FromBody] DebitoInputDTO debito)
        {
            if (!ModelState.IsValid)
                return BadRequest();          
            Result<string> validaDebito = CriaDebCommand.Valida(debito);
            if (!validaDebito.IsSuccess)
            {
                return BadRequest(validaDebito);
            }
            Result<DebitoOutputDTO> debitoOutDto = await _criaDebUseCase.CriarDebitoAsync((CriaDebCommand)debito);
            if (debitoOutDto.IsSuccess)
                return Created(string.Empty, debitoOutDto);

            return BadRequest(debitoOutDto);
        }
        [HttpPost("retorno")]
        [ProducesResponseType(typeof(List<DebitoOutputDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDebito()
        {
            var listDebito = await _retornaDebUseCase.RetornaDebitos();
            if (listDebito is not null && listDebito?.Valeu?.Any() == true)
                return Ok(listDebito);
            return NotFound(listDebito);
        }
        #region entity framework
        //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
        //   debito.UserId = user!.Id;
        #endregion
    }
}
