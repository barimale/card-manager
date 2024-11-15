namespace card_manager_ui.Services
{
    public interface IStarWarsService
    {
        ValueTask<dynamic> GetPeople(string peopleId);
        ValueTask<dynamic> GetPlanet(string planetId);
        ValueTask<dynamic> GetSpecies(string speciesId);
    }
}
