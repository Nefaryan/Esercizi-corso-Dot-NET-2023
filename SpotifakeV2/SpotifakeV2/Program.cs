using SpotifakeService.Service;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using SpotifakeData.Entity;
using SpotifakeService;
using Microsoft.Extensions.Logging;
using SpotifakeData.Repository;
using SpotifakeService.Service.Music;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SpotifakeData.DataContext;
using SpotifakeData.Repository.Interfaces;
using Serilog;


namespace SpotifakePresentation
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Configurazione Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(GetConfiguration()) // Legge la configurazione da appsettings.json
                .CreateLogger();

            try
            {
                Log.Information("Applicazione avviata.");

                var serviceProvider = new ServiceCollection()
                    .AddLogging(builder => builder.AddSerilog()) 
                    .AddAppService(GetConfiguration())
                    .BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                    loggerFactory.AddSerilog();  

                    var services = scope.ServiceProvider;

                  
                    var loggerSongService = services.GetRequiredService<ILogger<SongService>>();
                    var loggerPlaylistService = services.GetRequiredService<ILogger<PlaylistService>>();
                    var loggerUserService = services.GetRequiredService<ILogger<UserService>>();
                    var loggerMovieService = services.GetRequiredService<ILogger<MovieService>>();
                    var loggerRadioService = services.GetRequiredService<ILogger<RadioService>>();
                    var loggerAlbumService = services.GetRequiredService<ILogger<AlbumService>>();
                    var loggerArtistService = services.GetRequiredService<ILogger<ArtistService>>();
                    var loggerGroupService = services.GetRequiredService<ILogger<GroupService>>();
                    var loggerMediaPlayer = services.GetRequiredService<ILogger<MediaPlayer>>();
                    var loggerMovieMediaPlayer = services.GetRequiredService<ILogger<MovieMediaPlayer>>();

                   
                    var songService = services.GetRequiredService<SongService>();
                    var playlistService = services.GetRequiredService<PlaylistService>();
                    var userService = services.GetRequiredService<UserService>();
                    var movieService = services.GetRequiredService<MovieService>();
                    var radioService = services.GetRequiredService<RadioService>();
                    var albumService = services.GetRequiredService<AlbumService>();
                    var artistService = services.GetRequiredService<ArtistService>();
                    var groupService = services.GetRequiredService<GroupService>();
                    var mediaPlayer = services.GetRequiredService<MediaPlayer>();
                    var movieMediaPlayer = services.GetRequiredService<MovieMediaPlayer>();
                    var userUi = services.GetRequiredService<UserUI>();

                    
                    var ui = new UserUI(userService, mediaPlayer, movieMediaPlayer);
                    ui.Run();
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Applicazione terminata in modo anomalo.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }





    #region
    //Configurazione manuale
    /*
    // FolderPath for entity-------------------------------------------
    var SongFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Song";
    var UserFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\User";
    var MovieFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Movie";
    var PlaylistFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Playlist";
    var RadioFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Radio";
    var AlbumFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Album";
    var GroupFolderPath= @"C:\Users\giuse\Desktop\SpotiFake\Group";
    var ArtistFolderPath = @"C:\Users\giuse\Desktop\SpotiFake\Arits";
    //Repository logger--------------------------------------------------------------------
    var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    var logger = loggerFactory.CreateLogger<GenericRepository<Song>>();
    var logger1 = loggerFactory.CreateLogger<GenericRepository<User>>();
    var logger2 = loggerFactory.CreateLogger<GenericRepository<Movie>>();
    var logger3 = loggerFactory.CreateLogger<GenericRepository<Playlist>>();
    var logger4 = loggerFactory.CreateLogger<GenericRepository<Radio>>();
    var logger5 = loggerFactory.CreateLogger<GenericRepository<Album>>();
    var logger6 = loggerFactory.CreateLogger<GenericRepository<Group>>();
    var logger7 = loggerFactory.CreateLogger<GenericRepository<Artist>>();
    //Repo-----------------------------------------------------------------------------------
    var songRepo = new GenericRepository<Song>(SongFolderPath, logger);
    var userRepo = new GenericRepository<User>(UserFolderPath, logger1);
    var movieRepo = new GenericRepository<Movie>(MovieFolderPath, logger2);
    var playlistRepo = new GenericRepository<Playlist>(PlaylistFolderPath, logger3);
    var RadioRepo = new GenericRepository<Radio>(RadioFolderPath, logger4);
    var AlbumRepo = new GenericRepository<Album>(AlbumFolderPath, logger5);
    var GroupRepo = new GenericRepository<Group>(GroupFolderPath, logger6);
    var ArtistRepo = new GenericRepository<Artist>(ArtistFolderPath, logger7);
    //Service Logger----------------------------------------------------------------------------
    var loggerSongService = loggerFactory.CreateLogger<SongService>();
    var loggerUserService = loggerFactory.CreateLogger<UserService>();  
    var movieLoggerService = loggerFactory.CreateLogger<MovieService>();
    var loggerPlaylistService = loggerFactory.CreateLogger<PlaylistService>();
    var loggerRadio = loggerFactory.CreateLogger<RadioService>();
    var loggerAlbum = loggerFactory.CreateLogger<AlbumService>();
    var loggerGroup = loggerFactory.CreateLogger<GroupService>();
    var loggerArtist = loggerFactory.CreateLogger<ArtistService>();
    //Service------------------------------------------------------------------------------------
    var SongService = new SongService(songRepo, loggerSongService);
    var PlayListService = new PlaylistService(playlistRepo, SongService, loggerPlaylistService);
    var UserService = new UserService (userRepo,PlayListService,SongService, loggerUserService);
    var MovieService = new MovieService(movieRepo, movieLoggerService);
    var RadioService = new RadioService(RadioRepo, loggerRadio,SongService);
    var AlbumService = new AlbumService(AlbumRepo, loggerAlbum);
    var ArtistService = new ArtistService(ArtistRepo,AlbumService,SongService,loggerArtist);
    var GroupService = new GroupService(GroupRepo, ArtistService, AlbumService, SongService, loggerGroup);
    //-------MEDIA PLAYER-----------------------------------------------------------------------------------------
    var mediaLogger = loggerFactory.CreateLogger<MediaPlayer>();
    var videoMediaLogger = loggerFactory.CreateLogger<MovieMediaPlayer>();
    MediaPlayer mediaPlayer = new MediaPlayer(SongService, AlbumService, PlayListService, mediaLogger);
    MovieMediaPlayer movieMediaPlayer = new MovieMediaPlayer(MovieService, videoMediaLogger);
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    UserUI ui = new UserUI(UserService, mediaPlayer, movieMediaPlayer);
    ui.Run();*/

    #endregion
}






