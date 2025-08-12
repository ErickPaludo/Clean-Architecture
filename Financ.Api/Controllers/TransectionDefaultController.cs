using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Queries;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using Financ.Domain.Entities;
using Financ.Domain.Enums;
using Financ.Infrastructure.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Financ.Api.Controllers
{
    [Route("api/financ")]
    [ApiController]
    public class TransectionDefaultController : ControllerBase
    {
        private readonly ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> _createUseCase;
        private readonly IReturnUseCase<TransectionOutputDTO> _retornaDebUseCase;
        private readonly IReturnUseCase<TransectionOutputDTO> _retornaSaldoUseCase;


        public TransectionDefaultController(ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> createDebUseCase, IReturnUseCase<TransectionOutputDTO> retornaDebUseCase, IReturnUseCase<TransectionOutputDTO> retornasaldoUseCase)
        {
            _createUseCase = createDebUseCase;
            _retornaDebUseCase = retornaDebUseCase;
            _retornaSaldoUseCase = retornasaldoUseCase;
        }

        [HttpPost("registerTransection")]
        [ProducesResponseType(typeof(TransectionOutputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] BaseTransectionDTO<TransectionInputDTO> transection)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Result<TransectionOutputDTO>? objTranjection = null;

            Result<string> validaDebito = CreateTransectionCommand.Valida(transection);
            CreateTransectionCommand command = (CreateTransectionCommand)transection;

            if (!validaDebito.IsSuccess)
            {
                return BadRequest(validaDebito);
            }
            objTranjection = await _createUseCase.CreateTransactionHandler(command, transection.TypeTransection,"0");


            if (objTranjection != null && objTranjection.IsSuccess)
                return Created(string.Empty, objTranjection);

            return BadRequest(objTranjection);
        }

        [HttpGet("returnTransection/{type}/{idBanco:int}")]
        [ProducesResponseType(typeof(List<TransectionOutputDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ReturnTransection(TransectionType type, int idBanco, [FromQuery] GetObjQuery search)
        {
            Result<List<TransectionOutputDTO>> listEntity;
            switch (type)
            {
                case TransectionType.Debito:
                    listEntity = await _retornaDebUseCase.GetTransection(type, idBanco, search);
                    break;
                case TransectionType.Saldo:
                    listEntity = await _retornaSaldoUseCase.GetTransection(type, idBanco, search);
                    break;
                default:
                    return BadRequest("Tipo de transação não suportado.");
            }
            if (!listEntity.IsSuccess)
                return BadRequest(listEntity);
            if (listEntity.Valeu is not null)
                return Ok(listEntity);

            return NotFound(listEntity);
        }
        #region entity framework
        //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
        //   debito.UserId = user!.Id;
        #endregion
    }
}
