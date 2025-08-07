using Financ.Application.Mappers;
using Financ.Application.Queries;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using System.Text;
using System.Threading.Tasks;
using Financ.Application.DTOs;
using Financ.Application.UseCases.Interfaces;
using Financ.Domain.Enums;

namespace Financ.Application.UseCases.Service
{
    public class ReturnTransectionUseCase : IReturnUseCase<TransectionOutputDTO>
    {
        private readonly IUnitOfWork _unit;
        public ReturnTransectionUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Result<List<TransectionOutputDTO>>> GetTransection(TransectionType type, int idBanco, GetObjQuery search)
        {
            switch (type)
            {
                case TransectionType.Debito:
                    Expression<Func<Domain.Entities.Debito, bool>> predicateDeb = x => x.IdBanco == idBanco && search.Date.StartDate <= x.DthrReg && search.Date.StartEnd >= x.DthrReg;
                    if (!string.IsNullOrEmpty(search.Title))
                    {
                        predicateDeb = predicateDeb.And(x => x.Titulo.Contains(search.Title));
                    }
                    if (!string.IsNullOrEmpty(search.Description))
                    {
                        predicateDeb = predicateDeb.And(x => x.Descricao.Contains(search.Description));
                    }
                    if (!string.IsNullOrEmpty(search.Status))
                    {
                        predicateDeb = predicateDeb.And(x => x.Status.Equals(search.Status));
                    }

                    IEnumerable<Domain.Entities.Debito> listEntity = (await _unit.DebitoRepository.GetObjects(predicateDeb))!;

                    return Result<List<TransectionOutputDTO>>.Success(idBanco, TranseectionMappersDefault.ToDebitoOutputDTOinList(listEntity.ToList()).ToList());

                case TransectionType.Saldo:
                    Expression<Func<Domain.Entities.Saldo, bool>> predicateSaldo = x => x.IdBanco == idBanco && search.Date.StartDate <= x.DthrReg && search.Date.StartEnd >= x.DthrReg;
                    if (!string.IsNullOrEmpty(search.Title))
                    {
                        predicateSaldo = predicateSaldo.And(x => x.Titulo.Contains(search.Title));
                    }
                    if (!string.IsNullOrEmpty(search.Description))
                    {
                        predicateSaldo = predicateSaldo.And(x => x.Descricao.Contains(search.Description));
                    }
                    if (!string.IsNullOrEmpty(search.Status))
                    {
                        predicateSaldo = predicateSaldo.And(x => x.Status.Equals(search.Status));
                    }

                    IEnumerable<Domain.Entities.Saldo> listEntitySaldo = (await _unit.SaldoRepository.GetObjects(predicateSaldo))!;

                    return Result<List<TransectionOutputDTO>>.Success(idBanco, TranseectionMappersDefault.ToSaldoDTOinList(listEntitySaldo.ToList()).ToList());
                default:
                    return Result<List<TransectionOutputDTO>>.Failure(idBanco, "Tipo de transação não suportado.");
            }
        }
    }
}
