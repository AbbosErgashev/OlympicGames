using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IGameRepository
    {
        IEnumerable<GameViewModel> GetAllGameList();
        GameViewModel GetByIdGame(int id);
        Task AddGame(GameViewModel model);
        Task UpdateGame(GameViewModel model);
        void DeleteGame(int id);
    }
}
