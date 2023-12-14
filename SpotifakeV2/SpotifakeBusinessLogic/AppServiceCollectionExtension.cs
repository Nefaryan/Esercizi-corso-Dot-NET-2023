using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifakeData.DataContext;
using SpotifakeData.Entity.Music;
using SpotifakeData.Entity;
using SpotifakeData.Repository;
using SpotifakeService.Service;
using SpotifakeService.Service.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifakeData.Repository.Interfaces;

namespace SpotifakeService
{
    public static class AppServiceCollectionExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<DBContext>(provider =>
            {
                var baseFolderPath = configuration.GetSection("FolderPath").Value;
                if (string.IsNullOrEmpty(baseFolderPath))
                {
                    throw new InvalidOperationException("FolderPath non configurato.");
                }
                return new DBContext(baseFolderPath);
            });

            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IGenericRepository<Song>, GenericRepository<Song>>();
            services.AddSingleton<IGenericRepository<Radio>, GenericRepository<Radio>>();
            services.AddSingleton<IGenericRepository<Playlist>, GenericRepository<Playlist>>();
            services.AddSingleton<IGenericRepository<Album>, GenericRepository<Album>>();
            services.AddSingleton<IGenericRepository<Artist>, GenericRepository<Artist>>();
            services.AddSingleton<IGenericRepository<Group>, GenericRepository<Group>>();
            services.AddSingleton<IGenericRepository<User>, GenericRepository<User>>();
            services.AddSingleton<IGenericRepository<Movie>, GenericRepository<Movie>>();
          
            services.AddSingleton<SongService>();
            services.AddSingleton<RadioService>();
            services.AddSingleton<PlaylistService>();
            services.AddSingleton<AlbumService>();
            services.AddSingleton<ArtistService>();
            services.AddSingleton<GroupService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<MediaPlayer>();
            services.AddSingleton<MovieMediaPlayer>();
            services.AddSingleton<UserUI>();

            return services;

        }
       
    }
}
