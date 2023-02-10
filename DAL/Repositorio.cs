using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private PizzariaNapoleEntities Context;

        protected Repositorio()
        {
            Context = new PizzariaNapoleEntities();
        }
        
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public void Contexto()
        {
            Context = new PizzariaNapoleEntities();
        }

        public IQueryable<T> GetTodos()
        {
            return Context.Set<T>();
        }
        public T Find(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        public T ProcuraPor(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Adicionar(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Atualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Deletar(Func<T, bool> predicate)
        {
            Context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => Context.Set<T>().Remove(del));
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}