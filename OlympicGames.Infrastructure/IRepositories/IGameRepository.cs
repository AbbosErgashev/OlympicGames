using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IGameRepository
    {
        PagedResult<GameViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<GameViewModel> GetAllGameList();
        GameViewModel GetByIdGame(int id);
        Task AddGame(GameViewModel model);
        Task UpdateGame(GameViewModel model);
        void DeleteGame(int id);
    }
}
