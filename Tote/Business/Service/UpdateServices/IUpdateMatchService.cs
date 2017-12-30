using Common.Models;
using System.Collections.Generic;

namespace Business.Service
{
    public interface IUpdateMatchService
    {
        bool UpdateMatch(Match match);

        bool AddMatch(Match match);

        bool DeleteMatch(int matchId);

        bool UpdateEvent(Event[] events);

        bool AddEvent(IReadOnlyList<Event> events);

        bool DeleteEvent(int matchId);
    }
}
