using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using Financ.Domain.Entities;
using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service
{
    public class CreateTransectionUseCase : ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO>
    {
        private readonly IUnitOfWork _unit;
        public CreateTransectionUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Result<TransectionOutputDTO>> CreateTransactionHandler(CreateTransectionCommand valueTransection, TransectionType type)
        {
            object? entity = null;

            switch (type)
            {
                case TransectionType.Debito:
                    entity = await _unit.DebitoRepository.Create(Domain.Entities.Debito.CriaObjetoDebito(valueTransection.Titulo, valueTransection.Descricao, valueTransection.Valor, valueTransection.DthrReg, valueTransection.Status, valueTransection.IdBanco));
                    _unit.Commit();
                    return entity != null ? Result<TransectionOutputDTO>.Success(valueTransection.IdBanco, TranseectionMappersDefault.ToDebitoOutputDTO((Domain.Entities.Debito)entity)!) : Result<TransectionOutputDTO>.Failure(valueTransection.IdBanco, "Erro ao criar débito, verifique os dados informados e tente novamente.");

                case TransectionType.Saldo:
                    entity = await _unit.SaldoRepository.Create(Financ.Domain.Entities.Saldo.CriaObjetoSaldo(valueTransection.Titulo, valueTransection.Descricao, valueTransection.Valor, valueTransection.DthrReg, valueTransection.Status, valueTransection.IdBanco));
                    _unit.Commit();
                    return entity != null ? Result<TransectionOutputDTO>.Success(valueTransection.IdBanco, TranseectionMappersDefault.ToSaldoOutputDTO((Domain.Entities.Saldo)entity)!) : Result<TransectionOutputDTO>.Failure(valueTransection.IdBanco, "Erro ao criar débito, verifique os dados informados e tente novamente.");
                default:
                    return Result<TransectionOutputDTO>.Failure(valueTransection.IdBanco, "Tipo de transação não suportado.");
            }

        }
    }
}
