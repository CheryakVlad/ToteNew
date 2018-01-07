
using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface ISportService
    {
        Sport GetSport(int? id);
        IReadOnlyList<Sport> GetSports();
    }
}
