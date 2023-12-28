using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DbContext
{
    public class RapidProgerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public RapidProgerDbContext(DbContextOptions<RapidProgerDbContext> options) : base(options) { }
    }
}
