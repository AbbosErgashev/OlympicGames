using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountryViewModel() { }

        public CountryViewModel(Country model)
        {
            Id = model.Id;
            Name = model.Name;
        }

        public Country ConvertViewModel(CountryViewModel model)
        {
            return new Country
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
