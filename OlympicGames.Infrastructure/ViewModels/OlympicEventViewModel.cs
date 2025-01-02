using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class OlympicEventViewModel
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int CountryId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<Year> Year { get; set; }
        public List<Country> Country { get; set; }

        public OlympicEventViewModel() { }

        public OlympicEventViewModel(OlympicEvent model)
        {
            Id = model.Id;
            YearId = model.YearId;
            CountryId = model.CountryId;
            StartDateTime = model.StartDateTime;
            EndDateTime = model.EndDateTime;
            Year = model.Year;
            Country = model.Country;
        }

        public OlympicEvent ConvertViewModel(OlympicEventViewModel model)
        {
            return new OlympicEvent
            {
                Id = model.Id,
                YearId = model.YearId,
                CountryId = model.CountryId,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Year = model.Year,
                Country = model.Country
            };
        }
    }
}
