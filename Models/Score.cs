using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreMaster.Models
{
    public class Score
    {
        public int Id { get; set; }
        [Required]
        public int Total { get; set; }
        [Required, MaxLength(15)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
