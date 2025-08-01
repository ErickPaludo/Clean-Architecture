﻿using Financ.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICreditoRepository CreditoRepository { get; }
        IDebitoRepository DebitoRepository { get; }
        IParcelaRepository ParcelaRepository { get; }
        ISaldoRepository SaldoRepository { get; }
        void Commit();
    }
}
