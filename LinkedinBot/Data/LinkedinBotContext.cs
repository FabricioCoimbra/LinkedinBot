using Microsoft.EntityFrameworkCore;

namespace LinkedinBot.Data
{
    public class LinkedinBotContext : DbContext
    {
        public LinkedinBotContext(DbContextOptions<LinkedinBotContext> options)
            : base(options)
        {
        }
        public DbSet<LinkedinBot.Models.Recruiter> Recruiter { get; set; } = default!;
    }
}
