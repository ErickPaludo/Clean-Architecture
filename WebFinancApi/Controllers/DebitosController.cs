using Financ.Application.DTOs;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Debito;
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
        public DebitosController(UserManager<ApplicationUser> userManager, ICriaDebUseCase criaDebUseCase)
        {
            _userManager = userManager;
            _criaDebUseCase = criaDebUseCase;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> CadastraDebito([FromBody] CriaDebCommand debito)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
            //   debito.UserId = user!.Id;
            var processado = await _criaDebUseCase.CriaDeb(debito);
            // _gerenciamento.RegistraDebito(debito);
            return Ok(processado);
        }
    }
}
