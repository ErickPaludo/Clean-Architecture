using Financ.Application.Repository.UnitOfWork;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Debito
{
    public class CriaDebUseCase : ICriaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public CriaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<CriaDebCommand> CriaDeb(CriaDebCommand debito)
        {
            Domain.Entities.Debito deb = (Domain.Entities.Debito)debito;
            await _unit.DebitoRepository.Create(deb);
            _unit.Commit();
            return debito;
        }
    }
}
