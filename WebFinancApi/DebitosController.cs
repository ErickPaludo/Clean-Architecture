using Financ.Application.DTOs;
using Financ.Application.DTOs.Input;
using Financ.Application.Interfaces.Repository.UnitOfWork;
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
        private readonly IUnitOfWork _unit;

        private readonly UserManager<ApplicationUser> _userManager;


        public DebitosController(IUnitOfWork unit, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _unit = unit;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult> CadastraDebito([FromBody] DebInDTO debito)
        {
            //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
            //   debito.UserId = user!.Id;
            Debito deb = (Debito)debito;
            _unit.DebitoRepository.Create(deb);
            _unit.Commit();
            // _gerenciamento.RegistraDebito(debito);
            return Ok();
        }
    }
}
