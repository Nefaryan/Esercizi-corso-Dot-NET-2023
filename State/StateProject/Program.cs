using StateProject.entities;
using StateProject.entities.EU;
using System;

namespace StateProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUProvincia p1 = new EUProvincia("Consenza");
            EUComune c1 = new EUComune("Castrovillari");

            p1.AddCoumne(c1);

            EUProvincia p2 = new EUProvincia("Catanzaro");
            p2.ChangeProvinciaForComune(c1, p2);
                                   
        }
    }
}
