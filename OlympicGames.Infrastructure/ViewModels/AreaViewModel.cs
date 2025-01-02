using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class AreaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public AreaViewModel() { }

        public AreaViewModel(Area model)
        {
            Id = model.Id;
            Name = model.Name;
            CountryId = model.CountryId;
            Country = model.Country;
        }

        public Area ConvertToViewModel(AreaViewModel model)
        {
            return new Area
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId,
                Country = model.Country
            };
        }
    }
}
