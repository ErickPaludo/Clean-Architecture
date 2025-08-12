using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Interfaces;
using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Handlers
{
    public class TransectionHandlerFactory
    {
        private readonly IUnitOfWork _unit;

        public TransectionHandlerFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public ITransectionHandlerCreate GetHandler(TransectionType transectionType)
        {
            switch (transectionType) {
                case TransectionType.Debito:
                    return new DebitoHandlerCreate(_unit);
                case TransectionType.Saldo:
                    return new SaldoHandlerCreate(_unit);
                default:
                    return null;
            }
        }
    }
}
