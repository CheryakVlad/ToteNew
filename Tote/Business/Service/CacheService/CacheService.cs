using Common.Models;
using System.Collections.Generic;
using System;
using System.Web;
using Business.Providers;
using System.Collections;
using Common.Logger;

namespace Business.Service
{
    public class CacheService : ICacheService
    {
        private const string sortCacheKey = "sortKey";
        private const string navigateCacheKey = "navigateKey";
        private const string sportCacheKey = "sportKey";
        private const string tournamentCacheKey = "tournamentKey";
        private readonly IMatchProvider matchProvider;
        private readonly IBetListProvider betListProvider;
        private readonly ITournamentProvider tournamentProvider;
        private readonly ISportProvider sportProvider;
        private readonly ILogService<CacheService> logService;

        public CacheService(IMatchProvider matchProvider, IBetListProvider betListProvider,
            ITournamentProvider tournamentProvider, ISportProvider sportProvider, ILogService<CacheService> logService)
        {
            if (matchProvider == null || betListProvider == null || tournamentProvider == null || sportProvider == null)
            {
                throw new ArgumentNullException();
            }
            this.matchProvider = matchProvider;
            this.betListProvider = betListProvider;
            this.tournamentProvider = tournamentProvider;
            this.sportProvider = sportProvider;
            if (logService == null)
            {
                this.logService = new LogService<CacheService>();
            }
            else
            {
                this.logService = logService;                
            }
        }

        
        public void DeleteCache(string cacheKey)
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
            string cacheSortKey = sortCacheKey + sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cacheSortKey) as IReadOnlyList<Match>;           
            return matches;
        }

        public IReadOnlyList<Match> InsertCache(int sportId, string dateMatch, int status)
        {            
            string cacheSortKey = sortCacheKey + sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
            if (matches == null)
            {
                logService.LogError("CacheService method:InsertCache cacheKey: Sort is null");
                return null;
            }
            HttpRuntime.Cache.Insert(cacheSortKey, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            return matches;
        }

        public IReadOnlyList<Sport> GetCache()
        {            
            IReadOnlyList<Sport> sports = HttpRuntime.Cache.Get(sportCacheKey) as IReadOnlyList<Sport>;            
            return sports;
        }

        public IReadOnlyList<Sport> InsertCache()
        {
            IReadOnlyList<Sport> sports = sportProvider.GetSports();
            if (sports == null)
            {
                logService.LogError("CacheService method:InsertCache cacheKey: Sport is null");
                return null;
            }
            HttpRuntime.Cache.Insert(sportCacheKey, sports, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            return sports;
        }

        public IReadOnlyList<Tournament> GetCache(int sportId)
        {            
            string cacheTournamentKey = tournamentCacheKey + sportId.ToString();
            IReadOnlyList<Tournament> tournaments = HttpRuntime.Cache.Get(cacheTournamentKey) as IReadOnlyList<Tournament>;            
            return tournaments;
        }

        public IReadOnlyList<Tournament> InsertCache(int sportId)
        {
            string cacheTournamentKey = tournamentCacheKey + sportId.ToString();
            IReadOnlyList<Tournament> tournaments = tournamentProvider.GetTournament(sportId);
            if (tournaments == null)
            {
                logService.LogError("CacheService method:InsertCache cacheKey: Tournament is null");
                return null;
            }
            HttpRuntime.Cache.Insert(cacheTournamentKey, tournaments, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            return tournaments;
        }

        public IReadOnlyList<Match> GetCache(int sportId, int tournamentId)
        {           
            string cacheNavigateKey = navigateCacheKey + sportId.ToString() +  tournamentId.ToString();
            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cacheNavigateKey) as IReadOnlyList<Match>;            
            return matches;
        }

        public IReadOnlyList<Match> InsertCache(int sportId, int tournamentId)
        {            
            string cacheNavigateKey = navigateCacheKey + sportId.ToString() + tournamentId.ToString();
            IReadOnlyList<Match> matches = betListProvider.GetBetList(sportId, tournamentId);
            if (matches == null)
            {
                logService.LogError("CacheService method:InsertCache cacheKey: Navigate is null");
                return null;
            }
            HttpRuntime.Cache.Insert(cacheNavigateKey, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            return matches;
        }
    }
}
