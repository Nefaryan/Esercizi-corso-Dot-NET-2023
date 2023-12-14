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
using Microsoft.Extensions.Logging;
using System.IO;

namespace SpotifakeService
{
    public static class AppServiceCollectionExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            var folderPathSection = configuration.GetSection("FolderPath");
            var basePath = folderPathSection["Base"];

            if (string.IsNullOrEmpty(basePath))
            {
                throw new InvalidOperationException("PercorsoBase non configurato.");
            }

            // Registro il repository per ogni tipo di entità che desidero gestire
            RegisterRepository<Song>(services, basePath, "Song");
            RegisterRepository<Radio>(services, basePath, "Radio");
            RegisterRepository<Playlist>(services, basePath, "Playlist");
            RegisterRepository<Movie>(services, basePath, "Movie");
            RegisterRepository<Album>(services, basePath, "Album");
            RegisterRepository<Artist>(services, basePath, "Artist");
            RegisterRepository<Group>(services, basePath, "Group");
            RegisterRepository<User>(services, basePath, "User");

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

        private static void RegisterRepository<T>(IServiceCollection services, string basePath, string repositoryName) where T : class
        {
            var repositoryPath = Path.Combine(basePath, repositoryName);

            if (string.IsNullOrEmpty(repositoryPath))
            {
                throw new InvalidOperationException($"Percorso del repository {repositoryName} non configurato.");
            }

            services.AddSingleton<IGenericRepository<T>>(provider =>
            {
                var dbContext = new DBContext(repositoryPath);
                return new GenericRepository<T>(repositoryPath, provider.GetRequiredService<ILogger<GenericRepository<T>>>(), dbContext);
            });
        }
    }


}
