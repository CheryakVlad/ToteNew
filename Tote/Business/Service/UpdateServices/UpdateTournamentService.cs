using System;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateTournamentService : IUpdateTournamentService
    {
        private readonly ITournamentClient tournamentClient;
        private readonly ILogService<UpdateTournamentService> logService;
        public UpdateTournamentService(ITournamentClient tournamentClient, ILogService<UpdateTournamentService> logService)
        {
            if (tournamentClient == null)
            {
                throw new ArgumentNullException();
            }
            this.tournamentClient = tournamentClient;
            if (logService == null)
            {
                this.logService = new LogService<UpdateTournamentService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public bool AddTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                logService.LogError("Class: UpdateTournamentService Method: AddTournament  Tournament don't add to DB");
                return false;
            }
            return tournamentClient.AddTournament(tournament);
        }

        public bool DeleteTournament(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: UpdateTournamentService Method: DeleteTournament  Tournament don't delete from DB");
                return false;
            }
            return tournamentClient.DeleteTournament(tournamentId);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                logService.LogError("Class: UpdateTournamentService Method: UpdateTournament  Tournament don't update to DB");
                return false;
            }
            return tournamentClient.UpdateTournament(tournament);
        }
    }
}
