function TournamentChange() {
    var tournamentId = $('#TournamentId').val();
    $.ajax({
        type: 'GET',
        url: '/Match/MatchesByTournament?tournamentId=' + tournamentId,
        success: function (data) {
            $('#teams').replaceWith(data);
        }
    });
}