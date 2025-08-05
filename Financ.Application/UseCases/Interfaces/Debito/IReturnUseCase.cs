using Financ.Application.DTOs;
using Financ.Application.Queries;
using Financ.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces.Debito
{
    public interface IReturnUseCase<TResult>
    {
        Task<Result<List<TResult>>> RetornarDebito(int idBanco,GetObjQuery search);
    }
}
