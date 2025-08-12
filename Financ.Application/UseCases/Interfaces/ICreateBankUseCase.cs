using Financ.Application.DTOs;
using Financ.Application.UseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces
{
    public interface ICreateBankUseCase
    {
        Task<BankOutputDTO> Create(CommandBank bank);
    }
}
