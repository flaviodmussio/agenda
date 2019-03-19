using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class AgendaModel
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public ContatoModel Contato { get; set; }
        public List<ContatoModel> Contatos {get; set;}
    }
}
