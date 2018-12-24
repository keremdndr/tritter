using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using TP.Data.Contracts;
using TP.Data.Includables;

namespace TP.Data
{
    public class GenericRepository<TContext, T> : IGenericRepository<TContext, T> where TContext : DbContext where T : class
    {
        protected TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T Get(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Add(T t)
        {
            _context.Set<T>().Add(t);

            return t;
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public virtual T FindIncluding(Expression<Func<T, bool>> match, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties)
        {
            return _context.Set<T>().ApplyDomainIncludeForEF(includeProperties).SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public ICollection<T> FindAllIncluding(Expression<Func<T, bool>> match, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties)
        {
            return _context.Set<T>().ApplyDomainIncludeForEF(includeProperties).Where(match).ToList();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _context.Set<T>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().ApplyDomainIncludeForEF(includeProperties).Where(predicate);
            return query;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<IQueryable<T>, IDomainIncludable<T>>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();

            queryable = queryable.ApplyDomainIncludeForEF(includeProperties);

            return queryable;
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return _context.Set<T>().FromSql<T>(query, parameters);
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, CommandType commandType = CommandType.StoredProcedure, params object[] parameters) where TElement : new()
        {
            this._context.Database.OpenConnection();
            DbCommand cmd = this._context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);

            List<TElement> result = null;

            using (var reader = cmd.ExecuteReader())
            {
                result = reader.MapToList<TElement>();
            }

            this._context.Database.CloseConnection();

            return result;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public int SqlQueryForInt<TElement>(string sql, CommandType commandType = CommandType.StoredProcedure, params object[] parameters) where TElement : new()
        {
            this._context.Database.OpenConnection();
            DbCommand cmd = this._context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);

            int result = 0;

            using (var reader = cmd.ExecuteReader())
            {
                result = reader.MapToSingle<int>();
            }

            this._context.Database.CloseConnection();

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}