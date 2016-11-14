using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Methub.Models
{
    public class Question
    {
        public Question()
        {
        }

        [Key]
        public int id { get; set; }
        public int question_type { get; set; }
        public string title { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }
        public Guid rowguid { get; set; }

        public List<QuestionDetail> QuestionDetails { get; set; }
    }
}
