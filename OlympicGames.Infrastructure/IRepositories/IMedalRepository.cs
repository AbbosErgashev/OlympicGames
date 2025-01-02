using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IMedalRepository
    {
        IEnumerable<MedalViewModel> GetAllMedalList();
        MedalViewModel GetByIdMedal(int id);
        Task AddMedal(MedalViewModel model);
        Task UpdateMedal(MedalViewModel model);
        void DeleteMedal(int id);
    }
}
