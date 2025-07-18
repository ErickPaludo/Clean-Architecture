using Financ.Application.Repository;
using Financ.Domain.Entities;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class DebitoRepository : BaseRepository<Debito>, IDebitoRepository
    {
        public DebitoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
