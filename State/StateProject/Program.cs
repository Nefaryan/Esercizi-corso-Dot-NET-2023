using StateProject.entities;
using StateProject.entities.EU;
using System;

namespace StateProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EuropeanUnion eu = new EuropeanUnion();
            EUParliament parliament = new EUParliament();
            parliament.Permision = true;
            
            State state = new State("Ucraina","locale","ucraina",345634,"Russia");

            eu.EnterINEU(state,1000);

            EUState EuState = new EUState("Italy", "Euro", "Italy", 341, "Svizzera", 30, 399999);
            EUID c1 = new("Marco", "Verdi", "M", "01/01/2000", 23);
            EUID c2 = new("Mario", "Rossi", "M", "01/01/1990", 33);
            EUCitizen marco = new EUCitizen(c1, 1000, true, true, true);
            EUCitizen mario = new EUCitizen(c2 , 1000, true, true,false);

            marco.EuIdDocument();

            EUComune Castrovillari = new EUComune("Castrovillari");
            Castrovillari.AddCittadino(marco);
            Castrovillari.AddCittadino(mario);

            Castrovillari.EducationalSystem(c2);

           

            EuState.BoarderRedefinition(parliament);
                   
        }
    }
}
