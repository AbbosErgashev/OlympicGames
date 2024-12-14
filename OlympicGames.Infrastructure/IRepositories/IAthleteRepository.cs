using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IAthleteRepository
    {
        IEnumerable<AthleteViewModel> GetAllAthleteList();
        AthleteViewModel GetByIdAthlete(int id);
        Task AddAthlete(AthleteViewModel model);
        Task UpdateAthlete(AthleteViewModel model);
        void DeleteAthlete(int id);
    }
}
