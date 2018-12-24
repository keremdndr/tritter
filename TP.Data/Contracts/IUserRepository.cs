using System.Collections.Generic;
using TP.Data.Entities;

namespace TP.Data.Contracts
{
    public interface IUserRepository : IGenericRepository<TPContext, User>
    {
        //List<CampaignListItemTeamLeaderReport> GenerateReport(int teamLeaderId);
    }
}