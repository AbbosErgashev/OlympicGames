using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddGame(GameViewModel model)
        {
            var add = new GameViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Game>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteGame(int id)
        {
            var delete = _unitOfWork.GenericRepository<Game>().GetById(id);
            _unitOfWork.GenericRepository<Game>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<GameViewModel> GetAllGameList()
        {
            var getAll = _unitOfWork.GenericRepository<Game>().GetAll().ToList();
            var vmList = ConvertModelToViewModellist(getAll);
            return vmList;
        }

        public GameViewModel GetByIdGame(int id)
        {
            var getById = _unitOfWork.GenericRepository<Game>().GetById(id);
            var vmId = new GameViewModel(getById);
            return vmId;
        }

        public Task UpdateGame(GameViewModel model)
        {
            var update = new GameViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<Game>().GetById(update.Id);
            getById.Id = update.Id;
            getById.Name = update.Name;

            _unitOfWork.GenericRepository<Game>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<GameViewModel> ConvertModelToViewModellist(List<Game> modelList)
        {
            var list = modelList.Select(x => new GameViewModel(x)).ToList();
            return list;
        }
    }
}
