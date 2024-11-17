using card_manager_ui.Model;

namespace card_manager_ui.Services
{
    public partial class DataHttpClient
    {
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
    }
}
