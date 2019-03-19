using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class ContatoModel
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }        
        public long AgendasID { get; set; }
    }
}
