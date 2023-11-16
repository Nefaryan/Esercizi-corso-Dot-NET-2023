using StateProject.entities.EU.Abstract;
using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUProvincia : EUPublicAdministration
    {
        string _name;
        List<EUComune> _comunes;
        EURegione regione;

        public EUProvincia(string name)
        {
            Name = name;
            _comunes = new List<EUComune>();
        }

        public string Name { get => _name; set => _name = value; }
        public EURegione Regione { get => regione; set => regione = value; }

        public void AddCoumne(EUComune comune)
        {
            comune.Provincia = this;
            _comunes.Add(comune);
        }

        public void RemouveComune(EUComune comune)
        {
            comune.Provincia = null;
            _comunes.Remove(comune);
        }

        public EUComune GetComune(string nomeCoumne)
        {
            EUComune comune = _comunes.FirstOrDefault(c => c.Name == nomeCoumne);
            return comune;
        }
        public void ChangeProvinciaForComune(string NomeComune, EUProvincia ProvinciaDiDestinazione)
        {
            EUComune comune = GetComune(NomeComune);
            if(comune!= null)
            {
                Console.WriteLine($"Il comune {comune.Name} cambia provincia di appartenaza da {comune.Provincia}");
                comune.Provincia.RemouveComune(comune);
                comune.Provincia = ProvinciaDiDestinazione;
                ProvinciaDiDestinazione.AddCoumne(comune);
                Console.WriteLine($"La nuova provincia del comune {comune.Name} è {ProvinciaDiDestinazione.Name} ");
            }
            else
            {
                Console.WriteLine("Operazione non riuscita");
            }
        }

      

    }
}
