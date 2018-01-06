using System;
using System.Collections.Generic;
using Common.Models;
using System.Linq;

namespace Common.Pagination
{
    public class MatchPaging : IMatchPaging
    {
        private int currentPageIndex;
        private int pageCount;
        private IReadOnlyList<Match> matches;

        public void SetMatches(IReadOnlyList<Match> matches)
        {
            this.matches = matches;
        }
        public int GetPageCount()
        {
            return pageCount;
        }

        public int GetCurrentPageIndex()
        {
            return currentPageIndex;
        }
        
        public IReadOnlyList<Match> GetMatchesPaging(int currentPage, int maxRows)
        {
            if(currentPage <= 0 || maxRows <= 0)
            {
                return null;
            }            
            IReadOnlyList<Match> currentMatches = (from match in matches
                                                   select match)                        
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pagesCount = (double)((decimal)matches.Count / Convert.ToDecimal(maxRows));
            this.pageCount = (int)Math.Ceiling(pagesCount);
            currentPageIndex = currentPage;

            return currentMatches;
        }
    }
}
