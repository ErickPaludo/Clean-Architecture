using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using Financ.Application.UseCases.Service.Handlers;
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
        private readonly TransectionHandlerFactory _handlerFactory;
        public CreateTransectionUseCase(IUnitOfWork unit)
        {
            _unit = unit;
            _handlerFactory = new TransectionHandlerFactory(unit);
        }

        public async Task<Result<TransectionOutputDTO>> CreateTransactionHandler(CreateTransectionCommand valueTransection, TransectionType type,string userId)
        {
            var bankExists = await _unit.BankRepository.ObjectAny(x => x.Id == valueTransection.IdBanco && x.UserId == userId);

            if (!bankExists)
            {
                return Result<TransectionOutputDTO>.Failure(valueTransection.IdBanco, "Banco não encontrado.");
            }
            var handler = _handlerFactory.GetHandler(type);
            return await handler.HandleCreate(valueTransection);
        }
    }
}
