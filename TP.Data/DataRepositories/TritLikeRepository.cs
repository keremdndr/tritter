using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TP.Data.Contracts;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritModel;

namespace TP.Data.DataRepositories
{
    public class TritLikeRepository : GenericRepository<TPContext, TritLike>, ITritLikeRepository
    {
        public TritLikeRepository(TPContext context)
            : base(context)
        { }
    }
}