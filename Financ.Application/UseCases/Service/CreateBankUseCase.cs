using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service
{
    public class CreateBankUseCase : ICreateBankUseCase
    {
        private readonly IUnitOfWork _unit;

        public CreateBankUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<BankOutputDTO> Create(CommandBank bank)
        {
            var entity = await _unit.BankRepository.Create(Domain.Entities.Banco.CriaObjectBank(bank.Titulo, "0", bank.Status));
            _unit.Commit();
            if (entity == null)
            {
                return null;
            }
            return TransectionMappersDefault.ToBancoInOutput(entity);
        }
    }
}
