namespace OlympicGames.Model
{
    public class Competition
    {
        public int Id { get; set; }
        public int GameId {  get; set; }
        public required DateTime StartDateTime { get; set; }
        public int OlympicEventId { get; set; }
        public int AreaId { get; set; }
        public int AthleteId { get; set; }
        public int MeladId { get; set; }
        public required string Image {  get; set; }
        public string Video { get; set; } = string.Empty;
        public List<Game> Game { get; set; }
        public List<OlympicEvent> OlympicEvent { get; set; }
        public List<Area> Area { get; set; }
        public List<Athlete> Athlete { get; set; }
        public List<Medal> Medal { get; set; }
    }
}
