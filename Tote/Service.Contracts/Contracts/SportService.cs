using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts.Dto;
using Service.Contracts.Context;

namespace Service.Contracts.Contracts
{
    public class SportService : ISportService
    {
        private readonly ToteContext db;
        public SportDto GetSport(int? id)
        {
            var selectedSport = from sport in db.Sports
                                where sport.SportId == id
                                select sport;
            return selectedSport.First();
        }

        public IEnumerable<SportDto> GetSports()
        {
            return db.Sports;
        }
    }
}
