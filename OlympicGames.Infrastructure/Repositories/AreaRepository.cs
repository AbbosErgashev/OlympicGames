using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AreaRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddArea(AreaViewModel model)
        {
            var add = new AreaViewModel().ConvertToViewModel(model);
            _unitOfWork.GenericRepository<Area>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteArea(int id)
        {
            var delete = _unitOfWork.GenericRepository<Area>().GetById(id);
            _unitOfWork.GenericRepository<Area>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<AreaViewModel> GetAllAreaList()
        {
            var getAll = _unitOfWork.GenericRepository<Area>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(getAll);
            return vmList;
        }

        public AreaViewModel GetByIdArea(int id)
        {
            var getById = _unitOfWork.GenericRepository<Area>().GetById(id);
            var vmById = new AreaViewModel(getById);
            return vmById;
        }

        public Task UpdateArea(AreaViewModel model)
        {
            var update = new AreaViewModel().ConvertToViewModel(model);
            var getById = _unitOfWork.GenericRepository<Area>().GetById(model.Id);
            getById.Id = model.Id;
            getById.Name = model.Name;
            getById.CountryId = model.CountryId;
            getById.Country = model.Country;

            _unitOfWork.GenericRepository<Area>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<AreaViewModel> ConvertModelToViewModelList(List<Area> modelList)
        {
            return modelList.Select(x => new AreaViewModel(x)).ToList();
        }
    }
}
