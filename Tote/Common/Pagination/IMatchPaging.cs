
using Common.Models;
using System.Collections.Generic;

namespace Common.Pagination
{
    public interface IMatchPaging
    {
        void SetMatches(IReadOnlyList<Match> matches);
        int GetPageCount();
        int GetCurrentPageIndex();        
        IReadOnlyList<Match> GetMatchesPaging(int currentPage, int maxRows);
    }
}
