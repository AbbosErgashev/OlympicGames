using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model
{
    public class Year
    {
        public int Id { get; set; }
        [MaxLength(4, ErrorMessage = "YearNumber must be 4 characters or less")]
        public required int YearNumber { get; set; }
    }
}