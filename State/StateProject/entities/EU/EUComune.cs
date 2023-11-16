﻿using StateProject.entities.EU.Abstract;
using StateProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace StateProject.entities.EU
{
    public class EUComune : EUCitizenPublicService
    {
        string _name;
        List<EUCitizen> _citizenList;
        EUProvincia _provincia;
        GeographicArea _geographicArea;
        public EUComune(string name)
        {
            Name = name;
            _citizenList = new List<EUCitizen>();
        }

        public string Name { get => _name; set => _name = value; }
        public EUProvincia Provincia { get => _provincia; set => _provincia = value; }
        public GeographicArea GeographicArea { get => _geographicArea; set => _geographicArea = value; }

        public void AddCittadino(EUCitizen cittadino)
        {
            cittadino.Comune = this;
            _citizenList.Add(cittadino);
        }
        public void RemoveCittadino(EUCitizen cittadino)
        {
            cittadino.Comune = null;
            _citizenList.Remove(cittadino);
        }

        private EUCitizen GetCitizen(EUID eUID)
        {
            EUCitizen citizen = _citizenList.FirstOrDefault(c => c.EUID == eUID);
            return citizen;
        }

        public override void WellfareServices()
        {
            Console.WriteLine("Not Implemented for now");
        }

        public override void HSN(EUID eUID)
        {
            EUCitizen eUCitizen = GetCitizen(eUID);
            if (eUCitizen != null)
            {
                if (eUCitizen.AsDirictForSanity)
                {
                    Console.WriteLine($"{eUCitizen.EUID.Name} {eUCitizen.EUID.Surname} has dirict at sanity");
                }
                else { Console.WriteLine($"{eUCitizen.EUID.Name} {eUCitizen.EUID.Surname} has dirict at sanity"); }
            }
            else
            {
                Console.WriteLine("EUID not found");
            }
        }

        public override void EducationalSystem(EUID eUID)
        {
            EUCitizen eUCitizen = GetCitizen(eUID);
            if (eUCitizen != null)
            {
                if (eUCitizen.EUID.Age <= 18 || eUCitizen.AsDirictForInsturction)
                {
                    Console.WriteLine($"{eUCitizen.EUID.Name} {eUCitizen.EUID.Surname} has direct access for instruction");
                }
                else { Console.WriteLine($"{eUCitizen.EUID.Name} {eUCitizen.EUID.Surname} does not have direct access for instruction"); }
            }
            else
            {
                Console.WriteLine("EUID not found");
            }
        }
    }

}
