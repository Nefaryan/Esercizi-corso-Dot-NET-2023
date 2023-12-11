using SpotifakeService.Service;
using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using SpotifakeData.Entity;
using SpotifakeService;
using Microsoft.Extensions.Logging;
using SpotifakeData.Repository;
using SpotifakeService.Service.Music;

namespace SpotifakePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            ui.LogIn();




           
        
       

         
         






        }
    }
 }

