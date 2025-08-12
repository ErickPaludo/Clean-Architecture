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
    public class DebitoHandlerCreate : ITransectionHandlerCreate
    {
        private readonly IUnitOfWork _unit;
        public DebitoHandlerCreate(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Result<TransectionOutputDTO>> HandleCreate(CreateTransectionCommand command)
        {
            var entity = await _unit.DebitoRepository.Create(
                       Domain.Entities.Debito.CriaObjetoDebito(command.Titulo, command.Descricao, command.Valor, command.DthrReg, command.Status, command.IdBanco));
            _unit.Commit();
            return entity != null
                ? Result<TransectionOutputDTO>.Success(command.IdBanco, TranseectionMappersDefault.ToDebitoOutputDTO(entity)!)
                : Result<TransectionOutputDTO>.Failure(command.IdBanco, "Erro ao criar débito, verifique os dados informados e tente novamente.");
        }
    }
}
