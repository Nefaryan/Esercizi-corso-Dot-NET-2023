using SpotifakeData.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeData.DTO
{
    public class RadioDTO
    { 
        public int Id { get; set; }   
        public string Name { get; set; }
        public List<SongDTO> Song { get; set; }

        public RadioDTO(Radio radio) 
        {
            Id = radio.Id;
            Name = radio.Name;
            Song = new List<SongDTO>();
        
        }
    }
}
