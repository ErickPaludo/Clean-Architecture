using System;
using Financ.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.DTOs;
using Financ.Application.Service;

namespace Financ.Application.UseCases.Interfaces.Debito
{
    public interface ICriaDebUseCase
    {
        Task<Result<DebitoOutputDTO>> CriarDebitoAsync(CriaDebCommand debito);
    }
}
