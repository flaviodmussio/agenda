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
    public class ContatosRepository : IRepository<Contatos>, IDisposable
    {
        private readonly Context ctx;

        public ContatosRepository(Context _ctx)
        {
            ctx = _ctx;
        }

        public void Add(Contatos obj)
        {
            ctx.Contatos.Add(obj);
        }

        public void Delete(Func<Contatos, bool> predicate)
        {
            ctx.Contatos.Where(predicate).ToList()
                .ForEach(del => ctx.Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public bool Exist(Contatos obj)
        {
            return ctx.Contatos.Any(a => a.Id == obj.Id);
        }

        public Contatos Find(params object[] key)
        {
            return ctx.Contatos.Find(key);
        }

        public IList<Contatos> Get(Func<Contatos, bool> predicate)
        {
            return ctx.Contatos.Where(predicate).ToList();
        }

        public List<Contatos> GetAllQuery()
        {
            return ctx.Contatos.ToList();
        }

        public List<Contatos> GetAll()
        {
            return ctx.Contatos.Where(a => a.Status == true).ToList();
        }


        public Contatos GetUnit(Func<Contatos, bool> predicate)
        {
            return ctx.Contatos.FirstOrDefault(predicate);
        }

        public int GetUnid()
        {
            return ctx.Contatos.Where(a => a.Status == true).Count();
        }

        public Contatos GetElement(long id)
        {
            return ctx.Contatos.Where(a => a.Status == true && a.Id == id).FirstOrDefault();
        }

        public int Save()
        {
            return ctx.SaveChanges();
        }

        public async System.Threading.Tasks.Task<int> SaveAsync()
        {
            return await ctx.SaveChangesAsync();
        }

        public void Update(Contatos obj)
        {
            ctx.Contatos.Update(obj);
        }

        IList<Contatos> IRepository<Contatos>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
