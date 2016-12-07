using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methub.Models
{
    public class ConstraintDetail
    {
        public ConstraintDetail()
        {
        }

        public int id { get; set; }
        public int constraint_id { get; set; }
        public int day_id { get; set; }
        public int is_valid_day { get; set; }
    }
}
