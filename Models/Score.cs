using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreMaster.Models
{
    public class Score
    {
        public int Id { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    // public class NewScore
    // {
    //     [Required]
    //     public int Total { get; set; }
    //     [Required]
    //     public string Name { get; set; }
    // }
}
