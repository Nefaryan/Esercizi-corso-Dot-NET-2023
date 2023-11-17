using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateProject.entities.EU.Abstract;

namespace StateProject.entities.EU
{
    public class EURegione: EUPublicAdministration
    {
        string _name;
        EUProvincia[] _provinciaList;
        GeographicArea _geographicArea;
        EUState state;

        public EURegione(string name)
        {
            _name = name;
            ProvinciaList = new EUProvincia[0];
            
        }

        public string Name { get => _name; set => _name = value; }
       
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }
        public EUState State { get => state; set => state = value; }
        public EUProvincia[] ProvinciaList { get => _provinciaList; set => _provinciaList = value; }

        public void AddProvincia(EUProvincia provincia)
        {
           Array.Resize(ref _provinciaList, ProvinciaList.Length + 1);
           provincia.Regione = this;
            _provinciaList[_provinciaList.Length - 1] = provincia;
        }

        public void RemoveProvincia(EUProvincia provincia)
        {
           _provinciaList = _provinciaList.Where(p => p != provincia).ToArray();
        }

        public EUProvincia GetEUProvincia(string NomeProvincia)
        {
            EUProvincia provincia = Array.Find(_provinciaList, p => p.Name == NomeProvincia);
            return provincia;
        }

        public void ChangeRegioneAtProvincia(string NomeProvincia, EURegione RegioneDiDestinazione)
        {
            EUProvincia eUProvincia = GetEUProvincia(NomeProvincia);
            if(eUProvincia != null)
            {
                Console.WriteLine($"La provincia {eUProvincia.Name} sta cambiando regiona da {eUProvincia.Regione.Name}");
                eUProvincia.Regione.RemoveProvincia(eUProvincia); 
                eUProvincia.Regione = RegioneDiDestinazione;
                RegioneDiDestinazione.AddProvincia(eUProvincia);
                Console.WriteLine($"La provincia {eUProvincia.Name} ha cambiato la sua regione a {RegioneDiDestinazione.Name}");
            }
            else
            {
                Console.WriteLine("Non è stato possibile eseguire l'operazione");
            }
        }


       
    }
}
