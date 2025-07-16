using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities.EntityBase
{
    public abstract class EntyId
    {
        public int Id { get; private set; }
        public string UserId { get; set; } = string.Empty;
    }
}
