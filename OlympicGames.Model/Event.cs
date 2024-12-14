using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public int CountryId { get; set; }
        public List<Country> Country { get; set; }
    }
}