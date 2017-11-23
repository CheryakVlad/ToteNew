using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using Service.Contracts.Context;
using System;

namespace Service.Contracts.Contracts
{
    public class RateListService : IRateListService
    {
        private List<SportDto> sports;
        private List<TournamentDto> tournaments;
        private List<CommandDto> commands;
        private List<MatchDto> matches;
        private List<TourDto> tours;
        private List<RateDto> rates;

        public RateListService()
        {            


            sports = new List<SportDto>();
            sports.Add(new SportDto { SportId = 1, Name = "Football" });
            sports.Add(new SportDto { SportId = 2, Name = "Hockey" });
            sports.Add(new SportDto { SportId = 3, Name = "Basketball" });

            commands = new List<CommandDto>();
            commands.Add(new CommandDto { CommandId = 1, Name = "AC Milan", SportId = 1 });
            commands.Add(new CommandDto { CommandId = 2, Name = "Juventus", SportId = 1 });
            commands.Add(new CommandDto { CommandId = 3, Name = "Napoli", SportId = 1 });
            commands.Add(new CommandDto { CommandId = 4, Name = "Dinamo Minsk", SportId = 2 });
            commands.Add(new CommandDto { CommandId = 5, Name = "AK Bars", SportId = 2 });
            commands.Add(new CommandDto { CommandId = 6, Name = "Dinamo Riga", SportId = 2 });
            commands.Add(new CommandDto { CommandId = 7, Name = "CSKA Moscow", SportId = 3 });
            commands.Add(new CommandDto { CommandId = 8, Name = "Khimki", SportId = 3 });
            commands.Add(new CommandDto { CommandId = 9, Name = "Bayern Munich", SportId = 1 });
            commands.Add(new CommandDto { CommandId = 10, Name = "Real Madrid", SportId = 1 });

            tournaments = new List<TournamentDto>();
            tournaments.Add(new TournamentDto { TournamentId = 1, Name = "Seria A", SportId = 1 });
            tournaments.Add(new TournamentDto { TournamentId = 2, Name = "Bundesliga", SportId = 1 });
            tournaments.Add(new TournamentDto { TournamentId = 3, Name = "Spain Championship", SportId = 1 });
            tournaments.Add(new TournamentDto { TournamentId = 4, Name = "Euroliga", SportId = 3 });
            tournaments.Add(new TournamentDto { TournamentId = 5, Name = "KHL", SportId = 2 });
            tournaments.Add(new TournamentDto { TournamentId = 6, Name = "Champions League", SportId = 1 });

            tours = new List<TourDto>();
            tours.Add(new TourDto { TourId = 1, Name = "The first tour" });
            tours.Add(new TourDto { TourId = 2, Name = "The second tour" });
            tours.Add(new TourDto { TourId = 3, Name = "The third tour" });
            tours.Add(new TourDto { TourId = 4, Name = "The quarter-final" });

            matches = new List<MatchDto>();
            matches.Add(new MatchDto { MatchId = 1, CommandIdHome = 1, CommandIdGuest = 2, TournamentId = 1, TourId = 1, Date = new DateTime(2017, 09, 17, 21, 45, 0), Result = "0:2" });
            matches.Add(new MatchDto { MatchId = 2, CommandIdHome = 3, CommandIdGuest = 2, TournamentId = 1, TourId = 2, Date = new DateTime(2017, 10, 12, 21, 45, 0), Result = "3:2" });
            matches.Add(new MatchDto { MatchId = 3, CommandIdHome = 3, CommandIdGuest = 1, TournamentId = 1, TourId = 3, Date = new DateTime(2017, 11, 19, 22, 45, 0), Result = "" });
            matches.Add(new MatchDto { MatchId = 4, CommandIdHome = 4, CommandIdGuest = 6, TournamentId = 5, TourId = 1, Date = new DateTime(2017, 09, 17, 16, 0, 0), Result = "3:2" });
            matches.Add(new MatchDto { MatchId = 5, CommandIdHome = 5, CommandIdGuest = 4, TournamentId = 5, TourId = 3, Date = new DateTime(2017, 11, 21, 21, 0, 0), Result = "" });
            matches.Add(new MatchDto { MatchId = 6, CommandIdHome = 7, CommandIdGuest = 8, TournamentId = 4, TourId = 4, Date = new DateTime(2017, 12, 18, 21, 10, 0), Result = "102:88" });
            matches.Add(new MatchDto { MatchId = 7, CommandIdHome = 9, CommandIdGuest = 10, TournamentId = 6, TourId = 1, Date = new DateTime(2017, 09, 17, 21, 45, 0), Result = "2:2" });
            matches.Add(new MatchDto { MatchId = 8, CommandIdHome = 10, CommandIdGuest = 9, TournamentId = 6, TourId = 3, Date = new DateTime(2017, 11, 22, 21, 45, 0), Result = "3:1" });

            rates = new List<RateDto>();
            rates.Add(new RateDto { RateId = 1, MatchId = 1, WinCommandHome = 1.5, WinCommandGuest = 3.12, Draw = 2.26 });
            rates.Add(new RateDto { RateId = 2, MatchId = 2, WinCommandHome = 2.89, WinCommandGuest = 1.72, Draw = 1.96 });
            rates.Add(new RateDto { RateId = 3, MatchId = 3, WinCommandHome = 1.32, WinCommandGuest = 2.46, Draw = 1.82 });
            rates.Add(new RateDto { RateId = 4, MatchId = 5, WinCommandHome = 4.6, WinCommandGuest = 1.35, Draw = 2.37 });
            rates.Add(new RateDto { RateId = 5, MatchId = 7, WinCommandHome = 1.57, WinCommandGuest = 2.12, Draw = 3.52 });
            rates.Add(new RateDto { RateId = 6, MatchId = 8, WinCommandHome = 1.34, WinCommandGuest = 2.68, Draw = 1.98 });
        
    }

        public List<RateListDto> GetRates(int? sportId, int? tournamentId)
        {
            
            var rates = this.rates;            
            var sports = this.sports;            
            var commands = this.commands;
            var tournamentes = this.tournaments;
            var matches = this.matches;

            List<RateListDto> ratesList = new List<RateListDto>();

            if (sportId == null)
            {
                var models = from r in rates
                             join m in matches on r.MatchId equals m.MatchId
                             join cH in commands on m.CommandIdHome equals cH.CommandId
                             join cG in commands on m.CommandIdGuest equals cG.CommandId
                             join s in sports on cH.SportId equals s.SportId
                             select new
                             {
                                 RateId = r.RateId,
                                 MatchId = r.MatchId,
                                 WinCommandHome = r.WinCommandHome,
                                 WinCommandGuest = r.WinCommandGuest,
                                 Draw = r.Draw,
                                 CommandHome = cH.Name,
                                 CommandGuest = cG.Name,
                                 Date = m.Date
                             };

                foreach (var model in models)
                {
                    ratesList.Add(new RateListDto
                    {
                        RateId = model.RateId,
                        MatchId = model.MatchId,
                        WinCommandGuest = model.WinCommandGuest,
                        WinCommandHome = model.WinCommandHome,
                        Date = model.Date,
                        Draw = model.Draw,
                        CommandHome = model.CommandHome,
                        CommandGuest = model.CommandGuest
                    });
                }
            }
            else
            {
                if (tournamentId == null)
                {
                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SportId equals s.SportId
                                 where s.SportId == sportId
                                 select new
                                 {
                                     RateId = r.RateId,
                                     MatchId = r.MatchId,
                                     WinCommandHome = r.WinCommandHome,
                                     WinCommandGuest = r.WinCommandGuest,
                                     Draw = r.Draw,
                                     CommandHome = cH.Name,
                                     CommandGuest = cG.Name,
                                     Date = m.Date
                                 };

                    foreach (var model in models)
                    {
                        ratesList.Add(new RateListDto
                        {
                            RateId = model.RateId,
                            MatchId = model.MatchId,
                            WinCommandGuest = model.WinCommandGuest,
                            WinCommandHome = model.WinCommandHome,
                            Date = model.Date,
                            Draw = model.Draw,
                            CommandHome = model.CommandHome,
                            CommandGuest = model.CommandGuest
                        });
                    }
                }
                else
                {
                    var models = from r in rates
                                 join m in matches on r.MatchId equals m.MatchId
                                 join cH in commands on m.CommandIdHome equals cH.CommandId
                                 join cG in commands on m.CommandIdGuest equals cG.CommandId
                                 join s in sports on cH.SportId equals s.SportId
                                 join t in tournamentes on m.TournamentId equals t.TournamentId
                                 where t.TournamentId == tournamentId && s.SportId == sportId
                                 select new
                                 {
                                     RateId = r.RateId,
                                     MatchId = r.MatchId,
                                     WinCommandHome = r.WinCommandHome,
                                     WinCommandGuest = r.WinCommandGuest,
                                     Draw = r.Draw,
                                     CommandHome = cH.Name,
                                     CommandGuest = cG.Name,
                                     Date = m.Date
                                 };

                    foreach (var model in models)
                    {
                        ratesList.Add(new RateListDto
                        {
                            RateId = model.RateId,
                            MatchId = model.MatchId,
                            WinCommandGuest = model.WinCommandGuest,
                            WinCommandHome = model.WinCommandHome,
                            Date = model.Date,
                            Draw = model.Draw,
                            CommandHome = model.CommandHome,
                            CommandGuest = model.CommandGuest
                        });
                    }
                }
            }


            return ratesList;
        }

        public List<RateListDto> GetRatesAll()
        {
            var rates = this.rates;
            var sports = this.sports;
            var commands = this.commands;
            var tournamentes = this.tournaments;
            var matches = this.matches;

            List<RateListDto> ratesList = new List<RateListDto>();

            var models = from r in rates
                         join m in matches on r.MatchId equals m.MatchId
                         join cH in commands on m.CommandIdHome equals cH.CommandId
                         join cG in commands on m.CommandIdGuest equals cG.CommandId
                         join s in sports on cH.SportId equals s.SportId
                         select new
                         {
                             RateId = r.RateId,
                             MatchId = r.MatchId,
                             WinCommandHome = r.WinCommandHome,
                             WinCommandGuest = r.WinCommandGuest,
                             Draw = r.Draw,
                             CommandHome = cH.Name,
                             CommandGuest = cG.Name,
                             Date = m.Date
                         };

            foreach (var model in models)
            {
                ratesList.Add(new RateListDto
                {
                    RateId = model.RateId,
                    MatchId = model.MatchId,
                    WinCommandGuest = model.WinCommandGuest,
                    WinCommandHome = model.WinCommandHome,
                    Date = model.Date,
                    Draw = model.Draw,
                    CommandHome = model.CommandHome,
                    CommandGuest = model.CommandGuest
                });
            }

            return ratesList;
        }

        public SportDto GetSport(int? id)
        {
            var sports = this.sports;
            var sport = from s in sports
                        where s.SportId == id
                        select s;
            return sport.First();

        }

        public List<SportDto> GetSports()
        {
            return this.sports;
        }

        public List<TournamentDto> GetTournament(int? sportId)
        {
            var tournaments = this.tournaments;
            var tournament = from t in tournaments
                             where t.SportId == sportId
                        select t;
            List<TournamentDto> tournamentList= new List<TournamentDto>();
            foreach (var t in tournament)
            {
                tournamentList.Add(new TournamentDto
                {
                    TournamentId = t.TournamentId,
                    SportId=t.SportId,
                    Name=t.Name
                });
            }

            return tournamentList;
        }

        public List<TournamentDto> GetTournamentes()
        {
            return this.tournaments;
        }

       
    }
}
