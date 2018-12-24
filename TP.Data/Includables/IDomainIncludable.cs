using System.Collections.Generic;
using TP.Data.Includables.Infos;

namespace TP.Data.Includables
{
    public interface IDomainIncludable<out TEntity>
    {     
        IEnumerable<DomainIncludeInfo> IncludeInfos { get; }
    }

    public interface IDomainIncludable<out TEntity, out TProperty>
        : IDomainIncludable<TEntity>
    { }
}
