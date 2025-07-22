using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Commands;
using Financ.Application.UseCases.Interfaces;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service
{
    public class CriaDebUseCase : ICriaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public CriaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Debito> CriarDebitoAsync(CriaDebCommand debito)
        {  
                var debCreated = await _unit.DebitoRepository.Create((Debito)debito);               
                _unit.Commit();    
                return debCreated!;
        }
    }
}
