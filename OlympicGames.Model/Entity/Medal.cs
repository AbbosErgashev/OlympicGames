using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model.Entity
{
    public class Medal
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less")]
        public required string Name { get; set; }
    }
}