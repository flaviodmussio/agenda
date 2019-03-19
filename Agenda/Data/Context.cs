using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using agenda.Domain;
using System;

namespace Agenda.Data
{
    public class Context : DbContext
    {


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Agendas> Agendas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }

    }
}