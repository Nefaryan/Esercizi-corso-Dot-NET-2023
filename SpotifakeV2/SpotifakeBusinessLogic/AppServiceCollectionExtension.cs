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
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DBContext>(provider =>
            {
                //Devo modificare qui--------------------------------------------------------
                var baseFolderPath = configuration.GetSection("FolderPath:User").Value;
                if (string.IsNullOrEmpty(baseFolderPath))
                {
                    throw new InvalidOperationException("FolderPath per le canzoni non configurato.");
                }

                return new DBContext(baseFolderPath);
            });

            // Registro il repository per ogni tipo di entità che desidero gestire
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGenericRepository<Song>, GenericRepository<Song>>();
            services.AddScoped<IGenericRepository<Radio>, GenericRepository<Radio>>();
            services.AddScoped<IGenericRepository<Playlist>, GenericRepository<Playlist>>();
            services.AddScoped<IGenericRepository<Album>, GenericRepository<Album>>();
            services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();
            services.AddScoped<IGenericRepository<Group>, GenericRepository<Group>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Movie>, GenericRepository<Movie>>();

            

            services.AddSingleton<SongService>();
            services.AddSingleton<RadioService>();
            services.AddSingleton<PlaylistService>();
            services.AddSingleton<MovieService>();
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
