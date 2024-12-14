using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class YearViewModel
    {
        public int Id { get; set; }
        public int YearNumber { get; set; }

        public YearViewModel() { }

        public YearViewModel(Year model)
        {
            Id = model.Id;
            YearNumber = model.YearNumber;
        }

        public Year ConvertViewModel(YearViewModel model)
        {
            return new Year
            {
                Id = model.Id,
                YearNumber = model.YearNumber
            };
        }
    }
}
