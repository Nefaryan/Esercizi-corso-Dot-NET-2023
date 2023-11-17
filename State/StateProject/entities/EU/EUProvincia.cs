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
        EUComune[] _comunes;
        EURegione regione;

        public EUProvincia(string name)
        {
            Name = name;
            _comunes = new EUComune[0];
        }

        public string Name { get => _name; set => _name = value; }
        public EURegione Regione { get => regione; set => regione = value; }

        public void AddCoumne(EUComune comune)
        {
            Array.Resize(ref _comunes, _comunes.Length +1);
            comune.Provincia = this;
            _comunes[_comunes.Length - 1] = comune;
        }

        public void RemoveComune(EUComune comune)
        {
          _comunes = _comunes.Where(c => c != comune).ToArray();
          comune.Provincia = null;
        }

        public EUComune GetComune(string nomeComune)
        {
            EUComune comune = Array.Find(_comunes, c=> c.Name == nomeComune);
            return comune;
        }
        public void ChangeProvinciaForComune(string comune, EUProvincia ProvinciaDiDestinazione)
        {
            EUComune eUComune = GetComune(comune);
            if (eUComune != null)
            {
                Console.WriteLine($"Il comune {eUComune.Name} cambia provincia di appartenenza da {eUComune.Provincia.Name} a {ProvinciaDiDestinazione.Name}");

                eUComune.Provincia.RemoveComune(eUComune);

                eUComune.Provincia = ProvinciaDiDestinazione;

                ProvinciaDiDestinazione.AddCoumne(eUComune);

                Console.WriteLine($"La nuova provincia del comune {eUComune.Name} è {ProvinciaDiDestinazione.Name}");
            }
            else
            {
                Console.WriteLine("Operazione non riuscita. Il comune non è stato trovato.");
            }

        }
            
          
    }
    
}
