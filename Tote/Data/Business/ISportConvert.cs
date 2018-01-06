
using Common.Models;
using Data.ToteService;
using System.Collections.Generic;

namespace Data.Business
{
    public interface ISportConvert
    {
        Sport ToSport(SportDto sportDto);
        IReadOnlyList<Sport> ToSport(IReadOnlyList<SportDto> sportsDto);
        SportDto ToSportDto(Sport sport);
        
    }
}
