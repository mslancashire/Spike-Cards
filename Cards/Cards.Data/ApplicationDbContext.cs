using Cards.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cards.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardEntity>(entity =>
        {
            entity.ToTable("cards").HasKey("id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("id");
            entity.Property(p => p.DateCreated).HasColumnName("date_created");
            entity.Property(p => p.DateModified).HasColumnName("date_modified");
            entity.Property(p => p.Card).HasColumnName("card_data").HasColumnType("jsonb").HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Card>(v));
        });
    }

    public DbSet<CardEntity> Cards { get; set; }
}
