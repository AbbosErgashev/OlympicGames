using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.ViewModels
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DateTime StartDateTime { get; set; }
        public int OlympicEventId { get; set; }
        public int AreaId { get; set; }
        public int AthleteId { get; set; }
        public int MedalId { get; set; }
        public string Image { get; set; }
        public string Video { get; set; } = string.Empty;
        public List<Game> Game { get; set; }
        public List<OlympicEvent> OlympicEvent { get; set; }
        public List<Area> Area { get; set; }
        public List<Athlete> Athlete { get; set; }
        public List<Medal> Medal { get; set; }

        public CompetitionViewModel() { }

        public CompetitionViewModel(Competition model)
        {
            Id = model.Id;
            GameId = model.GameId;
            StartDateTime = model.StartDateTime;
            OlympicEventId = model.OlympicEventId;
            AreaId = model.AreaId;
            AthleteId = model.AthleteId;
            MedalId = model.MeladId;
            Image = model.Image;
            Video = model.Video;
            Game = model.Game;
            OlympicEvent = model.OlympicEvent;
            Area = model.Area;
            Athlete = model.Athlete;
            Medal = model.Medal;
        }

        public Competition ConvertViewModel(CompetitionViewModel model)
        {
            return new Competition
            {
                Id = model.Id,
                GameId = model.GameId,
                StartDateTime = model.StartDateTime,
                OlympicEventId = model.OlympicEventId,
                AreaId = model.AreaId,
                AthleteId = model.AthleteId,
                MeladId = model.MedalId,
                Image = model.Image,
                Video = model.Video,
                Game = model.Game,
                OlympicEvent = model.OlympicEvent,
                Area = model.Area,
                Athlete = model.Athlete,
                Medal = model.Medal
            };
        }
    }
}
