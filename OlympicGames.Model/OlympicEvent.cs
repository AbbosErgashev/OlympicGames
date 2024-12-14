namespace OlympicGames.Model
{
    public class OlympicEvent
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}