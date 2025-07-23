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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICriaDebUseCase _criaDebUseCase;
        private readonly IRetornaDebUseCase _retornaDebUseCase;
        public DebitosController(UserManager<ApplicationUser> userManager, ICriaDebUseCase criaDebUseCase, IRetornaDebUseCase retornaDebUseCase)
        {
            _userManager = userManager;
            _criaDebUseCase = criaDebUseCase;
            _retornaDebUseCase = retornaDebUseCase;
        }

        [HttpPost("cadastro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CadastraDebito([FromBody] DebitoInputDTO debito)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            DebitoOutputDTO debitoOutDto = await _criaDebUseCase.CriarDebitoAsync((CriaDebCommand)debito);
            return Created(string.Empty, debitoOutDto);
            #region entity framework
            //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
            //   debito.UserId = user!.Id;
            #endregion
        }
        [HttpPost("retorno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDebito()
        {
            var listDebito = _retornaDebUseCase.RetornaDebitos().Result.ToList();
            return Ok(listDebito.ToList());
            #region entity framework
            //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
            //   debito.UserId = user!.Id;
            #endregion
        }
    }
}
