using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface ICountryRepository
    {
        PagedResult<CountryViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<CountryViewModel> GetAllCountryList();
        CountryViewModel GetByIdCountry(int id);
        Task AddCountry(CountryViewModel model);
        Task UpdateCountry(CountryViewModel model);
        void DeleteCountry(int id);
    }
}
