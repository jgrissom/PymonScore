using Microsoft.EntityFrameworkCore;

namespace ScoreMaster.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Score> Scores { get; set; }
    }
}
