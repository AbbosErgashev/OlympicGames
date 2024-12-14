using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Model
{
    public class Athlete
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "FiratName must be 100 characters or less")]
        public required string FirstName { get; set; }
        [MaxLength(100, ErrorMessage = "LastName must be 100 characters or less")]
        public required string LastName { get; set; }
        public required DateTime DOB { get; set; }
        public int CountryId { get; set; }
        public int GameId { get; set; }
        public required string ProfileImage { get; set; }
        public List<Country> Country { get; set; }
        public List<Game> Game { get; set; }
    }
}
