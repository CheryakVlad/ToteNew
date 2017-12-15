using Common.Models;
using System.Collections.Generic;

namespace Business.Service
{
    public interface ICacheService
    {
        IReadOnlyList<Match> GetCache(int sportId, string dateMatch, int status);
        IReadOnlyList<Match> InsertCache(int sportId, string dateMatch, int status);
        void DeleteCache();
    }
}
