using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
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
        public async Task<HeaderResponseDTO<List<DebitoOutputDTO>>> RetornaDebitos()
        {
            IQueryable<Financ.Domain.Entities.Debito> listDebito = await _unit.DebitoRepository.Get();

            if (listDebito is not null && listDebito.Any())
            {
                var teste = new HeaderResponseDTO<List<DebitoOutputDTO>>
                {
                    Message = "Sucess",
                    IdBanco = listDebito.First().IdBanco,
                    Response = DebitoMapper.ToDebitoOutputDTOinList(listDebito).ToList()
                };
                return teste;
            }
            else
            {
                return new HeaderResponseDTO<List<DebitoOutputDTO>>
                {
                    Message = "Not Found",
                    IdBanco = null,
                    Response = null
                };
            }
        }
    }
}
