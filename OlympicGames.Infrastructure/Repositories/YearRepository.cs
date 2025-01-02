using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class YearRepository : IYearRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public YearRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddYear(YearViewModel model)
        {
            var add = new YearViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Year>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteYear(int id)
        {
            var delete = _unitOfWork.GenericRepository<Year>().GetById(id);
            _unitOfWork.GenericRepository<Year>().Delete(delete);
            _unitOfWork.Save();
        }

        public PagedResult<YearViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new YearViewModel();
            int totalCount;
            List<YearViewModel> vmlist = new List<YearViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Year>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Year>().GetAll().ToList().Count;

                vmlist = ConvertModelToViewModellist(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<YearViewModel>
            {
                Data = vmlist,
                TotalItems = vmlist.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public IEnumerable<YearViewModel> GetAllYearList()
        {
            var getAll = _unitOfWork.GenericRepository<Year>().GetAll().ToList();
            var vmList = ConvertModelToViewModellist(getAll);
            return vmList;
        }

        public YearViewModel GetByIdYear(int id)
        {
            var getById = _unitOfWork.GenericRepository<Year>().GetById(id);
            var vmId = new YearViewModel(getById);
            return vmId;
        }

        public Task UpdateYear(YearViewModel model)
        {
            var update = new YearViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<Year>().GetById(update.Id);
            getById.Id = update.Id;
            getById.YearNumber = update.YearNumber;

            _unitOfWork.GenericRepository<Year>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<YearViewModel> ConvertModelToViewModellist(List<Year> modelList)
        {
            var list = modelList.Select(x => new YearViewModel(x)).ToList();
            return list;
        }
    }
}
