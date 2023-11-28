using Spotifake.Entities;
using Spotifake.Interfaces;
using Spotifake.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeDataAndLogic
{
    internal class MediaPlayer : IMedia
    {
        private List<Song> _queue;
        private int _index;
        public MediaPlayer()
        {
            _queue = new List<Song>();
            _index = 0;
        }

        public void AddToQueue(Song song)
        {
            if (song != null)
                _queue.Add(song);
        }
        public void RemoveFromQueue(Song song) => _queue.Remove(song);
        public void Play(Song s)
        {
            AddToQueue(s);
        }

        public void Play(Album a)
        {
            foreach (Song item in a.Song)
            {
                AddToQueue(item);
            }
            PlayQueue();
        }

        public void Play(Playlist p)
        {
            foreach (Song item in p.Songs)
            {
                AddToQueue(item);
            }
            PlayQueue();
        }

      
        public void Pause()
        {
            try
            {
                Console.WriteLine($"Paused :{_queue[_index].Name}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Non esiste una coda al momento!");
            }

        }

        public void Stop()
        {
            try
            {
                Console.WriteLine($"Stopped reproduction of :{_queue[_index].Name}");
                _queue.Clear();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Non esiste una coda al momento!");
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


                    Console.WriteLine($"Now Playing : {_queue[_index].Name}");
                // System.Threading.Thread.Sleep(_queue[_index].Duration * 1000);//here we fake actually playing the song

            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine($"la canzone numero {_index} è corrotta");
            }

        }

        private bool CheckQueue()
        {
            if (_queue.Count > 0)
                return true;
            Console.WriteLine("Non esiste una coda al momento!");
            return false;
        }
    }
}

