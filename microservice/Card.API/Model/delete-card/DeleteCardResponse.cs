namespace Ordering.API.Model.order
{
    public class DeleteCardResponse
    {
        public DeleteCardResponse()
        {
            // intentionally left blank
        }

        public DeleteCardResponse(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
