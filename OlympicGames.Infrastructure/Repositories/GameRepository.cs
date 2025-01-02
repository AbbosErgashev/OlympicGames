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
            if (delete == null)
            {
                throw new Exception($"Game with ID {id} was not found for deletion.");
            }
            _unitOfWork.GenericRepository<Game>().Delete(delete);
            _unitOfWork.Save();
        }


        public IEnumerable<GameViewModel> GetAllGameList()
        {
            var getAll = _unitOfWork.GenericRepository<Game>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(getAll);
            return vmList;
        }

        public GameViewModel GetByIdGame(int id)
        {
            var getById = _unitOfWork.GenericRepository<Game>().GetById(id);
            if (getById == null)
            {
                throw new Exception($"Game with ID {id} was not found.");
            }
            var vmId = new GameViewModel(getById);
            return vmId;
        }


        public Task UpdateGame(GameViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "GameViewModel cannot be null.");
            }

            var update = new GameViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<Game>().GetById(update.Id);
            if (getById == null)
            {
                throw new Exception($"Game with ID {update.Id} was not found for update.");
            }

            getById.Id = update.Id;
            getById.Name = update.Name;

            _unitOfWork.GenericRepository<Game>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }


        private List<GameViewModel> ConvertModelToViewModelList(List<Game> modelList)
        {
            var list = modelList.Select(x => new GameViewModel(x)).ToList();
            return list;
        }

        PagedResult<GameViewModel> IGameRepository.GetAll(int pageNumber, int pageSize)
        {
            var vm = new GameViewModel();
            int totalCount;
            List<GameViewModel> vmList = new List<GameViewModel>();
            try
            {
                int ExcludeRecords = (pageSize - pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Game>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Game>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<GameViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
    }
}
