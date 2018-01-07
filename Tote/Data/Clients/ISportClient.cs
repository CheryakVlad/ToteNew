

using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface ISportClient
    {
        ToteService.SportDto GetSport(int? id);
        IReadOnlyList<ToteService.SportDto> GetSports();
        bool UpdateSport(Sport sport);
        bool AddSport(Sport sport);
        bool DeleteSport(int sportId);
    }
}
