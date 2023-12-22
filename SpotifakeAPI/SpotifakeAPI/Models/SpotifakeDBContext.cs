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
        public virtual DbSet<AlbumSong> AlbumSongs { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupArtist> GroupArtists { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<RadioSong> RadioSongs { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongArtist> SongArtists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SpotifakeDB; User id = sa ; password = Password.123;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.NofTrack).HasColumnName("NOfTrack");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Album__ArtistId__412EB0B6");

                entity.HasOne(d => d.Gruop)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.GruopId)
                    .HasConstraintName("FK__Album__GruopId__4222D4EF");
            });

            modelBuilder.Entity<AlbumSong>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.SongId })
                    .HasName("PK__AlbumSon__F69A835E942079B7");

                entity.ToTable("AlbumSong");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumSongs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumSong__Album__46E78A0C");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.AlbumSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumSong__SongI__47DBAE45");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Artist__GroupId__3E52440B");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GruopName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<GroupArtist>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.ArtistId })
                    .HasName("PK__GroupArt__06CDF5DF075C9996");

                entity.ToTable("GroupArtist");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.GroupArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupArti__Artis__4BAC3F29");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupArtists)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupArti__Group__4AB81AF0");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Genre).HasMaxLength(255);

                entity.Property(e => e.Regista).HasMaxLength(255);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Playlist__UserId__52593CB8");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.SongId })
                    .HasName("PK__Playlist__D22F5AC973BCC014");

                entity.ToTable("PlaylistSong");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlaylistS__Playl__5535A963");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlaylistS__SongI__5629CD9C");
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("Radio");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<RadioSong>(entity =>
            {
                entity.HasKey(e => new { e.RadioId, e.SongId })
                    .HasName("PK__RadioSon__BAC4A147ECE5185B");

                entity.ToTable("RadioSong");

                entity.HasOne(d => d.Radio)
                    .WithMany(p => p.RadioSongs)
                    .HasForeignKey(d => d.RadioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RadioSong__Radio__5AEE82B9");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.RadioSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RadioSong__SongI__5BE2A6F2");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Setting__1788CC4C4B1A26FB");

                entity.ToTable("Setting");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Equalaizer).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Setting)
                    .HasForeignKey<Setting>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Setting__UserId__398D8EEE");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Genre).HasMaxLength(255);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SongArtist>(entity =>
            {
                entity.HasKey(e => new { e.SongId, e.ArtistId })
                    .HasName("PK__SongArti__00B4D0220FDA0EF9");

                entity.ToTable("SongArtist");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SongArtis__Artis__4F7CD00D");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SongArtis__SongI__4E88ABD4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CultureInfo).HasMaxLength(10);

                entity.Property(e => e.DateOfBirth).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
