using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methub.Models
{
    public class QuestionDetail
    {
        public QuestionDetail()
        {
        }

        [Key]
        public int id { get; set; }
        public int question_id { get; set; }
        public Guid rowguid { get; set; }
    }
}
