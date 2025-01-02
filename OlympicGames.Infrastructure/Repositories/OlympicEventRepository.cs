using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class OlympicEventRepository : IOlympicEventRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public OlympicEventRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOlympicEvent(OlympicEventViewModel model)
        {
            var add = new OlympicEventViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<OlympicEvent>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteOlympicEvent(int id)
        {
            var delete = _unitOfWork.GenericRepository<OlympicEvent>().GetById(id);
            _unitOfWork.GenericRepository<OlympicEvent>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<OlympicEventViewModel> GetAllOlympicEventList()
        {
            var getAll = _unitOfWork.GenericRepository<OlympicEvent>().GetAll().ToList();
            var vmList = ConvertModelToViewModellist(getAll);
            return vmList;
        }

        public OlympicEventViewModel GetByIdOlympicEvent(int id)
        {
            var getById = _unitOfWork.GenericRepository<OlympicEvent>().GetById(id);
            var vmId = new OlympicEventViewModel(getById);
            return vmId;
        }

        public Task UpdateOlympicEvent(OlympicEventViewModel model)
        {
            var update = new OlympicEventViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<OlympicEvent>().GetById(update.Id);
            getById.Id = update.Id;
            getById.YearId = update.YearId;
            getById.CountryId = update.CountryId;
            getById.StartDateTime = update.StartDateTime;
            getById.EndDateTime = update.EndDateTime;
            getById.Year = update.Year;
            getById.Country = update.Country;

            _unitOfWork.GenericRepository<OlympicEvent>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<OlympicEventViewModel> ConvertModelToViewModellist(List<OlympicEvent> modelList)
        {
            var list = modelList.Select(x => new OlympicEventViewModel(x)).ToList();
            return list;
        }
    }
}
