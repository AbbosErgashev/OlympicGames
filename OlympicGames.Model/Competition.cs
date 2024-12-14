using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Model
{
    public class Competition
    {
        public int Id { get; set; }
        public string Game {  get; set; }
        public DateTime StartDateTime { get; set; }
        public int EventId { get; set; }

        public OlympicEvent OlympicEvent { get; set; }
        public Event Event { get; set; }

    }
}
