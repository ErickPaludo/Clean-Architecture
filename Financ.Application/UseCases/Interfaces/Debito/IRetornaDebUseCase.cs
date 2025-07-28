using Financ.Application.DTOs;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands.Debito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces.Debito
{
    public interface IRetornaDebUseCase
    {
        Task<Result<List<DebitoOutputDTO>>> RetornaDebitos();
    }
}
