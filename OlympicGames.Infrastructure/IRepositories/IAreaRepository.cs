using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IAreaRepository
    {
        IEnumerable<AreaViewModel> GetAllAreaList();
        AreaViewModel GetByIdArea(int id);
        Task AddArea(AreaViewModel model);
        Task UpdateArea(AreaViewModel model);
        void DeleteArea(int id);
    }
}
