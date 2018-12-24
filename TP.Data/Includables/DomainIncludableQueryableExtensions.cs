using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TP.Data.Includables.Infos;

namespace TP.Data.Includables
{
    public static class DomainIncludableQueryableExtensions
    {
        public static IDomainIncludable<TEntity, TProperty> DomainInclude<TEntity, TProperty>(
           this IQueryable<TEntity> source,
           Expression<Func<TEntity, TProperty>> navigationPropertyPath)
           where TEntity : class
        {
            IRootDomainIncludable<TEntity> root = new RootDomainIncludable<TEntity>();
            return new DomainIncludable<TEntity, TProperty>(root, DomainIncludeType.Include, navigationPropertyPath);
        }

        public static IDomainIncludable<TEntity, TProperty> DomainInclude<TEntity, TProperty>(
            this IDomainIncludable<TEntity> source,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            IRootDomainIncludable<TEntity> root = source.GetRoot();
            return new DomainIncludable<TEntity, TProperty>(root, DomainIncludeType.Include, navigationPropertyPath);
        }

        public static IDomainIncludable<TEntity, TProperty> DomainThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IDomainIncludable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            IRootDomainIncludable<TEntity> root = source.GetRoot();
            return new DomainIncludable<TEntity, TPreviousProperty, TProperty>(root, DomainIncludeType.ThenInclude, navigationPropertyPath);
        }

        public static IDomainIncludable<TEntity, TProperty> DomainEnumerableThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IDomainIncludable<TEntity, IEnumerable<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            IRootDomainIncludable<TEntity> root = source.GetRoot();
            return new EnumerableDomainIncludable<TEntity, TPreviousProperty, TProperty>(root, DomainIncludeType.ThenInclude, navigationPropertyPath);
        }

        private static IRootDomainIncludable<TEntity> GetRoot<TEntity>(this IDomainIncludable<TEntity> domainIncludable)
        {
            if (domainIncludable is IHasRootDomainInclude<TEntity> root)
            {
                return root.GetRoot();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        #region DomainIncludable classes 
        private interface IRootDomainIncludable<out TEntity> : IDomainIncludable<TEntity>
        {
            void AddIncludeInfo(DomainIncludeInfo info);
        }

        private interface IHasRootDomainInclude<TEntity>
        {
            IRootDomainIncludable<TEntity> GetRoot();
        }

        private class RootDomainIncludable<TEntity> : IRootDomainIncludable<TEntity>, IHasRootDomainInclude<TEntity>
        {

            protected readonly List<DomainIncludeInfo> _includes;

            public RootDomainIncludable()
            {
                _includes = new List<DomainIncludeInfo>();
            }

            public IEnumerable<DomainIncludeInfo> IncludeInfos
            {
                get
                {
                    return _includes;
                }
            }

            public void AddIncludeInfo(DomainIncludeInfo info)
            {
                if (info != null)
                {
                    _includes.Add(info);
                }
            }

            public IRootDomainIncludable<TEntity> GetRoot()
            {
                return this;
            }
        }

        private abstract class ChieldDomainIncludable<TEntity> : IDomainIncludable<TEntity>, IHasRootDomainInclude<TEntity>
        {
            private readonly IRootDomainIncludable<TEntity> _root;

            public ChieldDomainIncludable(IRootDomainIncludable<TEntity> root)
            {
                _root = root;
            }


            public IEnumerable<DomainIncludeInfo> IncludeInfos
            {
                get
                {
                    return _root.IncludeInfos;
                }
            }

            public IRootDomainIncludable<TEntity> GetRoot()
            {
                return _root;
            }
        }

        private class DomainIncludable<TEntity, TProperty> : ChieldDomainIncludable<TEntity>, IDomainIncludable<TEntity, TProperty>
        {
            public DomainIncludable(IRootDomainIncludable<TEntity> root, DomainIncludeType includeType, Expression<Func<TEntity, TProperty>> navigationPropertyPath)
                : base(root)
            {
                GetRoot().AddIncludeInfo(new DomainIncludeInfo<TEntity, TProperty>(includeType, false, navigationPropertyPath));
            }
        }

        private class DomainIncludable<TEntity, TPreviousProperty, TProperty> : ChieldDomainIncludable<TEntity>, IDomainIncludable<TEntity, TProperty>
        {
            public DomainIncludable(IRootDomainIncludable<TEntity> root, DomainIncludeType includeType, Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
                : base(root)
            {
                GetRoot().AddIncludeInfo(new DomainIncludeInfo<TEntity, TPreviousProperty, TProperty>(includeType, false, navigationPropertyPath));
            }
        }

        private class EnumerableDomainIncludable<TEntity, TPreviousProperty, TProperty> : ChieldDomainIncludable<TEntity>, IDomainIncludable<TEntity, TProperty>
        {
            public EnumerableDomainIncludable(IRootDomainIncludable<TEntity> root, DomainIncludeType includeType, Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
                : base(root)
            {
                GetRoot().AddIncludeInfo(new DomainIncludeInfo<TEntity, TPreviousProperty, TProperty>(includeType, true, navigationPropertyPath));
            }
        }
        #endregion

    }
}
