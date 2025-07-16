using Financ.Domain.Entities;
using Financ.Domain.Interfaces;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class ParcelaRepository : BaseRepository<Parcela>, IParcelaRepository
    {
        public ParcelaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
