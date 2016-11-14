using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Methub.Models
{
    public class Survey
    {
        public Survey()
        {
            // this.date_created = DateTime.Now;
            // this.date_modified = DateTime.Now;
            // this.rowguid = Guid.NewGuid();
        }

        [Key]
        public int id { get; set; }
        [RequiredAttribute]
        public string title { get; set; }
        [RequiredAttribute]
        public string description { get; set; }
        public Nullable<DateTime> date_created { get; set; }
        public Nullable<DateTime> date_modified { get; set; }
        public Nullable<Guid> rowguid { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
