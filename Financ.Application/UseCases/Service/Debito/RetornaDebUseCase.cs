using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Debito
{
    public class RetornaDebUseCase : IRetornaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public RetornaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<IEnumerable<RetornaDebCommand>> RetornaDebitos()
        {
            //  var listDebito = await _unit.DebitoRepository.Get();
            return null;
        }
    }
}
