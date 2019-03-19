using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace agenda.Domain
{
    public class Contatos
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public long AgendasID { get; set; }
    }
}
