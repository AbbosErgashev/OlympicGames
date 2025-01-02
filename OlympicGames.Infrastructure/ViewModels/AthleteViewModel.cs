using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class AthleteViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int CountryId { get; set; }
        public int GameId { get; set; }
        public string ProfileImage { get; set; }
        public Country Country { get; set; }
        public Game Game { get; set; }

        public AthleteViewModel() { }

        public AthleteViewModel(Athlete model)
        {
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            DOB = model.DOB;
            CountryId = model.CountryId;
            GameId = model.GameId;
            ProfileImage = model.ProfileImage;
            Country = model.Country;
            Game = model.Game;
        }

        public Athlete ConvertViewModel(AthleteViewModel model)
        {
            return new Athlete
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                CountryId = model.CountryId,
                GameId = model.GameId,
                ProfileImage = model.ProfileImage,
                Country = model.Country,
                Game = model.Game
            };
        }
    }
}
