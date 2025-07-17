using Financ.Application.Ports.Interfaces.Repository;
using Financ.Domain.Entities;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class CreditoRepository : BaseRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
