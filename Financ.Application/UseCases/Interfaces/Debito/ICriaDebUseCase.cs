using System;
using Financ.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.DTOs;

namespace Financ.Application.UseCases.Interfaces.Debito
{
    public interface ICriaDebUseCase
    {
        Task<DebitoOutputDTO> CriarDebitoAsync(CriaDebCommand debito);
    }
}
