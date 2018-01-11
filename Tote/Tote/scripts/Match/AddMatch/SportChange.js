﻿function SportChange() {
    var sportId = $('#SportId').val();
    $.ajax({
        type: 'GET',
        url: '/Match/TournamentesBySport?sportId=' + sportId,
        success: function (data) {
            $('#tournamentId').replaceWith(data).change();
            var tournamentId = $('#TournamentId').val();
            if (tournamentId == null)
            {
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
    });

}