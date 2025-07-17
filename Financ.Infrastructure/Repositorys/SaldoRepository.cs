using Financ.Application.Ports.Interfaces.Repository;
using Financ.Domain.Entities;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class SaldoRepository : BaseRepository<Saldo>, ISaldoRepository
    {
        public SaldoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
