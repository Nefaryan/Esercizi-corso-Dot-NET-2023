using SpotifakeClasses;
using SpotifakeClasses.Entities;
using SpotifakeClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifakeDateAndLogic.Logic
{
    public class MediaComponent : IMedia
    {
        User User { get; set; }
        private List<Song> _queue;
        private int _index;
        public MediaComponent(User user)
        {
            _queue = new List<Song>();
            _index = 0;
            User = user;

        }

        public MediaComponent()
        {
        }

        public void AddToQueue(Song song)
        {
            if (song != null)
                _queue.Add(song);
        }
        public void RemoveFromQueue(Song song) => _queue.Remove(song);
        public void Play(User u,Song s)
        {
            if (u.Settings.PremiumType == PremiumType.GOLD)
            {
                AddToQueue(s);
            }
            else if (u.Settings.PremiumType == PremiumType.FREE || User.Settings.PremiumType == PremiumType.PREMIUM)
            {
                if( u.Settings.RemainigTime > 0)
                {
                    u.Settings.RemainigTime -= s.Duration;
                    AddToQueue(s);
                }
                else
                {
                    Console.WriteLine("Tempo Esaurito, passa all'abonamento gold o aspetta il prossimo mese");
                    //RandomSong(); Fa ascoltare una canzone radomica all'utente 
                }
            }

        }

        public void Play(Album a)
        {
            foreach (Song item in a.Songs)
            {
                AddToQueue(item);
            }
            PlayQueue();
        }

        public void PlayPlaylist(Playlist p)
        {
            foreach (Song item in p.Songs)
            {
                AddToQueue(item);
            }
            PlayQueue();
        }

        public void PlayRadio(Radio r,User u)
        {
            foreach (Song item in r.Songs)
            {
                Play(u, item);
            }
        }
        public void Pause()
        {
            try
            {
                Console.WriteLine($"Paused :{_queue[_index].Title}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }

        }

        public void Stop()
        {
            try
            {
                Console.WriteLine($"Stopped reproduction of :{_queue[_index].Title}");
                _queue.Clear();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }

        }

        public void Forward()
        {
            if (!CheckQueue())
                return;
            _index++;
            PlayQueue();
        }

        public void Previous()
        {
            if (!CheckQueue())
                return;
            _index--;
            PlayQueue();
        }

        public void PlayQueue()
        {
            try
            {

                if (_index < _queue.Count)


                    Console.WriteLine($"Now Playing : {_queue[_index].Title}");


            }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list);
            }

        }

        private bool CheckQueue()
        {
            if (_queue.Count > 0)
                return true;
            Console.WriteLine("Non esiste una coda al momento!");
            return false;
        }
        
       /* //Randomsong per utenti con minuti di ascolto terminati
        private void RandomSong()
        { 
            List<Song> songs = new List<Song>();//Momentaneo PlaceOlder per DB

            if (User.Settings.RemainigTime == 0)
            {
                Random random = new Random();
                int randomSOng = random.Next(songs.Count);
                AddToQueue(songs[randomSOng]);
            } 
        }*/
    }
}
