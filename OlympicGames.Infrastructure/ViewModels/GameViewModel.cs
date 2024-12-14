using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GameViewModel() { }

        public GameViewModel(Game model)
        {
            Id = model.Id;
            Name = model.Name;
        }

        public Game ConvertViewModel(GameViewModel model)
        {
            return new Game
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
