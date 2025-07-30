using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Queries;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
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
        public async Task<Result<List<DebitoOutputDTO>>> RetornarDebito(int idBanco, GetObjQuery search)
        {
            Expression<Func<Financ.Domain.Entities.Debito, bool>> predicate = x => x.IdBanco == idBanco &&  search.Date.StartDate <= x.DthrReg && search.Date.StartEnd >= x.DthrReg;

            if (!string.IsNullOrEmpty(search.Title))
            {
                predicate = predicate.And(x => x.Titulo.Contains(search.Title));
            }
            if (!string.IsNullOrEmpty(search.Description))
            {
                predicate = predicate.And(x => x.Descricao.Contains(search.Description));
            }
            if (!string.IsNullOrEmpty(search.Status))
            {
                predicate = predicate.And(x => x.Status.Equals(search.Status));
            }
           
            IEnumerable<Financ.Domain.Entities.Debito> debito = (await _unit.DebitoRepository.GetObjects(predicate))!;
            return Result<List<DebitoOutputDTO>>.Success(DebitoMapper.ToDebitoOutputDTOinList(debito.ToList()).ToList());
        }
    }
}
