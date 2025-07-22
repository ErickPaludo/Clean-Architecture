using Financ.Application.UseCases.Commands;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces
{
    public interface ICriaDebUseCase 
    {
        Task<Debito> CriarDebitoAsync(CriaDebCommand debito);
    }
}
