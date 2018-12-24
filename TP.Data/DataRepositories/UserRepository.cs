using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TP.Data.Contracts;
using TP.Data.Entities;

namespace TP.Data.DataRepositories
{
    public class UserRepository : GenericRepository<TPContext, User>, IUserRepository
    {
        public UserRepository(TPContext context)
            : base(context)
        { }

        //public override void Delete(User entity)
        //{
        //    base.Delete(entity);
        //    _context.RemoveRange(_context.CampaignListAuth.Where(r => r.UserId == entity.Id));
        //}

        //public List<CampaignListItemTeamLeaderReport> GenerateReport(int teamLeaderId)
        //{
        //    var param = new SqlParameter("@TeamLeaderId", teamLeaderId);

        //    return SqlQuery<CampaignListItemTeamLeaderReport>("SP_GetReportForTeamLeader", System.Data.CommandType.StoredProcedure, param).ToList();
        //}

    }
}