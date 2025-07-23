using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Debito
{
    public class CriaDebUseCase : ICriaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public CriaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Domain.Entities.Debito> CriarDebitoAsync(CriaDebCommand debito)
        {
            var debCreated = await _unit.DebitoRepository.Create(new Domain.Entities.Debito(debito.Titulo,debito.Descricao,debito.Valor,debito.DthrReg,debito.Status));
            _unit.Commit();
            return debCreated!;
        }
    }
}
