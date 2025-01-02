using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model.Entity
{
    public class Area
    {
        public int Id { get; set; }
        [MaxLength(250, ErrorMessage = "Name must be 250 characters or less")]
        public required string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}