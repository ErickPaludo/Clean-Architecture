﻿using Financ.Application.DTOs;
using Financ.Application.Mappers;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.Service;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Service.Debito
{
    public class CriaDebUseCase : ICriaDebUseCase
    {
        private readonly IUnitOfWork _unit;
        public CriaDebUseCase(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Result<DebitoOutputDTO>> CriarDebitoAsync(CriaDebCommand debito)
        {
            var debCreated = await _unit.DebitoRepository.Create(Financ.Domain.Entities.Debito.CriaObjetoDebito(debito.Titulo, debito.Descricao, debito.Valor, debito.DthrReg, debito.Status, debito.IdBanco));
            _unit.Commit();

            if (debCreated != null)
                return Result<DebitoOutputDTO>.Success(DebitoMapper.ToDebitoOutputDTO(debCreated)!);
             
            return Result<DebitoOutputDTO>.Failure("Erro ao criar débito, verifique os dados informados e tente novamente.");
        }
    }
}
