using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using agenda.Domain;

namespace agenda.Repository
{
    public class AgendasRepository : IRepository<Agendas>, IDisposable
    {
        private readonly Context ctx;

        public AgendasRepository(Context _ctx)
        {
            ctx = _ctx;
        }

        public void Add(Agendas obj)
        {
            ctx.Agendas.Add(obj);
        }

        public void Delete(Func<Agendas, bool> predicate)
        {
            ctx.Agendas.Where(predicate).ToList()
                .ForEach(del => ctx.Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public bool Exist(Agendas obj)
        {
            return ctx.Agendas.Any(a => a.Id == obj.Id);
        }

        public Agendas Find(params object[] key)
        {
            return ctx.Agendas.Find(key);
        }

        public IList<Agendas> Get(Func<Agendas, bool> predicate)
        {
            return ctx.Agendas.Where(predicate).ToList();
        }

        public List<Agendas> GetAllQuery()
        {
            return ctx.Agendas.ToList();
        }

        public List<Agendas> GetAll()
        {
            return ctx.Agendas.Where(a => a.Status == true).ToList();
        }

        public List<Agendas> GetAllFiltro(string nome)
        {
            var agendas = new List<Agendas>();

            if (nome != "")
                agendas = ctx.Agendas.Where(a => a.Status == true && a.Nome.Contains(nome)).ToList();

            return agendas;
        }

            IList<Agendas> IRepository<Agendas>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Agendas GetUnit(Func<Agendas, bool> predicate)
        {
            return ctx.Agendas.FirstOrDefault(predicate);
        }


        public int GetUnid()
        {
            return ctx.Agendas.Where(a => a.Status == true).Count();
        }

        public Agendas GetElement(long id)
        {
            return ctx.Agendas.Where(a => a.Status == true && a.Id == id).FirstOrDefault();
        }

        public int Save()
        {
            return ctx.SaveChanges();
        }

        public async System.Threading.Tasks.Task<int> SaveAsync()
        {
            return await ctx.SaveChangesAsync();
        }

        public void Update(Agendas obj)
        {
            ctx.Agendas.Update(obj);
        }

    }
}
