using System;
using System.Collections.Generic;
using System.Text;

namespace agenda.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        IList<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity GetUnit(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        bool Exist(TEntity obj);
        int Save();
        System.Threading.Tasks.Task<int> SaveAsync();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
    }
}

