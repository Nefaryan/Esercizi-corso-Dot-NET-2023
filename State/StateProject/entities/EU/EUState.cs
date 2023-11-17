using StateProject.entities.EU;
using StateProject.interfaces.EUInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities
{
    public class EUState: State, IEUAdministrativeEntity
    {
        int _timeInEU;
        EURegione[] _regioni;   
       
        public EUState(string name, string money,
            string banner, decimal expenses, string confine,
            int timeInEU): base(name,money,banner,
                expenses, confine)
        {
            _timeInEU = timeInEU;
            _regioni = new EURegione[0];
            
        }

        public int TimeInEU { get => _timeInEU; set => _timeInEU = value; }
      
        public EURegione[] Regioni { get => _regioni; set => _regioni = value; }

        public void AddRegion(EURegione region)
        {
            Array.Resize(ref _regioni, _regioni.Length + 1);
            region.State = this;
            _regioni[_regioni.Length - 1] = region;
        }

        public void RemoveRegione(EURegione region)
        {
            _regioni = _regioni.Where(r => r != region).ToArray();
            region.State = null;
        }

        //Metodo per distribuire la popolazione
        public void DistribuisciPopolazione(int PoloazioneDaSuddividere)
        {
            int popolazioneTot = PoloazioneDaSuddividere;

            //Distribuisco gli abitanti in base al numero di province presenti nella regione
            foreach (EURegione region in _regioni)
            {
                int popRegione = popolazioneTot / _regioni.Length;
                region.PopolazioneRegione = popRegione;

                Console.WriteLine($"Popolazione {popRegione} introdotta nella regione {region.Name} ");

                //Distribisco la popolazione in base al numero di comuni presenti nella provincia
                foreach(EUProvincia provincia in region.ProvinciaList)
                {
                    int popProvincia = popRegione / provincia.Comuni.Length;
                    provincia.Popolazione = popProvincia;

                    Console.WriteLine($"Popolazione {popProvincia} introdotta nella provincia {provincia.Name}");
                    foreach(EUComune comune in provincia.Comuni)
                    {
                        int popComune = popProvincia / comune.Capacita;
                        comune.Popolazione = popComune;

                        Console.WriteLine($"Popolazione {popComune} introdotta nel comune {comune.Name}");
                    }

                }

            }
        }

        public void EducationalSystem()
        {
            Console.WriteLine("");
        }
        public void HNS()
        {
            Console.WriteLine("");
        }
        public void LawSystem()
        {
            Console.WriteLine("");
        }
        public void WellfareService()
        {
            Console.WriteLine("");
        }
        public void BoarderRedefinition(State destionation)
        {
            throw new NotImplementedException();
        }
    }
}
