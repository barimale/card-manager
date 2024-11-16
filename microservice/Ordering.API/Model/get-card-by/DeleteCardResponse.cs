namespace Ordering.API.Model.order
{
    public class GetCardResponse
    {
        public GetCardResponse()
        {
            // intentionally left blank
        }

        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public int SerialNumber { get; set; }
        public int PIN { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
