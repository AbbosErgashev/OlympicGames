using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IAthleteRepository
    {
        PagedResult<AthleteViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<AthleteViewModel> GetAllAthleteList();
        AthleteViewModel GetByIdAthlete(int id);
        Task AddAthlete(AthleteViewModel model);
        Task UpdateAthlete(AthleteViewModel model);
        void DeleteAthlete(int id);
    }
}
