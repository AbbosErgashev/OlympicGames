using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IYearRepository
    {
        PagedResult<YearViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<YearViewModel> GetAllYearList();
        YearViewModel GetByIdYear(int id);
        Task AddYear(YearViewModel model);
        Task UpdateYear(YearViewModel model);
        void DeleteYear(int id);
    }
}
