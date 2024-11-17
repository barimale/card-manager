namespace card_manager_ui.Services
{
    public class RegisterCardResult
    {
        public RegisterCardResult()
        {
            // intentionally left blank
        }

        public RegisterCardResult(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
