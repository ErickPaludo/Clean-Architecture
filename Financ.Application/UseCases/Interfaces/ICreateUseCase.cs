using System;
using Financ.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Domain.Enums;

namespace Financ.Application.UseCases.Interfaces
{
    public interface ICreateUseCase<TCommand, TResult> where TCommand : class
                                                      where TResult : class
    {
        Task<Result<TResult>> CreateTransactionHandler(TCommand valueTransection,TransectionType type);
    }
}
