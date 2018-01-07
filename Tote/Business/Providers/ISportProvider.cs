
using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface ISportProvider
    {
        Sport GetSport(int? id);
        IReadOnlyList<Sport> GetSports();
    }
}
