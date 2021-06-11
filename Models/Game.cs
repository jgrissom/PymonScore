using System.Collections.Generic;

namespace ScoreMaster.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
