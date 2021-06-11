namespace ScoreMaster.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int ScoreTotal { get; set; }
        public string PlayerName { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
