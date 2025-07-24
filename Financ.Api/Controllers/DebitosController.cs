using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
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
                DebitoOutputDTO debitoOutDto = await _criaDebUseCase.CriarDebitoAsync((CriaDebCommand)debito);
                return Created(string.Empty, new HeaderResponseDTO<DebitoOutputDTO>
                {
                    IdBanco = debito.IdBanco,
                    Message = "Sucess",
                    Response = debitoOutDto
                });
    
        }
        [HttpPost("retorno")]
        [ProducesResponseType(typeof(HeaderResponseDTO<List<DebitoOutputDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDebito()
        {
            var listDebito = await _retornaDebUseCase.RetornaDebitos();
            if (listDebito is not null && listDebito?.Response?.Any() == true)
                return Ok(listDebito);
            return NotFound();
        }
        #region entity framework
        //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
        //   debito.UserId = user!.Id;
        #endregion
    }
}
