function TournamentChange() {   
   
    var tournamentId = $('#TournamentId').val();
    if (tournamentId == null) {
        tournamentId = 0;
    }
    $.ajax({
        type: 'GET',
        url: '/Match/MatchesByTournament?tournamentId=' + tournamentId,        
        success: function (data) {            
            $('#teams').replaceWith(data);
        }
    });
}