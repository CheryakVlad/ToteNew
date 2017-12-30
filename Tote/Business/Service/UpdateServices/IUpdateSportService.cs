using Common.Models;

namespace Business.Service
{
    public interface IUpdateSportService
    {
        bool UpdateSport(Sport sport);
        bool AddSport(Sport sport);
        bool DeleteSport(int sportId);
    }
}
