using Financ.Application.DTOs;
using Financ.Application.Queries;
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
        private readonly IReturnBankUseCase _returnBankUseCase;

        public AcountController(ICreateBankUseCase createBankUseCase, IReturnBankUseCase returnBankUseCase)
        {
            _createBankUseCase = createBankUseCase;
            _returnBankUseCase = returnBankUseCase;
        }

        [HttpPost("registerBank")]
        [ProducesResponseType(typeof(BankInputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] BankInputDTO bank)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CommandBank(bank, "0");
            var entity = await _createBankUseCase.Create(command);
            if (entity != null)
                return Created(string.Empty, entity);
            return BadRequest();
        }
        [HttpGet("ReturnBank")]
        [ProducesResponseType(typeof(BankInputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get([FromQuery] BaseQuery search)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var listBank = await _returnBankUseCase.GetBanks("0", search);
            if (listBank != null)
                return Ok(listBank);
            return BadRequest();
        }
    }
}
