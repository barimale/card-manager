using Ordering.Application.Dtos;

namespace Ordering.Application.CQRS.Queries;

public class GetCardResult
{
    public GetCardResult()
    {
        //intentionally left blank
    }
    public GetCardResult(CardDto orders)
    {
        this.Card = orders;
    }
    
    public CardDto Card { get; set; }
}