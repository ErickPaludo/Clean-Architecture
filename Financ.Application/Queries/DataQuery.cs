using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Queries
{
    public class DataQuery
    {
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        public DateTime StartEnd { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
    }
}
