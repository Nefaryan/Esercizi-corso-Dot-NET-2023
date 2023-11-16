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
        private List<EUProvincia> _provinciaList;
        GeographicArea _geographicArea;
        EUState state;

        public EURegione(string name)
        {
            _name = name;
            _provinciaList = new List<EUProvincia>();
        }

        public string Name { get => _name; set => _name = value; }
        public List<EUProvincia> ProvinciaList { get => _provinciaList; set => _provinciaList = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }
        public EUState State { get => state; set => state = value; }

        public void AddProvincia(EUProvincia provincia)
        {
            provincia.Regione = this;
            _provinciaList.Add(provincia);
        }

        public void RemoveProvincia(EUProvincia provincia)
        {
            provincia.Regione = null;
            _provinciaList?.Remove(provincia);
        }

        public EUProvincia GetEUProvincia(string NomeProvincia)
        {
            return _provinciaList.FirstOrDefault(p => p.Name == NomeProvincia);
        }

        public void ChangeRegioneAtProvincia(string NomeProvincia, EURegione RegioneDiDestinazione)
        {
            EUProvincia eUProvincia = GetEUProvincia(NomeProvincia);
            if(eUProvincia != null)
            {
                Console.WriteLine($"La provincia {eUProvincia.Name} sta cambiando regiona da {eUProvincia.Regione.Name}");
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
