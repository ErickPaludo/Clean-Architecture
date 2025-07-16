using Financ.Domain.Interfaces;
using Financ.Domain.Interfaces.UnitOfWork;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICreditoRepository creditoRepository;
        private IDebitoRepository debitoRepository;
        private IParcelaRepository parcelaRepository;
        private ISaldoRepository saldoRepository;

        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICreditoRepository CreditoRepository { get { return creditoRepository = creditoRepository ?? new CreditoRepository(_context); } }

        public IDebitoRepository DebitoRepository { get { return debitoRepository = debitoRepository ?? new DebitoRepository(_context); } }

        public IParcelaRepository ParcelaRepository { get { return parcelaRepository = parcelaRepository ?? new ParcelaRepository(_context); } }

        public ISaldoRepository SaldoRepository { get { return saldoRepository = saldoRepository ?? new SaldoRepository(_context); } }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
