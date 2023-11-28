using SpotifakeClasses.Entities;
using SpotifakeClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class MediaComponent : IMedia
    {
        private List<Song> _queue;
        private int _index;
        public MediaComponent()
        {
         _queue = new List<Song>();
        _index = 0;
        }

        public void AddToQueue(Song song) { 
            if(song!=null)
                _queue.Add(song); 
        }
        public void RemoveFromQueue(Song song) => _queue.Remove(song);
        public void Play(Song s)
        {
            AddToQueue(s);
        }

        public void Play(Album a)
        {
            foreach(Song item in a.Songs){
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

        public void Play(Radio r)
        {
            foreach (Song item in r.Songs)
            {
                Play(item);//radios in spotify overwrite your current Queue,this is reflected here
            }
        }
        public void Pause(  )
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

        public void Stop(   )
        {
            try {
                Console.WriteLine($"Stopped reproduction of :{_queue[_index].Title}");
                _queue.Clear();
            }
            catch (ArgumentOutOfRangeException ex) {
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
                
                if( _index<_queue.Count )
                

                    Console.WriteLine($"Now Playing : {_queue[_index].Title}");
                   // System.Threading.Thread.Sleep(_queue[_index].Duration * 1000);//here we fake actually playing the song

            }
            catch (System.NullReferenceException ex)
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
    }
}
