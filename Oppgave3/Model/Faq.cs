using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Oppgave3.Model
{
    public class Faq
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ?!,. \-]{2,250}")]
        public String Question { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ?!,. \-]{2,250}")]
        public String Answer { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ\-]{2,20}")]
        public String Category { get; set; }
        [RegularExpression(@"[0-9]{1,3}")]
        public int UpVotes { get; set; }
        [RegularExpression(@"[0-9]{1,3}")]
        public int DownVotes { get; set; }
    }
}
