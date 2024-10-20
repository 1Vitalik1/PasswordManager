using Microsoft.EntityFrameworkCore;

namespace BA_PasswordManager.Classes
{
    class Database : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public Database()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=ep-crimson-boat-a2uxhntj.eu-central-1.aws.neon.tech;Port=5432;Database=BloodyAlphaDatabase;Username=BloodyAlphaDatabase_owner;Password=CfQ3UnjBOG8x");
        

    }
}
