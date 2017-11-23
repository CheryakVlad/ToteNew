using System;
using System.Collections.Generic;

using Service.Contracts.Dto;

namespace Service.Contracts.Context
{
   public  class ToteContext
    {
        public List<SportDto> Sports { get; set; }
        public List<TournamentDto> Tournaments { get; set; }
        public List<CommandDto> Commands { get; set; }
        public List<MatchDto> Matches { get; set; }
        public List<TourDto> Tours { get; set; }
        public List<RateDto> Rates { get; set; }

        public ToteContext()
        {
            Sports = new List<SportDto>();
            Sports.Add(new SportDto { SportId = 1, Name = "Football" });
            Sports.Add(new SportDto { SportId = 2, Name = "Hockey" });
            Sports.Add(new SportDto { SportId = 3, Name = "Basketball" });

            Commands = new List<CommandDto>();
            Commands.Add(new CommandDto { CommandId = 1, Name = "AC Milan", SportId = 1 });
            Commands.Add(new CommandDto { CommandId = 2, Name = "Juventus", SportId = 1 });
            Commands.Add(new CommandDto { CommandId = 3, Name = "Napoli", SportId = 1 });
            Commands.Add(new CommandDto { CommandId = 4, Name = "Dinamo Minsk", SportId = 2 });
            Commands.Add(new CommandDto { CommandId = 5, Name = "AK Bars", SportId = 2 });
            Commands.Add(new CommandDto { CommandId = 6, Name = "Dinamo Riga", SportId = 2 });
            Commands.Add(new CommandDto { CommandId = 7, Name = "CSKA Moscow", SportId = 3 });
            Commands.Add(new CommandDto { CommandId = 8, Name = "Khimki", SportId = 3 });
            Commands.Add(new CommandDto { CommandId = 9, Name = "Bayern Munich", SportId = 1 });
            Commands.Add(new CommandDto { CommandId = 10, Name = "Real Madrid", SportId = 1 });

            Tournaments = new List<TournamentDto>();
            Tournaments.Add(new TournamentDto { TournamentId = 1, Name = "Seria A", SportId = 1 });
            Tournaments.Add(new TournamentDto { TournamentId = 2, Name = "Bundesliga", SportId = 1 });
            Tournaments.Add(new TournamentDto { TournamentId = 3, Name = "Spain Championship", SportId = 1 });
            Tournaments.Add(new TournamentDto { TournamentId = 4, Name = "Euroliga", SportId = 3 });
            Tournaments.Add(new TournamentDto { TournamentId = 5, Name = "KHL", SportId = 2 });
            Tournaments.Add(new TournamentDto { TournamentId = 6, Name = "Champions League", SportId = 1 });

            Tours = new List<TourDto>();
            Tours.Add(new TourDto { TourId = 1, Name = "The first tour" });
            Tours.Add(new TourDto { TourId = 2, Name = "The second tour" });
            Tours.Add(new TourDto { TourId = 3, Name = "The third tour" });
            Tours.Add(new TourDto { TourId = 4, Name = "The quarter-final" });

            Matches = new List<MatchDto>();
            Matches.Add(new MatchDto { MatchId = 1, CommandIdHome = 1, CommandIdGuest = 2, TournamentId = 1, TourId = 1, Date = new DateTime(2017, 09, 17, 21, 45, 0), Result = "0:2" });
            Matches.Add(new MatchDto { MatchId = 2, CommandIdHome = 3, CommandIdGuest = 2, TournamentId = 1, TourId = 2, Date = new DateTime(2017, 10, 12, 21, 45, 0), Result = "3:2" });
            Matches.Add(new MatchDto { MatchId = 3, CommandIdHome = 3, CommandIdGuest = 1, TournamentId = 1, TourId = 3, Date = new DateTime(2017, 11, 19, 22, 45, 0), Result = "" });
            Matches.Add(new MatchDto { MatchId = 4, CommandIdHome = 4, CommandIdGuest = 6, TournamentId = 5, TourId = 1, Date = new DateTime(2017, 09, 17, 16, 0, 0), Result = "3:2" });
            Matches.Add(new MatchDto { MatchId = 5, CommandIdHome = 5, CommandIdGuest = 4, TournamentId = 5, TourId = 3, Date = new DateTime(2017, 11, 21, 21, 0, 0), Result = "" });
            Matches.Add(new MatchDto { MatchId = 6, CommandIdHome = 7, CommandIdGuest = 8, TournamentId = 4, TourId = 4, Date = new DateTime(2017, 12, 18, 21, 10, 0), Result = "102:88" });
            Matches.Add(new MatchDto { MatchId = 7, CommandIdHome = 9, CommandIdGuest = 10, TournamentId = 6, TourId = 1, Date = new DateTime(2017, 09, 17, 21, 45, 0), Result = "2:2" });
            Matches.Add(new MatchDto { MatchId = 8, CommandIdHome = 10, CommandIdGuest = 9, TournamentId = 6, TourId = 3, Date = new DateTime(2017, 11, 22, 21, 45, 0), Result = "3:1" });

            Rates = new List<RateDto>();
            Rates.Add(new RateDto { RateId = 1, MatchId = 1, WinCommandHome = 1.5, WinCommandGuest = 3.12, Draw = 2.26 });
            Rates.Add(new RateDto { RateId = 2, MatchId = 2, WinCommandHome = 2.89, WinCommandGuest = 1.72, Draw = 1.96 });
            Rates.Add(new RateDto { RateId = 3, MatchId = 3, WinCommandHome = 1.32, WinCommandGuest = 2.46, Draw = 1.82 });
            Rates.Add(new RateDto { RateId = 4, MatchId = 5, WinCommandHome = 4.6, WinCommandGuest = 1.35, Draw = 2.37 });
            Rates.Add(new RateDto { RateId = 5, MatchId = 7, WinCommandHome = 1.57, WinCommandGuest = 2.12, Draw = 3.52 });
            Rates.Add(new RateDto { RateId = 6, MatchId = 8, WinCommandHome = 1.34, WinCommandGuest = 2.68, Draw = 1.98 });
        }
    }
}
