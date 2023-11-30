using Microsoft.Extensions.Logging;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeBusinessLogic.Service
{
    public class GroupService
    {
        private readonly GroupRepository _groupRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly SongRepository _songRepository;
        private readonly ILogger<GroupService> _logger;

        public GroupService(
            GroupRepository groupRepository,
            ArtistRepository artistRepository,
            AlbumRepository albumRepository,
            SongRepository songRepository,
            ILogger<GroupService> logger)
        {
            _groupRepository = groupRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
            _logger = logger;
        }

        public void CreateGroup(Group group)
        {
            try
            {
                _groupRepository.Add(group);
                _logger.LogInformation($"Gruppo '{group.GruopName}' creato con successo.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante la creazione del gruppo '{group.GruopName}'.");
                throw;
            }
        }

        public void AddArtistToGroup(int groupId, int artistId)
        {
            try
            {
                var group = _groupRepository.GetById(groupId);
                var artist = _artistRepository.GetById(artistId);

                if (group != null && artist != null)
                {
                    if (group.Artists == null)
                    {
                        group.Artists = new List<Artist>();
                    }

                    group.Artists.Add(artist);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Artista '{artist.ArtistName}' aggiunto con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o artista non trovato con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'artista al gruppo con ID {groupId}.");
                throw;
            }
        }

        public List<Group> GetAllGroups()
        {
            try
            {
                return _groupRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutti i gruppi.");
                throw;
            }
        }

        public Group GetGroupById(int id)
        {
            try
            {
                return _groupRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del gruppo con ID {id}.");
                throw;
            }
        }

        public void AddAlbumToGroup(int groupId, int albumId)
        {
            try
            {
                var group = _groupRepository.GetById(groupId);
                var album = _albumRepository.GetById(albumId);

                if (group != null && album != null)
                {
                    if (group.Albums == null)
                    {
                        group.Albums = new List<Album>();
                    }

                    group.Albums.Add(album);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Album '{album.Title}' aggiunto con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o album non trovato con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album al gruppo con ID {groupId}.");
                throw;
            }
        }

        public void AddSongToGroup(int groupId, int songId)
        {
            try
            {
                var group = _groupRepository.GetById(groupId);
                var song = _songRepository.GetById(songId);

                if (group != null && song != null)
                {
                    if (group.Song == null)
                    {
                        group.Song = new List<Song>();
                    }

                    group.Song.Add(song);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o canzone non trovato con gli ID forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone al gruppo con ID {groupId}.");
                throw;
            }
        }
    }
}
