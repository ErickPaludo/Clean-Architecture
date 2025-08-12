using Financ.Application.DTOs;
using Financ.Application.Queries;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands;
using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Interfaces
{
    public interface ITransectionHandlerCreate
    {
        Task<Result<TransectionOutputDTO>> HandleCreate(CreateTransectionCommand command);
    }
}
