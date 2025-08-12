using Financ.Application.DTOs;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financ.Api.Controllers
{
    [Route("api/financ")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly ICreateBankUseCase _createBankUseCase;

        public AcountController(ICreateBankUseCase createBankUseCase)
        {
            _createBankUseCase = createBankUseCase;
        }

        [HttpPost("registerBank")]
        [ProducesResponseType(typeof(TransectionOutputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] BankInputDTO bank)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CommandBank(bank,"0");
            var entity = await _createBankUseCase.Create(command);
            if (entity != null)
                return Created(string.Empty,entity);
            return BadRequest();
        }
    }
}
