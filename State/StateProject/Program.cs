using StateProject.entities;
using StateProject.entities.EU;
using System;

namespace StateProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUState italia = new EUState("Italia","Euro","tricolore"
                ,2345323,"Svizzera",1);

           
            EURegione Calabria = new EURegione("Calabira");
            EURegione Lazio = new EURegione("Lazio");

           
            italia.AddRegion(Calabria);
            italia.AddRegion(Lazio);

            EUProvincia Cosenza = new EUProvincia("Cosenza");
            EUProvincia Catanzaro = new EUProvincia("Catanzaro");
            EUProvincia Crotnone = new EUProvincia("Crotone");
            EUProvincia Viterbo = new EUProvincia("Viterbo");
            EUProvincia Latina = new EUProvincia("Latina");

            Calabria.AddProvincia(Cosenza);
            Calabria.AddProvincia(Crotnone);
            Calabria.AddProvincia(Catanzaro);

            Lazio.AddProvincia(Latina);
            Lazio.AddProvincia(Viterbo);

            EUComune c1 = new EUComune("c1",30);
            EUComune c2 = new EUComune("c2", 3);
            EUComune c3 = new EUComune("c3",19);
            EUComune c4 = new EUComune("c4",22);
            EUComune c5 = new EUComune("c5",10);
            EUComune c6 = new EUComune("c6",40);
            EUComune c7 = new EUComune("c7",30);
            EUComune c8 = new EUComune("c6",20);
            EUComune c9 = new EUComune("c6",100);
            EUComune c10 = new EUComune("c6",1);

            Cosenza.AddCoumne(c1);
            Cosenza.AddCoumne(c2);
            Cosenza.AddCoumne(c3);
            Cosenza.AddCoumne(c10);
            Crotnone.AddCoumne(c4);
            Crotnone.AddCoumne(c5);
            Catanzaro.AddCoumne(c6);
            Viterbo.AddCoumne(c7);
            Viterbo.AddCoumne(c8);
            Latina.AddCoumne(c9);

            italia.DistribuisciPopolazione(12900000);
            



        }
    }
}
