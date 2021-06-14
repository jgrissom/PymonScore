using System;
namespace ScoreMaster.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
