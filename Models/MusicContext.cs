using Microsoft.EntityFrameworkCore;

namespace FavoriteSongs.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Respondents> Respondents { get; set; }
        public DbSet<SurveyResults> SurveyResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Respondents>()
                .Property(r => r.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Respondents>()
                .Property(r => r.LastName)
                .HasColumnName("Last_name");

            modelBuilder.Entity<Respondents>()
                .Property(r => r.AgeCategory)
                .HasColumnName("Age_category");
        }
    }
}
