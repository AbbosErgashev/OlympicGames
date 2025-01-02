using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IAreaRepository
    {
        PagedResult<AreaViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<AreaViewModel> GetAllAreaList();
        AreaViewModel GetByIdArea(int id);
        Task AddArea(AreaViewModel model);
        Task UpdateArea(AreaViewModel model);
        void DeleteArea(int id);
    }
}
