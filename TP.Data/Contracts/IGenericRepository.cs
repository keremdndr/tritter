using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using TP.Data.Includables;

namespace TP.Data.Contracts
{
    public interface IGenericRepository<TContext, T> where TContext : DbContext where T : class
    {
        T Add(T t);

        int Count();

        void Delete(T entity);

        void DeleteById(int id);

        void Dispose();

        T Find(Expression<Func<T, bool>> match);

        T FindIncluding(Expression<Func<T, bool>> match, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        ICollection<T> FindAllIncluding(Expression<Func<T, bool>> match, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties);

        T Get(int id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllIncluding(params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties);

        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);

        void Save();

        T Update(T t, object key);

        IEnumerable<TElement> SqlQuery<TElement>(string sql, CommandType commandType = CommandType.StoredProcedure, params object[] parameters) where TElement : new();
    }
}