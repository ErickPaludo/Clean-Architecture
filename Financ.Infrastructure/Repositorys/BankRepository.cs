using Financ.Application.Repository;
using Financ.Domain.Entities;
using Financ.Domain.Entities.EntityBase;
using Financ.Domain.Interfaces.Repository;
using Financ.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Repositorys
{
    public class BankRepository : BaseRepository<Banco>,IBankRepository
    {
        public BankRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
