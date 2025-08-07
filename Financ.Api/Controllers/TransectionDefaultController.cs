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
        private readonly ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> _criaDebUseCase;
        private readonly IReturnUseCase<TransectionOutputDTO> _retornaDebUseCase;
        private readonly ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> _criaSaldoUseCase;
        private readonly IReturnUseCase<TransectionOutputDTO> _retornaSaldoUseCase;


        public TransectionDefaultController(ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> criaDebUseCase, IReturnUseCase<TransectionOutputDTO> retornaDebUseCase, ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO> criasaldoUseCase, IReturnUseCase<TransectionOutputDTO> retornasaldoUseCase)
        {
            _criaDebUseCase = criaDebUseCase;
            _retornaDebUseCase = retornaDebUseCase;
            _criaSaldoUseCase = criasaldoUseCase;
            _retornaSaldoUseCase = retornasaldoUseCase;
        }

        [HttpPost("registerTransection")]
        [ProducesResponseType(typeof(TransectionOutputDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] TransectionInputDTO transection)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Result<TransectionOutputDTO>? objTranjection = null;

            Result<string> validaDebito = CreateTransectionCommand.Valida(transection);
            CreateTransectionCommand command = (CreateTransectionCommand)transection;

            switch (transection.Type)
            {
                case TransectionType.Debito:
                    objTranjection = await _criaDebUseCase.CreateTransactionHandler(command, TransectionType.Debito);
                    break;
                case TransectionType.Saldo:
                    objTranjection = await _criaSaldoUseCase.CreateTransactionHandler(command, TransectionType.Debito);
                    break;
                default:
                    return BadRequest("Tipo de transação não suportado.");
            }

            if (!validaDebito.IsSuccess)
            {
                return BadRequest(validaDebito);
            }

            if (objTranjection != null && objTranjection.IsSuccess)
                return Created(string.Empty, objTranjection);

            return BadRequest(objTranjection);
        }

        [HttpPost("returnTransection/{type}/{idBanco:int}")]
        [ProducesResponseType(typeof(List<TransectionOutputDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ReturnTransection(TransectionType type, int idBanco, [FromQuery] GetObjQuery search)
        {
            Result<List<TransectionOutputDTO>> listEntity;
            switch (type)
            {
                case TransectionType.Debito:
                    listEntity = await _retornaDebUseCase.GetTransection(type,idBanco, search);
                    break;
                case TransectionType.Saldo:
                    listEntity = await _retornaSaldoUseCase.GetTransection(type,idBanco, search);
                    break;
                default:
                    return BadRequest("Tipo de transação não suportado.");
            }
            if (!listEntity.IsSuccess)
                return BadRequest(listEntity);
            if (listEntity.Valeu is not null && listEntity.Valeu.Count() > 0)
                return Ok(listEntity);

            return NotFound(listEntity);
        }
        #region entity framework
        //  var user = await _userManager.FindByNameAsync(User.FindFirstValue(ClaimTypes.Name)!);
        //   debito.UserId = user!.Id;
        #endregion
    }
}
