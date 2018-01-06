using Common.Models;
using Data.ToteService;
using System.Collections.Generic;

namespace Data.Business
{
    public class SportConvert:ISportConvert
    {
        public Sport ToSport(SportDto sportDto)
        {
            if (sportDto == null)
            {
                return null;
            }
            var sport = new Sport
            {
                SportId = sportDto.SportId,
                Name = sportDto.Name
            };

            return sport;
        }

        public IReadOnlyList<Sport> ToSport(IReadOnlyList<SportDto> sportsDto)
        {
            if (sportsDto.Count == 0)
            {
                return null;
            }
            var sports = new List<Sport>();
            foreach (var sportDto in sportsDto)
            {
                sports.Add(ToSport(sportDto));
            }

            return sports;
        }

        public SportDto ToSportDto(Sport sport)
        {
            if (sport == null)
            {
                return null;
            }
            var sportDto = new SportDto
            {
                SportId = sport.SportId,
                Name = sport.Name
            };

            return sportDto;
        }
    }
}
