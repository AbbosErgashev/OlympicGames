using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AthleteRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAthlete(AthleteViewModel model)
        {
            var add = new AthleteViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Athlete>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteAthlete(int id)
        {
            var delete = _unitOfWork.GenericRepository<Athlete>().GetById(id);
            _unitOfWork.GenericRepository<Athlete>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<AthleteViewModel> GetAllAthleteList()
        {
            var getAll = _unitOfWork.GenericRepository<Athlete>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(getAll);
            return vmList;
        }

        public AthleteViewModel GetByIdAthlete(int id)
        {
            var getById = _unitOfWork.GenericRepository<Athlete>().GetById(id);
            var vmId = new AthleteViewModel(getById);
            return vmId;
        }

        public Task UpdateAthlete(AthleteViewModel model)
        {
            var update = new AthleteViewModel().ConvertViewModel(model);
            var getById = _unitOfWork.GenericRepository<Athlete>().GetById(update.Id);
            getById.Id = update.Id;
            getById.FirstName = update.FirstName;
            getById.LastName = update.LastName;
            getById.DOB = update.DOB;
            getById.CountryId = update.CountryId;
            getById.GameId = update.GameId;
            getById.ProfileImage = update.ProfileImage;
            getById.Country = update.Country;
            getById.Game = update.Game;

            _unitOfWork.GenericRepository<Athlete>().Update(getById);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }


        private List<AthleteViewModel> ConvertModelToViewModelList(List<Athlete> modelList)
        {
            var vmList = modelList.Select(list => new AthleteViewModel(list)).ToList();
            return vmList;
        }

        PagedResult<AthleteViewModel> IAthleteRepository.GetAll(int pageNumber, int pageSize)
        {
            var vm = new AthleteViewModel();
            int totalCount;
            List<AthleteViewModel> vmList = new List<AthleteViewModel>();
            try
            {
                int ExcludeRecords = (pageSize - pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Athlete>().GetAll(includeProperties: "Country")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                var modelListTwo = _unitOfWork.GenericRepository<Athlete>().GetAll(includePropertiesTwo: "Game")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Athlete>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
                vmList = ConvertModelToViewModelList(modelListTwo);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<AthleteViewModel>
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
