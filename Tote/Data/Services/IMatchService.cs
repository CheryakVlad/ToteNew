using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IMatchService
    {
        IReadOnlyList<Match> GetMatchsAll();
        Match GetMatchById(int matchId);
    }
}
