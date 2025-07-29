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

            return Result<List<DebitoOutputDTO>>.Success(DebitoMapper.ToDebitoOutputDTOinList(listDebito.ToList()).ToList());

        }
        public async Task<Result<List<DebitoOutputDTO>>> RetornaDebitoId(int id)
        {
            IEnumerable<Financ.Domain.Entities.Debito> debito = (await _unit.DebitoRepository.GetObjects(x => x.Id == id))!;
            return Result<List<DebitoOutputDTO>>.Success(DebitoMapper.ToDebitoOutputDTOinList(debito.ToList()).ToList());
        }
    }
}
