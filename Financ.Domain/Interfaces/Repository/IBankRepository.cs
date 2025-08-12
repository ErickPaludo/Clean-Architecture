using Financ.Application.Repository;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Interfaces.Repository
{
    public interface IBankRepository : IBaseRepository<Banco>
    {
    }
}
