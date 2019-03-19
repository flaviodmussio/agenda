using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace agenda.Domain
{
    public class Agendas
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
