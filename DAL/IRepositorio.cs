using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetTodos();
        T Find(params object[] key);
        T ProcuraPor(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(Func<T, bool> predicate);
        void Commit();
        void Dispose();
    }
}