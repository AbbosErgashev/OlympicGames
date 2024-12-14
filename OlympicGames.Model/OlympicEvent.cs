namespace OlympicGames.Model
{
    public class OlympicEvent
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int CountryId { get; set; }
        public required DateTime StartDateTime { get; set; }
        public required DateTime EndDateTime { get; set; }
        public List<Year> Year { get; set; }
        public List<Country> Country { get; set; }
    }
}