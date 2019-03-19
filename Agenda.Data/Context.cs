using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Agenda.Data
{
    public class Context : DbContext
    {


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<> Viajantes { get; set; }


    }
}