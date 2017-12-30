using Common.Models;
using System.Collections.Generic;

namespace Business.Service
{
    public interface ICacheService
    {
        IReadOnlyList<Match> GetCache(int sportId, string dateMatch, int status);
        IReadOnlyList<Match> InsertCache(int sportId, string dateMatch, int status);
        IReadOnlyList<Sport> GetCache();
        IReadOnlyList<Sport> InsertCache();
        IReadOnlyList<Tournament> GetCache(int sportId);
        IReadOnlyList<Tournament> InsertCache(int sportId);
        IReadOnlyList<Match> GetCache(int sportId, int tournamentId);
        IReadOnlyList<Match> InsertCache(int sportId, int tournamentId);
        void DeleteCache(string cacheKey);
    }
}
