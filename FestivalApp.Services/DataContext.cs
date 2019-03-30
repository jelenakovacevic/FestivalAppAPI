namespace FestivalApp.Services
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Festival> Festivals { get; set; }
        public virtual DbSet<FestivalType> FestivalTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Festival>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Festivals)
                .Map(m => m.ToTable("FestivalAttending").MapLeftKey("FestivalId").MapRightKey("UserId"));

            modelBuilder.Entity<FestivalType>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<FestivalType>()
                .HasMany(e => e.Festivals)
                .WithRequired(e => e.FestivalType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FestivalType>()
                .HasMany(e => e.Users)
                .WithMany(e => e.FestivalTypes)
                .Map(m => m.ToTable("UserFestivalType").MapLeftKey("FestivalTypeId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
