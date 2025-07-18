using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Debito
{
    public interface ICriaDebUseCase
    {
        Task<CriaDebCommand> CriaDeb(CriaDebCommand debito);
    }
}
