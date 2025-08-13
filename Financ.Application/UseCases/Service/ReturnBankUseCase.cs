using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Queries;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Interfaces;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service
{
    public class ReturnBankUseCase : IReturnBankUseCase
    {
        private readonly IUnitOfWork _unit;
        public ReturnBankUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<BankOutputDTO>> GetBanks(string userId, BaseQuery query)
        {
            Expression<Func<Domain.Entities.Banco, bool>> filter = x => x.UserId == userId;
            if (query.Id > 0)
            {
                filter = filter.And(x => x.Id == query.Id);
            }
            if (!string.IsNullOrEmpty(query.Title))
            {
                filter = filter.And(x => x.Titulo.Contains(query.Title));
            }
            if (!string.IsNullOrEmpty(query.Status))
            {
                filter = filter.And(x => x.Status.Equals(query.Status));
            }
            var listBank = await _unit.BankRepository.GetObjects(filter);

            return TransectionMappersDefault.ToBancoOutputDTOinList(listBank!);
        }
    }
}
