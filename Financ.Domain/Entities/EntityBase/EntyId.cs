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
        public string UserId { get; private set; } = string.Empty;
        public EntyId() { }
        public EntyId(int id)
        {
            Id = id;
        }
        public EntyId(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
