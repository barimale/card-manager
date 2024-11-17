namespace card_manager_ui.Model
{
    public class RegisterCardResult
    {
        public RegisterCardResult()
        {
            // intentionally left blank
        }

        public RegisterCardResult(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
