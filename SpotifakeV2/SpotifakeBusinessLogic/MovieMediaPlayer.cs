using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity;
using SpotifakeService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService
{
    public class MovieMediaPlayer
    {
        private bool _playing;
        private readonly MovieService _movieService;
        private readonly ILogger<MovieMediaPlayer> _logger;

        public MovieMediaPlayer(MovieService movieService, ILogger<MovieMediaPlayer> logger)
        {
            _playing = false;
            _movieService = movieService;
            _logger = logger;
        }

        public string SeeAllMovie()
        {
            try
            {
                var movies = _movieService.GetMovies();
                if (movies.Any())
                {
                    var movieInfo = movies.Select(m => $"{m.ID} - {m.Title} - {m.Regista}");
                    var result = string.Join(Environment.NewLine, movieInfo);

                    _logger.LogInformation("Visualizzazione di tutti i movie");

                    return result;
                }
                else
                {
                    _logger.LogInformation("Nessun film disponibilie");
                    return "Nessun fil disponinile";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la visualizzazione dei movie");
                return "Errore durante la visualizzazione dei movie";
            }
        }

        public string Top5Movie()
        {
            try
            {
                var movies = _movieService.GetTop5Movie();
                if (movies.Any())
                {
                    var moviesInfo = movies.Select(m => $"{m.ID} - {m.Title} - {m.Regista} - {m.Raiting}");
                    var result = string.Join(Environment.NewLine, moviesInfo);

                    _logger.LogInformation("TOP 5 Movie");
                    return result;
                }
                else
                {
                    _logger.LogInformation($"Non ho trovato i miglior movie");
                    return "Non ho trovato i miglior movie";

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", ex);
                return ex.Message;

            }

        }

        public string PlayMovie(User user, int id)
        {
            try
            {
                var movie = _movieService.GetMovieById(id);
                if (movie != null)
                {
                    if (CanUserPlayMovie(user, movie))
                    {
                        movie.Raiting++;
                        UpdateUserRemainingTime(user, movie.Duration);

                        _playing = true;
                        return PlayCyurrentMovie(movie);
                    }
                    else
                    {
                        _logger.LogInformation("Impossibile riprodurre");
                        return "Impossibile riprodurre";
                    }
                }
                else
                {
                    _logger.LogInformation($" Movie con titolo '{movie.Title}'non trovato");
                    return $" Movie con titolo '{movie.Title}'non trovato";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return "Errore dirante la riprovuzione";
            }
        }

        public string PauseMovie()
        {
            _playing = false;
            return "Movie Stopped";
        }
        private void UpdateUserRemainingTime(User user, int duration)
        {
            if (user.Setting.PremiumType != PremiumTypeEnum.GOLD)
            {
                user.Setting.RemainigTime -= duration;
            }
        }
        private bool CanUserPlayMovie(User user, MovieDTO movie)
        {
            return user.Setting.RemainigTime > 0 || user.Setting.PremiumType == PremiumTypeEnum.GOLD;
        }
        private string PlayCyurrentMovie(MovieDTO movie)
        {
            string result = $"Playing: {movie.Title}";
            return result;
        }
    }
}
