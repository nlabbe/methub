using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methub.Models
{
    public class Constraint
    {
        public Constraint()
        {
        }

        public int id { get; set; }
        public int constraint_type { get; set; }
        public int rol { get; set; }
        public int frequency { get; set; }
        public int priority { get; set; }
        public DateTime start_date { get; set; }
        public Nullable<DateTime> end_date { get; set; }
        public Nullable<DateTime> min_time { get; set; }
        public Nullable<DateTime> max_time { get; set; }
        public string comment { get; set; }
    }
}
