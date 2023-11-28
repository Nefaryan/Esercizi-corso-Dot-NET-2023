using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Interfaces
{
    public interface IMedia
    {
        public void Play(Song s);
        public void Pause();
        public void Stop();
        public void Forward();
        public void Previous();
    }
}
