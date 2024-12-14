using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface ICountryRepository
    {
        IEnumerable<CountryViewModel> GetAllCountryList();
        CountryViewModel GetByIdCountry(int id);
        Task AddCountry(CountryViewModel model);
        Task UpdateCountry(CountryViewModel model);
        void DeleteCountry(int id);
    }
}
