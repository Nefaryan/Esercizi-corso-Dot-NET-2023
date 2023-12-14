using Microsoft.Extensions.Logging;
using SpotifakeData.DTO;
using SpotifakeData.Entity.Music;
using SpotifakeData.Repository;
using SpotifakeData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeService.Service
{
    public class GroupService
    {
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly ArtistService _artistService;
        private readonly AlbumService _albumService;
        private readonly SongService _songService;
        private readonly ILogger<GroupService> _logger;

        public GroupService(
            IGenericRepository<Group> groupRepository,
            ArtistService artistService,
            AlbumService albumService,
            SongService songService,
            ILogger<GroupService> logger)
        {
            _groupRepository = groupRepository;
            _albumService = albumService;
            _artistService = artistService;
            _songService = songService;
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
                var artist = _artistService.GetArtist(artistId);

                if (group != null && artist != null)
                {
                    if (group.Artists == null)
                    {
                        group.Artists = new List<Artist>();
                    }

                    Artist ar = new Artist();
                    ar.Id = artistId;
                    ar.Name = artist.Name;
                    ar.Surname = artist.Surname;
                    ar.ArtistName = artist.ArtistName;

                    group.Artists.Add(ar);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Artista '{artist.ArtistName}' aggiunto con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o artista non trovato con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'artista al gruppo con Id {groupId}.");
                throw;
            }
        }

        public List<GroupDTO> GetAllGroups()
        {
            try
            {
                var groups = _groupRepository.GetALL(); 
                return groups.Select(group => new GroupDTO(group)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero di tutti i gruppi.");
                throw;
            }
        }

        public GroupDTO? GetGroupById(int id)
        {
            try
            {
                var group = _groupRepository.GetById(id);
                return group != null ? new GroupDTO(group) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del gruppo con Id {id}.");
                throw;
            }
        }

        public void AddAlbumToGroup(int groupId, int albumId)
        {
            try
            {
                var group = _groupRepository.GetById(groupId);
                var album = _albumService.GetAlbumById(albumId);

                if (group != null && album != null)
                {
                    if (group.Albums == null)
                    {
                        group.Albums = new List<Album>();
                    }

                    Album al = new Album();
                    al.Title = album.Title;
                    al.Artist = album.Artist;
                    al.IsLiveVersionAlbum = album.IsLiveVersion;
                    al.NOfTrack = album.NumberOfTrack;
                    al.ID  = album.ID;


                    group.Albums.Add(al);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Album '{album.Title}' aggiunto con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o album non trovato con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta dell'album al gruppo con Id {groupId}.");
                throw;
            }
        }

        public void AddSongToGroup(int groupId, int songId)
        {
            try
            {
                var group = _groupRepository.GetById(groupId);
                var songDTO = _songService.GetSongById(songId);

                if (group != null && songDTO != null)
                {
                    if (group.Song == null)
                    {
                        group.Song = new List<Song>();
                    }
                    Song song = new Song();
                    song.Id = songDTO.ID;
                    song.Title = songDTO.Title;
                    song.Duration = songDTO.Duration;
                    song.Rating = songDTO.Raiting;
                    song.ReleaseDate = songDTO.ReleaseDate;

                    group.Song.Add(song);
                    _groupRepository.Add(group);

                    _logger.LogInformation($"Canzone '{song.Title}' aggiunta con successo al gruppo '{group.GruopName}'.");
                }
                else
                {
                    _logger.LogError($"Gruppo o canzone non trovato con gli Id forniti.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiunta della canzone al gruppo con Id {groupId}.");
                throw;
            }
        }
    }
}
