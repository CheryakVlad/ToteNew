using System.Collections.Generic;
using Common.Models;
namespace Data.Business
{
    public interface IConvert
    {
        IReadOnlyList<Bet> ToBetsList(IReadOnlyList<ToteService.BetListDto> betsListDto);
        IReadOnlyList<Sport> ToSport(IReadOnlyList<ToteService.SportDto> sportsDto);
        IReadOnlyList<Tournament> ToTournament(IReadOnlyList<ToteService.TournamentDto> tournamentsDto);
        Sport ToSport(ToteService.SportDto sportDto);

        IReadOnlyList<Event> ToEvents(IReadOnlyList<ToteService.EventDto> eventsDto);

        IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto);

        IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto,IReadOnlyList<ToteService.EventDto> eventsDto );

        IReadOnlyList<User> ToUsers(IReadOnlyList<UserService.UserDto> usersDto);

        User ToUser(UserService.UserDto userDto);
        IReadOnlyList<Role> ToRoles(IReadOnlyList<UserService.RoleDto> rolesDto);

        UserService.UserDto ToUserDto(User user);

        ToteService.SportDto ToSportDto(Sport sport);

        TeamService.TeamDto ToTeamDto(Team team);
        Team ToTeam(TeamService.TeamDto teamDto);
        IReadOnlyList<Team> ToTeams(IReadOnlyList<TeamService.TeamDto> teamsDto);
        Tournament ToTournament(ToteService.TournamentDto tournamentDto);
        ToteService.TournamentDto ToTournamentDto(Tournament tournament);
        IReadOnlyList<Country> ToCountry(IReadOnlyList<TeamService.CountryDto> countriesDto);

        Basket ToBasket(ToteService.BasketDto basketDto);
        IReadOnlyList<Basket> ToBasket(IReadOnlyList<ToteService.BasketDto> basketsDto);
        ToteService.BasketDto ToBasketDto(Basket basket);

        Rate ToRate(ToteService.RateDto rateDto);
        IReadOnlyList<Rate> ToRate(IReadOnlyList<ToteService.RateDto> ratesDto);

        Bet ToBet(ToteService.BetDto betDto);
        IReadOnlyList<Bet> ToBet(IReadOnlyList<ToteService.BetDto> betsDto);

        ToteService.BetDto ToBetDto(Bet bet);

        ToteService.RateDto ToRateDto(Rate rate);

    }
}
