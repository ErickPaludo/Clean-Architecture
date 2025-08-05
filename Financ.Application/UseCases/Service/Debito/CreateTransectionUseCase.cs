using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Debito
{
    public class CreateTransectionUseCase : ICreateUseCase<CreateTransectionCommand, TransectionOutputDTO>
    {
        private readonly IUnitOfWork _unit;
        public CreateTransectionUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }

      s

        public async Task<Result<TransectionOutputDTO>> CriarDebitoAsync(CreateTransectionCommand debito)
        {
            var debCreated = await _unit.DebitoRepository.Create(Financ.Domain.Entities.Debito.CriaObjetoDebito(debito.Titulo, debito.Descricao, debito.Valor, debito.DthrReg, debito.Status, debito.IdBanco));
            _unit.Commit();

            if (debCreated != null)
                return Result<TransectionOutputDTO>.Success(TranseectionMappersDefault.ToDebitoOutputDTO(debCreated)!);
             
            return Result<TransectionOutputDTO>.Failure("Erro ao criar débito, verifique os dados informados e tente novamente.");
        }
    }
}
