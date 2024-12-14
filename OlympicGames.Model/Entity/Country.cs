using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model.Entity
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Name must be 100 characters or less")]
        public required string Name { get; set; }
    }
}
