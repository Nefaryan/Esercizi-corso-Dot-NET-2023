using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpotifakeAPI.Models
{
    public partial class SpotifakeDBContext : DbContext
    {
        public SpotifakeDBContext()
        {
        }

        public SpotifakeDBContext(DbContextOptions<SpotifakeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SpotifakeDB; User id = sa ; password = Password.123;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NofTrack).HasColumnName("NOfTrack");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_Album_Artist");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Album_Group");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Artist_Group");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Playlist_User");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("Radio");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Setting__1788CC4C99AA9A81");

                entity.ToTable("Setting");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Setting)
                    .HasForeignKey<Setting>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Setting_User");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
