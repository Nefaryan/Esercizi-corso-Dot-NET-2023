using SpotifakeClasses.Entities;
using SpotifakeDateAndLogic.Entities.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Interfaces
{
    public interface IMedia
    {
        public void Play(User u,Song s);
        public void Pause();
        public void Stop();
        public void Forward();
        public void Previous();
    }
}
