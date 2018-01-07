using System.Collections.Generic;
using Common.Models;
namespace Data.Business
{
    public interface IConvert
    {
        IReadOnlyList<Bet> ToBetsList(IReadOnlyList<ToteService.BetListDto> betsListDto);
        IReadOnlyList<Event> ToEvents(IReadOnlyList<ToteService.EventDto> eventsDto);               
        
        Basket ToBasket(ToteService.BasketDto basketDto);
        IReadOnlyList<Basket> ToBasket(IReadOnlyList<ToteService.BasketDto> basketsDto);
        ToteService.BasketDto ToBasketDto(Basket basket);

        Rate ToRate(ToteService.RateDto rateDto);
        IReadOnlyList<Rate> ToRate(IReadOnlyList<ToteService.RateDto> ratesDto);
        ToteService.RateDto ToRateDto(Rate rate);

        Bet ToBet(ToteService.BetDto betDto);
        IReadOnlyList<Bet> ToBet(IReadOnlyList<ToteService.BetDto> betsDto);
        ToteService.BetDto ToBetDto(Bet bet);
    }
}
