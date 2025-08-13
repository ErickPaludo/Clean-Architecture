using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Handlers
{
    public class SaldoHandlerCreate : ITransectionHandlerCreate
    {
        private readonly IUnitOfWork _unit;

        public SaldoHandlerCreate(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Result<TransectionOutputDTO>> HandleCreate(CreateTransectionCommand command)
        {
            var entity = await _unit.SaldoRepository.Create(
           Domain.Entities.Saldo.CriaObjetoSaldo(command.Titulo, command.Descricao, command.Valor, command.DthrReg, command.Status, command.IdBanco));
            _unit.Commit();
            return entity != null
                ? Result<TransectionOutputDTO>.Success(command.IdBanco, TransectionMappersDefault.ToSaldoOutputDTO(entity)!)
                : Result<TransectionOutputDTO>.Failure(command.IdBanco, "Erro ao criar saldo, verifique os dados informados e tente novamente.");
        }
    }
}
