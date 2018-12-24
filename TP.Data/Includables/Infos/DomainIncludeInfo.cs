using System;
using System.Linq.Expressions;

namespace TP.Data.Includables.Infos
{
    public abstract class DomainIncludeInfo
    {
        public DomainIncludeInfo(DomainIncludeType includeType, bool isEnumerable, Type[] genericMethodArguments, Expression expression)
        {
            IncludeType = includeType;
            GenericMethodArguments = genericMethodArguments;
            IsEnumerable = isEnumerable;
            Expression = expression;
        }

        public DomainIncludeType IncludeType { get; }

        public Type[] GenericMethodArguments { get; }

        public bool IsEnumerable { get; }

        public Expression Expression { get; }
    }

    public class DomainIncludeInfo<TEntity, TProperty> : DomainIncludeInfo
    {
        public DomainIncludeInfo(DomainIncludeType includeType, bool isEnumerable, Expression<Func<TEntity, TProperty>> expression)
            : base(includeType, isEnumerable, new Type[] { typeof(TEntity), typeof(TProperty) }, expression)
        { }
    }

    public class DomainIncludeInfo<TEntity, TPreviousProperty, TProperty> : DomainIncludeInfo
    {
        public DomainIncludeInfo(DomainIncludeType includeType, bool isEnumerable, Expression<Func<TPreviousProperty, TProperty>> expression)
            : base(includeType, isEnumerable, new Type[] { typeof(TEntity), typeof(TPreviousProperty), typeof(TProperty) }, expression)
        { }
    }
}
