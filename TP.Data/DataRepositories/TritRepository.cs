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
    public class TritRepository : GenericRepository<TPContext, Trit>, ITritRepository
    {
        public TritRepository(TPContext context)
            : base(context)
        { }

        //public override void Delete(Trit entity)
        //{
        //    base.Delete(entity);
        //    _context.RemoveRange(_context.CampaignListAuth.Where(r => r.TritId == entity.Id));
        //}

        public List<TritOthersListModel> GetTritOthers(string user_id)
        {
            var param = new SqlParameter("@User_id", user_id);

            return SqlQuery<TritOthersListModel>("SP_GetOhtersTrit", System.Data.CommandType.StoredProcedure, param).ToList();
        }

    }
}