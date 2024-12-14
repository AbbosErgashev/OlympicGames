using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class MedalViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public MedalViewModel() { }

        public MedalViewModel(Medal model)
        {
            Id = model.Id;
            Name = model.Name;
        }

        public Medal ConvertViewModel(MedalViewModel model)
        {
            return new Medal
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
