using Common.Models;
using System.Collections.Generic;
using System;
using System.Web;
using Business.Providers;
using System.Collections;

namespace Business.Service
{
    public class CacheService : ICacheService
    {
        private const string cacheKey = "sortKey";
        private readonly IMatchProvider matchProvider;

        public CacheService(IMatchProvider matchProvider)
        {
            this.matchProvider = matchProvider;
        }

        public void DeleteCache()
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (CacheEnum.Key.ToString().StartsWith(cacheKey))
                {
                    HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
                }
            }
        }

        public IReadOnlyList<Match> GetCache(int sportId, string dateMatch, int status)
        {
            string cacheSortKey = cacheKey + sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cacheSortKey) as IReadOnlyList<Match>;
            return matches;
        }

        public IReadOnlyList<Match> InsertCache(int sportId, string dateMatch, int status)
        {
            string cacheSortKey = cacheKey + sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
            HttpRuntime.Cache.Insert(cacheSortKey, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            return matches;
        }
    }
}
