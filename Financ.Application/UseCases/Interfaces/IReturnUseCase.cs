using Financ.Application.DTOs;
using Financ.Application.Queries;
using Financ.Application.Service;
using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces
{
    public interface IReturnUseCase<TResult>
    {
        Task<Result<List<TResult>>> GetTransection(TransectionType type, int idBanco,GetObjQuery search);
    }
}
