using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class MedalRepository : IMedalRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedalRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddMedal(MedalViewModel model)
        {
            var add = new MedalViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Medal>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteMedal(int id)
        {
            var delete = _unitOfWork.GenericRepository<Medal>().GetById(id);
            _unitOfWork.GenericRepository<Medal>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<MedalViewModel> GetAllMedalList()
        {
            var getAll = _unitOfWork.GenericRepository<Medal>().GetAll().ToList();
            var vmList = ConvertModelToViewModellist(getAll);
            return vmList;
        }

        public MedalViewModel GetByIdMedal(int id)
        {
            var getById = _unitOfWork.GenericRepository<Medal>().GetById(id);
            var vmId = new MedalViewModel(getById);
            return vmId;
        }

        public Task UpdateMedal(MedalViewModel model)
        {
            var update = new MedalViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<Medal>().GetById(update.Id);
            getById.Id = update.Id;
            getById.Name = update.Name;

            _unitOfWork.GenericRepository<Medal>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<MedalViewModel> ConvertModelToViewModellist(List<Medal> modelList)
        {
            var list = modelList.Select(x => new MedalViewModel(x)).ToList();
            return list;
        }
    }
}
