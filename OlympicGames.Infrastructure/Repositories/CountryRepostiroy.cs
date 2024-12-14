using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class CountryRepostiroy : ICountryRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryRepostiroy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddCountry(CountryViewModel model)
        {
            var add = new CountryViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Country>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteCountry(int id)
        {
            var delete = _unitOfWork.GenericRepository<Country>().GetById(id);
            _unitOfWork.GenericRepository<Country>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<CountryViewModel> GetAllCountryList()
        {
            var getAlll = _unitOfWork.GenericRepository<Country>().GetAll().ToList();
            var convert = ConvertModelToViewModelList(getAlll);
            return convert;
        }

        public CountryViewModel GetByIdCountry(int id)
        {
            var get = _unitOfWork.GenericRepository<Country>().GetById(id);
            var convert = new CountryViewModel(get);
            return convert;
        }

        public Task UpdateCountry(CountryViewModel model)
        {
            var get = new CountryViewModel().ConvertViewModel(model);
            var update = _unitOfWork.GenericRepository<Country>().GetById(model.Id);
            update.Id = model.Id;
            update.Name = model.Name;
            _unitOfWork.GenericRepository<Country>().Update(update);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<CountryViewModel> ConvertModelToViewModelList(List<Country> list)
        {
            var vmList = list.Select(x => new CountryViewModel(x)).ToList();
            return vmList;
        }
    }
}
