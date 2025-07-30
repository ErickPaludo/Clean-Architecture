using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Queries
{
    public class GetObjQuery
    {
        public int Id { get; set; }
        public DataQuery Date { get; set; } = new DataQuery();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
