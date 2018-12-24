using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TP.Data.Includables
{
    public static class EFQueryableExtentions
    {
        private static readonly MethodInfo _efIncludeMethodInfo = typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include)).SingleOrDefault(mi => mi.GetGenericArguments().Count() == 2);
        private static readonly MethodInfo _efThenIncludeAfterEnumerableMethodInfo = typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude))
            .Where(mi => mi.GetGenericArguments().Count() == 3)
            .Single(
                mi =>
                {
                    TypeInfo typeInfo = mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].GetTypeInfo();
                    return typeInfo.IsGenericType
                           && typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);
                });
        private static readonly MethodInfo _efThenIncludeAfterReferenceMethodInfo = typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude))
            .Single(mi => mi.GetGenericArguments().Count() == 3
                          && mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsGenericParameter);


        public static IQueryable<TEntity> ApplyDomainIncludeForEF<TEntity>(this IQueryable<TEntity> query, IDomainIncludable<TEntity> include)
        {
            IQueryable<TEntity> resultQuery = query;
            if (include != null)
            {
                object result = query;
                foreach (Infos.DomainIncludeInfo item in include.IncludeInfos)
                {
                    MethodInfo methodInfo = null;
                    switch (item.IncludeType)
                    {
                        case Infos.DomainIncludeType.Include:
                            {
                                methodInfo = _efIncludeMethodInfo;
                                break;
                            }
                        case Infos.DomainIncludeType.ThenInclude:
                            {
                                methodInfo = (item.IsEnumerable ? _efThenIncludeAfterEnumerableMethodInfo : _efThenIncludeAfterReferenceMethodInfo);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    result = methodInfo.MakeGenericMethod(item.GenericMethodArguments).Invoke(null, new object[] { result, item.Expression });
                }
                resultQuery = result as IQueryable<TEntity>;
            }
            return resultQuery;

        }

        public static IQueryable<TEntity> ApplyDomainIncludeForEF<TEntity>(this IQueryable<TEntity> query, params Expression<Func<IQueryable<TEntity>, IDomainIncludable<TEntity>>>[] includes)
        {
            IQueryable<TEntity> resultQuery = query;

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    if (include != null)
                    {
                        resultQuery = resultQuery.ApplyDomainIncludeForEF(include.Compile().Invoke(resultQuery));
                    }
                }
            }

            return resultQuery;
        }
    }
}
