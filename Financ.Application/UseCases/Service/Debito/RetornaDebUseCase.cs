using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Debito
{
    public class RetornaDebUseCase : IRetornaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public RetornaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }


        public async Task<Result<List<DebitoOutputDTO>>> RetornaDebitos()
        {
            IQueryable<Financ.Domain.Entities.Debito> listDebito = await _unit.DebitoRepository.Get();

                return Result<List<DebitoOutputDTO>>.Success(DebitoMapper.ToDebitoOutputDTOinList(listDebito).ToList());
           
        }
        public Task<Result<DebitoOutputDTO>> RetornaDebitoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
