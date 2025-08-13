using Financ.Application.DTOs;
using Financ.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces
{
    public interface IReturnBankUseCase
    {
        Task<IEnumerable<BankOutputDTO>> GetBanks(string userId,BaseQuery query); 
    }
}
